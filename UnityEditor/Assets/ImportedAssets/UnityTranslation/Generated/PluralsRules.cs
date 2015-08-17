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
              PluralsDefaultFunction  // Default
            , PluralsFallbackFunction // Afar
            , PluralsFallbackFunction // Abkhazian
            , PluralsFallbackFunction // Achinese
            , PluralsFallbackFunction // Acoli
            , PluralsFallbackFunction // Adangme
            , PluralsFallbackFunction // Adyghe
            , PluralsFallbackFunction // Avestan
            , PluralsFallbackFunction // TunisianArabic
            , PluralsFunction1        // Afrikaans
            , PluralsFallbackFunction // Afrihili
            , PluralsFallbackFunction // Aghem
            , PluralsFallbackFunction // Ainu
            , PluralsFunction2        // Akan
            , PluralsFallbackFunction // Akkadian
            , PluralsFallbackFunction // Alabama
            , PluralsFallbackFunction // Aleut
            , PluralsFallbackFunction // GhegAlbanian
            , PluralsFallbackFunction // SouthernAltai
            , PluralsFunction3        // Amharic
            , PluralsFallbackFunction // Aragonese
            , PluralsFallbackFunction // OldEnglish
            , PluralsFallbackFunction // Angika
            , PluralsFunction4        // Arabic
            , PluralsFunction4        // ModernStandardArabic
            , PluralsFallbackFunction // Aramaic
            , PluralsFallbackFunction // Mapuche
            , PluralsFallbackFunction // Araona
            , PluralsFallbackFunction // Arapaho
            , PluralsFallbackFunction // AlgerianArabic
            , PluralsFallbackFunction // Arawak
            , PluralsFallbackFunction // MoroccanArabic
            , PluralsFallbackFunction // EgyptianArabic
            , PluralsFallbackFunction // Assamese
            , PluralsFunction1        // Asu
            , PluralsFallbackFunction // AmericanSignLanguage
            , PluralsDefaultFunction  // Asturian
            , PluralsFallbackFunction // Avaric
            , PluralsFallbackFunction // Kotava
            , PluralsFallbackFunction // Awadhi
            , PluralsFallbackFunction // Aymara
            , PluralsFunction1        // Azerbaijani
            , PluralsFunction1        // Azeri
            , PluralsFallbackFunction // SouthAzerbaijani
            , PluralsFallbackFunction // Bashkir
            , PluralsFallbackFunction // Baluchi
            , PluralsFallbackFunction // Balinese
            , PluralsFallbackFunction // Bavarian
            , PluralsFallbackFunction // Basaa
            , PluralsFallbackFunction // Bamun
            , PluralsFallbackFunction // BatakToba
            , PluralsFallbackFunction // Ghomala
            , PluralsFunction5        // Belarusian
            , PluralsFallbackFunction // Beja
            , PluralsFunction1        // Bemba
            , PluralsFallbackFunction // Betawi
            , PluralsFunction1        // Bena
            , PluralsFallbackFunction // Bafut
            , PluralsFallbackFunction // Badaga
            , PluralsFunction1        // Bulgarian
            , PluralsFallbackFunction // Bhojpuri
            , PluralsFallbackFunction // Bislama
            , PluralsFallbackFunction // Bikol
            , PluralsFallbackFunction // Bini
            , PluralsFallbackFunction // Banjar
            , PluralsFallbackFunction // Kom
            , PluralsFallbackFunction // Siksika
            , PluralsFunction6        // Bambara
            , PluralsFunction3        // Bengali
            , PluralsFunction6        // Tibetan
            , PluralsFallbackFunction // Bishnupriya
            , PluralsFallbackFunction // Bakhtiari
            , PluralsFunction7        // Breton
            , PluralsFallbackFunction // Braj
            , PluralsFallbackFunction // Brahui
            , PluralsFunction1        // Bodo
            , PluralsFunction8        // Bosnian
            , PluralsFallbackFunction // Akoose
            , PluralsFallbackFunction // Buriat
            , PluralsFallbackFunction // Buginese
            , PluralsFallbackFunction // Bulu
            , PluralsFallbackFunction // Blin
            , PluralsFallbackFunction // Medumba
            , PluralsDefaultFunction  // Catalan
            , PluralsFallbackFunction // Caddo
            , PluralsFallbackFunction // Carib
            , PluralsFallbackFunction // Cayuga
            , PluralsFallbackFunction // Atsam
            , PluralsFallbackFunction // Chechen
            , PluralsFallbackFunction // Cebuano
            , PluralsFunction1        // Chiga
            , PluralsFallbackFunction // Chamorro
            , PluralsFallbackFunction // Chibcha
            , PluralsFallbackFunction // Chagatai
            , PluralsFallbackFunction // Chuukese
            , PluralsFallbackFunction // Mari
            , PluralsFallbackFunction // ChinookJargon
            , PluralsFallbackFunction // Choctaw
            , PluralsFallbackFunction // Chipewyan
            , PluralsFunction1        // Cherokee
            , PluralsFallbackFunction // Cheyenne
            , PluralsFunction1        // SoraniKurdish
            , PluralsFallbackFunction // Corsican
            , PluralsFallbackFunction // Coptic
            , PluralsFallbackFunction // Capiznon
            , PluralsFallbackFunction // Cree
            , PluralsFallbackFunction // CrimeanTurkish
            , PluralsFunction9        // Czech
            , PluralsFallbackFunction // Kashubian
            , PluralsFallbackFunction // ChurchSlavic
            , PluralsFallbackFunction // Chuvash
            , PluralsFunction10       // Welsh
            , PluralsFunction11       // Danish
            , PluralsFallbackFunction // Dakota
            , PluralsFallbackFunction // Dargwa
            , PluralsFallbackFunction // Taita
            , PluralsDefaultFunction  // German
            , PluralsDefaultFunction  // AustrianGerman
            , PluralsDefaultFunction  // SwissHighGerman
            , PluralsFallbackFunction // Delaware
            , PluralsFallbackFunction // Slave
            , PluralsFallbackFunction // Dogrib
            , PluralsFallbackFunction // Dinka
            , PluralsFallbackFunction // Zarma
            , PluralsFallbackFunction // Dogri
            , PluralsFunction12       // LowerSorbian
            , PluralsFallbackFunction // CentralDusun
            , PluralsFallbackFunction // Duala
            , PluralsFallbackFunction // MiddleDutch
            , PluralsFunction1        // Divehi
            , PluralsFallbackFunction // JolaFonyi
            , PluralsFallbackFunction // Dyula
            , PluralsFunction6        // Dzongkha
            , PluralsFallbackFunction // Dazaga
            , PluralsFallbackFunction // Embu
            , PluralsFunction1        // Ewe
            , PluralsFallbackFunction // Efik
            , PluralsFallbackFunction // Emilian
            , PluralsFallbackFunction // AncientEgyptian
            , PluralsFallbackFunction // Ekajuk
            , PluralsFunction1        // Greek
            , PluralsFallbackFunction // Elamite
            , PluralsDefaultFunction  // English
            , PluralsDefaultFunction  // AustralianEnglish
            , PluralsDefaultFunction  // CanadianEnglish
            , PluralsDefaultFunction  // BritishEnglish
            , PluralsDefaultFunction  // UKEnglish
            , PluralsDefaultFunction  // AmericanEnglish
            , PluralsDefaultFunction  // USEnglish
            , PluralsFallbackFunction // MiddleEnglish
            , PluralsFunction1        // Esperanto
            , PluralsFunction1        // Spanish
            , PluralsFunction1        // LatinAmericanSpanish
            , PluralsFunction1        // EuropeanSpanish
            , PluralsFunction1        // MexicanSpanish
            , PluralsFallbackFunction // CentralYupik
            , PluralsDefaultFunction  // Estonian
            , PluralsFunction1        // Basque
            , PluralsFallbackFunction // Ewondo
            , PluralsFallbackFunction // Extremaduran
            , PluralsFunction3        // Persian
            , PluralsFallbackFunction // Fang
            , PluralsFallbackFunction // Fanti
            , PluralsFunction13       // Fulah
            , PluralsDefaultFunction  // Finnish
            , PluralsFunction14       // Filipino
            , PluralsFallbackFunction // TornedalenFinnish
            , PluralsFallbackFunction // Fijian
            , PluralsFunction1        // Faroese
            , PluralsFallbackFunction // Fon
            , PluralsFunction13       // French
            , PluralsFunction13       // CanadianFrench
            , PluralsFunction13       // SwissFrench
            , PluralsFallbackFunction // CajunFrench
            , PluralsFallbackFunction // MiddleFrench
            , PluralsFallbackFunction // OldFrench
            , PluralsFallbackFunction // Arpitan
            , PluralsFallbackFunction // NorthernFrisian
            , PluralsFallbackFunction // EasternFrisian
            , PluralsFunction1        // Friulian
            , PluralsDefaultFunction  // WesternFrisian
            , PluralsFunction15       // Irish
            , PluralsFallbackFunction // Ga
            , PluralsFallbackFunction // Gagauz
            , PluralsFallbackFunction // GanChinese
            , PluralsFallbackFunction // Gayo
            , PluralsFallbackFunction // Gbaya
            , PluralsFallbackFunction // ZoroastrianDari
            , PluralsFunction16       // ScottishGaelic
            , PluralsFallbackFunction // Geez
            , PluralsFallbackFunction // Gilbertese
            , PluralsDefaultFunction  // Galician
            , PluralsFallbackFunction // Gilaki
            , PluralsFallbackFunction // MiddleHighGerman
            , PluralsFallbackFunction // Guarani
            , PluralsFallbackFunction // OldHighGerman
            , PluralsFallbackFunction // GoanKonkani
            , PluralsFallbackFunction // Gondi
            , PluralsFallbackFunction // Gorontalo
            , PluralsFallbackFunction // Gothic
            , PluralsFallbackFunction // Grebo
            , PluralsFallbackFunction // AncientGreek
            , PluralsFunction1        // SwissGerman
            , PluralsFunction3        // Gujarati
            , PluralsFallbackFunction // Wayuu
            , PluralsFallbackFunction // Frafra
            , PluralsFallbackFunction // Gusii
            , PluralsFunction17       // Manx
            , PluralsFallbackFunction // Gwichin
            , PluralsFunction1        // Hausa
            , PluralsFallbackFunction // Haida
            , PluralsFallbackFunction // HakkaChinese
            , PluralsFunction1        // Hawaiian
            , PluralsFunction18       // Hebrew
            , PluralsFunction3        // Hindi
            , PluralsFallbackFunction // FijiHindi
            , PluralsFallbackFunction // Hiligaynon
            , PluralsFallbackFunction // Hittite
            , PluralsFallbackFunction // Hmong
            , PluralsFallbackFunction // HiriMotu
            , PluralsFunction8        // Croatian
            , PluralsFunction12       // UpperSorbian
            , PluralsFallbackFunction // XiangChinese
            , PluralsFallbackFunction // Haitian
            , PluralsFunction1        // Hungarian
            , PluralsFallbackFunction // Hupa
            , PluralsFunction13       // Armenian
            , PluralsFallbackFunction // Herero
            , PluralsFallbackFunction // Interlingua
            , PluralsFallbackFunction // Iban
            , PluralsFallbackFunction // Ibibio
            , PluralsFunction6        // Indonesian
            , PluralsFallbackFunction // Interlingue
            , PluralsFunction6        // Igbo
            , PluralsFunction6        // SichuanYi
            , PluralsFallbackFunction // Inupiaq
            , PluralsFallbackFunction // Iloko
            , PluralsFallbackFunction // Ingush
            , PluralsFallbackFunction // Ido
            , PluralsFunction19       // Icelandic
            , PluralsDefaultFunction  // Italian
            , PluralsFunction20       // Inuktitut
            , PluralsFallbackFunction // Ingrian
            , PluralsFunction6        // Japanese
            , PluralsFallbackFunction // JamaicanCreoleEnglish
            , PluralsFunction6        // Lojban
            , PluralsFunction1        // Ngomba
            , PluralsFunction1        // Machame
            , PluralsFallbackFunction // JudeoPersian
            , PluralsFallbackFunction // JudeoArabic
            , PluralsFallbackFunction // Jutish
            , PluralsFunction6        // Javanese
            , PluralsFunction1        // Georgian
            , PluralsFallbackFunction // KaraKalpak
            , PluralsFunction13       // Kabyle
            , PluralsFallbackFunction // Kachin
            , PluralsFunction1        // Jju
            , PluralsFallbackFunction // Kamba
            , PluralsFallbackFunction // Kawi
            , PluralsFallbackFunction // Kabardian
            , PluralsFallbackFunction // Kanembu
            , PluralsFunction1        // Tyap
            , PluralsFunction6        // Makonde
            , PluralsFunction6        // Kabuverdianu
            , PluralsFallbackFunction // Kenyang
            , PluralsFallbackFunction // Koro
            , PluralsFallbackFunction // Kongo
            , PluralsFallbackFunction // Kaingang
            , PluralsFallbackFunction // Khasi
            , PluralsFallbackFunction // Khotanese
            , PluralsFallbackFunction // KoyraChiini
            , PluralsFallbackFunction // Khowar
            , PluralsFallbackFunction // Kikuyu
            , PluralsFallbackFunction // Kirmanjki
            , PluralsFallbackFunction // Kuanyama
            , PluralsFunction1        // Kazakh
            , PluralsFunction1        // Kako
            , PluralsFunction1        // Kalaallisut
            , PluralsFallbackFunction // Kalenjin
            , PluralsFunction6        // Khmer
            , PluralsFallbackFunction // Kimbundu
            , PluralsFunction3        // Kannada
            , PluralsFunction6        // Korean
            , PluralsFallbackFunction // KomiPermyak
            , PluralsFallbackFunction // Konkani
            , PluralsFallbackFunction // Kosraean
            , PluralsFallbackFunction // Kpelle
            , PluralsFallbackFunction // Kanuri
            , PluralsFallbackFunction // KarachayBalkar
            , PluralsFallbackFunction // Krio
            , PluralsFallbackFunction // KinarayA
            , PluralsFallbackFunction // Karelian
            , PluralsFallbackFunction // Kurukh
            , PluralsFunction1        // Kashmiri
            , PluralsFunction1        // Shambala
            , PluralsFallbackFunction // Bafia
            , PluralsFunction21       // Colognian
            , PluralsFunction1        // Kurdish
            , PluralsFallbackFunction // Kumyk
            , PluralsFallbackFunction // Kutenai
            , PluralsFallbackFunction // Komi
            , PluralsFunction20       // Cornish
            , PluralsFunction1        // Kyrgyz
            , PluralsFunction1        // Kirghiz
            , PluralsFallbackFunction // Latin
            , PluralsFallbackFunction // Ladino
            , PluralsFunction22       // Langi
            , PluralsFallbackFunction // Lahnda
            , PluralsFallbackFunction // Lamba
            , PluralsFunction1        // Luxembourgish
            , PluralsFallbackFunction // Lezghian
            , PluralsFallbackFunction // LinguaFrancaNova
            , PluralsFunction1        // Ganda
            , PluralsFallbackFunction // Limburgish
            , PluralsFallbackFunction // Ligurian
            , PluralsFallbackFunction // Livonian
            , PluralsFunction6        // Lakota
            , PluralsFallbackFunction // Lombard
            , PluralsFunction2        // Lingala
            , PluralsFunction6        // Lao
            , PluralsFallbackFunction // Mongo
            , PluralsFallbackFunction // Lozi
            , PluralsFunction23       // Lithuanian
            , PluralsFallbackFunction // Latgalian
            , PluralsFallbackFunction // LubaKatanga
            , PluralsFallbackFunction // LubaLulua
            , PluralsFallbackFunction // Luiseno
            , PluralsFallbackFunction // Lunda
            , PluralsFallbackFunction // Luo
            , PluralsFallbackFunction // Mizo
            , PluralsFallbackFunction // Luyia
            , PluralsFunction24       // Latvian
            , PluralsFallbackFunction // LiteraryChinese
            , PluralsFallbackFunction // Laz
            , PluralsFallbackFunction // Madurese
            , PluralsFallbackFunction // Mafa
            , PluralsFallbackFunction // Magahi
            , PluralsFallbackFunction // Maithili
            , PluralsFallbackFunction // Makasar
            , PluralsFallbackFunction // Mandingo
            , PluralsFunction1        // Masai
            , PluralsFallbackFunction // Maba
            , PluralsFallbackFunction // Moksha
            , PluralsFallbackFunction // Mandar
            , PluralsFallbackFunction // Mende
            , PluralsFallbackFunction // Meru
            , PluralsFallbackFunction // Morisyen
            , PluralsFunction2        // Malagasy
            , PluralsFallbackFunction // MiddleIrish
            , PluralsFallbackFunction // MakhuwaMeetto
            , PluralsFunction1        // Meta
            , PluralsFallbackFunction // Marshallese
            , PluralsFallbackFunction // Maori
            , PluralsFallbackFunction // Micmac
            , PluralsFallbackFunction // Minangkabau
            , PluralsFunction25       // Macedonian
            , PluralsFunction1        // Malayalam
            , PluralsFunction1        // Mongolian
            , PluralsFallbackFunction // Manchu
            , PluralsFallbackFunction // Manipuri
            , PluralsFallbackFunction // Mohawk
            , PluralsFallbackFunction // Mossi
            , PluralsFunction3        // Marathi
            , PluralsFallbackFunction // WesternMari
            , PluralsFunction6        // Malay
            , PluralsFunction26       // Maltese
            , PluralsFallbackFunction // Mundang
            , PluralsFallbackFunction // MultipleLanguages
            , PluralsFallbackFunction // Creek
            , PluralsFallbackFunction // Mirandese
            , PluralsFallbackFunction // Marwari
            , PluralsFallbackFunction // Mentawai
            , PluralsFunction6        // Burmese
            , PluralsFallbackFunction // Myene
            , PluralsFallbackFunction // Erzya
            , PluralsFallbackFunction // Mazanderani
            , PluralsFallbackFunction // Nauru
            , PluralsFallbackFunction // MinNanChinese
            , PluralsFallbackFunction // Neapolitan
            , PluralsFunction20       // Nama
            , PluralsFunction1        // NorwegianBokmal
            , PluralsFunction1        // NorthNdebele
            , PluralsFallbackFunction // LowGerman
            , PluralsFunction1        // Nepali
            , PluralsFallbackFunction // Newari
            , PluralsFallbackFunction // Ndonga
            , PluralsFallbackFunction // Nias
            , PluralsFallbackFunction // Niuean
            , PluralsFallbackFunction // AoNaga
            , PluralsDefaultFunction  // Dutch
            , PluralsDefaultFunction  // Flemish
            , PluralsFallbackFunction // Kwasio
            , PluralsFunction1        // NorwegianNynorsk
            , PluralsFunction1        // Ngiemboon
            , PluralsFunction1        // Norwegian
            , PluralsFallbackFunction // Nogai
            , PluralsFallbackFunction // OldNorse
            , PluralsFallbackFunction // Novial
            , PluralsFunction6        // Nko
            , PluralsFunction1        // SouthNdebele
            , PluralsFunction2        // NorthernSotho
            , PluralsFallbackFunction // Nuer
            , PluralsFallbackFunction // Navajo
            , PluralsFallbackFunction // ClassicalNewari
            , PluralsFunction1        // Nyanja
            , PluralsFallbackFunction // Nyamwezi
            , PluralsFunction1        // Nyankole
            , PluralsFallbackFunction // Nyoro
            , PluralsFallbackFunction // Nzima
            , PluralsFallbackFunction // Occitan
            , PluralsFallbackFunction // Ojibwa
            , PluralsFunction1        // Oromo
            , PluralsFunction1        // Oriya
            , PluralsFunction1        // Ossetic
            , PluralsFallbackFunction // Osage
            , PluralsFallbackFunction // OttomanTurkish
            , PluralsFunction2        // Punjabi
            , PluralsFallbackFunction // Pangasinan
            , PluralsFallbackFunction // Pahlavi
            , PluralsFallbackFunction // Pampanga
            , PluralsFunction1        // Papiamento
            , PluralsFallbackFunction // Palauan
            , PluralsFallbackFunction // Picard
            , PluralsFallbackFunction // PennsylvaniaGerman
            , PluralsFallbackFunction // Plautdietsch
            , PluralsFallbackFunction // OldPersian
            , PluralsFallbackFunction // PalatineGerman
            , PluralsFallbackFunction // Phoenician
            , PluralsFallbackFunction // Pali
            , PluralsFunction27       // Polish
            , PluralsFallbackFunction // Piedmontese
            , PluralsFallbackFunction // Pontic
            , PluralsFallbackFunction // Pohnpeian
            , PluralsFunction24       // Prussian
            , PluralsFallbackFunction // OldProvencal
            , PluralsFunction1        // Pashto
            , PluralsFunction1        // Pushto
            , PluralsFunction28       // Portuguese
            , PluralsFunction28       // BrazilianPortuguese
            , PluralsFunction28       // EuropeanPortuguese
            , PluralsFallbackFunction // Quechua
            , PluralsFallbackFunction // Kiche
            , PluralsFallbackFunction // ChimborazoHighlandQuichua
            , PluralsFallbackFunction // Rajasthani
            , PluralsFallbackFunction // Rapanui
            , PluralsFallbackFunction // Rarotongan
            , PluralsFallbackFunction // Romagnol
            , PluralsFallbackFunction // Riffian
            , PluralsFunction1        // Romansh
            , PluralsFallbackFunction // Rundi
            , PluralsFunction30       // Romanian
            , PluralsFunction30       // Moldavian
            , PluralsFunction1        // Rombo
            , PluralsFallbackFunction // Romany
            , PluralsFallbackFunction // Rotuman
            , PluralsFunction31       // Russian
            , PluralsFallbackFunction // Rusyn
            , PluralsFallbackFunction // Roviana
            , PluralsFallbackFunction // Aromanian
            , PluralsFallbackFunction // Kinyarwanda
            , PluralsFunction1        // Rwa
            , PluralsFallbackFunction // Sanskrit
            , PluralsFallbackFunction // Sandawe
            , PluralsFunction6        // Sakha
            , PluralsFallbackFunction // SamaritanAramaic
            , PluralsFunction1        // Samburu
            , PluralsFallbackFunction // Sasak
            , PluralsFallbackFunction // Santali
            , PluralsFallbackFunction // Saurashtra
            , PluralsFallbackFunction // Ngambay
            , PluralsFallbackFunction // Sangu
            , PluralsFallbackFunction // Sardinian
            , PluralsFallbackFunction // Sicilian
            , PluralsFallbackFunction // Scots
            , PluralsFallbackFunction // Sindhi
            , PluralsFallbackFunction // SassareseSardinian
            , PluralsFunction20       // NorthernSami
            , PluralsFallbackFunction // Seneca
            , PluralsFunction1        // Sena
            , PluralsFallbackFunction // Seri
            , PluralsFallbackFunction // Selkup
            , PluralsFunction6        // KoyraboroSenni
            , PluralsFunction6        // Sango
            , PluralsFallbackFunction // OldIrish
            , PluralsFallbackFunction // Samogitian
            , PluralsFunction8        // SerboCroatian
            , PluralsFunction32       // Tachelhit
            , PluralsFallbackFunction // Shan
            , PluralsFallbackFunction // ChadianArabic
            , PluralsFunction33       // Sinhala
            , PluralsFallbackFunction // Sidamo
            , PluralsFunction9        // Slovak
            , PluralsFunction34       // Slovenian
            , PluralsFallbackFunction // LowerSilesian
            , PluralsFallbackFunction // Selayar
            , PluralsFallbackFunction // Samoan
            , PluralsFunction20       // SouthernSami
            , PluralsFunction20       // LuleSami
            , PluralsFunction20       // InariSami
            , PluralsFunction20       // SkoltSami
            , PluralsFunction1        // Shona
            , PluralsFallbackFunction // Soninke
            , PluralsFunction1        // Somali
            , PluralsFallbackFunction // Sogdien
            , PluralsFunction1        // Albanian
            , PluralsFunction8        // Serbian
            , PluralsFallbackFunction // SrananTongo
            , PluralsFallbackFunction // Serer
            , PluralsFunction1        // Swati
            , PluralsFunction1        // Saho
            , PluralsFunction1        // SouthernSotho
            , PluralsFallbackFunction // SaterlandFrisian
            , PluralsFallbackFunction // Sundanese
            , PluralsFallbackFunction // Sukuma
            , PluralsFallbackFunction // Susu
            , PluralsFallbackFunction // Sumerian
            , PluralsDefaultFunction  // Swedish
            , PluralsDefaultFunction  // Swahili
            , PluralsFallbackFunction // Comorian
            , PluralsFallbackFunction // CongoSwahili
            , PluralsFallbackFunction // ClassicalSyriac
            , PluralsFunction1        // Syriac
            , PluralsFallbackFunction // Silesian
            , PluralsFunction1        // Tamil
            , PluralsFallbackFunction // Tulu
            , PluralsFunction1        // Telugu
            , PluralsFallbackFunction // Timne
            , PluralsFunction1        // Teso
            , PluralsFallbackFunction // Tereno
            , PluralsFallbackFunction // Tetum
            , PluralsFallbackFunction // Tajik
            , PluralsFunction6        // Thai
            , PluralsFunction2        // Tigrinya
            , PluralsFunction1        // Tigre
            , PluralsFallbackFunction // Tiv
            , PluralsFunction1        // Turkmen
            , PluralsFallbackFunction // Tokelau
            , PluralsFallbackFunction // Tsakhur
            , PluralsFunction14       // Tagalog
            , PluralsFallbackFunction // Klingon
            , PluralsFallbackFunction // Tlingit
            , PluralsFallbackFunction // Talysh
            , PluralsFallbackFunction // Tamashek
            , PluralsFunction1        // Tswana
            , PluralsFunction6        // Tongan
            , PluralsFallbackFunction // NyasaTonga
            , PluralsFallbackFunction // TokPisin
            , PluralsFunction1        // Turkish
            , PluralsFallbackFunction // Turoyo
            , PluralsFallbackFunction // Taroko
            , PluralsFunction1        // Tsonga
            , PluralsFallbackFunction // Tsakonian
            , PluralsFallbackFunction // Tsimshian
            , PluralsFallbackFunction // Tatar
            , PluralsFallbackFunction // MuslimTat
            , PluralsFallbackFunction // Tumbuka
            , PluralsFallbackFunction // Tuvalu
            , PluralsFallbackFunction // Twi
            , PluralsFallbackFunction // Tasawaq
            , PluralsFallbackFunction // Tahitian
            , PluralsFallbackFunction // Tuvinian
            , PluralsFunction35       // CentralAtlasTamazight
            , PluralsFallbackFunction // Udmurt
            , PluralsFunction1        // Uyghur
            , PluralsFunction1        // Uighur
            , PluralsFallbackFunction // Ugaritic
            , PluralsFunction31       // Ukrainian
            , PluralsFallbackFunction // Umbundu
            , PluralsFallbackFunction // UnknownLanguage
            , PluralsDefaultFunction  // Urdu
            , PluralsFunction1        // Uzbek
            , PluralsFallbackFunction // Vai
            , PluralsFunction1        // Venda
            , PluralsFallbackFunction // Venetian
            , PluralsFallbackFunction // Veps
            , PluralsFunction6        // Vietnamese
            , PluralsFallbackFunction // WestFlemish
            , PluralsFallbackFunction // MainFranconian
            , PluralsFunction1        // Volapuk
            , PluralsFallbackFunction // Votic
            , PluralsFallbackFunction // Voro
            , PluralsFunction1        // Vunjo
            , PluralsFunction2        // Walloon
            , PluralsFunction1        // Walser
            , PluralsFallbackFunction // Wolaytta
            , PluralsFallbackFunction // Waray
            , PluralsFallbackFunction // Washo
            , PluralsFunction6        // Wolof
            , PluralsFallbackFunction // WuChinese
            , PluralsFallbackFunction // Kalmyk
            , PluralsFunction1        // Xhosa
            , PluralsFallbackFunction // Mingrelian
            , PluralsFunction1        // Soga
            , PluralsFallbackFunction // Yao
            , PluralsFallbackFunction // Yapese
            , PluralsFallbackFunction // Yangben
            , PluralsFallbackFunction // Yemba
            , PluralsDefaultFunction  // Yiddish
            , PluralsFunction6        // Yoruba
            , PluralsFallbackFunction // Nheengatu
            , PluralsFallbackFunction // Cantonese
            , PluralsFallbackFunction // Zhuang
            , PluralsFallbackFunction // Zapotec
            , PluralsFallbackFunction // Blissymbols
            , PluralsFallbackFunction // Zeelandic
            , PluralsFallbackFunction // Zenaga
            , PluralsFallbackFunction // StandardMoroccanTamazight
            , PluralsFunction6        // Chinese
            , PluralsFunction6        // SimplifiedChinese
            , PluralsFunction6        // TraditionalChinese
            , PluralsFunction3        // Zulu
            , PluralsFallbackFunction // Zuni
            , PluralsFallbackFunction // NoLinguisticContent
            , PluralsFallbackFunction // Zaza
        };

        /// <summary>
        /// Fallback function for any language without plurals rules that just return PluralsQuantity.Other.
        /// </summary>
        /// <returns>PluralsQuantity.Other.</returns>
        /// <param name="quantity">Quantity.</param>
        private static PluralsQuantity PluralsFallbackFunction(double quantity)
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
        private static PluralsQuantity PluralsDefaultFunction(double quantity)
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
        private static PluralsQuantity PluralsFunction1(double quantity)
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
        private static PluralsQuantity PluralsFunction2(double quantity)
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
        private static PluralsQuantity PluralsFunction3(double quantity)
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
        private static PluralsQuantity PluralsFunction4(double quantity)
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
        private static PluralsQuantity PluralsFunction5(double quantity)
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
        private static PluralsQuantity PluralsFunction6(double quantity)
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
        private static PluralsQuantity PluralsFunction7(double quantity)
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
        private static PluralsQuantity PluralsFunction8(double quantity)
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
        private static PluralsQuantity PluralsFunction9(double quantity)
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
        private static PluralsQuantity PluralsFunction10(double quantity)
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
        private static PluralsQuantity PluralsFunction11(double quantity)
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
        private static PluralsQuantity PluralsFunction12(double quantity)
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
        private static PluralsQuantity PluralsFunction13(double quantity)
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
        private static PluralsQuantity PluralsFunction14(double quantity)
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
        private static PluralsQuantity PluralsFunction15(double quantity)
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
        private static PluralsQuantity PluralsFunction16(double quantity)
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
        private static PluralsQuantity PluralsFunction17(double quantity)
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
        private static PluralsQuantity PluralsFunction18(double quantity)
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
        private static PluralsQuantity PluralsFunction19(double quantity)
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
        private static PluralsQuantity PluralsFunction20(double quantity)
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
        private static PluralsQuantity PluralsFunction21(double quantity)
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
        private static PluralsQuantity PluralsFunction22(double quantity)
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
        private static PluralsQuantity PluralsFunction23(double quantity)
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
        private static PluralsQuantity PluralsFunction24(double quantity)
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
        private static PluralsQuantity PluralsFunction25(double quantity)
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
        private static PluralsQuantity PluralsFunction26(double quantity)
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
        private static PluralsQuantity PluralsFunction27(double quantity)
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
        private static PluralsQuantity PluralsFunction28(double quantity)
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
        private static PluralsQuantity PluralsFunction29(double quantity)
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
        private static PluralsQuantity PluralsFunction30(double quantity)
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
        private static PluralsQuantity PluralsFunction31(double quantity)
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
        private static PluralsQuantity PluralsFunction32(double quantity)
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
        private static PluralsQuantity PluralsFunction33(double quantity)
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
        private static PluralsQuantity PluralsFunction34(double quantity)
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
        private static PluralsQuantity PluralsFunction35(double quantity)
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
