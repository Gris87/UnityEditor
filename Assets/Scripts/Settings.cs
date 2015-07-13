using UnityEngine;
using UnityEngine.Events;



/// <summary>
/// Class for storing settings.
/// </summary>
public static class Settings
{
	/// <summary>
	/// Key for storing InternalMode value.
	/// </summary>
	public const string KEY_INTERNAL_MODE = "Settings.InternalMode";



	/// <summary>
	/// Gets or sets a value indicating whether internal mode enabled or not.
	/// </summary>
	/// <value><c>true</c> if internal mode enabled; otherwise, <c>false</c>.</value>
	public static bool internalMode
	{
		get
        {
			return sInternalMode;
		}

		set
		{
			if (sInternalMode != value)
			{
				sInternalMode = value;

				PlayerPrefs.SetString(KEY_INTERNAL_MODE, sInternalMode.ToString());				
				PlayerPrefs.Save();

				sInternalModeListeners.Invoke();
			}
		}
	}



	private static bool sInternalMode;

	private static UnityEvent sInternalModeListeners;



	/// <summary>
	/// Initializes the <see cref="Settings"/> class.
	/// </summary>
	static Settings()
	{
		sInternalModeListeners = new UnityEvent();

		Load();
	}

	/// <summary>
	/// Adds InternalMode listener.
	/// </summary>
	/// <param name="listener">Listener.</param>
	public static void AddInternalModeListener(UnityAction listener)
	{
		sInternalModeListeners.AddListener(listener);
	}

	/// <summary>
	/// Removes InternalMode listener.
	/// </summary>
	/// <param name="listener">Listener.</param>
	public static void RemoveInternalModeListener(UnityAction listener)
	{
		sInternalModeListeners.RemoveListener(listener);
	}

	/// <summary>
	/// Save settings.
	/// </summary>
	public static void Save()
	{
		PlayerPrefs.SetString(KEY_INTERNAL_MODE, sInternalMode.ToString());
		
		PlayerPrefs.Save();
	}
	
	/// <summary>
	/// Load settings.
	/// </summary>
	public static void Load()
	{
		sInternalMode = (PlayerPrefs.GetString(KEY_INTERNAL_MODE, "False").ToLower() == "true");
	}
}