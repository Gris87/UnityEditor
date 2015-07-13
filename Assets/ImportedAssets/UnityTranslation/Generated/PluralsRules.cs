// This file generated from "CLDR/json-full/supplemental/plurals.json" file.
using System;



namespace UnityTranslationInternal
{
    /// <summary>
    /// Container for all plurals rules for each language.
    /// </summary>
    public static class PluralsRules
    {
        /// <summary>
        /// Delegate function that returns PluralsQuantity related to provided quantity.
        /// </summary>
        /// <returns>PluralsQuantity value</returns>
        /// <param name="quantity">Quantity</param>
        public delegate PluralsQuantity PluralsFunction(double quantity);

        /// <summary>
        /// Array of functions for getting PluralsQuantity.
        /// </summary>
        public static readonly PluralsFunction[] pluralsFunctions = new PluralsFunction[]
        {
              pluralsDefaultFunction  // Default
            , pluralsFallbackFunction // Afar
            , pluralsFallbackFunction // Abkhazian
            , pluralsFallbackFunction // Achinese
            , pluralsFallbackFunction // Acoli
            , pluralsFallbackFunction // Adangme
            , pluralsFallbackFunction // Adyghe
            , pluralsFallbackFunction // Avestan
            , pluralsFallbackFunction // TunisianArabic
            , pluralsFunction1        // Afrikaans
            , pluralsFallbackFunction // Afrihili
            , pluralsFallbackFunction // Aghem
            , pluralsFallbackFunction // Ainu
            , pluralsFunction2        // Akan
            , pluralsFallbackFunction // Akkadian
            , pluralsFallbackFunction // Alabama
            , pluralsFallbackFunction // Aleut
            , pluralsFallbackFunction // GhegAlbanian
            , pluralsFallbackFunction // SouthernAltai
            , pluralsFunction3        // Amharic
            , pluralsFallbackFunction // Aragonese
            , pluralsFallbackFunction // OldEnglish
            , pluralsFallbackFunction // Angika
            , pluralsFunction4        // Arabic
            , pluralsFunction4        // ModernStandardArabic
            , pluralsFallbackFunction // Aramaic
            , pluralsFallbackFunction // Mapuche
            , pluralsFallbackFunction // Araona
            , pluralsFallbackFunction // Arapaho
            , pluralsFallbackFunction // AlgerianArabic
            , pluralsFallbackFunction // Arawak
            , pluralsFallbackFunction // MoroccanArabic
            , pluralsFallbackFunction // EgyptianArabic
            , pluralsFallbackFunction // Assamese
            , pluralsFunction1        // Asu
            , pluralsFallbackFunction // AmericanSignLanguage
            , pluralsDefaultFunction  // Asturian
            , pluralsFallbackFunction // Avaric
            , pluralsFallbackFunction // Kotava
            , pluralsFallbackFunction // Awadhi
            , pluralsFallbackFunction // Aymara
            , pluralsFunction1        // Azerbaijani
            , pluralsFunction1        // Azeri
            , pluralsFallbackFunction // SouthAzerbaijani
            , pluralsFallbackFunction // Bashkir
            , pluralsFallbackFunction // Baluchi
            , pluralsFallbackFunction // Balinese
            , pluralsFallbackFunction // Bavarian
            , pluralsFallbackFunction // Basaa
            , pluralsFallbackFunction // Bamun
            , pluralsFallbackFunction // BatakToba
            , pluralsFallbackFunction // Ghomala
            , pluralsFunction5        // Belarusian
            , pluralsFallbackFunction // Beja
            , pluralsFunction1        // Bemba
            , pluralsFallbackFunction // Betawi
            , pluralsFunction1        // Bena
            , pluralsFallbackFunction // Bafut
            , pluralsFallbackFunction // Badaga
            , pluralsFunction1        // Bulgarian
            , pluralsFallbackFunction // Bhojpuri
            , pluralsFallbackFunction // Bislama
            , pluralsFallbackFunction // Bikol
            , pluralsFallbackFunction // Bini
            , pluralsFallbackFunction // Banjar
            , pluralsFallbackFunction // Kom
            , pluralsFallbackFunction // Siksika
            , pluralsFunction6        // Bambara
            , pluralsFunction3        // Bengali
            , pluralsFunction6        // Tibetan
            , pluralsFallbackFunction // Bishnupriya
            , pluralsFallbackFunction // Bakhtiari
            , pluralsFunction7        // Breton
            , pluralsFallbackFunction // Braj
            , pluralsFallbackFunction // Brahui
            , pluralsFunction1        // Bodo
            , pluralsFunction8        // Bosnian
            , pluralsFallbackFunction // Akoose
            , pluralsFallbackFunction // Buriat
            , pluralsFallbackFunction // Buginese
            , pluralsFallbackFunction // Bulu
            , pluralsFallbackFunction // Blin
            , pluralsFallbackFunction // Medumba
            , pluralsDefaultFunction  // Catalan
            , pluralsFallbackFunction // Caddo
            , pluralsFallbackFunction // Carib
            , pluralsFallbackFunction // Cayuga
            , pluralsFallbackFunction // Atsam
            , pluralsFallbackFunction // Chechen
            , pluralsFallbackFunction // Cebuano
            , pluralsFunction1        // Chiga
            , pluralsFallbackFunction // Chamorro
            , pluralsFallbackFunction // Chibcha
            , pluralsFallbackFunction // Chagatai
            , pluralsFallbackFunction // Chuukese
            , pluralsFallbackFunction // Mari
            , pluralsFallbackFunction // ChinookJargon
            , pluralsFallbackFunction // Choctaw
            , pluralsFallbackFunction // Chipewyan
            , pluralsFunction1        // Cherokee
            , pluralsFallbackFunction // Cheyenne
            , pluralsFunction1        // SoraniKurdish
            , pluralsFallbackFunction // Corsican
            , pluralsFallbackFunction // Coptic
            , pluralsFallbackFunction // Capiznon
            , pluralsFallbackFunction // Cree
            , pluralsFallbackFunction // CrimeanTurkish
            , pluralsFunction9        // Czech
            , pluralsFallbackFunction // Kashubian
            , pluralsFallbackFunction // ChurchSlavic
            , pluralsFallbackFunction // Chuvash
            , pluralsFunction10       // Welsh
            , pluralsFunction11       // Danish
            , pluralsFallbackFunction // Dakota
            , pluralsFallbackFunction // Dargwa
            , pluralsFallbackFunction // Taita
            , pluralsDefaultFunction  // German
            , pluralsDefaultFunction  // AustrianGerman
            , pluralsDefaultFunction  // SwissHighGerman
            , pluralsFallbackFunction // Delaware
            , pluralsFallbackFunction // Slave
            , pluralsFallbackFunction // Dogrib
            , pluralsFallbackFunction // Dinka
            , pluralsFallbackFunction // Zarma
            , pluralsFallbackFunction // Dogri
            , pluralsFunction12       // LowerSorbian
            , pluralsFallbackFunction // CentralDusun
            , pluralsFallbackFunction // Duala
            , pluralsFallbackFunction // MiddleDutch
            , pluralsFunction1        // Divehi
            , pluralsFallbackFunction // JolaFonyi
            , pluralsFallbackFunction // Dyula
            , pluralsFunction6        // Dzongkha
            , pluralsFallbackFunction // Dazaga
            , pluralsFallbackFunction // Embu
            , pluralsFunction1        // Ewe
            , pluralsFallbackFunction // Efik
            , pluralsFallbackFunction // Emilian
            , pluralsFallbackFunction // AncientEgyptian
            , pluralsFallbackFunction // Ekajuk
            , pluralsFunction1        // Greek
            , pluralsFallbackFunction // Elamite
            , pluralsDefaultFunction  // English
            , pluralsDefaultFunction  // AustralianEnglish
            , pluralsDefaultFunction  // CanadianEnglish
            , pluralsDefaultFunction  // BritishEnglish
            , pluralsDefaultFunction  // UKEnglish
            , pluralsDefaultFunction  // AmericanEnglish
            , pluralsDefaultFunction  // USEnglish
            , pluralsFallbackFunction // MiddleEnglish
            , pluralsFunction1        // Esperanto
            , pluralsFunction1        // Spanish
            , pluralsFunction1        // LatinAmericanSpanish
            , pluralsFunction1        // EuropeanSpanish
            , pluralsFunction1        // MexicanSpanish
            , pluralsFallbackFunction // CentralYupik
            , pluralsDefaultFunction  // Estonian
            , pluralsFunction1        // Basque
            , pluralsFallbackFunction // Ewondo
            , pluralsFallbackFunction // Extremaduran
            , pluralsFunction3        // Persian
            , pluralsFallbackFunction // Fang
            , pluralsFallbackFunction // Fanti
            , pluralsFunction13       // Fulah
            , pluralsDefaultFunction  // Finnish
            , pluralsFunction14       // Filipino
            , pluralsFallbackFunction // TornedalenFinnish
            , pluralsFallbackFunction // Fijian
            , pluralsFunction1        // Faroese
            , pluralsFallbackFunction // Fon
            , pluralsFunction13       // French
            , pluralsFunction13       // CanadianFrench
            , pluralsFunction13       // SwissFrench
            , pluralsFallbackFunction // CajunFrench
            , pluralsFallbackFunction // MiddleFrench
            , pluralsFallbackFunction // OldFrench
            , pluralsFallbackFunction // Arpitan
            , pluralsFallbackFunction // NorthernFrisian
            , pluralsFallbackFunction // EasternFrisian
            , pluralsFunction1        // Friulian
            , pluralsDefaultFunction  // WesternFrisian
            , pluralsFunction15       // Irish
            , pluralsFallbackFunction // Ga
            , pluralsFallbackFunction // Gagauz
            , pluralsFallbackFunction // GanChinese
            , pluralsFallbackFunction // Gayo
            , pluralsFallbackFunction // Gbaya
            , pluralsFallbackFunction // ZoroastrianDari
            , pluralsFunction16       // ScottishGaelic
            , pluralsFallbackFunction // Geez
            , pluralsFallbackFunction // Gilbertese
            , pluralsDefaultFunction  // Galician
            , pluralsFallbackFunction // Gilaki
            , pluralsFallbackFunction // MiddleHighGerman
            , pluralsFallbackFunction // Guarani
            , pluralsFallbackFunction // OldHighGerman
            , pluralsFallbackFunction // GoanKonkani
            , pluralsFallbackFunction // Gondi
            , pluralsFallbackFunction // Gorontalo
            , pluralsFallbackFunction // Gothic
            , pluralsFallbackFunction // Grebo
            , pluralsFallbackFunction // AncientGreek
            , pluralsFunction1        // SwissGerman
            , pluralsFunction3        // Gujarati
            , pluralsFallbackFunction // Wayuu
            , pluralsFallbackFunction // Frafra
            , pluralsFallbackFunction // Gusii
            , pluralsFunction17       // Manx
            , pluralsFallbackFunction // Gwichin
            , pluralsFunction1        // Hausa
            , pluralsFallbackFunction // Haida
            , pluralsFallbackFunction // HakkaChinese
            , pluralsFunction1        // Hawaiian
            , pluralsFunction18       // Hebrew
            , pluralsFunction3        // Hindi
            , pluralsFallbackFunction // FijiHindi
            , pluralsFallbackFunction // Hiligaynon
            , pluralsFallbackFunction // Hittite
            , pluralsFallbackFunction // Hmong
            , pluralsFallbackFunction // HiriMotu
            , pluralsFunction8        // Croatian
            , pluralsFunction12       // UpperSorbian
            , pluralsFallbackFunction // XiangChinese
            , pluralsFallbackFunction // Haitian
            , pluralsFunction1        // Hungarian
            , pluralsFallbackFunction // Hupa
            , pluralsFunction13       // Armenian
            , pluralsFallbackFunction // Herero
            , pluralsFallbackFunction // Interlingua
            , pluralsFallbackFunction // Iban
            , pluralsFallbackFunction // Ibibio
            , pluralsFunction6        // Indonesian
            , pluralsFallbackFunction // Interlingue
            , pluralsFunction6        // Igbo
            , pluralsFunction6        // SichuanYi
            , pluralsFallbackFunction // Inupiaq
            , pluralsFallbackFunction // Iloko
            , pluralsFallbackFunction // Ingush
            , pluralsFallbackFunction // Ido
            , pluralsFunction19       // Icelandic
            , pluralsDefaultFunction  // Italian
            , pluralsFunction20       // Inuktitut
            , pluralsFallbackFunction // Ingrian
            , pluralsFunction6        // Japanese
            , pluralsFallbackFunction // JamaicanCreoleEnglish
            , pluralsFunction6        // Lojban
            , pluralsFunction1        // Ngomba
            , pluralsFunction1        // Machame
            , pluralsFallbackFunction // JudeoPersian
            , pluralsFallbackFunction // JudeoArabic
            , pluralsFallbackFunction // Jutish
            , pluralsFunction6        // Javanese
            , pluralsFunction1        // Georgian
            , pluralsFallbackFunction // KaraKalpak
            , pluralsFunction13       // Kabyle
            , pluralsFallbackFunction // Kachin
            , pluralsFunction1        // Jju
            , pluralsFallbackFunction // Kamba
            , pluralsFallbackFunction // Kawi
            , pluralsFallbackFunction // Kabardian
            , pluralsFallbackFunction // Kanembu
            , pluralsFunction1        // Tyap
            , pluralsFunction6        // Makonde
            , pluralsFunction6        // Kabuverdianu
            , pluralsFallbackFunction // Kenyang
            , pluralsFallbackFunction // Koro
            , pluralsFallbackFunction // Kongo
            , pluralsFallbackFunction // Kaingang
            , pluralsFallbackFunction // Khasi
            , pluralsFallbackFunction // Khotanese
            , pluralsFallbackFunction // KoyraChiini
            , pluralsFallbackFunction // Khowar
            , pluralsFallbackFunction // Kikuyu
            , pluralsFallbackFunction // Kirmanjki
            , pluralsFallbackFunction // Kuanyama
            , pluralsFunction1        // Kazakh
            , pluralsFunction1        // Kako
            , pluralsFunction1        // Kalaallisut
            , pluralsFallbackFunction // Kalenjin
            , pluralsFunction6        // Khmer
            , pluralsFallbackFunction // Kimbundu
            , pluralsFunction3        // Kannada
            , pluralsFunction6        // Korean
            , pluralsFallbackFunction // KomiPermyak
            , pluralsFallbackFunction // Konkani
            , pluralsFallbackFunction // Kosraean
            , pluralsFallbackFunction // Kpelle
            , pluralsFallbackFunction // Kanuri
            , pluralsFallbackFunction // KarachayBalkar
            , pluralsFallbackFunction // Krio
            , pluralsFallbackFunction // KinarayA
            , pluralsFallbackFunction // Karelian
            , pluralsFallbackFunction // Kurukh
            , pluralsFunction1        // Kashmiri
            , pluralsFunction1        // Shambala
            , pluralsFallbackFunction // Bafia
            , pluralsFunction21       // Colognian
            , pluralsFunction1        // Kurdish
            , pluralsFallbackFunction // Kumyk
            , pluralsFallbackFunction // Kutenai
            , pluralsFallbackFunction // Komi
            , pluralsFunction20       // Cornish
            , pluralsFunction1        // Kyrgyz
            , pluralsFunction1        // Kirghiz
            , pluralsFallbackFunction // Latin
            , pluralsFallbackFunction // Ladino
            , pluralsFunction22       // Langi
            , pluralsFallbackFunction // Lahnda
            , pluralsFallbackFunction // Lamba
            , pluralsFunction1        // Luxembourgish
            , pluralsFallbackFunction // Lezghian
            , pluralsFallbackFunction // LinguaFrancaNova
            , pluralsFunction1        // Ganda
            , pluralsFallbackFunction // Limburgish
            , pluralsFallbackFunction // Ligurian
            , pluralsFallbackFunction // Livonian
            , pluralsFunction6        // Lakota
            , pluralsFallbackFunction // Lombard
            , pluralsFunction2        // Lingala
            , pluralsFunction6        // Lao
            , pluralsFallbackFunction // Mongo
            , pluralsFallbackFunction // Lozi
            , pluralsFunction23       // Lithuanian
            , pluralsFallbackFunction // Latgalian
            , pluralsFallbackFunction // LubaKatanga
            , pluralsFallbackFunction // LubaLulua
            , pluralsFallbackFunction // Luiseno
            , pluralsFallbackFunction // Lunda
            , pluralsFallbackFunction // Luo
            , pluralsFallbackFunction // Mizo
            , pluralsFallbackFunction // Luyia
            , pluralsFunction24       // Latvian
            , pluralsFallbackFunction // LiteraryChinese
            , pluralsFallbackFunction // Laz
            , pluralsFallbackFunction // Madurese
            , pluralsFallbackFunction // Mafa
            , pluralsFallbackFunction // Magahi
            , pluralsFallbackFunction // Maithili
            , pluralsFallbackFunction // Makasar
            , pluralsFallbackFunction // Mandingo
            , pluralsFunction1        // Masai
            , pluralsFallbackFunction // Maba
            , pluralsFallbackFunction // Moksha
            , pluralsFallbackFunction // Mandar
            , pluralsFallbackFunction // Mende
            , pluralsFallbackFunction // Meru
            , pluralsFallbackFunction // Morisyen
            , pluralsFunction2        // Malagasy
            , pluralsFallbackFunction // MiddleIrish
            , pluralsFallbackFunction // MakhuwaMeetto
            , pluralsFunction1        // Meta
            , pluralsFallbackFunction // Marshallese
            , pluralsFallbackFunction // Maori
            , pluralsFallbackFunction // Micmac
            , pluralsFallbackFunction // Minangkabau
            , pluralsFunction25       // Macedonian
            , pluralsFunction1        // Malayalam
            , pluralsFunction1        // Mongolian
            , pluralsFallbackFunction // Manchu
            , pluralsFallbackFunction // Manipuri
            , pluralsFallbackFunction // Mohawk
            , pluralsFallbackFunction // Mossi
            , pluralsFunction3        // Marathi
            , pluralsFallbackFunction // WesternMari
            , pluralsFunction6        // Malay
            , pluralsFunction26       // Maltese
            , pluralsFallbackFunction // Mundang
            , pluralsFallbackFunction // MultipleLanguages
            , pluralsFallbackFunction // Creek
            , pluralsFallbackFunction // Mirandese
            , pluralsFallbackFunction // Marwari
            , pluralsFallbackFunction // Mentawai
            , pluralsFunction6        // Burmese
            , pluralsFallbackFunction // Myene
            , pluralsFallbackFunction // Erzya
            , pluralsFallbackFunction // Mazanderani
            , pluralsFallbackFunction // Nauru
            , pluralsFallbackFunction // MinNanChinese
            , pluralsFallbackFunction // Neapolitan
            , pluralsFunction20       // Nama
            , pluralsFunction1        // NorwegianBokmal
            , pluralsFunction1        // NorthNdebele
            , pluralsFallbackFunction // LowGerman
            , pluralsFunction1        // Nepali
            , pluralsFallbackFunction // Newari
            , pluralsFallbackFunction // Ndonga
            , pluralsFallbackFunction // Nias
            , pluralsFallbackFunction // Niuean
            , pluralsFallbackFunction // AoNaga
            , pluralsDefaultFunction  // Dutch
            , pluralsDefaultFunction  // Flemish
            , pluralsFallbackFunction // Kwasio
            , pluralsFunction1        // NorwegianNynorsk
            , pluralsFunction1        // Ngiemboon
            , pluralsFunction1        // Norwegian
            , pluralsFallbackFunction // Nogai
            , pluralsFallbackFunction // OldNorse
            , pluralsFallbackFunction // Novial
            , pluralsFunction6        // Nko
            , pluralsFunction1        // SouthNdebele
            , pluralsFunction2        // NorthernSotho
            , pluralsFallbackFunction // Nuer
            , pluralsFallbackFunction // Navajo
            , pluralsFallbackFunction // ClassicalNewari
            , pluralsFunction1        // Nyanja
            , pluralsFallbackFunction // Nyamwezi
            , pluralsFunction1        // Nyankole
            , pluralsFallbackFunction // Nyoro
            , pluralsFallbackFunction // Nzima
            , pluralsFallbackFunction // Occitan
            , pluralsFallbackFunction // Ojibwa
            , pluralsFunction1        // Oromo
            , pluralsFunction1        // Oriya
            , pluralsFunction1        // Ossetic
            , pluralsFallbackFunction // Osage
            , pluralsFallbackFunction // OttomanTurkish
            , pluralsFunction2        // Punjabi
            , pluralsFallbackFunction // Pangasinan
            , pluralsFallbackFunction // Pahlavi
            , pluralsFallbackFunction // Pampanga
            , pluralsFunction1        // Papiamento
            , pluralsFallbackFunction // Palauan
            , pluralsFallbackFunction // Picard
            , pluralsFallbackFunction // PennsylvaniaGerman
            , pluralsFallbackFunction // Plautdietsch
            , pluralsFallbackFunction // OldPersian
            , pluralsFallbackFunction // PalatineGerman
            , pluralsFallbackFunction // Phoenician
            , pluralsFallbackFunction // Pali
            , pluralsFunction27       // Polish
            , pluralsFallbackFunction // Piedmontese
            , pluralsFallbackFunction // Pontic
            , pluralsFallbackFunction // Pohnpeian
            , pluralsFunction24       // Prussian
            , pluralsFallbackFunction // OldProvencal
            , pluralsFunction1        // Pashto
            , pluralsFunction1        // Pushto
            , pluralsFunction28       // Portuguese
            , pluralsFunction28       // BrazilianPortuguese
            , pluralsFunction28       // EuropeanPortuguese
            , pluralsFallbackFunction // Quechua
            , pluralsFallbackFunction // Kiche
            , pluralsFallbackFunction // ChimborazoHighlandQuichua
            , pluralsFallbackFunction // Rajasthani
            , pluralsFallbackFunction // Rapanui
            , pluralsFallbackFunction // Rarotongan
            , pluralsFallbackFunction // Romagnol
            , pluralsFallbackFunction // Riffian
            , pluralsFunction1        // Romansh
            , pluralsFallbackFunction // Rundi
            , pluralsFunction30       // Romanian
            , pluralsFunction30       // Moldavian
            , pluralsFunction1        // Rombo
            , pluralsFallbackFunction // Romany
            , pluralsFallbackFunction // Rotuman
            , pluralsFunction31       // Russian
            , pluralsFallbackFunction // Rusyn
            , pluralsFallbackFunction // Roviana
            , pluralsFallbackFunction // Aromanian
            , pluralsFallbackFunction // Kinyarwanda
            , pluralsFunction1        // Rwa
            , pluralsFallbackFunction // Sanskrit
            , pluralsFallbackFunction // Sandawe
            , pluralsFunction6        // Sakha
            , pluralsFallbackFunction // SamaritanAramaic
            , pluralsFunction1        // Samburu
            , pluralsFallbackFunction // Sasak
            , pluralsFallbackFunction // Santali
            , pluralsFallbackFunction // Saurashtra
            , pluralsFallbackFunction // Ngambay
            , pluralsFallbackFunction // Sangu
            , pluralsFallbackFunction // Sardinian
            , pluralsFallbackFunction // Sicilian
            , pluralsFallbackFunction // Scots
            , pluralsFallbackFunction // Sindhi
            , pluralsFallbackFunction // SassareseSardinian
            , pluralsFunction20       // NorthernSami
            , pluralsFallbackFunction // Seneca
            , pluralsFunction1        // Sena
            , pluralsFallbackFunction // Seri
            , pluralsFallbackFunction // Selkup
            , pluralsFunction6        // KoyraboroSenni
            , pluralsFunction6        // Sango
            , pluralsFallbackFunction // OldIrish
            , pluralsFallbackFunction // Samogitian
            , pluralsFunction8        // SerboCroatian
            , pluralsFunction32       // Tachelhit
            , pluralsFallbackFunction // Shan
            , pluralsFallbackFunction // ChadianArabic
            , pluralsFunction33       // Sinhala
            , pluralsFallbackFunction // Sidamo
            , pluralsFunction9        // Slovak
            , pluralsFunction34       // Slovenian
            , pluralsFallbackFunction // LowerSilesian
            , pluralsFallbackFunction // Selayar
            , pluralsFallbackFunction // Samoan
            , pluralsFunction20       // SouthernSami
            , pluralsFunction20       // LuleSami
            , pluralsFunction20       // InariSami
            , pluralsFunction20       // SkoltSami
            , pluralsFunction1        // Shona
            , pluralsFallbackFunction // Soninke
            , pluralsFunction1        // Somali
            , pluralsFallbackFunction // Sogdien
            , pluralsFunction1        // Albanian
            , pluralsFunction8        // Serbian
            , pluralsFallbackFunction // SrananTongo
            , pluralsFallbackFunction // Serer
            , pluralsFunction1        // Swati
            , pluralsFunction1        // Saho
            , pluralsFunction1        // SouthernSotho
            , pluralsFallbackFunction // SaterlandFrisian
            , pluralsFallbackFunction // Sundanese
            , pluralsFallbackFunction // Sukuma
            , pluralsFallbackFunction // Susu
            , pluralsFallbackFunction // Sumerian
            , pluralsDefaultFunction  // Swedish
            , pluralsDefaultFunction  // Swahili
            , pluralsFallbackFunction // Comorian
            , pluralsFallbackFunction // CongoSwahili
            , pluralsFallbackFunction // ClassicalSyriac
            , pluralsFunction1        // Syriac
            , pluralsFallbackFunction // Silesian
            , pluralsFunction1        // Tamil
            , pluralsFallbackFunction // Tulu
            , pluralsFunction1        // Telugu
            , pluralsFallbackFunction // Timne
            , pluralsFunction1        // Teso
            , pluralsFallbackFunction // Tereno
            , pluralsFallbackFunction // Tetum
            , pluralsFallbackFunction // Tajik
            , pluralsFunction6        // Thai
            , pluralsFunction2        // Tigrinya
            , pluralsFunction1        // Tigre
            , pluralsFallbackFunction // Tiv
            , pluralsFunction1        // Turkmen
            , pluralsFallbackFunction // Tokelau
            , pluralsFallbackFunction // Tsakhur
            , pluralsFunction14       // Tagalog
            , pluralsFallbackFunction // Klingon
            , pluralsFallbackFunction // Tlingit
            , pluralsFallbackFunction // Talysh
            , pluralsFallbackFunction // Tamashek
            , pluralsFunction1        // Tswana
            , pluralsFunction6        // Tongan
            , pluralsFallbackFunction // NyasaTonga
            , pluralsFallbackFunction // TokPisin
            , pluralsFunction1        // Turkish
            , pluralsFallbackFunction // Turoyo
            , pluralsFallbackFunction // Taroko
            , pluralsFunction1        // Tsonga
            , pluralsFallbackFunction // Tsakonian
            , pluralsFallbackFunction // Tsimshian
            , pluralsFallbackFunction // Tatar
            , pluralsFallbackFunction // MuslimTat
            , pluralsFallbackFunction // Tumbuka
            , pluralsFallbackFunction // Tuvalu
            , pluralsFallbackFunction // Twi
            , pluralsFallbackFunction // Tasawaq
            , pluralsFallbackFunction // Tahitian
            , pluralsFallbackFunction // Tuvinian
            , pluralsFunction35       // CentralAtlasTamazight
            , pluralsFallbackFunction // Udmurt
            , pluralsFunction1        // Uyghur
            , pluralsFunction1        // Uighur
            , pluralsFallbackFunction // Ugaritic
            , pluralsFunction31       // Ukrainian
            , pluralsFallbackFunction // Umbundu
            , pluralsFallbackFunction // UnknownLanguage
            , pluralsDefaultFunction  // Urdu
            , pluralsFunction1        // Uzbek
            , pluralsFallbackFunction // Vai
            , pluralsFunction1        // Venda
            , pluralsFallbackFunction // Venetian
            , pluralsFallbackFunction // Veps
            , pluralsFunction6        // Vietnamese
            , pluralsFallbackFunction // WestFlemish
            , pluralsFallbackFunction // MainFranconian
            , pluralsFunction1        // Volapuk
            , pluralsFallbackFunction // Votic
            , pluralsFallbackFunction // Voro
            , pluralsFunction1        // Vunjo
            , pluralsFunction2        // Walloon
            , pluralsFunction1        // Walser
            , pluralsFallbackFunction // Wolaytta
            , pluralsFallbackFunction // Waray
            , pluralsFallbackFunction // Washo
            , pluralsFunction6        // Wolof
            , pluralsFallbackFunction // WuChinese
            , pluralsFallbackFunction // Kalmyk
            , pluralsFunction1        // Xhosa
            , pluralsFallbackFunction // Mingrelian
            , pluralsFunction1        // Soga
            , pluralsFallbackFunction // Yao
            , pluralsFallbackFunction // Yapese
            , pluralsFallbackFunction // Yangben
            , pluralsFallbackFunction // Yemba
            , pluralsDefaultFunction  // Yiddish
            , pluralsFunction6        // Yoruba
            , pluralsFallbackFunction // Nheengatu
            , pluralsFallbackFunction // Cantonese
            , pluralsFallbackFunction // Zhuang
            , pluralsFallbackFunction // Zapotec
            , pluralsFallbackFunction // Blissymbols
            , pluralsFallbackFunction // Zeelandic
            , pluralsFallbackFunction // Zenaga
            , pluralsFallbackFunction // StandardMoroccanTamazight
            , pluralsFunction6        // Chinese
            , pluralsFunction6        // SimplifiedChinese
            , pluralsFunction6        // TraditionalChinese
            , pluralsFunction3        // Zulu
            , pluralsFallbackFunction // Zuni
            , pluralsFallbackFunction // NoLinguisticContent
            , pluralsFallbackFunction // Zaza
        };

        /// <summary>
        /// Fallback function for any language without plurals rules that just return PluralsQuantity.Other.
        /// </summary>
        /// <returns>PluralsQuantity.Other.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFallbackFunction(double quantity)
        {
            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Default function for languages that has the same plurals rules as for English</para>
        /// <para>Used in languages:</para>
        /// <para>Asturian</para>
        /// <para>Catalan</para>
        /// <para>German</para>
        /// <para>AustrianGerman</para>
        /// <para>SwissHighGerman</para>
        /// <para>English</para>
        /// <para>AustralianEnglish</para>
        /// <para>CanadianEnglish</para>
        /// <para>BritishEnglish</para>
        /// <para>UKEnglish</para>
        /// <para>AmericanEnglish</para>
        /// <para>USEnglish</para>
        /// <para>Estonian</para>
        /// <para>Finnish</para>
        /// <para>WesternFrisian</para>
        /// <para>Galician</para>
        /// <para>Italian</para>
        /// <para>Dutch</para>
        /// <para>Flemish</para>
        /// <para>Swedish</para>
        /// <para>Swahili</para>
        /// <para>Urdu</para>
        /// <para>Yiddish</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsDefaultFunction(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }

            if (i == 1 && v == 0) // i = 1 and v = 0 @integer 1
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Afrikaans</para>
        /// <para>Asu</para>
        /// <para>Azerbaijani</para>
        /// <para>Azeri</para>
        /// <para>Bemba</para>
        /// <para>Bena</para>
        /// <para>Bulgarian</para>
        /// <para>Bodo</para>
        /// <para>Chiga</para>
        /// <para>Cherokee</para>
        /// <para>SoraniKurdish</para>
        /// <para>Divehi</para>
        /// <para>Ewe</para>
        /// <para>Greek</para>
        /// <para>Esperanto</para>
        /// <para>Spanish</para>
        /// <para>LatinAmericanSpanish</para>
        /// <para>EuropeanSpanish</para>
        /// <para>MexicanSpanish</para>
        /// <para>Basque</para>
        /// <para>Faroese</para>
        /// <para>Friulian</para>
        /// <para>SwissGerman</para>
        /// <para>Hausa</para>
        /// <para>Hawaiian</para>
        /// <para>Hungarian</para>
        /// <para>Ngomba</para>
        /// <para>Machame</para>
        /// <para>Georgian</para>
        /// <para>Jju</para>
        /// <para>Tyap</para>
        /// <para>Kazakh</para>
        /// <para>Kako</para>
        /// <para>Kalaallisut</para>
        /// <para>Kashmiri</para>
        /// <para>Shambala</para>
        /// <para>Kurdish</para>
        /// <para>Kyrgyz</para>
        /// <para>Kirghiz</para>
        /// <para>Luxembourgish</para>
        /// <para>Ganda</para>
        /// <para>Masai</para>
        /// <para>Meta</para>
        /// <para>Malayalam</para>
        /// <para>Mongolian</para>
        /// <para>NorwegianBokmal</para>
        /// <para>NorthNdebele</para>
        /// <para>Nepali</para>
        /// <para>NorwegianNynorsk</para>
        /// <para>Ngiemboon</para>
        /// <para>Norwegian</para>
        /// <para>SouthNdebele</para>
        /// <para>Nyanja</para>
        /// <para>Nyankole</para>
        /// <para>Oromo</para>
        /// <para>Oriya</para>
        /// <para>Ossetic</para>
        /// <para>Papiamento</para>
        /// <para>Pashto</para>
        /// <para>Pushto</para>
        /// <para>Romansh</para>
        /// <para>Rombo</para>
        /// <para>Rwa</para>
        /// <para>Samburu</para>
        /// <para>Sena</para>
        /// <para>Shona</para>
        /// <para>Somali</para>
        /// <para>Albanian</para>
        /// <para>Swati</para>
        /// <para>Saho</para>
        /// <para>SouthernSotho</para>
        /// <para>Syriac</para>
        /// <para>Tamil</para>
        /// <para>Telugu</para>
        /// <para>Teso</para>
        /// <para>Tigre</para>
        /// <para>Turkmen</para>
        /// <para>Tswana</para>
        /// <para>Turkish</para>
        /// <para>Tsonga</para>
        /// <para>Uyghur</para>
        /// <para>Uighur</para>
        /// <para>Uzbek</para>
        /// <para>Venda</para>
        /// <para>Volapuk</para>
        /// <para>Vunjo</para>
        /// <para>Walser</para>
        /// <para>Xhosa</para>
        /// <para>Soga</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction1(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)

            if (n == 1) // n = 1 @integer 1 @decimal 1.0, 1.00, 1.000, 1.0000
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Akan</para>
        /// <para>Lingala</para>
        /// <para>Malagasy</para>
        /// <para>NorthernSotho</para>
        /// <para>Punjabi</para>
        /// <para>Tigrinya</para>
        /// <para>Walloon</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction2(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)

            if ((n >= 0 && n <= 1)) // n = 0..1 @integer 0, 1 @decimal 0.0, 1.0, 0.00, 1.00, 0.000, 1.000, 0.0000, 1.0000
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Amharic</para>
        /// <para>Bengali</para>
        /// <para>Persian</para>
        /// <para>Gujarati</para>
        /// <para>Hindi</para>
        /// <para>Kannada</para>
        /// <para>Marathi</para>
        /// <para>Zulu</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction3(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n

            if (i == 0 || n == 1) // i = 0 or n = 1 @integer 0, 1 @decimal 0.0~1.0, 0.00~0.04
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Arabic</para>
        /// <para>ModernStandardArabic</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction4(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            double n_mod_100 = n % 100;

            if (n == 0) // n = 0 @integer 0 @decimal 0.0, 0.00, 0.000, 0.0000
            {
                return PluralsQuantity.Zero;
            }

            if (n == 1) // n = 1 @integer 1 @decimal 1.0, 1.00, 1.000, 1.0000
            {
                return PluralsQuantity.One;
            }

            if (n == 2) // n = 2 @integer 2 @decimal 2.0, 2.00, 2.000, 2.0000
            {
                return PluralsQuantity.Two;
            }

            if ((n_mod_100 >= 3 && n_mod_100 <= 10)) // n % 100 = 3..10 @integer 3~10, 103~110, 1003, … @decimal 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 103.0, 1003.0, …
            {
                return PluralsQuantity.Few;
            }

            if ((n_mod_100 >= 11 && n_mod_100 <= 99)) // n % 100 = 11..99 @integer 11~26, 111, 1011, … @decimal 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 111.0, 1011.0, …
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Belarusian</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction5(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            double n_mod_100 = n % 100;
            double n_mod_10 = n % 10;

            if (n_mod_10 == 1 && n_mod_100 != 11) // n % 10 = 1 and n % 100 != 11 @integer 1, 21, 31, 41, 51, 61, 71, 81, 101, 1001, … @decimal 1.0, 21.0, 31.0, 41.0, 51.0, 61.0, 71.0, 81.0, 101.0, 1001.0, …
            {
                return PluralsQuantity.One;
            }

            if ((n_mod_10 >= 2 && n_mod_10 <= 4) && (n_mod_100 < 12 || n_mod_100 > 14)) // n % 10 = 2..4 and n % 100 != 12..14 @integer 2~4, 22~24, 32~34, 42~44, 52~54, 62, 102, 1002, … @decimal 2.0, 3.0, 4.0, 22.0, 23.0, 24.0, 32.0, 33.0, 102.0, 1002.0, …
            {
                return PluralsQuantity.Few;
            }

            if (n_mod_10 == 0 || (n_mod_10 >= 5 && n_mod_10 <= 9) || (n_mod_100 >= 11 && n_mod_100 <= 14)) // n % 10 = 0 or n % 10 = 5..9 or n % 100 = 11..14 @integer 0, 5~19, 100, 1000, 10000, 100000, 1000000, … @decimal 0.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, …
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Bambara</para>
        /// <para>Tibetan</para>
        /// <para>Dzongkha</para>
        /// <para>Indonesian</para>
        /// <para>Igbo</para>
        /// <para>SichuanYi</para>
        /// <para>Japanese</para>
        /// <para>Lojban</para>
        /// <para>Javanese</para>
        /// <para>Makonde</para>
        /// <para>Kabuverdianu</para>
        /// <para>Khmer</para>
        /// <para>Korean</para>
        /// <para>Lakota</para>
        /// <para>Lao</para>
        /// <para>Malay</para>
        /// <para>Burmese</para>
        /// <para>Nko</para>
        /// <para>Sakha</para>
        /// <para>KoyraboroSenni</para>
        /// <para>Sango</para>
        /// <para>Thai</para>
        /// <para>Tongan</para>
        /// <para>Vietnamese</para>
        /// <para>Wolof</para>
        /// <para>Yoruba</para>
        /// <para>Chinese</para>
        /// <para>SimplifiedChinese</para>
        /// <para>TraditionalChinese</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction6(double quantity)
        {
            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Breton</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction7(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            double n_mod_100 = n % 100;
            double n_mod_10 = n % 10;
            double n_mod_1000000 = n % 1000000;

            if (n_mod_10 == 1 && (n_mod_100 != 11 && n_mod_100 != 71 && n_mod_100 != 91)) // n % 10 = 1 and n % 100 != 11,71,91 @integer 1, 21, 31, 41, 51, 61, 81, 101, 1001, … @decimal 1.0, 21.0, 31.0, 41.0, 51.0, 61.0, 81.0, 101.0, 1001.0, …
            {
                return PluralsQuantity.One;
            }

            if (n_mod_10 == 2 && (n_mod_100 != 12 && n_mod_100 != 72 && n_mod_100 != 92)) // n % 10 = 2 and n % 100 != 12,72,92 @integer 2, 22, 32, 42, 52, 62, 82, 102, 1002, … @decimal 2.0, 22.0, 32.0, 42.0, 52.0, 62.0, 82.0, 102.0, 1002.0, …
            {
                return PluralsQuantity.Two;
            }

            if (((n_mod_10 >= 3 && n_mod_10 <= 4) || n_mod_10 == 9) && ((n_mod_100 < 10 || n_mod_100 > 19) && (n_mod_100 < 70 || n_mod_100 > 79) && (n_mod_100 < 90 || n_mod_100 > 99))) // n % 10 = 3..4,9 and n % 100 != 10..19,70..79,90..99 @integer 3, 4, 9, 23, 24, 29, 33, 34, 39, 43, 44, 49, 103, 1003, … @decimal 3.0, 4.0, 9.0, 23.0, 24.0, 29.0, 33.0, 34.0, 103.0, 1003.0, …
            {
                return PluralsQuantity.Few;
            }

            if (n != 0 && n_mod_1000000 == 0) // n != 0 and n % 1000000 = 0 @integer 1000000, … @decimal 1000000.0, 1000000.00, 1000000.000, …
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Bosnian</para>
        /// <para>Croatian</para>
        /// <para>SerboCroatian</para>
        /// <para>Serbian</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction8(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            int i_mod_100 = i % 100;
            int i_mod_10 = i % 10;
            int f_mod_100 = f % 100;
            int f_mod_10 = f % 10;

            if (v == 0 && i_mod_10 == 1 && i_mod_100 != 11 || f_mod_10 == 1 && f_mod_100 != 11) // v = 0 and i % 10 = 1 and i % 100 != 11 or f % 10 = 1 and f % 100 != 11 @integer 1, 21, 31, 41, 51, 61, 71, 81, 101, 1001, … @decimal 0.1, 1.1, 2.1, 3.1, 4.1, 5.1, 6.1, 7.1, 10.1, 100.1, 1000.1, …
            {
                return PluralsQuantity.One;
            }

            if (v == 0 && (i_mod_10 >= 2 && i_mod_10 <= 4) && (i_mod_100 < 12 || i_mod_100 > 14) || (f_mod_10 >= 2 && f_mod_10 <= 4) && (f_mod_100 < 12 || f_mod_100 > 14)) // v = 0 and i % 10 = 2..4 and i % 100 != 12..14 or f % 10 = 2..4 and f % 100 != 12..14 @integer 2~4, 22~24, 32~34, 42~44, 52~54, 62, 102, 1002, … @decimal 0.2~0.4, 1.2~1.4, 2.2~2.4, 3.2~3.4, 4.2~4.4, 5.2, 10.2, 100.2, 1000.2, …
            {
                return PluralsQuantity.Few;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Czech</para>
        /// <para>Slovak</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction9(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }

            if (i == 1 && v == 0) // i = 1 and v = 0 @integer 1
            {
                return PluralsQuantity.One;
            }

            if ((i >= 2 && i <= 4) && v == 0) // i = 2..4 and v = 0 @integer 2~4
            {
                return PluralsQuantity.Few;
            }

            if (v != 0) // v != 0   @decimal 0.0~1.5, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, …
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Welsh</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction10(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)

            if (n == 0) // n = 0 @integer 0 @decimal 0.0, 0.00, 0.000, 0.0000
            {
                return PluralsQuantity.Zero;
            }

            if (n == 1) // n = 1 @integer 1 @decimal 1.0, 1.00, 1.000, 1.0000
            {
                return PluralsQuantity.One;
            }

            if (n == 2) // n = 2 @integer 2 @decimal 2.0, 2.00, 2.000, 2.0000
            {
                return PluralsQuantity.Two;
            }

            if (n == 3) // n = 3 @integer 3 @decimal 3.0, 3.00, 3.000, 3.0000
            {
                return PluralsQuantity.Few;
            }

            if (n == 6) // n = 6 @integer 6 @decimal 6.0, 6.00, 6.000, 6.0000
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Danish</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction11(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }

            int    t = f;                        // visible fractional digits in n, without trailing zeros

            if (n == 1 || t != 0 && (i == 0 || i == 1)) // n = 1 or t != 0 and i = 0,1 @integer 1 @decimal 0.1~1.6
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>LowerSorbian</para>
        /// <para>UpperSorbian</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction12(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            int i_mod_100 = i % 100;
            int f_mod_100 = f % 100;

            if (v == 0 && i_mod_100 == 1 || f_mod_100 == 1) // v = 0 and i % 100 = 1 or f % 100 = 1 @integer 1, 101, 201, 301, 401, 501, 601, 701, 1001, … @decimal 0.1, 1.1, 2.1, 3.1, 4.1, 5.1, 6.1, 7.1, 10.1, 100.1, 1000.1, …
            {
                return PluralsQuantity.One;
            }

            if (v == 0 && i_mod_100 == 2 || f_mod_100 == 2) // v = 0 and i % 100 = 2 or f % 100 = 2 @integer 2, 102, 202, 302, 402, 502, 602, 702, 1002, … @decimal 0.2, 1.2, 2.2, 3.2, 4.2, 5.2, 6.2, 7.2, 10.2, 100.2, 1000.2, …
            {
                return PluralsQuantity.Two;
            }

            if (v == 0 && (i_mod_100 >= 3 && i_mod_100 <= 4) || (f_mod_100 >= 3 && f_mod_100 <= 4)) // v = 0 and i % 100 = 3..4 or f % 100 = 3..4 @integer 3, 4, 103, 104, 203, 204, 303, 304, 403, 404, 503, 504, 603, 604, 703, 704, 1003, … @decimal 0.3, 0.4, 1.3, 1.4, 2.3, 2.4, 3.3, 3.4, 4.3, 4.4, 5.3, 5.4, 6.3, 6.4, 7.3, 7.4, 10.3, 100.3, 1000.3, …
            {
                return PluralsQuantity.Few;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Fulah</para>
        /// <para>French</para>
        /// <para>CanadianFrench</para>
        /// <para>SwissFrench</para>
        /// <para>Armenian</para>
        /// <para>Kabyle</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction13(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n

            if ((i == 0 || i == 1)) // i = 0,1 @integer 0, 1 @decimal 0.0~1.5
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Filipino</para>
        /// <para>Tagalog</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction14(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            int i_mod_10 = i % 10;
            int f_mod_10 = f % 10;

            if (v == 0 && (i == 1 || i == 2 || i == 3) || v == 0 && (i_mod_10 != 4 && i_mod_10 != 6 && i_mod_10 != 9) || v != 0 && (f_mod_10 != 4 && f_mod_10 != 6 && f_mod_10 != 9)) // v = 0 and i = 1,2,3 or v = 0 and i % 10 != 4,6,9 or v != 0 and f % 10 != 4,6,9 @integer 0~3, 5, 7, 8, 10~13, 15, 17, 18, 20, 21, 100, 1000, 10000, 100000, 1000000, … @decimal 0.0~0.3, 0.5, 0.7, 0.8, 1.0~1.3, 1.5, 1.7, 1.8, 2.0, 2.1, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, …
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Irish</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction15(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)

            if (n == 1) // n = 1 @integer 1 @decimal 1.0, 1.00, 1.000, 1.0000
            {
                return PluralsQuantity.One;
            }

            if (n == 2) // n = 2 @integer 2 @decimal 2.0, 2.00, 2.000, 2.0000
            {
                return PluralsQuantity.Two;
            }

            if ((n >= 3 && n <= 6)) // n = 3..6 @integer 3~6 @decimal 3.0, 4.0, 5.0, 6.0, 3.00, 4.00, 5.00, 6.00, 3.000, 4.000, 5.000, 6.000, 3.0000, 4.0000, 5.0000, 6.0000
            {
                return PluralsQuantity.Few;
            }

            if ((n >= 7 && n <= 10)) // n = 7..10 @integer 7~10 @decimal 7.0, 8.0, 9.0, 10.0, 7.00, 8.00, 9.00, 10.00, 7.000, 8.000, 9.000, 10.000, 7.0000, 8.0000, 9.0000, 10.0000
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>ScottishGaelic</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction16(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)

            if ((n == 1 || n == 11)) // n = 1,11 @integer 1, 11 @decimal 1.0, 11.0, 1.00, 11.00, 1.000, 11.000, 1.0000
            {
                return PluralsQuantity.One;
            }

            if ((n == 2 || n == 12)) // n = 2,12 @integer 2, 12 @decimal 2.0, 12.0, 2.00, 12.00, 2.000, 12.000, 2.0000
            {
                return PluralsQuantity.Two;
            }

            if (((n >= 3 && n <= 10) || (n >= 13 && n <= 19))) // n = 3..10,13..19 @integer 3~10, 13~19 @decimal 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 3.00
            {
                return PluralsQuantity.Few;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Manx</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction17(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            int i_mod_10 = i % 10;
            int i_mod_100 = i % 100;

            if (v == 0 && i_mod_10 == 1) // v = 0 and i % 10 = 1 @integer 1, 11, 21, 31, 41, 51, 61, 71, 101, 1001, …
            {
                return PluralsQuantity.One;
            }

            if (v == 0 && i_mod_10 == 2) // v = 0 and i % 10 = 2 @integer 2, 12, 22, 32, 42, 52, 62, 72, 102, 1002, …
            {
                return PluralsQuantity.Two;
            }

            if (v == 0 && (i_mod_100 == 0 || i_mod_100 == 20 || i_mod_100 == 40 || i_mod_100 == 60 || i_mod_100 == 80)) // v = 0 and i % 100 = 0,20,40,60,80 @integer 0, 20, 40, 60, 80, 100, 120, 140, 1000, 10000, 100000, 1000000, …
            {
                return PluralsQuantity.Few;
            }

            if (v != 0) // v != 0   @decimal 0.0~1.5, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, …
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Hebrew</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction18(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            double n_mod_10 = n % 10;

            if (i == 1 && v == 0) // i = 1 and v = 0 @integer 1
            {
                return PluralsQuantity.One;
            }

            if (i == 2 && v == 0) // i = 2 and v = 0 @integer 2
            {
                return PluralsQuantity.Two;
            }

            if (v == 0 && (n < 0 || n > 10) && n_mod_10 == 0) // v = 0 and n != 0..10 and n % 10 = 0 @integer 20, 30, 40, 50, 60, 70, 80, 90, 100, 1000, 10000, 100000, 1000000, …
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Icelandic</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction19(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }

            int    t = f;                        // visible fractional digits in n, without trailing zeros
            int i_mod_100 = i % 100;
            int i_mod_10 = i % 10;

            if (t == 0 && i_mod_10 == 1 && i_mod_100 != 11 || t != 0) // t = 0 and i % 10 = 1 and i % 100 != 11 or t != 0 @integer 1, 21, 31, 41, 51, 61, 71, 81, 101, 1001, … @decimal 0.1~1.6, 10.1, 100.1, 1000.1, …
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Inuktitut</para>
        /// <para>Cornish</para>
        /// <para>Nama</para>
        /// <para>NorthernSami</para>
        /// <para>SouthernSami</para>
        /// <para>LuleSami</para>
        /// <para>InariSami</para>
        /// <para>SkoltSami</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction20(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)

            if (n == 1) // n = 1 @integer 1 @decimal 1.0, 1.00, 1.000, 1.0000
            {
                return PluralsQuantity.One;
            }

            if (n == 2) // n = 2 @integer 2 @decimal 2.0, 2.00, 2.000, 2.0000
            {
                return PluralsQuantity.Two;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Colognian</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction21(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)

            if (n == 0) // n = 0 @integer 0 @decimal 0.0, 0.00, 0.000, 0.0000
            {
                return PluralsQuantity.Zero;
            }

            if (n == 1) // n = 1 @integer 1 @decimal 1.0, 1.00, 1.000, 1.0000
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Langi</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction22(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n

            if (n == 0) // n = 0 @integer 0 @decimal 0.0, 0.00, 0.000, 0.0000
            {
                return PluralsQuantity.Zero;
            }

            if ((i == 0 || i == 1) && n != 0) // i = 0,1 and n != 0 @integer 1 @decimal 0.1~1.6
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Lithuanian</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction23(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            double n_mod_100 = n % 100;
            double n_mod_10 = n % 10;
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }

            if (n_mod_10 == 1 && (n_mod_100 < 11 || n_mod_100 > 19)) // n % 10 = 1 and n % 100 != 11..19 @integer 1, 21, 31, 41, 51, 61, 71, 81, 101, 1001, … @decimal 1.0, 21.0, 31.0, 41.0, 51.0, 61.0, 71.0, 81.0, 101.0, 1001.0, …
            {
                return PluralsQuantity.One;
            }

            if ((n_mod_10 >= 2 && n_mod_10 <= 9) && (n_mod_100 < 11 || n_mod_100 > 19)) // n % 10 = 2..9 and n % 100 != 11..19 @integer 2~9, 22~29, 102, 1002, … @decimal 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 22.0, 102.0, 1002.0, …
            {
                return PluralsQuantity.Few;
            }

            if (f != 0) // f != 0   @decimal 0.1~0.9, 1.1~1.7, 10.1, 100.1, 1000.1, …
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Latvian</para>
        /// <para>Prussian</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction24(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            double n_mod_100 = n % 100;
            double n_mod_10 = n % 10;
            int f_mod_100 = f % 100;
            int f_mod_10 = f % 10;

            if (n_mod_10 == 0 || (n_mod_100 >= 11 && n_mod_100 <= 19) || v == 2 && (f_mod_100 >= 11 && f_mod_100 <= 19)) // n % 10 = 0 or n % 100 = 11..19 or v = 2 and f % 100 = 11..19 @integer 0, 10~20, 30, 40, 50, 60, 100, 1000, 10000, 100000, 1000000, … @decimal 0.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, …
            {
                return PluralsQuantity.Zero;
            }

            if (n_mod_10 == 1 && n_mod_100 != 11 || v == 2 && f_mod_10 == 1 && f_mod_100 != 11 || v != 2 && f_mod_10 == 1) // n % 10 = 1 and n % 100 != 11 or v = 2 and f % 10 = 1 and f % 100 != 11 or v != 2 and f % 10 = 1 @integer 1, 21, 31, 41, 51, 61, 71, 81, 101, 1001, … @decimal 0.1, 1.0, 1.1, 2.1, 3.1, 4.1, 5.1, 6.1, 7.1, 10.1, 100.1, 1000.1, …
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Macedonian</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction25(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            int i_mod_10 = i % 10;
            int f_mod_10 = f % 10;

            if (v == 0 && i_mod_10 == 1 || f_mod_10 == 1) // v = 0 and i % 10 = 1 or f % 10 = 1 @integer 1, 11, 21, 31, 41, 51, 61, 71, 101, 1001, … @decimal 0.1, 1.1, 2.1, 3.1, 4.1, 5.1, 6.1, 7.1, 10.1, 100.1, 1000.1, …
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Maltese</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction26(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            double n_mod_100 = n % 100;

            if (n == 1) // n = 1 @integer 1 @decimal 1.0, 1.00, 1.000, 1.0000
            {
                return PluralsQuantity.One;
            }

            if (n == 0 || (n_mod_100 >= 2 && n_mod_100 <= 10)) // n = 0 or n % 100 = 2..10 @integer 0, 2~10, 102~107, 1002, … @decimal 0.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 10.0, 102.0, 1002.0, …
            {
                return PluralsQuantity.Few;
            }

            if ((n_mod_100 >= 11 && n_mod_100 <= 19)) // n % 100 = 11..19 @integer 11~19, 111~117, 1011, … @decimal 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 111.0, 1011.0, …
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Polish</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction27(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            int i_mod_100 = i % 100;
            int i_mod_10 = i % 10;

            if (i == 1 && v == 0) // i = 1 and v = 0 @integer 1
            {
                return PluralsQuantity.One;
            }

            if (v == 0 && (i_mod_10 >= 2 && i_mod_10 <= 4) && (i_mod_100 < 12 || i_mod_100 > 14)) // v = 0 and i % 10 = 2..4 and i % 100 != 12..14 @integer 2~4, 22~24, 32~34, 42~44, 52~54, 62, 102, 1002, …
            {
                return PluralsQuantity.Few;
            }

            if (v == 0 && i != 1 && (i_mod_10 >= 0 && i_mod_10 <= 1) || v == 0 && (i_mod_10 >= 5 && i_mod_10 <= 9) || v == 0 && (i_mod_100 >= 12 && i_mod_100 <= 14)) // v = 0 and i != 1 and i % 10 = 0..1 or v = 0 and i % 10 = 5..9 or v = 0 and i % 100 = 12..14 @integer 0, 5~19, 100, 1000, 10000, 100000, 1000000, …
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Portuguese</para>
        /// <para>BrazilianPortuguese</para>
        /// <para>EuropeanPortuguese</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction28(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)

            if ((n >= 0 && n <= 2) && n != 2) // n = 0..2 and n != 2 @integer 0, 1 @decimal 0.0, 1.0, 0.00, 1.00, 0.000, 1.000, 0.0000, 1.0000
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>EuropeanPortuguese</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction29(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }

            if (n == 1 && v == 0) // n = 1 and v = 0 @integer 1
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Romanian</para>
        /// <para>Moldavian</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction30(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            double n_mod_100 = n % 100;

            if (i == 1 && v == 0) // i = 1 and v = 0 @integer 1
            {
                return PluralsQuantity.One;
            }

            if (v != 0 || n == 0 || n != 1 && (n_mod_100 >= 1 && n_mod_100 <= 19)) // v != 0 or n = 0 or n != 1 and n % 100 = 1..19 @integer 0, 2~16, 101, 1001, … @decimal 0.0~1.5, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, …
            {
                return PluralsQuantity.Few;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Russian</para>
        /// <para>Ukrainian</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction31(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            int i_mod_100 = i % 100;
            int i_mod_10 = i % 10;

            if (v == 0 && i_mod_10 == 1 && i_mod_100 != 11) // v = 0 and i % 10 = 1 and i % 100 != 11 @integer 1, 21, 31, 41, 51, 61, 71, 81, 101, 1001, …
            {
                return PluralsQuantity.One;
            }

            if (v == 0 && (i_mod_10 >= 2 && i_mod_10 <= 4) && (i_mod_100 < 12 || i_mod_100 > 14)) // v = 0 and i % 10 = 2..4 and i % 100 != 12..14 @integer 2~4, 22~24, 32~34, 42~44, 52~54, 62, 102, 1002, …
            {
                return PluralsQuantity.Few;
            }

            if (v == 0 && i_mod_10 == 0 || v == 0 && (i_mod_10 >= 5 && i_mod_10 <= 9) || v == 0 && (i_mod_100 >= 11 && i_mod_100 <= 14)) // v = 0 and i % 10 = 0 or v = 0 and i % 10 = 5..9 or v = 0 and i % 100 = 11..14 @integer 0, 5~19, 100, 1000, 10000, 100000, 1000000, …
            {
                return PluralsQuantity.Many;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Tachelhit</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction32(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n

            if (i == 0 || n == 1) // i = 0 or n = 1 @integer 0, 1 @decimal 0.0~1.0, 0.00~0.04
            {
                return PluralsQuantity.One;
            }

            if ((n >= 2 && n <= 10)) // n = 2..10 @integer 2~10 @decimal 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 2.00, 3.00, 4.00, 5.00, 6.00, 7.00, 8.00
            {
                return PluralsQuantity.Few;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Sinhala</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction33(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }

            if ((n == 0 || n == 1) || i == 0 && f == 1) // n = 0,1 or i = 0 and f = 1 @integer 0, 1 @decimal 0.0, 0.1, 1.0, 0.00, 0.01, 1.00, 0.000, 0.001, 1.000, 0.0000, 0.0001, 1.0000
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>Slovenian</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction34(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)
            int    i = (int)Math.Floor(n);       // integer digits of n
            int    v = 3;                        // number of visible fraction digits in n, with trailing zeros
            int    f = ((int)(n * 1000)) % 1000; // visible fractional digits in n, with trailing zeros

            if (f == 0)
            {
                v = 0;
            }
            else
            {
                while ((f > 0) && (f % 10 == 0))
                {
                    f /= 10;
                    --v;
                }
            }
            int i_mod_100 = i % 100;

            if (v == 0 && i_mod_100 == 1) // v = 0 and i % 100 = 1 @integer 1, 101, 201, 301, 401, 501, 601, 701, 1001, …
            {
                return PluralsQuantity.One;
            }

            if (v == 0 && i_mod_100 == 2) // v = 0 and i % 100 = 2 @integer 2, 102, 202, 302, 402, 502, 602, 702, 1002, …
            {
                return PluralsQuantity.Two;
            }

            if (v == 0 && (i_mod_100 >= 3 && i_mod_100 <= 4) || v != 0) // v = 0 and i % 100 = 3..4 or v != 0 @integer 3, 4, 103, 104, 203, 204, 303, 304, 403, 404, 503, 504, 603, 604, 703, 704, 1003, … @decimal 0.0~1.5, 10.0, 100.0, 1000.0, 10000.0, 100000.0, 1000000.0, …
            {
                return PluralsQuantity.Few;
            }

            return PluralsQuantity.Other;
        }

        /// <summary>
        /// <para>Some function for getting PluralsQuantity</para>
        /// <para>Used in languages:</para>
        /// <para>CentralAtlasTamazight</para>
        /// </summary>
        /// <returns>PluralsQuantity related to provided quantity.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity pluralsFunction35(double quantity)
        {
            double n = Math.Abs(quantity);       // absolute value of the source number (integer and decimals)

            if ((n >= 0 && n <= 1) || (n >= 11 && n <= 99)) // n = 0..1 or n = 11..99 @integer 0, 1, 11~24 @decimal 0.0, 1.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0, 21.0, 22.0, 23.0, 24.0
            {
                return PluralsQuantity.One;
            }

            return PluralsQuantity.Other;
        }
    }
}
