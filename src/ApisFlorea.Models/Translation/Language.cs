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
        /// 短い名前を取得します。
        /// </summary>
        public string ShortName { get; }
        #endregion


        #region コンストラクタ
        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        /// <param name="name">名前</param>
        /// <param name="shortName">短い名前</param>
        private Language(string name, string shortName)
        {
            if (name == null)      throw new ArgumentNullException(nameof(name));
            if (shortName == null) throw new ArgumentNullException(nameof(shortName));

            this.Name = name;
            this.ShortName = shortName;
        }
        #endregion


        #region オーラーライド
        /// <summary>
        /// インスタンスを文字列かします。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString() => this.Name;
        #endregion


        #region 生成
        /// <summary>
        /// 日本語を取得します。
        /// </summary>
        public static This Japanese { get; } = new This("日本語", "ja");


        /// <summary>
        /// 英語を取得します。
        /// </summary>
        public static This English { get; } = new This("英語", "en");


        /// <summary>
        /// フランス語を取得します。
        /// </summary>
        public static This French { get; } = new This("フランス語", "fr");


        /// <summary>
        /// すべての言語情報を取得します。
        /// </summary>
        public static IReadOnlyList<This> All { get; } = new []
        {
            This.Japanese,
            This.English,
            This.French,
        };


        /// <summary>
        /// 名前をキーにしたインスタンスのマップを取得します。
        /// </summary>
        public static IReadOnlyDictionary<string, This> ByName { get; } = This.All.ToDictionary(x => x.Name);


        /// <summary>
        /// 短い名前をキーにしたインスタンスのマップを取得します。
        /// </summary>
        public static IReadOnlyDictionary<string, This> ByShortName { get; } = This.All.ToDictionary(x => x.ShortName);
        #endregion
    }
}