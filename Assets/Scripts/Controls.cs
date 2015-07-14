using System.Collections.ObjectModel;
using UnityEngine;



/// <summary>
/// <see cref="Controls"/> is a set of user defined buttons and axes. It is better to store this file somewhere in your project.
/// </summary>
public static class Controls
{
    /// <summary>
    /// <see cref="Buttons"/> is a set of user defined buttons.
    /// </summary>
    public struct Buttons
    {
        public KeyMapping escape;
		public KeyMapping menu;
    }



    /// <summary>
    /// Set of buttons.
    /// </summary>
    public static Buttons buttons;



    /// <summary>
    /// Initializes the <see cref="Controls"/> class.
    /// </summary>
    static Controls()
    {
		buttons.escape = InputControl.SetKey("Escape", KeyCode.Escape);
		buttons.menu   = InputControl.SetKey("Menu",   KeyCode.Menu);

        Load();
    }

    /// <summary>
    /// Nothing. It just call static constructor if needed.
    /// </summary>
    public static void Init()
    {
        // Nothing. It just call static constructor if needed
    }

    /// <summary>
    /// Save controls.
    /// </summary>
    public static void Save()
    {
        // It is just an example. You may remove it or modify it if you want
        ReadOnlyCollection<KeyMapping> keys = InputControl.GetKeys();

        foreach(KeyMapping key in keys)
        {
            PlayerPrefs.SetString("Controls." + key.name + ".primary",   key.primaryInput.ToString());
            PlayerPrefs.SetString("Controls." + key.name + ".secondary", key.secondaryInput.ToString());
            PlayerPrefs.SetString("Controls." + key.name + ".third",     key.thirdInput.ToString());
        }

        PlayerPrefs.Save();
    }

    /// <summary>
    /// Load controls.
    /// </summary>
    public static void Load()
    {
        // It is just an example. You may remove it or modify it if you want
        ReadOnlyCollection<KeyMapping> keys = InputControl.GetKeys();

        foreach(KeyMapping key in keys)
        {
            string inputStr;

            inputStr = PlayerPrefs.GetString("Controls." + key.name + ".primary");

            if (inputStr != "")
            {
                key.primaryInput = CustomInputFromString(inputStr);
            }

            inputStr = PlayerPrefs.GetString("Controls." + key.name + ".secondary");

            if (inputStr != "")
            {
                key.secondaryInput = CustomInputFromString(inputStr);
            }

            inputStr = PlayerPrefs.GetString("Controls." + key.name + ".third");

            if (inputStr != "")
            {
                key.thirdInput = CustomInputFromString(inputStr);
            }
        }
    }

    /// <summary>
    /// Converts string representation of CustomInput to CustomInput.
    /// </summary>
    /// <returns>CustomInput from string.</returns>
    /// <param name="value">String representation of CustomInput.</param>
    private static CustomInput CustomInputFromString(string value)
    {
        CustomInput res;

        res = JoystickInput.FromString(value);

        if (res != null)
        {
            return res;
        }

        res = MouseInput.FromString(value);

        if (res != null)
        {
            return res;
        }

        res = KeyboardInput.FromString(value);

        if (res != null)
        {
            return res;
        }

        return null;
    }
}

