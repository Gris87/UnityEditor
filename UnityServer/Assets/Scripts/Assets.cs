using System;
using System.Collections.Generic;
using UnityEngine;

using Common;
using Common.App;
using Common.UI.ResourceTypes;



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
			public static Texture2D eastWest;
			public static Texture2D northEastSouthWest;
			public static Texture2D northSouth;
			public static Texture2D northWestSouthEast;



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
				eastWest           = AssetUtils.LoadScaledTexture2D("Common/Cursors/EastWest");
				northEastSouthWest = AssetUtils.LoadScaledTexture2D("Common/Cursors/NorthEastSouthWest");
				northSouth         = AssetUtils.LoadScaledTexture2D("Common/Cursors/NorthSouth");
				northWestSouthEast = AssetUtils.LoadScaledTexture2D("Common/Cursors/NorthWestSouthEast");
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
			/// Common color assets for Windows.
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
			/// Common text style assets for Windows.
			/// </summary>
			public static class TextStyles
			{
				public static TextStyle title;



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
					title = AssetUtils.LoadTextStyle("Common/TextStyles/UI/Windows/Title");
				}
			}
			
			/// <summary>
			/// Common texture assets for Windows.
			/// </summary>
			public static class Textures
			{
				public static Sprite window;
				public static Sprite windowDeselected;
				public static Sprite subWindow;
				public static Sprite subWindowDeselected;
				public static Sprite drawer;
				public static Sprite drawerDeselected;
				public static Sprite singleFrame;
				public static Sprite singleFrameDeselected;
				public static Sprite minimizeButton;
				public static Sprite minimizeButtonDeselected;
				public static Sprite minimizeButtonDisabled;
				public static Sprite minimizeButtonHighlighted;
				public static Sprite minimizeButtonPressed;
				public static Sprite maximizeButton;
				public static Sprite maximizeButtonDeselected;
				public static Sprite maximizeButtonDisabled;
				public static Sprite maximizeButtonHighlighted;
				public static Sprite maximizeButtonPressed;
				public static Sprite normalizeButton;
				public static Sprite normalizeButtonDeselected;
				public static Sprite normalizeButtonDisabled;
				public static Sprite normalizeButtonHighlighted;
				public static Sprite normalizeButtonPressed;
				public static Sprite closeButton;
				public static Sprite closeButtonDeselected;
				public static Sprite closeButtonDisabled;
				public static Sprite closeButtonHighlighted;
				public static Sprite closeButtonPressed;
				public static Sprite toolCloseButton;
				public static Sprite toolCloseButtonDeselected;
				public static Sprite toolCloseButtonDisabled;
				public static Sprite toolCloseButtonHighlighted;
				public static Sprite toolCloseButtonPressed;
				public static Sprite replacement;



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
					window                     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/Window");
					windowDeselected           = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/WindowDeselected");
					subWindow                  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/SubWindow");
					subWindowDeselected        = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/SubWindowDeselected");
					drawer                     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/Drawer");
					drawerDeselected           = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/DrawerDeselected");
					singleFrame                = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/SingleFrame");
					singleFrameDeselected      = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/SingleFrameDeselected");
					minimizeButton             = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButton");
					minimizeButtonDeselected   = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonDeselected");
					minimizeButtonDisabled     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonDisabled");
					minimizeButtonHighlighted  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonHighlighted");
					minimizeButtonPressed      = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonPressed");
					maximizeButton             = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButton");
					maximizeButtonDeselected   = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonDeselected");
					maximizeButtonDisabled     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonDisabled");
					maximizeButtonHighlighted  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonHighlighted");
					maximizeButtonPressed      = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonPressed");
					normalizeButton            = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButton");
					normalizeButtonDeselected  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonDeselected");
					normalizeButtonDisabled    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonDisabled");
					normalizeButtonHighlighted = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonHighlighted");
					normalizeButtonPressed     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonPressed");
					closeButton                = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButton");
					closeButtonDeselected      = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonDeselected");
					closeButtonDisabled        = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonDisabled");
					closeButtonHighlighted     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonHighlighted");
					closeButtonPressed         = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonPressed");
					toolCloseButton            = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButton");
					toolCloseButtonDeselected  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonDeselected");
					toolCloseButtonDisabled    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonDisabled");
					toolCloseButtonHighlighted = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonHighlighted");
					toolCloseButtonPressed     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonPressed");
					replacement                = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/Replacement");
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
				public static TextStyle title;



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
					title = AssetUtils.LoadTextStyle("Common/TextStyles/UI/DockWidgets/Title");
				}
			}
			
			/// <summary>
			/// Texture assets for DockWidgets.
			/// </summary>
			public static class Textures
			{
				public static Sprite tab;
				public static Sprite tabDisabled;
				public static Sprite tabHighlighted;
				public static Sprite tabPressed;
				public static Sprite tabActive;
				public static Sprite tabActiveDisabled;
				public static Sprite tabActiveHighlighted;
				public static Sprite tabActivePressed;
				public static Sprite icon;
				public static Sprite pageBackground;
				public static Sprite maximizeButton;
				public static Sprite maximizeButtonDisabled;
				public static Sprite maximizeButtonHighlighted;
				public static Sprite maximizeButtonPressed;
				public static Sprite closeButton;
				public static Sprite closeButtonDisabled;
				public static Sprite closeButtonHighlighted;
				public static Sprite closeButtonPressed;
				public static Sprite unlockedButton;
				public static Sprite unlockedButtonDisabled;
				public static Sprite unlockedButtonHighlighted;
				public static Sprite unlockedButtonPressed;
				public static Sprite lockedButton;
				public static Sprite lockedButtonDisabled;
				public static Sprite lockedButtonHighlighted;
				public static Sprite lockedButtonPressed;
				public static Sprite contextMenuButton;
				public static Sprite contextMenuButtonDisabled;
				public static Sprite contextMenuButtonHighlighted;
				public static Sprite contextMenuButtonPressed;



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
					tab                          = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/Tab");
					tabDisabled                  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabDisabled");
					tabHighlighted               = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabHighlighted");
					tabPressed                   = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabPressed");
					tabActive                    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActive");
					tabActiveDisabled            = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActiveDisabled");
					tabActiveHighlighted         = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActiveHighlighted");
					tabActivePressed             = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActivePressed");
					icon                         = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/Icon");
					pageBackground               = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/PageBackground");
					maximizeButton               = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButton");
					maximizeButtonDisabled       = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButtonDisabled");
					maximizeButtonHighlighted    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButtonHighlighted");
					maximizeButtonPressed        = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButtonPressed");
					closeButton                  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButton");
					closeButtonDisabled          = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButtonDisabled");
					closeButtonHighlighted       = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButtonHighlighted");
					closeButtonPressed           = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButtonPressed");
					unlockedButton               = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButton");
					unlockedButtonDisabled       = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButtonDisabled");
					unlockedButtonHighlighted    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButtonHighlighted");
					unlockedButtonPressed        = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButtonPressed");
					lockedButton                 = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButton");
					lockedButtonDisabled         = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButtonDisabled");
					lockedButtonHighlighted      = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButtonHighlighted");
					lockedButtonPressed          = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButtonPressed");
					contextMenuButton            = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButton");
					contextMenuButtonDisabled    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButtonDisabled");
					contextMenuButtonHighlighted = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButtonHighlighted");
					contextMenuButtonPressed     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButtonPressed");
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
				public static TextStyle button;
				public static TextStyle buttonDisabled;



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
					button         = AssetUtils.LoadTextStyle("Common/TextStyles/UI/Popups/Button");
					buttonDisabled = AssetUtils.LoadTextStyle("Common/TextStyles/UI/Popups/ButtonDisabled");
				}
			}
			
			/// <summary>
			/// Texture assets for Popups.
			/// </summary>
			public static class Textures
			{
				public static Sprite popupBackground;
				public static Sprite background;
				public static Sprite separator;
				public static Sprite button;
				public static Sprite buttonDisabled;
				public static Sprite buttonHighlighted;
				public static Sprite buttonPressed;
				public static Sprite arrow;
				public static Sprite checkbox;



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
					popupBackground   = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/PopupBackground");
					background        = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/Background");
					separator         = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/Separator");
					button            = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/Button");
					buttonDisabled    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/ButtonDisabled");
					buttonHighlighted = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/ButtonHighlighted");
					buttonPressed     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/ButtonPressed");
					arrow             = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/Arrow");
					checkbox          = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/Checkbox");
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
				public static TextStyle tooltipText;



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
					tooltipText = AssetUtils.LoadTextStyle("Common/TextStyles/UI/Tooltips/TooltipText");
				}
			}
			
			/// <summary>
			/// Texture assets for Tooltips.
			/// </summary>
			public static class Textures
			{
				public static Sprite tooltipBackground;



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
					tooltipBackground = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Tooltips/TooltipBackground");
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
				public static TextStyle toastText;



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
					toastText = AssetUtils.LoadTextStyle("Common/TextStyles/UI/Toasts/ToastText");
				}
			}
			
			/// <summary>
			/// Texture assets for Toasts.
			/// </summary>
			public static class Textures
			{
				public static Sprite toastBackground;



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
					toastBackground = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Toasts/ToastBackground");
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
                    public static TextStyle button;



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
						button = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/MainWindow/MainMenu/Button");
					}
                }

                /// <summary>
                /// Texture assets for MainMenu.
                /// </summary>
                public static class Textures
                {
                    public static Sprite background;
                    public static Sprite button;
                    public static Sprite buttonDisabled;
                    public static Sprite buttonHighlighted;
                    public static Sprite buttonPressed;



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
						background        = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Background");
						button            = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Button");
						buttonDisabled    = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonDisabled");
						buttonHighlighted = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonHighlighted");
						buttonPressed     = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonPressed");
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
						public static Color background;



						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Servers+Colors"/> class.
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
							background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Servers/Background");
						}
                    }

                    /// <summary>
					/// Texture assets for servers dock widget.
                    /// </summary>
                    public static class Textures
                    {
						public static Sprite icon;



						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+Servers+Textures"/> class.
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
							icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Servers/Icon");
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
					Servers.ResetValues();
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
                public static TextStyle version;
                public static TextStyle credits;
                public static TextStyle monoLogo;
                public static TextStyle monoLogo2;
                public static TextStyle physXLogo;
                public static TextStyle physXLogo2;
                public static TextStyle copyright;
                public static TextStyle license;



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
					version    = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Version");
					credits    = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Credits");
					monoLogo   = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/MonoLogo");
					monoLogo2  = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/MonoLogo2");
					physXLogo  = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/PhysXLogo");
					physXLogo2 = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/PhysXLogo2");
					copyright  = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Copyright");
					license    = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/License");
				}
            }

            /// <summary>
            /// Texture assets for AboutDialog.
            /// </summary>
            public static class Textures
            {
                public static Sprite unity;
                public static Sprite mono;
                public static Sprite physX;



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
					unity = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/Unity");
					mono  = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/Mono");
					physX = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/PhysX");
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
