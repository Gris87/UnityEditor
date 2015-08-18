using System;
using System.Collections.Generic;
using UnityEngine;

using Common;
using Common.UI.ResourceTypes;



/// <summary>
/// Class for loading assets of UnityEditor project.
/// </summary>
public static class Assets
{
    #region Assets structures
    #region Common assets
    /// <summary>
    /// Common assets.
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Common fonts.
        /// </summary>
        public static class Fonts
        {
            public static Font defaultFont;



            private static Dictionary<string, Font> sFonts;
            private static string[]                 sOsFonts;



            /// <summary>
            /// Initializes the <see cref="Assets+Common+Fonts"/> class.
            /// </summary>
            static Fonts()
            {
                defaultFont = LoadResource<Font>("Common/Fonts/Default");

                sFonts   = new Dictionary<string, Font>();
                sOsFonts = Font.GetOSInstalledFontNames();

                ResetValues();
            }

            /// <summary>
            /// Resets values.
            /// </summary>
            public static void ResetValues()
            {
                sFonts.Clear();

				Font[] fontList = Resources.LoadAll<Font>("Common/Fonts/"); // TODO: [Trivial] And "Fonts/"

                foreach (Font font in fontList)
                {
                    string[] fontNames = font.fontNames;

                    foreach (string fontName in fontNames)
                    {
                        if (!sFonts.ContainsKey(fontName))
                        {
                            sFonts.Add(fontName, font);
                        }
                        else
                        {
                            Debug.LogWarning("Already has a font with name: " + fontName);
                        }
                    }
                }

                string[] defaultFontNames = defaultFont.fontNames;

                foreach (string fontName in defaultFontNames)
                {
                    if (!sFonts.ContainsKey(fontName))
                    {
                        sFonts.Add(fontName, defaultFont);
                    }
                }
            }

            /// <summary>
            /// Gets the font with specified name.
            /// </summary>
            /// <returns>Font.</returns>
            /// <param name="fontName">Font name.</param>
            /// <param name="fontSize">Font size.</param>
            public static Font GetFont(string fontName, int fontSize = 12)
            {
                Font res;

                if (sFonts.TryGetValue(fontName, out res))
                {
                    return res;
                }

                string nameLower = fontName.ToLower();
                string bestFont  = "";

                foreach (string osFont in sOsFonts)
                {
                    if (osFont == fontName)
                    {
                        bestFont = osFont;
                        break;
                    }

                    string osNameLower = osFont.ToLower();

                    if (osNameLower == nameLower)
                    {
                        bestFont = osFont;
                        break;
                    }

                    if (osNameLower.Contains(nameLower))
                    {
                        if (bestFont == "" || osFont.Length < bestFont.Length)
                        {
                            bestFont = osFont;
                        }
                    }
                }

                if (bestFont != "")
                {
                    res = Font.CreateDynamicFontFromOSFont(bestFont, fontSize);
                    sFonts.Add(fontName, res);

                    return res;
                }

                return defaultFont;
            }
        }
    }
    #endregion

	// TODO: [Major] Change order
    #region Assets for Cursors
    /// <summary>
    /// Assets for Cursors.
    /// </summary>
    public static class Cursors
    {
        public static Texture2D eastWest           = LoadScaledTexture2D("Common/Cursors/EastWest");
		public static Texture2D northEastSouthWest = LoadScaledTexture2D("Common/Cursors/NorthEastSouthWest");
		public static Texture2D northSouth         = LoadScaledTexture2D("Common/Cursors/NorthSouth");
		public static Texture2D northWestSouthEast = LoadScaledTexture2D("Common/Cursors/NorthWestSouthEast");
    }
    #endregion

    #region Assets for Windows
    /// <summary>
    /// Assets for Windows.
    /// </summary>
    public static class Windows
    {
        #region Common assets for Windows
        /// <summary>
        /// Common assets for Windows.
        /// </summary>
        public static class Common
        {
            /// <summary>
            /// Common color assets for Windows.
            /// </summary>
            public static class Colors
            {
                public static Color background = LoadColor("Common/Colors/UI/Windows/Background");
            }

            /// <summary>
            /// Common text style assets for Windows.
            /// </summary>
            public static class TextStyles
            {
                public static TextStyle title = LoadTextStyle("Common/TextStyles/UI/Windows/Title");
            }

            /// <summary>
            /// Common texture assets for Windows.
            /// </summary>
            public static class Textures
            {
                public static Sprite window                     = LoadResource<Sprite>("Common/Textures/UI/Windows/Window");
                public static Sprite windowDeselected           = LoadResource<Sprite>("Common/Textures/UI/Windows/WindowDeselected");
                public static Sprite subWindow                  = LoadResource<Sprite>("Common/Textures/UI/Windows/SubWindow");
                public static Sprite subWindowDeselected        = LoadResource<Sprite>("Common/Textures/UI/Windows/SubWindowDeselected");
                public static Sprite drawer                     = LoadResource<Sprite>("Common/Textures/UI/Windows/Drawer");
                public static Sprite drawerDeselected           = LoadResource<Sprite>("Common/Textures/UI/Windows/DrawerDeselected");
                public static Sprite singleFrame                = LoadResource<Sprite>("Common/Textures/UI/Windows/SingleFrame");
                public static Sprite singleFrameDeselected      = LoadResource<Sprite>("Common/Textures/UI/Windows/SingleFrameDeselected");
                public static Sprite minimizeButton             = LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButton");
                public static Sprite minimizeButtonDeselected   = LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonDeselected");
                public static Sprite minimizeButtonDisabled     = LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonDisabled");
                public static Sprite minimizeButtonHighlighted  = LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonHighlighted");
                public static Sprite minimizeButtonPressed      = LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonPressed");
                public static Sprite maximizeButton             = LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButton");
                public static Sprite maximizeButtonDeselected   = LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonDeselected");
                public static Sprite maximizeButtonDisabled     = LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonDisabled");
                public static Sprite maximizeButtonHighlighted  = LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonHighlighted");
                public static Sprite maximizeButtonPressed      = LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonPressed");
                public static Sprite normalizeButton            = LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButton");
                public static Sprite normalizeButtonDeselected  = LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonDeselected");
                public static Sprite normalizeButtonDisabled    = LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonDisabled");
                public static Sprite normalizeButtonHighlighted = LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonHighlighted");
                public static Sprite normalizeButtonPressed     = LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonPressed");
                public static Sprite closeButton                = LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButton");
                public static Sprite closeButtonDeselected      = LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonDeselected");
                public static Sprite closeButtonDisabled        = LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonDisabled");
                public static Sprite closeButtonHighlighted     = LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonHighlighted");
                public static Sprite closeButtonPressed         = LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonPressed");
                public static Sprite toolCloseButton            = LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButton");
                public static Sprite toolCloseButtonDeselected  = LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonDeselected");
                public static Sprite toolCloseButtonDisabled    = LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonDisabled");
                public static Sprite toolCloseButtonHighlighted = LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonHighlighted");
                public static Sprite toolCloseButtonPressed     = LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonPressed");
                public static Sprite replacement                = LoadResource<Sprite>("Common/Textures/UI/Windows/Replacement");
            }
        }
        #endregion

        #region Assets for MainWindow
        /// <summary>
        /// Assets for MainWindow.
        /// </summary>
        public static class MainWindow
        {
            /// <summary>
            /// Color assets for MainWindow.
            /// </summary>
            public static class Colors
            {
                public static Color background = LoadColor("Colors/UI/Windows/MainWindow/Background");
            }

            #region Assets for MainMenu
            /// <summary>
            /// Assets for MainMenu.
            /// </summary>
            public static class MainMenu
            {
                /// <summary>
                /// Text style assets for MainMenu.
                /// </summary>
                public static class TextStyles
                {
                    public static TextStyle button = LoadTextStyle("TextStyles/UI/Windows/MainWindow/MainMenu/Button");
                }

                /// <summary>
                /// Texture assets for MainMenu.
                /// </summary>
                public static class Textures
                {
                    public static Sprite background        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Background");
                    public static Sprite button            = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Button");
                    public static Sprite buttonDisabled    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonDisabled");
                    public static Sprite buttonHighlighted = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonHighlighted");
                    public static Sprite buttonPressed     = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonPressed");
                }
            }
            #endregion

            #region Assets for Toolbar
            /// <summary>
            /// Assets for Toolbar.
            /// </summary>
            public static class Toolbar
            {
                /// <summary>
                /// Text style assets for Toolbar.
                /// </summary>
                public static class TextStyles
				{
					// TODO: [Trivial] Fill with resources
                }

                /// <summary>
                /// Texture assets for Toolbar.
                /// </summary>
                public static class Textures
                {   
					// TODO: [Trivial] Fill with resources
                }
            }
            #endregion

            #region Assets for DockWidgets
            /// <summary>
            /// Assets for DockWidgets.
            /// </summary>
            public static class DockWidgets
            {
                #region Assets for servers dock widget
                /// <summary>
				/// Assets for servers dock widget.
                /// </summary>
				public static class Servers
                {
                    /// <summary>
					/// Color assets for servers dock widget.
                    /// </summary>
                    public static class Colors
                    {
						public static Color background = LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Servers/Background");
                    }

                    /// <summary>
					/// Texture assets for servers dock widget.
                    /// </summary>
                    public static class Textures
                    {
						public static Sprite icon = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Servers/Icon");
                    }
                }
                #endregion
            }
            #endregion
        }
        #endregion

        #region Assets for AboutDialog
        /// <summary>
        /// Assets for AboutDialog.
        /// </summary>
        public static class AboutDialog
        {
            /// <summary>
            /// Color assets for AboutDialog.
            /// </summary>
            public static class Colors
            {
                public static Color background = LoadColor("Colors/UI/Windows/AboutDialog/Background");
            }

            /// <summary>
            /// Text style assets for AboutDialog.
            /// </summary>
            public static class TextStyles
            {
                public static TextStyle version    = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Version");
                public static TextStyle credits    = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Credits");
                public static TextStyle monoLogo   = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/MonoLogo");
                public static TextStyle monoLogo2  = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/MonoLogo2");
                public static TextStyle physXLogo  = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/PhysXLogo");
                public static TextStyle physXLogo2 = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/PhysXLogo2");
                public static TextStyle copyright  = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Copyright");
                public static TextStyle license    = LoadTextStyle("TextStyles/UI/Windows/AboutDialog/License");
            }

            /// <summary>
            /// Texture assets for AboutDialog.
            /// </summary>
            public static class Textures
            {
                public static Sprite unity = LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/Unity");
                public static Sprite mono  = LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/Mono");
                public static Sprite physX = LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/PhysX");
            }
        }
        #endregion
    }
    #endregion

    #region Assets for Popups
    /// <summary>
    /// Assets for Popups.
    /// </summary>
    public static class Popups
    {
        /// <summary>
        /// Text style assets for Popups.
        /// </summary>
        public static class TextStyles
        {
            public static TextStyle button         = LoadTextStyle("Common/TextStyles/UI/Popups/Button");
            public static TextStyle buttonDisabled = LoadTextStyle("Common/TextStyles/UI/Popups/ButtonDisabled");
        }

        /// <summary>
        /// Texture assets for Popups.
        /// </summary>
        public static class Textures
        {
            public static Sprite popupBackground   = LoadResource<Sprite>("Common/Textures/UI/Popups/PopupBackground");
            public static Sprite background        = LoadResource<Sprite>("Common/Textures/UI/Popups/Background");
            public static Sprite separator         = LoadResource<Sprite>("Common/Textures/UI/Popups/Separator");
            public static Sprite button            = LoadResource<Sprite>("Common/Textures/UI/Popups/Button");
            public static Sprite buttonDisabled    = LoadResource<Sprite>("Common/Textures/UI/Popups/ButtonDisabled");
            public static Sprite buttonHighlighted = LoadResource<Sprite>("Common/Textures/UI/Popups/ButtonHighlighted");
            public static Sprite buttonPressed     = LoadResource<Sprite>("Common/Textures/UI/Popups/ButtonPressed");
            public static Sprite arrow             = LoadResource<Sprite>("Common/Textures/UI/Popups/Arrow");
            public static Sprite checkbox          = LoadResource<Sprite>("Common/Textures/UI/Popups/Checkbox");
        }
    }
    #endregion

    #region Assets for Tooltips
    /// <summary>
    /// Assets for Tooltips.
    /// </summary>
    public static class Tooltips
    {
        /// <summary>
        /// Text style assets for Tooltips.
        /// </summary>
        public static class TextStyles
        {
            public static TextStyle tooltipText = LoadTextStyle("Common/TextStyles/UI/Tooltips/TooltipText");
        }

        /// <summary>
        /// Texture assets for Tooltips.
        /// </summary>
        public static class Textures
        {
            public static Sprite tooltipBackground = LoadResource<Sprite>("Common/Textures/UI/Tooltips/TooltipBackground");
        }
    }
    #endregion

    #region Assets for Toasts
    /// <summary>
    /// Assets for Toasts.
    /// </summary>
    public static class Toasts
    {
        /// <summary>
        /// Text style assets for Toasts.
        /// </summary>
        public static class TextStyles
        {
            public static TextStyle toastText = LoadTextStyle("Common/TextStyles/UI/Toasts/ToastText");
        }

        /// <summary>
        /// Texture assets for Toasts.
        /// </summary>
        public static class Textures
        {
            public static Sprite toastBackground = LoadResource<Sprite>("Common/Textures/UI/Toasts/ToastBackground");
        }
    }
    #endregion

    #region Assets for DockWidgets
    /// <summary>
    /// Assets for DockWidgets.
    /// </summary>
    public static class DockWidgets
    {
        /// <summary>
        /// Color assets for DockWidgets.
        /// </summary>
        public static class Colors
        {
            public static Color background      = LoadColor("Common/Colors/UI/DockWidgets/Background");
            public static Color dummyBackground = LoadColor("Common/Colors/UI/DockWidgets/DummyBackground");
            public static Color dockingWindow   = LoadColor("Common/Colors/UI/DockWidgets/DockingWindow");
        }

        /// <summary>
        /// Text style assets for DockWidgets.
        /// </summary>
        public static class TextStyles
        {
            public static TextStyle title = LoadTextStyle("Common/TextStyles/UI/DockWidgets/Title");
        }

        /// <summary>
        /// Texture assets for DockWidgets.
        /// </summary>
        public static class Textures
        {
            public static Sprite tab                          = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/Tab");
            public static Sprite tabDisabled                  = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabDisabled");
            public static Sprite tabHighlighted               = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabHighlighted");
            public static Sprite tabPressed                   = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabPressed");
            public static Sprite tabActive                    = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActive");
            public static Sprite tabActiveDisabled            = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActiveDisabled");
            public static Sprite tabActiveHighlighted         = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActiveHighlighted");
            public static Sprite tabActivePressed             = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActivePressed");
            public static Sprite icon                         = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/Icon");
            public static Sprite pageBackground               = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/PageBackground");
            public static Sprite maximizeButton               = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButton");
            public static Sprite maximizeButtonDisabled       = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButtonDisabled");
            public static Sprite maximizeButtonHighlighted    = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButtonHighlighted");
            public static Sprite maximizeButtonPressed        = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButtonPressed");
            public static Sprite closeButton                  = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButton");
            public static Sprite closeButtonDisabled          = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButtonDisabled");
            public static Sprite closeButtonHighlighted       = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButtonHighlighted");
            public static Sprite closeButtonPressed           = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButtonPressed");
            public static Sprite unlockedButton               = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButton");
            public static Sprite unlockedButtonDisabled       = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButtonDisabled");
            public static Sprite unlockedButtonHighlighted    = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButtonHighlighted");
            public static Sprite unlockedButtonPressed        = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButtonPressed");
            public static Sprite lockedButton                 = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButton");
            public static Sprite lockedButtonDisabled         = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButtonDisabled");
            public static Sprite lockedButtonHighlighted      = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButtonHighlighted");
            public static Sprite lockedButtonPressed          = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButtonPressed");
            public static Sprite contextMenuButton            = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButton");
            public static Sprite contextMenuButtonDisabled    = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButtonDisabled");
            public static Sprite contextMenuButtonHighlighted = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButtonHighlighted");
            public static Sprite contextMenuButtonPressed     = LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButtonPressed");
        }
    }
    #endregion
    #endregion

	// TODO: [Major] AssetsUtils
    /// <summary>
    /// Loads an asset stored at path in a resources.
    /// </summary>
    /// <returns>The asset at path if it can be found otherwise returns null.</returns>
    /// <param name="path">Pathname of the target asset.</param>
    /// <typeparam name="T">Type of resource.</typeparam>
    private static T LoadResource<T>(string path) where T : UnityEngine.Object
    {
        T res = Resources.Load<T>(path);

        if (res == null)
        {
            Debug.LogError("Resource \"" + path + "\" is not found");
        }

        return res;
    }

	/// <summary>
	/// Loads texture 2D stored at path in a resources and scales it.
	/// </summary>
	/// <returns>The asset at path if it can be found otherwise returns null.</returns>
	/// <param name="path">Pathname of the target asset.</param>
	private static Texture2D LoadScaledTexture2D(string path)
	{
		Texture2D res = LoadResource<Texture2D>(path);

		if (res != null && Utils.canvasScale != 1f)
		{
			TextureScale.Point(res, (int)(res.width * Utils.canvasScale), (int)(res.height * Utils.canvasScale));
		}

		return res;
	}

    /// <summary>
    /// Loads color asset stored at path in a resources.
    /// </summary>
    /// <returns>The color.</returns>
    /// <param name="path">Pathname of the target asset.</param>
    private static Color LoadColor(string path)
    {
        Color res = new Color(0f, 0f, 0f);

        TextAsset asset = LoadResource<TextAsset>(path);

        if (asset != null)
        {
            IniFile iniFile = new IniFile(asset);
            LoadColorFromIniFile(iniFile, ref res);
        }

        return res;
    }

    /// <summary>
    /// Loads text style asset stored at path in a resources.
    /// </summary>
    /// <returns>The text style.</returns>
    /// <param name="path">Pathname of the target asset.</param>
    private static TextStyle LoadTextStyle(string path)
    {
        TextAsset asset = LoadResource<TextAsset>(path);

        if (asset == null)
        {
            return null;
        }

        TextStyle res = new TextStyle();
        Color color   = new Color(0f, 0f, 0f);



        IniFile iniFile = new IniFile(asset);
        iniFile.BeginGroup("Font");

        string font        = iniFile.Get("Font",        "Microsoft Sans Serif");
        string fontStyle   = iniFile.Get("FontStyle",   "Normal");
        int    fontSize    = iniFile.Get("FontSize",    12);
        float  lineSpacing = iniFile.Get("LineSpacing", 1);
        string alignment   = iniFile.Get("Alignment",   "UpperLeft");
        LoadColorFromIniFile(iniFile, ref color);

        iniFile.EndGroup();



        res.font = Common.Fonts.GetFont(font, fontSize);

        try
        {
            res.fontStyle = (FontStyle) Enum.Parse(typeof(FontStyle), fontStyle);
        }
        catch (Exception)
        {
            Debug.LogError("Invalid font style value \"" + fontStyle + "\" for text style: " + path);
        }

        res.fontSize    = fontSize;
        res.lineSpacing = lineSpacing;

        try
        {
            res.alignment = (TextAnchor) Enum.Parse(typeof(TextAnchor), alignment);
        }
        catch (Exception)
        {
            Debug.LogError("Invalid alignment value \"" + alignment + "\" for text style: " + path);
        }

        res.color = color;



        return res;
    }

    /// <summary>
    /// Loads the color from ini file.
    /// </summary>
    /// <param name="iniFile">Ini file.</param>
    /// <param name="color">Result color.</param>
    private static void LoadColorFromIniFile(IniFile iniFile, ref Color color)
    {
        iniFile.BeginGroup("Color");

        color.r = iniFile.Get("Red",   0f);
        color.g = iniFile.Get("Green", 0f);
        color.b = iniFile.Get("Blue",  0f);
        color.a = iniFile.Get("Alpha", 1f);

        iniFile.EndGroup();
    }
}
