namespace UnityTranslationInternal
{
    /// <summary>
    /// Plurals quantity. This enumeration contains list of available plurals quantities.
    ///
    /// See also: <a UnityTranslationInternal="http://developer.android.com/guide/topics/resources/string-resource.html#Plurals">String Resources - Plurals</a>
    /// </summary>
    public enum PluralsQuantity
    {
        /// <summary>
        /// When the language requires special treatment of the number 0 (as in Arabic).
        /// </summary>
        Zero
        ,
        /// <summary>
        /// When the language requires special treatment of numbers like one (as with the number 1 in English and most other languages; in Russian, any number ending in 1 but not ending in 11 is in this class).
        /// </summary>
        One
        ,
        /// <summary>
        /// When the language requires special treatment of numbers like two (as with 2 in Welsh, or 102 in Slovenian).
        /// </summary>
        Two
        ,
        /// <summary>
        /// When the language requires special treatment of "small" numbers (as with 2, 3, and 4 in Czech; or numbers ending 2, 3, or 4 but not 12, 13, or 14 in Polish).
        /// </summary>
        Few
        ,
        /// <summary>
        /// When the language requires special treatment of "large" numbers (as with numbers ending 11-99 in Maltese).
        /// </summary>
        Many
        ,
        /// <summary>
        /// When the language does not require special treatment of the given quantity (as with all numbers in Chinese, or 42 in English).
        /// </summary>
        Other
        ,
        /// <summary>
        /// Total amount of Plurals quantities.
        /// </summary>
        Count
    }
}
