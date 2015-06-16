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
		Personal
	}

	/// <summary>
	/// Version build.
	/// </summary>
	public static readonly string build = "5.0.2f1";

	/// <summary>
	/// The type of the build.
	/// </summary>
	public static readonly BuildType buildType = BuildType.Personal;
}