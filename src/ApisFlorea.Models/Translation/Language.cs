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
        /// アフリカーンス語を取得します。
        /// </summary>
        public static This Afrikaans { get; } = new This("アフリカーンス語", "af");


        /// <summary>
        /// アムハラ語を取得します。
        /// </summary>
        public static This Amharic { get; } = new This("アムハラ語", "am");


        /// <summary>
        /// アラビア語を取得します。
        /// </summary>
        public static This Arabic { get; } = new This("アラビア語", "ar");


        /// <summary>
        /// アゼルバイジャン語を取得します。
        /// </summary>
        public static This Azerbaijan { get; } = new This("アゼルバイジャン語", "az");


        /// <summary>
        /// ベラルーシ語を取得します。
        /// </summary>
        public static This Belarusian { get; } = new This("ベラルーシ語", "be");


        /// <summary>
        /// ブルガリア語を取得します。
        /// </summary>
        public static This Bulgarian { get; } = new This("ブルガリア語", "bg");


        /// <summary>
        /// ベンガル語を取得します。
        /// </summary>
        public static This Bengali { get; } = new This("ベンガル語", "bn");


        /// <summary>
        /// ボスニア語を取得します。
        /// </summary>
        public static This Bosnian { get; } = new This("ボスニア語", "bs");


        /// <summary>
        /// カタロニア語を取得します。
        /// </summary>
        public static This Catalan { get; } = new This("カタロニア語", "ca");


        /// <summary>
        /// セブアノ語を取得します。
        /// </summary>
        public static This Cebuano { get; } = new This("セブアノ語", "ceb");


        /// <summary>
        /// コルシカ語を取得します。
        /// </summary>
        public static This Corsican { get; } = new This("コルシカ語", "co");


        /// <summary>
        /// チェコ語を取得します。
        /// </summary>
        public static This Czech { get; } = new This("チェコ語", "cs");


        /// <summary>
        /// ウェールズ語を取得します。
        /// </summary>
        public static This Welsh { get; } = new This("ウェールズ語", "cy");


        /// <summary>
        /// デンマーク語を取得します。
        /// </summary>
        public static This Danish { get; } = new This("デンマーク語", "da");


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
        /// エストニア語を取得します。
        /// </summary>
        public static This Estonian { get; } = new This("エストニア語", "et");


        /// <summary>
        /// バスク語を取得します。
        /// </summary>
        public static This Basque { get; } = new This("バスク語", "eu");


        /// <summary>
        /// ペルシア語を取得します。
        /// </summary>
        public static This Persian { get; } = new This("ペルシア語", "fa");


        /// <summary>
        /// フィンランド語を取得します。
        /// </summary>
        public static This Finnish { get; } = new This("フィンランド語", "fi");


        /// <summary>
        /// フランス語を取得します。
        /// </summary>
        public static This French { get; } = new This("フランス語", "fr");


        /// <summary>
        /// フリジア語を取得します。
        /// </summary>
        public static This Frisian { get; } = new This("フリジア語", "fy");


        /// <summary>
        /// アイルランド語を取得します。
        /// </summary>
        public static This Irish { get; } = new This("アイルランド語", "ga");


        /// <summary>
        /// スコットランド・ゲール語を取得します。
        /// </summary>
        public static This ScottishGaelic { get; } = new This("スコットランド・ゲール語", "gd");


        /// <summary>
        /// ガリシア語を取得します。
        /// </summary>
        public static This Galician { get; } = new This("ガリシア語", "gl");


        /// <summary>
        /// グジャラト語を取得します。
        /// </summary>
        public static This Gujarati { get; } = new This("グジャラト語", "gu");


        /// <summary>
        /// ハウサ語を取得します。
        /// </summary>
        public static This Hausa { get; } = new This("ハウサ語", "ha");


        /// <summary>
        /// ハワイ語を取得します。
        /// </summary>
        public static This Hawaiian { get; } = new This("ハワイ語", "haw");


        /// <summary>
        /// ヒンディー語を取得します。
        /// </summary>
        public static This Hindi { get; } = new This("ヒンディー語", "hi");


        /// <summary>
        /// モン語を取得します。
        /// </summary>
        public static This Hmong { get; } = new This("モン語", "hmn");


        /// <summary>
        /// クロアチア語を取得します。
        /// </summary>
        public static This Croatian { get; } = new This("クロアチア語", "hr");


        /// <summary>
        /// ハイチ語を取得します。
        /// </summary>
        public static This Haitian { get; } = new This("ハイチ語", "ht");


        /// <summary>
        /// ハンガリー語を取得します。
        /// </summary>
        public static This Hungarian { get; } = new This("ハンガリー語", "hu");


        /// <summary>
        /// アルメニア語を取得します。
        /// </summary>
        public static This Armenian { get; } = new This("アルメニア語", "hy");


        /// <summary>
        /// インドネシア語を取得します。
        /// </summary>
        public static This Indonesian { get; } = new This("インドネシア語", "id");


        /// <summary>
        /// イボ語を取得します。
        /// </summary>
        public static This Igbo { get; } = new This("イボ語", "ig");


        /// <summary>
        /// アイスランド語を取得します。
        /// </summary>
        public static This Icelandic { get; } = new This("アイスランド語", "is");


        /// <summary>
        /// イタリア語を取得します。
        /// </summary>
        public static This Italian { get; } = new This("イタリア語", "it");


        /// <summary>
        /// ヘブライ語を取得します。
        /// </summary>
        public static This Hebrew { get; } = new This("ヘブライ語", "iw");


        /// <summary>
        /// 日本語を取得します。
        /// </summary>
        public static This Japanese { get; } = new This("日本語", "ja");


        /// <summary>
        /// ジャワ語を取得します。
        /// </summary>
        public static This Java { get; } = new This("ジャワ語", "jw");


        /// <summary>
        /// グルジア語を取得します。
        /// </summary>
        public static This Georgian { get; } = new This("グルジア語", "ka");


        /// <summary>
        /// カザフ語を取得します。
        /// </summary>
        public static This Kazakh { get; } = new This("カザフ語", "kk");


        /// <summary>
        /// クメール語を取得します。
        /// </summary>
        public static This Khmer { get; } = new This("クメール語", "km");


        /// <summary>
        /// カンナダ語を取得します。
        /// </summary>
        public static This Kannada { get; } = new This("カンナダ語", "kn");


        /// <summary>
        /// 韓国語を取得します。
        /// </summary>
        public static This Korean { get; } = new This("韓国語", "ko");


        /// <summary>
        /// クルド語を取得します。
        /// </summary>
        public static This Kurdish { get; } = new This("クルド語", "ku");


        /// <summary>
        /// キルギス語を取得します。
        /// </summary>
        public static This Kyrgyz { get; } = new This("キルギス語", "ky");


        /// <summary>
        /// ラテン語を取得します。
        /// </summary>
        public static This Latin { get; } = new This("ラテン語", "la");


        /// <summary>
        /// ルクセンブルク語を取得します。
        /// </summary>
        public static This Luxembourg { get; } = new This("ルクセンブルク語", "lb");


        /// <summary>
        /// ラオ語を取得します。
        /// </summary>
        public static This Lao { get; } = new This("ラオ語", "lo");


        /// <summary>
        /// リトアニア語を取得します。
        /// </summary>
        public static This Lithuanian { get; } = new This("リトアニア語", "lt");


        /// <summary>
        /// ラトビア語を取得します。
        /// </summary>
        public static This Latvian { get; } = new This("ラトビア語", "lv");


        /// <summary>
        /// マラガシ語を取得します。
        /// </summary>
        public static This Malagasy { get; } = new This("マラガシ語", "mg");


        /// <summary>
        /// マオリ語を取得します。
        /// </summary>
        public static This Maori { get; } = new This("マオリ語", "mi");


        /// <summary>
        /// マケドニア語を取得します。
        /// </summary>
        public static This Macedonian { get; } = new This("マケドニア語", "mk");


        /// <summary>
        /// マラヤーラム語を取得します。
        /// </summary>
        public static This Malayalam { get; } = new This("マラヤーラム語", "ml");


        /// <summary>
        /// モンゴル語を取得します。
        /// </summary>
        public static This Mongolian { get; } = new This("モンゴル語", "mn");


        /// <summary>
        /// マラーティー語を取得します。
        /// </summary>
        public static This Marathi { get; } = new This("マラーティー語", "mr");


        /// <summary>
        /// マレー語を取得します。
        /// </summary>
        public static This Malay { get; } = new This("マレー語", "ms");


        /// <summary>
        /// マルタ語を取得します。
        /// </summary>
        public static This Maltese { get; } = new This("マルタ語", "mt");


        /// <summary>
        /// ビルマ語を取得します。
        /// </summary>
        public static This Burmese { get; } = new This("ビルマ語", "my");


        /// <summary>
        /// ネパール語を取得します。
        /// </summary>
        public static This Nepalese { get; } = new This("ネパール語", "ne");


        /// <summary>
        /// オランダ語を取得します。
        /// </summary>
        public static This Dutch { get; } = new This("オランダ語", "nl");


        /// <summary>
        /// ノルウェー語を取得します。
        /// </summary>
        public static This Norwegian { get; } = new This("ノルウェー語", "no");


        /// <summary>
        /// チェワ語を取得します。
        /// </summary>
        public static This Chichewa { get; } = new This("チェワ語", "ny");


        /// <summary>
        /// パンジャブ語を取得します。
        /// </summary>
        public static This Punjabi { get; } = new This("パンジャブ語", "pa");


        /// <summary>
        /// ポーランド語を取得します。
        /// </summary>
        public static This Polish { get; } = new This("ポーランド語", "pl");


        /// <summary>
        /// パシュト語を取得します。
        /// </summary>
        public static This Pashto { get; } = new This("パシュト語", "ps");


        /// <summary>
        /// ポルトガル語を取得します。
        /// </summary>
        public static This Portuguese { get; } = new This("ポルトガル語", "pt");


        /// <summary>
        /// ルーマニア語を取得します。
        /// </summary>
        public static This Romanian { get; } = new This("ルーマニア語", "ro");


        /// <summary>
        /// ロシア語を取得します。
        /// </summary>
        public static This Russian { get; } = new This("ロシア語", "ru");


        /// <summary>
        /// シンド語を取得します。
        /// </summary>
        public static This TheSindhi { get; } = new This("シンド語", "sd");


        /// <summary>
        /// シンハラ語を取得します。
        /// </summary>
        public static This Sinhala { get; } = new This("シンハラ語", "si");


        /// <summary>
        /// スロバキア語を取得します。
        /// </summary>
        public static This Slovak { get; } = new This("スロバキア語", "sk");


        /// <summary>
        /// スロベニア語を取得します。
        /// </summary>
        public static This Slovenian { get; } = new This("スロベニア語", "sl");


        /// <summary>
        /// サモア語を取得します。
        /// </summary>
        public static This Samoan { get; } = new This("サモア語", "sm");


        /// <summary>
        /// ショナ語を取得します。
        /// </summary>
        public static This Shona { get; } = new This("ショナ語", "sn");


        /// <summary>
        /// ソマリ語を取得します。
        /// </summary>
        public static This Somali { get; } = new This("ソマリ語", "so");


        /// <summary>
        /// アルバニア語を取得します。
        /// </summary>
        public static This Albanian { get; } = new This("アルバニア語", "sq");


        /// <summary>
        /// セルビア語を取得します。
        /// </summary>
        public static This Serbian { get; } = new This("セルビア語", "sr");


        /// <summary>
        /// ソト語を取得します。
        /// </summary>
        public static This Sotho { get; } = new This("ソト語", "st");


        /// <summary>
        /// スンダ語を取得します。
        /// </summary>
        public static This Sundanese { get; } = new This("スンダ語", "su");


        /// <summary>
        /// スウェーデン語を取得します。
        /// </summary>
        public static This Swedish { get; } = new This("スウェーデン語", "sv");


        /// <summary>
        /// スワヒリ語を取得します。
        /// </summary>
        public static This Swahili { get; } = new This("スワヒリ語", "sw");


        /// <summary>
        /// タミル語を取得します。
        /// </summary>
        public static This Tamil { get; } = new This("タミル語", "ta");


        /// <summary>
        /// テルグ語を取得します。
        /// </summary>
        public static This Telugu { get; } = new This("テルグ語", "te");


        /// <summary>
        /// タジク語を取得します。
        /// </summary>
        public static This Tajik { get; } = new This("タジク語", "tg");


        /// <summary>
        /// タイ語を取得します。
        /// </summary>
        public static This Thai { get; } = new This("タイ語", "th");


        /// <summary>
        /// タガログ語を取得します。
        /// </summary>
        public static This Tagalog { get; } = new This("タガログ語", "tl");


        /// <summary>
        /// トルコ語を取得します。
        /// </summary>
        public static This Turkish { get; } = new This("トルコ語", "tr");


        /// <summary>
        /// ウクライナ語を取得します。
        /// </summary>
        public static This Ukrainian { get; } = new This("ウクライナ語", "uk");


        /// <summary>
        /// ウルドゥ語を取得します。
        /// </summary>
        public static This Urdu { get; } = new This("ウルドゥ語", "ur");


        /// <summary>
        /// ウズベク語を取得します。
        /// </summary>
        public static This Uzbek { get; } = new This("ウズベク語", "uz");


        /// <summary>
        /// ベトナム語を取得します。
        /// </summary>
        public static This Vietnamese { get; } = new This("ベトナム語", "vi");


        /// <summary>
        /// コーサ語を取得します。
        /// </summary>
        public static This Xhosa { get; } = new This("コーサ語", "xh");


        /// <summary>
        /// イディッシュ語を取得します。
        /// </summary>
        public static This Yiddish { get; } = new This("イディッシュ語", "yi");


        /// <summary>
        /// ヨルバ語を取得します。
        /// </summary>
        public static This Yoruba { get; } = new This("ヨルバ語", "yo");


        /// <summary>
        /// 簡体中国語を取得します。
        /// </summary>
        public static This SimplifiedChinese { get; } = new This("簡体中国語", "zh-CN", "zh-CHS");


        /// <summary>
        /// 繁体中国語を取得します。
        /// </summary>
        public static This TraditionalChinese { get; } = new This("繁体中国語", "zh-TW", "zh-CHT");


        /// <summary>
        /// ズールー語を取得します。
        /// </summary>
        public static This Zulu { get; } = new This("ズールー語", "zu");


        /// <summary>
        /// すべての言語情報を取得します。
        /// </summary>
        public static IReadOnlyList<This> All { get; } = new []
        {
            This.Afrikaans,
            This.Amharic,
            This.Arabic,
            This.Azerbaijan,
            This.Belarusian,
            This.Bulgarian,
            This.Bengali,
            This.Bosnian,
            This.Catalan,
            This.Cebuano,
            This.Corsican,
            This.Czech,
            This.Welsh,
            This.Danish,
            This.German,
            This.Greek,
            This.English,
            This.Esperanto,
            This.Spanish,
            This.Estonian,
            This.Basque,
            This.Persian,
            This.Finnish,
            This.French,
            This.Frisian,
            This.Irish,
            This.ScottishGaelic,
            This.Galician,
            This.Gujarati,
            This.Hausa,
            This.Hawaiian,
            This.Hindi,
            This.Hmong,
            This.Croatian,
            This.Haitian,
            This.Hungarian,
            This.Armenian,
            This.Indonesian,
            This.Igbo,
            This.Icelandic,
            This.Italian,
            This.Hebrew,
            This.Japanese,
            This.Java,
            This.Georgian,
            This.Kazakh,
            This.Khmer,
            This.Kannada,
            This.Korean,
            This.Kurdish,
            This.Kyrgyz,
            This.Latin,
            This.Luxembourg,
            This.Lao,
            This.Lithuanian,
            This.Latvian,
            This.Malagasy,
            This.Maori,
            This.Macedonian,
            This.Malayalam,
            This.Mongolian,
            This.Marathi,
            This.Malay,
            This.Maltese,
            This.Burmese,
            This.Nepalese,
            This.Dutch,
            This.Norwegian,
            This.Chichewa,
            This.Punjabi,
            This.Polish,
            This.Pashto,
            This.Portuguese,
            This.Romanian,
            This.Russian,
            This.TheSindhi,
            This.Sinhala,
            This.Slovak,
            This.Slovenian,
            This.Samoan,
            This.Shona,
            This.Somali,
            This.Albanian,
            This.Serbian,
            This.Sotho,
            This.Sundanese,
            This.Swedish,
            This.Swahili,
            This.Tamil,
            This.Telugu,
            This.Tajik,
            This.Thai,
            This.Tagalog,
            This.Turkish,
            This.Ukrainian,
            This.Urdu,
            This.Uzbek,
            This.Vietnamese,
            This.Xhosa,
            This.Yiddish,
            This.Yoruba,
            This.SimplifiedChinese,
            This.TraditionalChinese,
            This.Zulu,
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