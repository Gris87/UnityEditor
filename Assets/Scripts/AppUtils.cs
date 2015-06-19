using UnityEngine;
using UnityTranslation;



/// <summary>
/// Class for Unity Editor usefull functions.
/// </summary>
public static class AppUtils
{
	/// <summary>
	/// Returns version info.
	/// </summary>
	public static string version()
	{
		string res = Version.build + " ";
		
		switch (Version.buildType)
		{
		case Version.BuildType.Personal:
		{	
			res += Translator.getString(R.sections.Version.strings.personal);
		}
			break;
		default:
		{	
			Debug.LogWarning("Unknown localization for build type \"" + Version.buildType.ToString() + "\". Using default value.");
			res += Version.buildType.ToString();
		}
			break;
		}
		
		return res;
	}
}