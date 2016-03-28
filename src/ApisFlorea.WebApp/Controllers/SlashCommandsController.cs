using System;
using System.Linq;
using System.Threading.Tasks;
using ApisFlorea.Core.Collections.Generic;
using ApisFlorea.Core.Threading.Tasks;
using ApisFlorea.Models.Translation;
using ApisFlorea.WebApp.Models.Slack;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using Newtonsoft.Json;



namespace ApisFlorea.WebApp.Controllers
{
    /// <summary>
    /// Slack SlashCommands に関する要求を処理します。
    /// </summary>
    public class SlashCommandsController : Controller
    {
        #region Overrides
        /// <summary>
        /// 指定されたオブジェクトを JSON 形式で返します。
        /// </summary>
        /// <param name="data">オブジェクト</param>
        /// <returns></returns>
        public override JsonResult Json(object data)
        {
            var setting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            return base.Json(data, setting);
        }


        /// <summary>
        /// アクションが実行されたとに呼び出されます。
        /// </summary>
        /// <param name="context">実行コンテキスト</param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            //--- 例外が飛んだ場合は握り潰してエラーを通知
            if (context.Exception != null)
            {
                var color = "#C00000";
                context.Result = this.Json(new Message
                {
                    Text = "Unhandled exception occured...",
                    IsEphemeral = true,
                    Attachments = new []
                    {
                        new Attachment
                        {
                            Color      = color,
                            AuthorName = "Type",
                            AuthorLink = Uri.EscapeUriString($"https://www.google.com/search?q={context.Exception.GetType()}"),
                            Text       = context.Exception.GetType().ToString(),
                        },
                        new Attachment
                        {
                            Color      = color,
                            AuthorName = nameof(context.Exception.Message),
                            Text       = context.Exception.Message,
                        },
                        new Attachment
                        {
                            Color      = color,
                            AuthorName = nameof(context.Exception.StackTrace),
                            Text       = context.Exception.StackTrace,
                        },
                        new Attachment
                        {
                            Color      = color,
                            AuthorName = nameof(context.Exception.InnerException),
                            Text       = context.Exception.InnerException?.Message,
                        },
                    }
                });
                context.ExceptionHandled = true;
            }

            //--- JSON を返していれば正常終了とみなす
            if (context.Result is JsonResult)
                return;

            //--- ステータスコードを持つ場合はそれを通知
            var message = "Error occured...";
            var result = context.Result as HttpStatusCodeResult;
            if (result != null)
                message += Environment.NewLine + $"[HTTP Status Code : {result.StatusCode}]";

            context.Result = this.Json(new Message
            {
                Text = message,
                IsEphemeral = true,
            });
        }
        #endregion


        #region API
        /// <summary>
        /// 指定した言語に文章を翻訳します。
        /// </summary>
        /// <param name="request">リクエスト</param>
        /// <returns>結果</returns>
        [HttpPost]
        public async Task<IActionResult> Translate([FromForm] SlashCommandsRequest request)
        {
            //--- エラーチェック
            if (!this.ModelState.IsValid)
                return this.HttpBadRequest();

            //--- コマンドチェック
            //if (request.Command != "/translate")
                //return this.HttpBadRequest();

            //--- 言語コード一覧
            var commands = request.Text.Split(' ');
            if (commands.Any() && commands[0].ToLower() == "code")
            {
                return this.Json(new Message
                {
                    Text = "*言語コード一覧*",
                    IsEphemeral = true,
                    IsMarkdown = true,
                    Attachments = new []
                    {
                        new Attachment
                        {
                            Fields = Language.All.Select(x => new Field
                            {
                                Title = x.Name,
                                Value = x.Code,
                                IsShort = true,
                            })
                            .ToArray(),
                        },
                    },
                });
            }

            //--- 引数は 2 つ以上必要
            if (commands.Length < 2)
                return this.HttpBadRequest();
            
            //--- 第 1 引数が言語コードかどうか
            var to = Language.ByCode.GetValueOrDefault(commands[0]);
            if (to == null)
                return this.HttpBadRequest();

            //--- 第 2 引数以降に文章があるか
            var text = string.Join(" ", commands.Skip(1));
            if (string.IsNullOrWhiteSpace(text))
                return this.HttpBadRequest();

            //--- 翻訳 API 呼び出し
            var attachments = (await new Translator[]
            {
                new BingTranslator(),
                new GoogleTranslator(),
                new YahooTranslator(),
            }
            .Select(async x =>
            {
                try
                {
                    return new
                    {
                        Translator = x,
                        Result = await x.TranslateAsync(to, text).Stay()
                    };
                }
                catch
                {
                    //--- API 呼び出し中にエラーが発生したら握り潰す
                    return null;
                }
            })
            .WhenAll())
            .Where(x => x != null)
            .Select(x => new Attachment
            {
                Color      = x.Translator.ThemeColor,
                AuthorName = x.Translator.Name,
                AuthorLink = x.Translator.SiteUrl,
                AuthorIcon = x.Translator.IconUrl,
                Text       = x.Result.After,
                Fallback   = $"{x.Translator.Name}{Environment.NewLine}{Environment.NewLine}{x.Result.After}",
                Fields = new []
                {
                    new Field
                    {
                        Title = "翻訳元",
                        Value = x.Result.From.Name,
                        IsShort = true,
                    },
                    new Field
                    {
                        Title = "翻訳先",
                        Value = x.Result.To.Name,
                        IsShort = true,
                    },
                },
            })
            .ToArray();

            //--- 結果
            return this.Json(new Message
            {
                Text = text,
                IsEphemeral = true,
                Attachments = attachments,
            });
        }
        #endregion


        public async Task<IActionResult> Test()
        {
            var result = await new BingTranslator().TranslateAsync(Language.Japanese, $"Hello!!{Environment.NewLine}Today is sunny day.");
            return this.Json(result);
        }
    }
}