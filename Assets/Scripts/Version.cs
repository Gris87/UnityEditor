/// <summary>
/// Class with information about version.
/// </summary>
public static class Version
{
    /// <summary>
    /// Enumeration of build types.
    /// </summary>
    public enum BuildType
    {
        /// <summary>
        /// Personal edition.
        /// </summary>
        Personal
        ,
        /// <summary>
        /// Professional edition.
        /// </summary>
        Professional
    }



    /// <summary>
    /// Version build.
    /// </summary>
    public const string BUILD = "5.1.1f1";

    /// <summary>
    /// The type of the build.
    /// </summary>
    public static BuildType buildType = BuildType.Personal;
}
