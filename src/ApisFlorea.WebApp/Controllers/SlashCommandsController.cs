using System;
using System.Linq;
using System.Threading.Tasks;
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

            //--- コマンド引数解析
            const int MinLength = 2;
            var commands = request.Text.Split(' ');
            if (commands.Length < MinLength)
                return this.HttpBadRequest();
            
            var to = Language.ByShortName[commands[0]];
            if (to == null)
                return this.HttpBadRequest();

            var text = string.Join(" ", commands.Skip(1));
            if (string.IsNullOrWhiteSpace(text))
                return this.HttpBadRequest();

            //--- 結果
            var result = await new BingTranslator().TranslateAsync(null, to, text);
            return this.Json(new Message
            {
                Text = result.Before,
                IsEphemeral = true,
                IsMarkdown = false,
                Attachments = new []
                {
                    new Attachment
                    {
                        Color = "#339933",
                        AuthorName = "Bing Translator",
                        AuthorLink = "https://www.bing.com/translator",
                        AuthorIcon = "http://www.wp7connect.com/wp-content/uploads/2012/04/translator.png",
                        Text = result.After,
                      //ThumbUrl = "http://www.wp7connect.com/wp-content/uploads/2012/04/translator.png",
                        Fallback = $"Bing Translator{Environment.NewLine}{Environment.NewLine}{result.After}",
                        Fields = new []
                        {
                            new Field
                            {
                                Title = "翻訳元",
                                Value = result.From.Name,
                                IsShort = true,
                            },
                            new Field
                            {
                                Title = "翻訳先",
                                Value = result.To.Name,
                                IsShort = true,
                            },
                        },
                    },
                },
            }, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
        #endregion
    }
}