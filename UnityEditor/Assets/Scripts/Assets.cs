using System;
using System.Collections.Generic;
using UnityEngine;

using Common;
using Common.App;
using Common.App.ResourceTypes.Loaders;



/// <summary>
/// Class for loading assets of UnityEditor project.
/// </summary>
public static class Assets
{
    #region Common assets
    /// <summary>
    /// Common assets.
    /// </summary>
    public static class Common
    {
		#region Assets for Fonts
		/// <summary>
		/// Assets for Fonts.
		/// </summary>
		public static class Fonts
		{
			/// <summary>
			/// Gets the default font.
			/// </summary>
			/// <value>The default font.</value>
			public static Font defaultFont
			{
				get
				{
					return AssetUtils.Fonts.defaultFont;
				}
			}
			
			
			
			/// <summary>
			/// Resets values.
			/// </summary>
			public static void ResetValues()
			{
				AssetUtils.Fonts.ResetValues();
			}
			
			/// <summary>
			/// Gets the font with specified name.
			/// </summary>
			/// <returns>Font.</returns>
			/// <param name="fontName">Font name.</param>
			/// <param name="fontSize">Font size.</param>
			public static Font GetFont(string fontName, int fontSize = 12)
			{
				return AssetUtils.Fonts.GetFont(fontName, fontSize);
			}
		}
		#endregion

		#region Assets for Cursors
		/// <summary>
		/// Assets for Cursors.
		/// </summary>
		public static class Cursors
		{
			public static ScaledTexture2DLoader eastWest;
			public static ScaledTexture2DLoader northEastSouthWest;
			public static ScaledTexture2DLoader northSouth;
			public static ScaledTexture2DLoader northWestSouthEast;



			/// <summary>
			/// Initializes the <see cref="Assets+Common+Cursors"/> class.
			/// </summary>
			static Cursors()
			{
				ResetValues();
			}
			
			/// <summary>
			/// Resets values.
			/// </summary>
			public static void ResetValues()
			{
				eastWest           = new ScaledTexture2DLoader("Common/Cursors/EastWest");
				northEastSouthWest = new ScaledTexture2DLoader("Common/Cursors/NorthEastSouthWest");
				northSouth         = new ScaledTexture2DLoader("Common/Cursors/NorthSouth");
				northWestSouthEast = new ScaledTexture2DLoader("Common/Cursors/NorthWestSouthEast");
			}
		}
		#endregion

		#region Assets for Windows
		/// <summary>
		/// Assets for Windows.
		/// </summary>
		public static class Windows
		{
			/// <summary>
			/// Color assets for Windows.
			/// </summary>
			public static class Colors
			{
				public static Color background;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+Windows+Colors"/> class.
				/// </summary>
				static Colors()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					background = AssetUtils.LoadColor("Common/Colors/UI/Windows/Background");
				}
			}
			
			/// <summary>
			/// Text style assets for Windows.
			/// </summary>
			public static class TextStyles
			{
				public static TextStyleLoader title;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+Windows+TextStyles"/> class.
				/// </summary>
				static TextStyles()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					title = new TextStyleLoader("Common/TextStyles/UI/Windows/Title");
				}
			}
			
			/// <summary>
			/// Texture assets for Windows.
			/// </summary>
			public static class Textures
			{
				public static SpriteLoader window;
				public static SpriteLoader windowDeselected;
				public static SpriteLoader subWindow;
				public static SpriteLoader subWindowDeselected;
				public static SpriteLoader drawer;
				public static SpriteLoader drawerDeselected;
				public static SpriteLoader singleFrame;
				public static SpriteLoader singleFrameDeselected;
				public static SpriteLoader minimizeButton;
				public static SpriteLoader minimizeButtonDeselected;
				public static SpriteLoader minimizeButtonDisabled;
				public static SpriteLoader minimizeButtonHighlighted;
				public static SpriteLoader minimizeButtonPressed;
				public static SpriteLoader maximizeButton;
				public static SpriteLoader maximizeButtonDeselected;
				public static SpriteLoader maximizeButtonDisabled;
				public static SpriteLoader maximizeButtonHighlighted;
				public static SpriteLoader maximizeButtonPressed;
				public static SpriteLoader normalizeButton;
				public static SpriteLoader normalizeButtonDeselected;
				public static SpriteLoader normalizeButtonDisabled;
				public static SpriteLoader normalizeButtonHighlighted;
				public static SpriteLoader normalizeButtonPressed;
				public static SpriteLoader closeButton;
				public static SpriteLoader closeButtonDeselected;
				public static SpriteLoader closeButtonDisabled;
				public static SpriteLoader closeButtonHighlighted;
				public static SpriteLoader closeButtonPressed;
				public static SpriteLoader toolCloseButton;
				public static SpriteLoader toolCloseButtonDeselected;
				public static SpriteLoader toolCloseButtonDisabled;
				public static SpriteLoader toolCloseButtonHighlighted;
				public static SpriteLoader toolCloseButtonPressed;
				public static SpriteLoader replacement;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+Windows+Textures"/> class.
				/// </summary>
				static Textures()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					window                     = new SpriteLoader("Common/Textures/UI/Windows/Window");
					windowDeselected           = new SpriteLoader("Common/Textures/UI/Windows/WindowDeselected");
					subWindow                  = new SpriteLoader("Common/Textures/UI/Windows/SubWindow");
					subWindowDeselected        = new SpriteLoader("Common/Textures/UI/Windows/SubWindowDeselected");
					drawer                     = new SpriteLoader("Common/Textures/UI/Windows/Drawer");
					drawerDeselected           = new SpriteLoader("Common/Textures/UI/Windows/DrawerDeselected");
					singleFrame                = new SpriteLoader("Common/Textures/UI/Windows/SingleFrame");
					singleFrameDeselected      = new SpriteLoader("Common/Textures/UI/Windows/SingleFrameDeselected");
					minimizeButton             = new SpriteLoader("Common/Textures/UI/Windows/MinimizeButton");
					minimizeButtonDeselected   = new SpriteLoader("Common/Textures/UI/Windows/MinimizeButtonDeselected");
					minimizeButtonDisabled     = new SpriteLoader("Common/Textures/UI/Windows/MinimizeButtonDisabled");
					minimizeButtonHighlighted  = new SpriteLoader("Common/Textures/UI/Windows/MinimizeButtonHighlighted");
					minimizeButtonPressed      = new SpriteLoader("Common/Textures/UI/Windows/MinimizeButtonPressed");
					maximizeButton             = new SpriteLoader("Common/Textures/UI/Windows/MaximizeButton");
					maximizeButtonDeselected   = new SpriteLoader("Common/Textures/UI/Windows/MaximizeButtonDeselected");
					maximizeButtonDisabled     = new SpriteLoader("Common/Textures/UI/Windows/MaximizeButtonDisabled");
					maximizeButtonHighlighted  = new SpriteLoader("Common/Textures/UI/Windows/MaximizeButtonHighlighted");
					maximizeButtonPressed      = new SpriteLoader("Common/Textures/UI/Windows/MaximizeButtonPressed");
					normalizeButton            = new SpriteLoader("Common/Textures/UI/Windows/NormalizeButton");
					normalizeButtonDeselected  = new SpriteLoader("Common/Textures/UI/Windows/NormalizeButtonDeselected");
					normalizeButtonDisabled    = new SpriteLoader("Common/Textures/UI/Windows/NormalizeButtonDisabled");
					normalizeButtonHighlighted = new SpriteLoader("Common/Textures/UI/Windows/NormalizeButtonHighlighted");
					normalizeButtonPressed     = new SpriteLoader("Common/Textures/UI/Windows/NormalizeButtonPressed");
					closeButton                = new SpriteLoader("Common/Textures/UI/Windows/CloseButton");
					closeButtonDeselected      = new SpriteLoader("Common/Textures/UI/Windows/CloseButtonDeselected");
					closeButtonDisabled        = new SpriteLoader("Common/Textures/UI/Windows/CloseButtonDisabled");
					closeButtonHighlighted     = new SpriteLoader("Common/Textures/UI/Windows/CloseButtonHighlighted");
					closeButtonPressed         = new SpriteLoader("Common/Textures/UI/Windows/CloseButtonPressed");
					toolCloseButton            = new SpriteLoader("Common/Textures/UI/Windows/ToolCloseButton");
					toolCloseButtonDeselected  = new SpriteLoader("Common/Textures/UI/Windows/ToolCloseButtonDeselected");
					toolCloseButtonDisabled    = new SpriteLoader("Common/Textures/UI/Windows/ToolCloseButtonDisabled");
					toolCloseButtonHighlighted = new SpriteLoader("Common/Textures/UI/Windows/ToolCloseButtonHighlighted");
					toolCloseButtonPressed     = new SpriteLoader("Common/Textures/UI/Windows/ToolCloseButtonPressed");
					replacement                = new SpriteLoader("Common/Textures/UI/Windows/Replacement");
				}
			}

			/// <summary>
			/// State sprites assets for Windows.
			/// </summary>
			public static class SpriteStates
			{
				public static SpriteStateLoader minimizeButton;
				public static SpriteStateLoader maximizeButton;
				public static SpriteStateLoader normalizeButton;
				public static SpriteStateLoader closeButton;
				public static SpriteStateLoader toolCloseButton;
				
				
				
				/// <summary>
				/// Initializes the <see cref="Assets+Common+Windows+SpriteStates"/> class.
				/// </summary>
				static SpriteStates()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					minimizeButton  = new SpriteStateLoader(Textures.minimizeButtonDisabled,  Textures.minimizeButtonHighlighted,  Textures.minimizeButtonPressed);
					maximizeButton  = new SpriteStateLoader(Textures.maximizeButtonDisabled,  Textures.maximizeButtonHighlighted,  Textures.maximizeButtonPressed);
					normalizeButton = new SpriteStateLoader(Textures.normalizeButtonDisabled, Textures.normalizeButtonHighlighted, Textures.normalizeButtonPressed);
					closeButton     = new SpriteStateLoader(Textures.closeButtonDisabled,     Textures.closeButtonHighlighted,     Textures.closeButtonPressed);
					toolCloseButton = new SpriteStateLoader(Textures.toolCloseButtonDisabled, Textures.toolCloseButtonHighlighted, Textures.toolCloseButtonPressed);
				}
			}



			/// <summary>
			/// Resets values.
			/// </summary>
			public static void ResetValues()
			{
				Colors.ResetValues();
				TextStyles.ResetValues();
				Textures.ResetValues();
				SpriteStates.ResetValues();
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
				public static Color background;
				public static Color dummyBackground;
				public static Color dockingWindow;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+DockWidgets+Colors"/> class.
				/// </summary>
				static Colors()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					background      = AssetUtils.LoadColor("Common/Colors/UI/DockWidgets/Background");
					dummyBackground = AssetUtils.LoadColor("Common/Colors/UI/DockWidgets/DummyBackground");
					dockingWindow   = AssetUtils.LoadColor("Common/Colors/UI/DockWidgets/DockingWindow");
				}
			}
			
			/// <summary>
			/// Text style assets for DockWidgets.
			/// </summary>
			public static class TextStyles
			{
				public static TextStyleLoader title;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+DockWidgets+TextStyles"/> class.
				/// </summary>
				static TextStyles()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					title = new TextStyleLoader("Common/TextStyles/UI/DockWidgets/Title");
				}
			}
			
			/// <summary>
			/// Texture assets for DockWidgets.
			/// </summary>
			public static class Textures
			{
				public static SpriteLoader tab;
				public static SpriteLoader tabDisabled;
				public static SpriteLoader tabHighlighted;
				public static SpriteLoader tabPressed;
				public static SpriteLoader tabActive;
				public static SpriteLoader tabActiveDisabled;
				public static SpriteLoader tabActiveHighlighted;
				public static SpriteLoader tabActivePressed;
				public static SpriteLoader icon;
				public static SpriteLoader pageBackground;
				public static SpriteLoader maximizeButton;
				public static SpriteLoader maximizeButtonDisabled;
				public static SpriteLoader maximizeButtonHighlighted;
				public static SpriteLoader maximizeButtonPressed;
				public static SpriteLoader closeButton;
				public static SpriteLoader closeButtonDisabled;
				public static SpriteLoader closeButtonHighlighted;
				public static SpriteLoader closeButtonPressed;
				public static SpriteLoader unlockedButton;
				public static SpriteLoader unlockedButtonDisabled;
				public static SpriteLoader unlockedButtonHighlighted;
				public static SpriteLoader unlockedButtonPressed;
				public static SpriteLoader lockedButton;
				public static SpriteLoader lockedButtonDisabled;
				public static SpriteLoader lockedButtonHighlighted;
				public static SpriteLoader lockedButtonPressed;
				public static SpriteLoader contextMenuButton;
				public static SpriteLoader contextMenuButtonDisabled;
				public static SpriteLoader contextMenuButtonHighlighted;
				public static SpriteLoader contextMenuButtonPressed;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+DockWidgets+Textures"/> class.
				/// </summary>
				static Textures()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					tab                          = new SpriteLoader("Common/Textures/UI/DockWidgets/Tab");
					tabDisabled                  = new SpriteLoader("Common/Textures/UI/DockWidgets/TabDisabled");
					tabHighlighted               = new SpriteLoader("Common/Textures/UI/DockWidgets/TabHighlighted");
					tabPressed                   = new SpriteLoader("Common/Textures/UI/DockWidgets/TabPressed");
					tabActive                    = new SpriteLoader("Common/Textures/UI/DockWidgets/TabActive");
					tabActiveDisabled            = new SpriteLoader("Common/Textures/UI/DockWidgets/TabActiveDisabled");
					tabActiveHighlighted         = new SpriteLoader("Common/Textures/UI/DockWidgets/TabActiveHighlighted");
					tabActivePressed             = new SpriteLoader("Common/Textures/UI/DockWidgets/TabActivePressed");
					icon                         = new SpriteLoader("Common/Textures/UI/DockWidgets/Icon");
					pageBackground               = new SpriteLoader("Common/Textures/UI/DockWidgets/PageBackground");
					maximizeButton               = new SpriteLoader("Common/Textures/UI/DockWidgets/MaximizeButton");
					maximizeButtonDisabled       = new SpriteLoader("Common/Textures/UI/DockWidgets/MaximizeButtonDisabled");
					maximizeButtonHighlighted    = new SpriteLoader("Common/Textures/UI/DockWidgets/MaximizeButtonHighlighted");
					maximizeButtonPressed        = new SpriteLoader("Common/Textures/UI/DockWidgets/MaximizeButtonPressed");
					closeButton                  = new SpriteLoader("Common/Textures/UI/DockWidgets/CloseButton");
					closeButtonDisabled          = new SpriteLoader("Common/Textures/UI/DockWidgets/CloseButtonDisabled");
					closeButtonHighlighted       = new SpriteLoader("Common/Textures/UI/DockWidgets/CloseButtonHighlighted");
					closeButtonPressed           = new SpriteLoader("Common/Textures/UI/DockWidgets/CloseButtonPressed");
					unlockedButton               = new SpriteLoader("Common/Textures/UI/DockWidgets/UnlockedButton");
					unlockedButtonDisabled       = new SpriteLoader("Common/Textures/UI/DockWidgets/UnlockedButtonDisabled");
					unlockedButtonHighlighted    = new SpriteLoader("Common/Textures/UI/DockWidgets/UnlockedButtonHighlighted");
					unlockedButtonPressed        = new SpriteLoader("Common/Textures/UI/DockWidgets/UnlockedButtonPressed");
					lockedButton                 = new SpriteLoader("Common/Textures/UI/DockWidgets/LockedButton");
					lockedButtonDisabled         = new SpriteLoader("Common/Textures/UI/DockWidgets/LockedButtonDisabled");
					lockedButtonHighlighted      = new SpriteLoader("Common/Textures/UI/DockWidgets/LockedButtonHighlighted");
					lockedButtonPressed          = new SpriteLoader("Common/Textures/UI/DockWidgets/LockedButtonPressed");
					contextMenuButton            = new SpriteLoader("Common/Textures/UI/DockWidgets/ContextMenuButton");
					contextMenuButtonDisabled    = new SpriteLoader("Common/Textures/UI/DockWidgets/ContextMenuButtonDisabled");
					contextMenuButtonHighlighted = new SpriteLoader("Common/Textures/UI/DockWidgets/ContextMenuButtonHighlighted");
					contextMenuButtonPressed     = new SpriteLoader("Common/Textures/UI/DockWidgets/ContextMenuButtonPressed");
				}
			}

			/// <summary>
			/// State sprites assets for DockWidgets.
			/// </summary>
			public static class SpriteStates
			{
				public static SpriteStateLoader button;
				public static SpriteStateLoader activeButton;
				public static SpriteStateLoader maximizeButton;
				public static SpriteStateLoader closeButton;
				public static SpriteStateLoader unlockedButton;
				public static SpriteStateLoader lockedButton;
				public static SpriteStateLoader contextMenuButton;
				
				
				
				/// <summary>
				/// Initializes the <see cref="Assets+Common+DockWidgets+SpriteStates"/> class.
				/// </summary>
				static SpriteStates()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					button            = new SpriteStateLoader(Textures.tabDisabled,               Textures.tabHighlighted,               Textures.tabPressed);
					activeButton      = new SpriteStateLoader(Textures.tabActiveDisabled,         Textures.tabActiveHighlighted,         Textures.tabActivePressed);
					maximizeButton    = new SpriteStateLoader(Textures.maximizeButtonDisabled,    Textures.maximizeButtonHighlighted,    Textures.maximizeButtonPressed);
					closeButton       = new SpriteStateLoader(Textures.closeButtonDisabled,       Textures.closeButtonHighlighted,       Textures.closeButtonPressed);
					unlockedButton    = new SpriteStateLoader(Textures.unlockedButtonDisabled,    Textures.unlockedButtonHighlighted,    Textures.unlockedButtonPressed);
					lockedButton      = new SpriteStateLoader(Textures.lockedButtonDisabled,      Textures.lockedButtonHighlighted,      Textures.lockedButtonPressed);
					contextMenuButton = new SpriteStateLoader(Textures.contextMenuButtonDisabled, Textures.contextMenuButtonHighlighted, Textures.contextMenuButtonPressed);
				}
			}



			/// <summary>
			/// Resets values.
			/// </summary>
			public static void ResetValues()
			{
				Colors.ResetValues();
				TextStyles.ResetValues();
				Textures.ResetValues();
				SpriteStates.ResetValues();
			}
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
				public static TextStyleLoader button;
				public static TextStyleLoader buttonDisabled;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+Popups+TextStyles"/> class.
				/// </summary>
				static TextStyles()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					button         = new TextStyleLoader("Common/TextStyles/UI/Popups/Button");
					buttonDisabled = new TextStyleLoader("Common/TextStyles/UI/Popups/ButtonDisabled");
				}
			}
			
			/// <summary>
			/// Texture assets for Popups.
			/// </summary>
			public static class Textures
			{
				public static SpriteLoader popupBackground;
				public static SpriteLoader background;
				public static SpriteLoader separator;
				public static SpriteLoader button;
				public static SpriteLoader buttonDisabled;
				public static SpriteLoader buttonHighlighted;
				public static SpriteLoader buttonPressed;
				public static SpriteLoader arrow;
				public static SpriteLoader checkbox;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+Popups+Textures"/> class.
				/// </summary>
				static Textures()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					popupBackground   = new SpriteLoader("Common/Textures/UI/Popups/PopupBackground");
					background        = new SpriteLoader("Common/Textures/UI/Popups/Background");
					separator         = new SpriteLoader("Common/Textures/UI/Popups/Separator");
					button            = new SpriteLoader("Common/Textures/UI/Popups/Button");
					buttonDisabled    = new SpriteLoader("Common/Textures/UI/Popups/ButtonDisabled");
					buttonHighlighted = new SpriteLoader("Common/Textures/UI/Popups/ButtonHighlighted");
					buttonPressed     = new SpriteLoader("Common/Textures/UI/Popups/ButtonPressed");
					arrow             = new SpriteLoader("Common/Textures/UI/Popups/Arrow");
					checkbox          = new SpriteLoader("Common/Textures/UI/Popups/Checkbox");
				}
			}

			/// <summary>
			/// State sprites assets for Popus.
			/// </summary>
			public static class SpriteStates
			{
				public static SpriteStateLoader button;
				public static SpriteStateLoader buttonDisabled;
				
				
				
				/// <summary>
				/// Initializes the <see cref="Assets+Common+Popups+SpriteStates"/> class.
				/// </summary>
				static SpriteStates()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					button         = new SpriteStateLoader(Textures.button, Textures.buttonHighlighted, Textures.buttonPressed);
					buttonDisabled = new SpriteStateLoader(Textures.button, Textures.buttonDisabled,    Textures.buttonDisabled);
				}
			}


			/// <summary>
			/// Resets values.
			/// </summary>
			public static void ResetValues()
			{
				TextStyles.ResetValues();
				Textures.ResetValues();
				SpriteStates.ResetValues();
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
				public static TextStyleLoader tooltipText;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+Tooltips+TextStyles"/> class.
				/// </summary>
				static TextStyles()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					tooltipText = new TextStyleLoader("Common/TextStyles/UI/Tooltips/TooltipText");
				}
			}
			
			/// <summary>
			/// Texture assets for Tooltips.
			/// </summary>
			public static class Textures
			{
				public static SpriteLoader tooltipBackground;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+Tooltips+Textures"/> class.
				/// </summary>
				static Textures()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					tooltipBackground = new SpriteLoader("Common/Textures/UI/Tooltips/TooltipBackground");
				}
			}



			/// <summary>
			/// Resets values.
			/// </summary>
			public static void ResetValues()
			{
				TextStyles.ResetValues();
				Textures.ResetValues();
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
				public static TextStyleLoader toastText;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+Toasts+TextStyles"/> class.
				/// </summary>
				static TextStyles()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					toastText = new TextStyleLoader("Common/TextStyles/UI/Toasts/ToastText");
				}
			}
			
			/// <summary>
			/// Texture assets for Toasts.
			/// </summary>
			public static class Textures
			{
				public static SpriteLoader toastBackground;



				/// <summary>
				/// Initializes the <see cref="Assets+Common+Toasts+Textures"/> class.
				/// </summary>
				static Textures()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					toastBackground = new SpriteLoader("Common/Textures/UI/Toasts/ToastBackground");
				}
			}



			/// <summary>
			/// Resets values.
			/// </summary>
			public static void ResetValues()
			{
				TextStyles.ResetValues();
				Textures.ResetValues();
			}
		}
		#endregion



		/// <summary>
		/// Resets values.
		/// </summary>
		public static void ResetValues()
		{
			Fonts.ResetValues();
			Cursors.ResetValues();
			Windows.ResetValues();
			DockWidgets.ResetValues();
			Popups.ResetValues();
			Tooltips.ResetValues();
			Toasts.ResetValues();
		}
    }
    #endregion    

    #region Assets for Windows
    /// <summary>
    /// Assets for Windows.
    /// </summary>
    public static class Windows
    {
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
                public static Color background;



				/// <summary>
				/// Initializes the <see cref="Assets+Windows+MainWindow+Colors"/> class.
				/// </summary>
				static Colors()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/Background");
				}
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
                    public static TextStyleLoader button;



					/// <summary>
					/// Initializes the <see cref="Assets+Windows+MainWindow+MainMenu+TextStyles"/> class.
					/// </summary>
					static TextStyles()
					{
						ResetValues();
					}
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						button = new TextStyleLoader("TextStyles/UI/Windows/MainWindow/MainMenu/Button");
					}
                }

                /// <summary>
                /// Texture assets for MainMenu.
                /// </summary>
                public static class Textures
                {
                    public static SpriteLoader background;
                    public static SpriteLoader button;
                    public static SpriteLoader buttonDisabled;
                    public static SpriteLoader buttonHighlighted;
                    public static SpriteLoader buttonPressed;



					/// <summary>
					/// Initializes the <see cref="Assets+Windows+MainWindow+MainMenu+Textures"/> class.
					/// </summary>
					static Textures()
					{
						ResetValues();
					}
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						background        = new SpriteLoader("Textures/UI/Windows/MainWindow/MainMenu/Background");
						button            = new SpriteLoader("Textures/UI/Windows/MainWindow/MainMenu/Button");
						buttonDisabled    = new SpriteLoader("Textures/UI/Windows/MainWindow/MainMenu/ButtonDisabled");
						buttonHighlighted = new SpriteLoader("Textures/UI/Windows/MainWindow/MainMenu/ButtonHighlighted");
						buttonPressed     = new SpriteLoader("Textures/UI/Windows/MainWindow/MainMenu/ButtonPressed");
					}
                }

				/// <summary>
				/// State sprites assets for MainMenu.
				/// </summary>
				public static class SpriteStates
				{
					public static SpriteStateLoader button;

					
					
					/// <summary>
					/// Initializes the <see cref="Assets+Windows+MainWindow+MainMenu+SpriteStates"/> class.
					/// </summary>
					static SpriteStates()
					{
						ResetValues();
					}
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						button = new SpriteStateLoader(Textures.buttonDisabled, Textures.buttonHighlighted, Textures.buttonPressed);
					}
				}



				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					TextStyles.ResetValues();
					Textures.ResetValues();
					SpriteStates.ResetValues();
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
                    public static TextStyleLoader point;
					public static TextStyleLoader coordinateSystem;
					public static TextStyleLoader layers;
					public static TextStyleLoader layout;



					/// <summary>
					/// Initializes the <see cref="Assets+Windows+MainWindow+Toolbar+TextStyles"/> class.
					/// </summary>
					static TextStyles()
					{
						ResetValues();
					}
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						point            = new TextStyleLoader("TextStyles/UI/Windows/MainWindow/Toolbar/Point");
						coordinateSystem = new TextStyleLoader("TextStyles/UI/Windows/MainWindow/Toolbar/CoordinateSystem");
						layers           = new TextStyleLoader("TextStyles/UI/Windows/MainWindow/Toolbar/Layers");
						layout           = new TextStyleLoader("TextStyles/UI/Windows/MainWindow/Toolbar/Layout");
					}
                }

                /// <summary>
                /// Texture assets for Toolbar.
                /// </summary>
                public static class Textures
                {
                    public static SpriteLoader background;
                    public static SpriteLoader toolLeftButton;
                    public static SpriteLoader toolLeftButtonDisabled;
                    public static SpriteLoader toolLeftButtonHighlighted;
                    public static SpriteLoader toolLeftButtonPressed;
                    public static SpriteLoader toolLeftButtonActive;
                    public static SpriteLoader toolLeftButtonActiveDisabled;
                    public static SpriteLoader toolLeftButtonActiveHighlighted;
                    public static SpriteLoader toolLeftButtonActivePressed;
                    public static SpriteLoader toolMiddleButton;
                    public static SpriteLoader toolMiddleButtonDisabled;
                    public static SpriteLoader toolMiddleButtonHighlighted;
                    public static SpriteLoader toolMiddleButtonPressed;
                    public static SpriteLoader toolMiddleButtonActive;
                    public static SpriteLoader toolMiddleButtonActiveDisabled;
                    public static SpriteLoader toolMiddleButtonActiveHighlighted;
                    public static SpriteLoader toolMiddleButtonActivePressed;
                    public static SpriteLoader toolRightButton;
                    public static SpriteLoader toolRightButtonDisabled;
                    public static SpriteLoader toolRightButtonHighlighted;
                    public static SpriteLoader toolRightButtonPressed;
                    public static SpriteLoader toolRightButtonActive;
                    public static SpriteLoader toolRightButtonActiveDisabled;
                    public static SpriteLoader toolRightButtonActiveHighlighted;
                    public static SpriteLoader toolRightButtonActivePressed;
                    public static SpriteLoader toolHand;
                    public static SpriteLoader toolHandActive;
                    public static SpriteLoader toolMove;
                    public static SpriteLoader toolMoveActive;
                    public static SpriteLoader toolRotate;
                    public static SpriteLoader toolRotateActive;
                    public static SpriteLoader toolScale;
                    public static SpriteLoader toolScaleActive;
                    public static SpriteLoader toolRectTransform;
                    public static SpriteLoader toolRectTransformActive;
                    public static SpriteLoader center;
                    public static SpriteLoader pivot;
                    public static SpriteLoader local;
                    public static SpriteLoader global;
                    public static SpriteLoader play;
                    public static SpriteLoader playActive;
                    public static SpriteLoader pause;
                    public static SpriteLoader pauseActive;
                    public static SpriteLoader step;
                    public static SpriteLoader stepActive;
                    public static SpriteLoader popupButton;
                    public static SpriteLoader popupButtonDisabled;
                    public static SpriteLoader popupButtonHighlighted;
                    public static SpriteLoader popupButtonPressed;



					/// <summary>
					/// Initializes the <see cref="Assets+Windows+MainWindow+Toolbar+Textures"/> class.
					/// </summary>
					static Textures()
					{
						ResetValues();
					}
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						background                        = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/Background");
						toolLeftButton                    = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButton");
						toolLeftButtonDisabled            = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonDisabled");
						toolLeftButtonHighlighted         = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonHighlighted");
						toolLeftButtonPressed             = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonPressed");
						toolLeftButtonActive              = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActive");
						toolLeftButtonActiveDisabled      = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActiveDisabled");
						toolLeftButtonActiveHighlighted   = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActiveHighlighted");
						toolLeftButtonActivePressed       = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActivePressed");
						toolMiddleButton                  = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButton");
						toolMiddleButtonDisabled          = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonDisabled");
						toolMiddleButtonHighlighted       = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonHighlighted");
						toolMiddleButtonPressed           = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonPressed");
						toolMiddleButtonActive            = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActive");
						toolMiddleButtonActiveDisabled    = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActiveDisabled");
						toolMiddleButtonActiveHighlighted = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActiveHighlighted");
						toolMiddleButtonActivePressed     = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActivePressed");
						toolRightButton                   = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButton");
						toolRightButtonDisabled           = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonDisabled");
						toolRightButtonHighlighted        = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonHighlighted");
						toolRightButtonPressed            = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonPressed");
						toolRightButtonActive             = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActive");
						toolRightButtonActiveDisabled     = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActiveDisabled");
						toolRightButtonActiveHighlighted  = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActiveHighlighted");
						toolRightButtonActivePressed      = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActivePressed");
						toolHand                          = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolHand");
						toolHandActive                    = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolHandActive");
						toolMove                          = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolMove");
						toolMoveActive                    = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolMoveActive");
						toolRotate                        = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRotate");
						toolRotateActive                  = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRotateActive");
						toolScale                         = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolScale");
						toolScaleActive                   = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolScaleActive");
						toolRectTransform                 = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRectTransform");
						toolRectTransformActive           = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/ToolRectTransformActive");
						center                            = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/Center");
						pivot                             = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/Pivot");
						local                             = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/Local");
						global                            = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/Global");
						play                              = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/Play");
						playActive                        = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/PlayActive");
						pause                             = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/Pause");
						pauseActive                       = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/PauseActive");
						step                              = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/Step");
						stepActive                        = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/StepActive");
						popupButton                       = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/PopupButton");
						popupButtonDisabled               = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/PopupButtonDisabled");
						popupButtonHighlighted            = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/PopupButtonHighlighted");
						popupButtonPressed                = new SpriteLoader("Textures/UI/Windows/MainWindow/Toolbar/PopupButtonPressed");
					}
                }

				/// <summary>
				/// State sprites assets for Toolbar.
				/// </summary>
				public static class SpriteStates
				{
					public static SpriteStateLoader leftButton;
					public static SpriteStateLoader leftButtonActive;
					public static SpriteStateLoader middleButton;
					public static SpriteStateLoader middleButtonActive;
					public static SpriteStateLoader rightButton;
					public static SpriteStateLoader rightButtonActive;
					public static SpriteStateLoader popup;



					/// <summary>
					/// Initializes the <see cref="Assets+Windows+MainWindow+Toolbar+SpriteStates"/> class.
					/// </summary>
					static SpriteStates()
					{
						ResetValues();
					}
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						leftButton         = new SpriteStateLoader(Textures.toolLeftButtonDisabled,         Textures.toolLeftButtonHighlighted,         Textures.toolLeftButtonPressed);
						leftButtonActive   = new SpriteStateLoader(Textures.toolLeftButtonActiveDisabled,   Textures.toolLeftButtonActiveHighlighted,   Textures.toolLeftButtonActivePressed);
						middleButton       = new SpriteStateLoader(Textures.toolMiddleButtonDisabled,       Textures.toolMiddleButtonHighlighted,       Textures.toolMiddleButtonPressed);
						middleButtonActive = new SpriteStateLoader(Textures.toolMiddleButtonActiveDisabled, Textures.toolMiddleButtonActiveHighlighted, Textures.toolMiddleButtonActivePressed);
						rightButton        = new SpriteStateLoader(Textures.toolRightButtonDisabled,        Textures.toolRightButtonHighlighted,        Textures.toolRightButtonPressed);
						rightButtonActive  = new SpriteStateLoader(Textures.toolRightButtonActiveDisabled,  Textures.toolRightButtonActiveHighlighted,  Textures.toolRightButtonActivePressed);
						popup              = new SpriteStateLoader(Textures.popupButtonDisabled,            Textures.popupButtonHighlighted,            Textures.popupButtonPressed);
					}
				}



				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					TextStyles.ResetValues();
					Textures.ResetValues();
					SpriteStates.ResetValues();
				}
            }
            #endregion

            #region Assets for DockWidgets
            /// <summary>
            /// Assets for DockWidgets.
            /// </summary>
            public static class DockWidgets
            {
                #region Assets for scene dock widget
                /// <summary>
				/// Assets for scene dock widget.
                /// </summary>
				public static class Scene
                {
                    /// <summary>
					/// Color assets for scene dock widget.
                    /// </summary>
                    public static class Colors
                    {
						public static Color background;



						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Scene+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Scene/Background");
						}
                    }

                    /// <summary>
					/// Texture assets for scene dock widget.
                    /// </summary>
                    public static class Textures
                    {
						public static SpriteLoader icon;



						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Scene+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Scene/Icon");
						}
                    }



					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
                }
                #endregion

				#region Assets for game dock widget
				/// <summary>
				/// Assets for game dock widget.
				/// </summary>
				public static class Game
				{
					/// <summary>
					/// Color assets for game dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Game+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Game/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for game dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Game+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Game/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for inspector dock widget
				/// <summary>
				/// Assets for inspector dock widget.
				/// </summary>
				public static class Inspector
				{
					/// <summary>
					/// Color assets for inspector dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Inspector+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Inspector/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for inspector dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Inspector+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Inspector/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for hierarchy dock widget
				/// <summary>
				/// Assets for hierarchy dock widget.
				/// </summary>
				public static class Hierarchy
				{
					/// <summary>
					/// Color assets for hierarchy dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Hierarchy+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Hierarchy/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for hierarchy dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Hierarchy+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Hierarchy/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for project dock widget
				/// <summary>
				/// Assets for project dock widget.
				/// </summary>
				public static class Project
				{
					/// <summary>
					/// Color assets for project dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Project+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Project/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for project dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Project+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Project/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for animation dock widget
				/// <summary>
				/// Assets for animation dock widget.
				/// </summary>
				public static class Animation
				{
					/// <summary>
					/// Color assets for animation dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Animation+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Animation/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for animation dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Animation+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Animation/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for profiler dock widget
				/// <summary>
				/// Assets for profiler dock widget.
				/// </summary>
				public static class Profiler
				{
					/// <summary>
					/// Color assets for profiler dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Profiler+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Profiler/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for profiler dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Profiler+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Profiler/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for audio mixer dock widget
				/// <summary>
				/// Assets for audio mixer dock widget.
				/// </summary>
				public static class AudioMixer
				{
					/// <summary>
					/// Color assets for audio mixer dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+AudioMixer+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/AudioMixer/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for audio mixer dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+AudioMixer+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/AudioMixer/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for asset store dock widget
				/// <summary>
				/// Assets for asset store dock widget.
				/// </summary>
				public static class AssetStore
				{
					/// <summary>
					/// Color assets for asset store dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+AssetStore+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/AssetStore/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for asset store dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+AssetStore+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/AssetStore/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for version control dock widget
				/// <summary>
				/// Assets for version control dock widget.
				/// </summary>
				public static class VersionControl
				{
					/// <summary>
					/// Color assets for version control dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+VersionControl+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/VersionControl/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for version control dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+VersionControl+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/VersionControl/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for animator parameter dock widget
				/// <summary>
				/// Assets for animator parameter dock widget.
				/// </summary>
				public static class AnimatorParameter
				{
					/// <summary>
					/// Color assets for animator parameter dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+AnimatorParameter+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/AnimatorParameter/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for animator parameter dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+AnimatorParameter+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/AnimatorParameter/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for animator dock widget
				/// <summary>
				/// Assets for animator dock widget.
				/// </summary>
				public static class Animator
				{
					/// <summary>
					/// Color assets for animator dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Animator+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Animator/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for animator dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Animator+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Animator/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for sprite packer dock widget
				/// <summary>
				/// Assets for sprite packer dock widget.
				/// </summary>
				public static class SpritePacker
				{
					/// <summary>
					/// Color assets for sprite packer dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+SpritePacker+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/SpritePacker/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for sprite packer dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+SpritePacker+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/SpritePacker/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for lighting dock widget
				/// <summary>
				/// Assets for lighting dock widget.
				/// </summary>
				public static class Lighting
				{
					/// <summary>
					/// Color assets for lighting dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Lighting+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Lighting/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for lighting dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Lighting+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Lighting/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for occlusion culling dock widget
				/// <summary>
				/// Assets for occlusion culling dock widget.
				/// </summary>
				public static class OcclusionCulling
				{
					/// <summary>
					/// Color assets for occlusion culling dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+OcclusionCulling+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/OcclusionCulling/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for occlusion culling dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+OcclusionCulling+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/OcclusionCulling/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for frame debugger dock widget
				/// <summary>
				/// Assets for frame debugger dock widget.
				/// </summary>
				public static class FrameDebugger
				{
					/// <summary>
					/// Color assets for frame debugger dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+FrameDebugger+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/FrameDebugger/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for frame debugger dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+FrameDebugger+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/FrameDebugger/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for navigation dock widget
				/// <summary>
				/// Assets for navigation dock widget.
				/// </summary>
				public static class Navigation
				{
					/// <summary>
					/// Color assets for navigation dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Navigation+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Navigation/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for navigation dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Navigation+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Navigation/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion

				#region Assets for console dock widget
				/// <summary>
				/// Assets for console dock widget.
				/// </summary>
				public static class Console
				{
					/// <summary>
					/// Color assets for console dock widget.
					/// </summary>
					public static class Colors
					{
						public static Color background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Console+Colors"/> class.
						/// </summary>
						static Colors()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Console/Background");
						}
					}
					
					/// <summary>
					/// Texture assets for console dock widget.
					/// </summary>
					public static class Textures
					{
						public static SpriteLoader icon;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Console+Textures"/> class.
						/// </summary>
						static Textures()
						{
							ResetValues();
						}
						
						/// <summary>
						/// Resets values.
						/// </summary>
						public static void ResetValues()
						{
							icon = new SpriteLoader("Textures/UI/Windows/MainWindow/DockWidgets/Console/Icon");
						}
					}
					
					
					
					/// <summary>
					/// Resets values.
					/// </summary>
					public static void ResetValues()
					{
						Colors.ResetValues();
						Textures.ResetValues();
					}
				}
				#endregion



				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					Scene.ResetValues();
					Game.ResetValues();
					Inspector.ResetValues();
					Hierarchy.ResetValues();
					Project.ResetValues();
					Animation.ResetValues();
					Profiler.ResetValues();
					AudioMixer.ResetValues();
					AssetStore.ResetValues();
					VersionControl.ResetValues();
					AnimatorParameter.ResetValues();
					Animator.ResetValues();
					SpritePacker.ResetValues();
					Lighting.ResetValues();
					OcclusionCulling.ResetValues();
					FrameDebugger.ResetValues();
					Navigation.ResetValues();
					Console.ResetValues();
				}
			}
            #endregion



			/// <summary>
			/// Resets values.
			/// </summary>
			public static void ResetValues()
			{
				Colors.ResetValues();
				MainMenu.ResetValues();
				Toolbar.ResetValues();
				DockWidgets.ResetValues();
			}
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
                public static Color background;



				/// <summary>
				/// Initializes the <see cref="Assets+Windows+AboutDialog+Colors"/> class.
				/// </summary>
				static Colors()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					background = AssetUtils.LoadColor("Colors/UI/Windows/AboutDialog/Background");
				}
            }

            /// <summary>
            /// Text style assets for AboutDialog.
            /// </summary>
            public static class TextStyles
            {
                public static TextStyleLoader version;
                public static TextStyleLoader credits;
                public static TextStyleLoader monoLogo;
                public static TextStyleLoader monoLogo2;
                public static TextStyleLoader physXLogo;
                public static TextStyleLoader physXLogo2;
                public static TextStyleLoader copyright;
                public static TextStyleLoader license;



				/// <summary>
				/// Initializes the <see cref="Assets+Windows+AboutDialog+TextStyles"/> class.
				/// </summary>
				static TextStyles()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					version    = new TextStyleLoader("TextStyles/UI/Windows/AboutDialog/Version");
					credits    = new TextStyleLoader("TextStyles/UI/Windows/AboutDialog/Credits");
					monoLogo   = new TextStyleLoader("TextStyles/UI/Windows/AboutDialog/MonoLogo");
					monoLogo2  = new TextStyleLoader("TextStyles/UI/Windows/AboutDialog/MonoLogo2");
					physXLogo  = new TextStyleLoader("TextStyles/UI/Windows/AboutDialog/PhysXLogo");
					physXLogo2 = new TextStyleLoader("TextStyles/UI/Windows/AboutDialog/PhysXLogo2");
					copyright  = new TextStyleLoader("TextStyles/UI/Windows/AboutDialog/Copyright");
					license    = new TextStyleLoader("TextStyles/UI/Windows/AboutDialog/License");
				}
            }

            /// <summary>
            /// Texture assets for AboutDialog.
            /// </summary>
            public static class Textures
            {
                public static SpriteLoader unity;
                public static SpriteLoader mono;
                public static SpriteLoader physX;



				/// <summary>
				/// Initializes the <see cref="Assets+Windows+AboutDialog+Textures"/> class.
				/// </summary>
				static Textures()
				{
					ResetValues();
				}
				
				/// <summary>
				/// Resets values.
				/// </summary>
				public static void ResetValues()
				{
					unity = new SpriteLoader("Textures/UI/Windows/AboutDialog/Unity");
					mono  = new SpriteLoader("Textures/UI/Windows/AboutDialog/Mono");
					physX = new SpriteLoader("Textures/UI/Windows/AboutDialog/PhysX");
				}
            }



			/// <summary>
			/// Resets values.
			/// </summary>
			public static void ResetValues()
			{
				Colors.ResetValues();
				TextStyles.ResetValues();
				Textures.ResetValues();
			}
        }
        #endregion

		/// <summary>
		/// Resets values.
		/// </summary>
		public static void ResetValues()
		{
			MainWindow.ResetValues();
			AboutDialog.ResetValues();
		}
    }
    #endregion

	/// <summary>
	/// Resets values.
	/// </summary>
	public static void ResetValues()
	{
		Common.ResetValues();
		Windows.ResetValues();
	}
}
