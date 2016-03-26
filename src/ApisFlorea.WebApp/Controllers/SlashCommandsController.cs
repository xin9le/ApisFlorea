using System;
using System.Linq;
using System.Threading.Tasks;
using ApisFlorea.Library.Threading.Tasks;
using ApisFlorea.Models.Translation;
using ApisFlorea.WebApp.Models.Slack;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;



namespace ApisFlorea.WebApp.Controllers
{
    /// <summary>
    /// Slack SlashCommands に関する要求を処理します。
    /// </summary>
    public class SlashCommandsController : Controller
    {
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
            if (request.Command != "/translate")
                return this.HttpBadRequest();

            //--- 引数解析 (翻訳可能一覧)
            var commands = request.Text.Split(' ');
            if (commands.Any() && commands[0].ToLower() == "list")
            {
                return this.Json(new Message
                {
                    Text = "*翻訳可能な言語一覧*",
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
                }, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }

            const int MinLength = 2;
            if (commands.Length < MinLength)
                return this.HttpBadRequest();
            
            var to = Language.ByCode[commands[0]];
            var text = string.Join(" ", commands.Skip(1));
            if (string.IsNullOrWhiteSpace(text))
                return this.HttpBadRequest();

            //--- 翻訳 API 呼び出し
            var attachments = (await new []
            {
                #region Translators
                //--- Bing
                new
                {
                    Translator = (Translator)new BingTranslator(),
                    Color      = "#339933",
                    Name       = "Bing 翻訳",
                    Url        = "https://www.bing.com/translator",
                    Icon       = "http://www.wp7connect.com/wp-content/uploads/2012/04/translator.png",
                },
                //--- Google
                new
                {
                    Translator = (Translator)new GoogleTranslator(),
                    Color      = "#377DF2",
                    Name       = "Google 翻訳",
                    Url        = "https://translate.google.com/",
                    Icon       = "http://icons.iconarchive.com/icons/marcus-roberto/google-play/512/Google-Translate-icon.png",
                },
                #endregion
            }
            .Select(async (x, i) =>
            {
                try
                {
                    return new
                    {
                        Order   = i,
                        Setting = x,
                        Result  = await x.Translator.TranslateAsync(to, text),
                    };
                }
                catch
                {
                    return null;
                }
            })
            .WhenAll())
            .Where(x => x != null)
            .OrderBy(x => x.Order)
            .Select(x => new Attachment
            {
                Color      = x.Setting.Color,
                AuthorName = x.Setting.Name,
                AuthorLink = x.Setting.Url,
                AuthorIcon = x.Setting.Icon,
                Text       = x.Result.After,
                Fallback   = $"{x.Setting.Name}{Environment.NewLine}{Environment.NewLine}{x.Result.After}",
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
                IsMarkdown = false,
                Attachments = attachments,
            }, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        #endregion


        public async Task<IActionResult> Test()
        {
            var result = await new GoogleTranslator().TranslateAsync(Language.Japanese, "Hello");
            return this.Json(result);
        }
    }
}