using System;
using System.Collections.Generic;
using System.Linq;
using This = ApisFlorea.Models.Translation.Language;



namespace ApisFlorea.Models.Translation
{
    /// <summary>
    /// 言語情報を提供します。
    /// </summary>
    public class Language
    {
        #region プロパティ
        /// <summary>
        /// 名前を取得します。
        /// </summary>
        public string Name { get; }


        /// <summary>
        /// 言語コードを取得します。
        /// </summary>
        public string Code { get; }


        /// <summary>
        /// Bing翻訳用の言語コードを取得します。
        /// </summary>
        internal string BingCode { get; }
        #endregion


        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="code">短い名前</param>
        /// <param name="bing">Bing翻訳用の短い名前</param>
        private Language(string name, string code, string bing = null)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (code == null) throw new ArgumentNullException(nameof(code));

            this.Name = name;
            this.Code = code;
            this.BingCode = bing ?? code;
        }
        #endregion


        #region オーラーライド
        /// <summary>
        /// インスタンスを文字列かします。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString() => this.Name;
        #endregion


        #region 言語一覧
        /// <summary>
        /// アラビア語を取得します。
        /// </summary>
        public static This Arabic { get; } = new This("アラビア語", "ar");


        /// <summary>
        /// ドイツ語を取得します。
        /// </summary>
        public static This German { get; } = new This("ドイツ語", "de");


        /// <summary>
        /// ギリシャ語を取得します。
        /// </summary>
        public static This Greek { get; } = new This("ギリシャ語", "el");


        /// <summary>
        /// 英語を取得します。
        /// </summary>
        public static This English { get; } = new This("英語", "en");


        /// <summary>
        /// エスペラント語を取得します。
        /// </summary>
        public static This Esperanto { get; } = new This("エスペラント語", "eo");


        /// <summary>
        /// スペイン語を取得します。
        /// </summary>
        public static This Spanish { get; } = new This("スペイン語", "es");


        /// <summary>
        /// フランス語を取得します。
        /// </summary>
        public static This French { get; } = new This("フランス語", "fr");


        /// <summary>
        /// イタリア語を取得します。
        /// </summary>
        public static This Italian { get; } = new This("イタリア語", "it");


        /// <summary>
        /// 日本語を取得します。
        /// </summary>
        public static This Japanese { get; } = new This("日本語", "ja");


        /// <summary>
        /// 韓国語を取得します。
        /// </summary>
        public static This Korean { get; } = new This("韓国語", "ko");


        /// <summary>
        /// ラテン語を取得します。
        /// </summary>
        public static This Latin { get; } = new This("ラテン語", "la");


        /// <summary>
        /// マレー語を取得します。
        /// </summary>
        public static This Malay { get; } = new This("マレー語", "ms");


        /// <summary>
        /// ロシア語を取得します。
        /// </summary>
        public static This Russian { get; } = new This("ロシア語", "ru");


        /// <summary>
        /// 簡体中国語を取得します。
        /// </summary>
        public static This SimplifiedChinese { get; } = new This("簡体中国語", "zh-CN", "zh-CHS");


        /// <summary>
        /// 繁体中国語を取得します。
        /// </summary>
        public static This TraditionalChinese { get; } = new This("繁体中国語", "zh-TW", "zh-CHT");


        /// <summary>
        /// すべての言語情報を取得します。
        /// </summary>
        public static IReadOnlyList<This> All { get; } = new []
        {
            This.Arabic,
            This.German,
            This.Greek,
            This.English,
            This.Esperanto,
            This.Spanish,
            This.French,
            This.Italian,
            This.Japanese,
            This.Korean,
            This.Latin,
            This.Malay,
            This.Russian,
            This.SimplifiedChinese,
            This.TraditionalChinese,
        };
        #endregion


        #region 言語マップ
        /// <summary>
        /// 名前をキーにしたインスタンスのマップを取得します。
        /// </summary>
        public static IReadOnlyDictionary<string, This> ByName { get; } = This.All.ToDictionary(x => x.Name);


        /// <summary>
        /// 言語コードをキーにしたインスタンスのマップを取得します。
        /// </summary>
        public static IReadOnlyDictionary<string, This> ByCode { get; } = This.All.ToDictionary(x => x.Code);


        /// <summary>
        /// Bing翻訳用の言語コードをキーにしたインスタンスのマップを取得します。
        /// </summary>
        internal static IReadOnlyDictionary<string, This> ByBingCode { get; } = This.All.ToDictionary(x => x.BingCode);
        #endregion
    }
}