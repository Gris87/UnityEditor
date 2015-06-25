using UnityEngine;
using UnityTranslation;

using Common.UI.Toasts;



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

	/// <summary>
	/// Show text notification with the contribute message.
	/// </summary>
	public static void ShowContributeMessage()
	{
		ShowContributeMessage(Global.dockingAreaScript.transform);
	}

	/// <summary>
	/// Show text notification with the contribute message.
	/// </summary>
	/// <param name="parent">Parent transform.</param>
	public static void ShowContributeMessage(Transform parent)
	{
		Toast.Show(parent, R.sections.Toasts.strings.contribute, Toast.LENGTH_LONG, Constants.sourceCodeUrl);
	}
}