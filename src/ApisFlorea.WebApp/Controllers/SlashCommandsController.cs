using System.Linq;
using System.Threading.Tasks;
using ApisFlorea.Models.Translation;
using ApisFlorea.WebApp.Models.Slack;
using Microsoft.AspNet.Mvc;



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
            return this.Json(new
            {
                //response_type = "ephemeral",
                response_type = "in_channel",
                text = result?.After ?? "翻訳に失敗しました...",
            });
        }
        #endregion
    }
}