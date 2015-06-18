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
	public static readonly string KEY_INTERNAL_MODE = "Settings.InternalMode";



	/// <summary>
	/// Gets or sets a value indicating whether internal mode enabled or not.
	/// </summary>
	/// <value><c>true</c> if internal mode enabled; otherwise, <c>false</c>.</value>
	public static bool internalMode
	{
		get
        {
			return mInternalMode;
		}

		set
		{
			if (mInternalMode != value)
			{
				mInternalMode = value;

				PlayerPrefs.SetString(KEY_INTERNAL_MODE, mInternalMode.ToString());				
				PlayerPrefs.Save();

				mInternalModeListeners.Invoke();
			}
		}
	}



	private static bool mInternalMode;

	private static UnityEvent mInternalModeListeners;



	/// <summary>
	/// Initializes the <see cref="Settings"/> class.
	/// </summary>
	static Settings()
	{
		mInternalModeListeners = new UnityEvent();

		Load();
	}

	/// <summary>
	/// Adds InternalMode listener.
	/// </summary>
	/// <param name="listener">Listener.</param>
	public static void AddInternalModeListener(UnityAction listener)
	{
		mInternalModeListeners.AddListener(listener);
	}

	/// <summary>
	/// Removes InternalMode listener.
	/// </summary>
	/// <param name="listener">Listener.</param>
	public static void RemoveInternalModeListener(UnityAction listener)
	{
		mInternalModeListeners.RemoveListener(listener);
	}

	/// <summary>
	/// Save settings.
	/// </summary>
	public static void Save()
	{
		PlayerPrefs.SetString(KEY_INTERNAL_MODE, mInternalMode.ToString());
		
		PlayerPrefs.Save();
	}
	
	/// <summary>
	/// Load settings.
	/// </summary>
	public static void Load()
	{
		mInternalMode = (PlayerPrefs.GetString(KEY_INTERNAL_MODE, "False").ToLower() == "true");
	}
}