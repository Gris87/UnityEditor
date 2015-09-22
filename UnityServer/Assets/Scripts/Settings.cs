using UnityEngine;
using UnityEngine.Events;

using Common;



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
			DebugEx.VeryVeryVerboseFormat("Settings.internalMode = {0}", sInternalMode);

            return sInternalMode;
        }

        set
        {
			DebugEx.VeryVerboseFormat("Settings.internalMode: {0} => {1}", sInternalMode, value);

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
        DebugEx.Verbose("Static class Settings initialized");

        sInternalModeListeners = new UnityEvent();

        Load();
    }

    /// <summary>
    /// Adds InternalMode listener.
    /// </summary>
    /// <param name="listener">Listener.</param>
    public static void AddInternalModeListener(UnityAction listener)
    {
        DebugEx.VerboseFormat("Settings.AddInternalModeListener(listener = {0})", listener);

        sInternalModeListeners.AddListener(listener);
    }

    /// <summary>
    /// Removes InternalMode listener.
    /// </summary>
    /// <param name="listener">Listener.</param>
    public static void RemoveInternalModeListener(UnityAction listener)
    {
        DebugEx.VerboseFormat("Settings.RemoveInternalModeListener(listener = {0})", listener);

        sInternalModeListeners.RemoveListener(listener);
    }

    /// <summary>
    /// Save settings.
    /// </summary>
    public static void Save()
    {
        DebugEx.Verbose("Settings.Save()");

        PlayerPrefs.SetString(KEY_INTERNAL_MODE, sInternalMode.ToString());

        PlayerPrefs.Save();
    }

    /// <summary>
    /// Load settings.
    /// </summary>
    public static void Load()
    {
        DebugEx.Verbose("Settings.Load()");

        sInternalMode = (PlayerPrefs.GetString(KEY_INTERNAL_MODE, "False").ToLower() == "true");

        DebugEx.Debug("Settings loaded:");
		DebugEx.Debug("  * sInternalMode = {0}", sInternalMode);
    }
}
