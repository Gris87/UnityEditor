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
			public static Texture2D eastWest           = AssetUtils.LoadScaledTexture2D("Common/Cursors/EastWest");
			public static Texture2D northEastSouthWest = AssetUtils.LoadScaledTexture2D("Common/Cursors/NorthEastSouthWest");
			public static Texture2D northSouth         = AssetUtils.LoadScaledTexture2D("Common/Cursors/NorthSouth");
			public static Texture2D northWestSouthEast = AssetUtils.LoadScaledTexture2D("Common/Cursors/NorthWestSouthEast");
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
				public static Color background = AssetUtils.LoadColor("Common/Colors/UI/Windows/Background");
			}
			
			/// <summary>
			/// Common text style assets for Windows.
			/// </summary>
			public static class TextStyles
			{
				public static TextStyle title = AssetUtils.LoadTextStyle("Common/TextStyles/UI/Windows/Title");
			}
			
			/// <summary>
			/// Common texture assets for Windows.
			/// </summary>
			public static class Textures
			{
				public static Sprite window                     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/Window");
				public static Sprite windowDeselected           = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/WindowDeselected");
				public static Sprite subWindow                  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/SubWindow");
				public static Sprite subWindowDeselected        = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/SubWindowDeselected");
				public static Sprite drawer                     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/Drawer");
				public static Sprite drawerDeselected           = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/DrawerDeselected");
				public static Sprite singleFrame                = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/SingleFrame");
				public static Sprite singleFrameDeselected      = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/SingleFrameDeselected");
				public static Sprite minimizeButton             = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButton");
				public static Sprite minimizeButtonDeselected   = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonDeselected");
				public static Sprite minimizeButtonDisabled     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonDisabled");
				public static Sprite minimizeButtonHighlighted  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonHighlighted");
				public static Sprite minimizeButtonPressed      = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MinimizeButtonPressed");
				public static Sprite maximizeButton             = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButton");
				public static Sprite maximizeButtonDeselected   = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonDeselected");
				public static Sprite maximizeButtonDisabled     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonDisabled");
				public static Sprite maximizeButtonHighlighted  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonHighlighted");
				public static Sprite maximizeButtonPressed      = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/MaximizeButtonPressed");
				public static Sprite normalizeButton            = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButton");
				public static Sprite normalizeButtonDeselected  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonDeselected");
				public static Sprite normalizeButtonDisabled    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonDisabled");
				public static Sprite normalizeButtonHighlighted = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonHighlighted");
				public static Sprite normalizeButtonPressed     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/NormalizeButtonPressed");
				public static Sprite closeButton                = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButton");
				public static Sprite closeButtonDeselected      = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonDeselected");
				public static Sprite closeButtonDisabled        = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonDisabled");
				public static Sprite closeButtonHighlighted     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonHighlighted");
				public static Sprite closeButtonPressed         = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/CloseButtonPressed");
				public static Sprite toolCloseButton            = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButton");
				public static Sprite toolCloseButtonDeselected  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonDeselected");
				public static Sprite toolCloseButtonDisabled    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonDisabled");
				public static Sprite toolCloseButtonHighlighted = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonHighlighted");
				public static Sprite toolCloseButtonPressed     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/ToolCloseButtonPressed");
				public static Sprite replacement                = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Windows/Replacement");
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
				public static Color background      = AssetUtils.LoadColor("Common/Colors/UI/DockWidgets/Background");
				public static Color dummyBackground = AssetUtils.LoadColor("Common/Colors/UI/DockWidgets/DummyBackground");
				public static Color dockingWindow   = AssetUtils.LoadColor("Common/Colors/UI/DockWidgets/DockingWindow");
			}
			
			/// <summary>
			/// Text style assets for DockWidgets.
			/// </summary>
			public static class TextStyles
			{
				public static TextStyle title = AssetUtils.LoadTextStyle("Common/TextStyles/UI/DockWidgets/Title");
			}
			
			/// <summary>
			/// Texture assets for DockWidgets.
			/// </summary>
			public static class Textures
			{
				public static Sprite tab                          = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/Tab");
				public static Sprite tabDisabled                  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabDisabled");
				public static Sprite tabHighlighted               = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabHighlighted");
				public static Sprite tabPressed                   = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabPressed");
				public static Sprite tabActive                    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActive");
				public static Sprite tabActiveDisabled            = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActiveDisabled");
				public static Sprite tabActiveHighlighted         = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActiveHighlighted");
				public static Sprite tabActivePressed             = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/TabActivePressed");
				public static Sprite icon                         = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/Icon");
				public static Sprite pageBackground               = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/PageBackground");
				public static Sprite maximizeButton               = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButton");
				public static Sprite maximizeButtonDisabled       = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButtonDisabled");
				public static Sprite maximizeButtonHighlighted    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButtonHighlighted");
				public static Sprite maximizeButtonPressed        = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/MaximizeButtonPressed");
				public static Sprite closeButton                  = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButton");
				public static Sprite closeButtonDisabled          = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButtonDisabled");
				public static Sprite closeButtonHighlighted       = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButtonHighlighted");
				public static Sprite closeButtonPressed           = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/CloseButtonPressed");
				public static Sprite unlockedButton               = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButton");
				public static Sprite unlockedButtonDisabled       = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButtonDisabled");
				public static Sprite unlockedButtonHighlighted    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButtonHighlighted");
				public static Sprite unlockedButtonPressed        = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/UnlockedButtonPressed");
				public static Sprite lockedButton                 = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButton");
				public static Sprite lockedButtonDisabled         = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButtonDisabled");
				public static Sprite lockedButtonHighlighted      = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButtonHighlighted");
				public static Sprite lockedButtonPressed          = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/LockedButtonPressed");
				public static Sprite contextMenuButton            = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButton");
				public static Sprite contextMenuButtonDisabled    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButtonDisabled");
				public static Sprite contextMenuButtonHighlighted = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButtonHighlighted");
				public static Sprite contextMenuButtonPressed     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/DockWidgets/ContextMenuButtonPressed");
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
				public static TextStyle button         = AssetUtils.LoadTextStyle("Common/TextStyles/UI/Popups/Button");
				public static TextStyle buttonDisabled = AssetUtils.LoadTextStyle("Common/TextStyles/UI/Popups/ButtonDisabled");
			}
			
			/// <summary>
			/// Texture assets for Popups.
			/// </summary>
			public static class Textures
			{
				public static Sprite popupBackground   = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/PopupBackground");
				public static Sprite background        = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/Background");
				public static Sprite separator         = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/Separator");
				public static Sprite button            = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/Button");
				public static Sprite buttonDisabled    = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/ButtonDisabled");
				public static Sprite buttonHighlighted = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/ButtonHighlighted");
				public static Sprite buttonPressed     = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/ButtonPressed");
				public static Sprite arrow             = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/Arrow");
				public static Sprite checkbox          = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Popups/Checkbox");
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
				public static TextStyle tooltipText = AssetUtils.LoadTextStyle("Common/TextStyles/UI/Tooltips/TooltipText");
			}
			
			/// <summary>
			/// Texture assets for Tooltips.
			/// </summary>
			public static class Textures
			{
				public static Sprite tooltipBackground = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Tooltips/TooltipBackground");
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
				public static TextStyle toastText = AssetUtils.LoadTextStyle("Common/TextStyles/UI/Toasts/ToastText");
			}
			
			/// <summary>
			/// Texture assets for Toasts.
			/// </summary>
			public static class Textures
			{
				public static Sprite toastBackground = AssetUtils.LoadResource<Sprite>("Common/Textures/UI/Toasts/ToastBackground");
			}
		}
		#endregion
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
                public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/Background");
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
                    public static TextStyle button = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/MainWindow/MainMenu/Button");
                }

                /// <summary>
                /// Texture assets for MainMenu.
                /// </summary>
                public static class Textures
                {
                    public static Sprite background        = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Background");
                    public static Sprite button            = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Button");
                    public static Sprite buttonDisabled    = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonDisabled");
                    public static Sprite buttonHighlighted = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonHighlighted");
                    public static Sprite buttonPressed     = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonPressed");
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
                    public static TextStyle point            = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/MainWindow/Toolbar/Point");
                    public static TextStyle coordinateSystem = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/MainWindow/Toolbar/CoordinateSystem");
                    public static TextStyle layers           = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/MainWindow/Toolbar/Layers");
                    public static TextStyle layout           = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/MainWindow/Toolbar/Layout");
                }

                /// <summary>
                /// Texture assets for Toolbar.
                /// </summary>
                public static class Textures
                {
                    public static Sprite background                        = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Background");
                    public static Sprite toolLeftButton                    = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButton");
                    public static Sprite toolLeftButtonDisabled            = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonDisabled");
                    public static Sprite toolLeftButtonHighlighted         = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonHighlighted");
                    public static Sprite toolLeftButtonPressed             = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonPressed");
                    public static Sprite toolLeftButtonActive              = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActive");
                    public static Sprite toolLeftButtonActiveDisabled      = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActiveDisabled");
                    public static Sprite toolLeftButtonActiveHighlighted   = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActiveHighlighted");
                    public static Sprite toolLeftButtonActivePressed       = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActivePressed");
                    public static Sprite toolMiddleButton                  = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButton");
                    public static Sprite toolMiddleButtonDisabled          = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonDisabled");
                    public static Sprite toolMiddleButtonHighlighted       = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonHighlighted");
                    public static Sprite toolMiddleButtonPressed           = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonPressed");
                    public static Sprite toolMiddleButtonActive            = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActive");
                    public static Sprite toolMiddleButtonActiveDisabled    = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActiveDisabled");
                    public static Sprite toolMiddleButtonActiveHighlighted = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActiveHighlighted");
                    public static Sprite toolMiddleButtonActivePressed     = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActivePressed");
                    public static Sprite toolRightButton                   = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButton");
                    public static Sprite toolRightButtonDisabled           = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonDisabled");
                    public static Sprite toolRightButtonHighlighted        = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonHighlighted");
                    public static Sprite toolRightButtonPressed            = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonPressed");
                    public static Sprite toolRightButtonActive             = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActive");
                    public static Sprite toolRightButtonActiveDisabled     = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActiveDisabled");
                    public static Sprite toolRightButtonActiveHighlighted  = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActiveHighlighted");
                    public static Sprite toolRightButtonActivePressed      = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActivePressed");
                    public static Sprite toolHand                          = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolHand");
                    public static Sprite toolHandActive                    = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolHandActive");
                    public static Sprite toolMove                          = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMove");
                    public static Sprite toolMoveActive                    = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMoveActive");
                    public static Sprite toolRotate                        = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRotate");
                    public static Sprite toolRotateActive                  = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRotateActive");
                    public static Sprite toolScale                         = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolScale");
                    public static Sprite toolScaleActive                   = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolScaleActive");
                    public static Sprite toolRectTransform                 = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRectTransform");
                    public static Sprite toolRectTransformActive           = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRectTransformActive");
                    public static Sprite center                            = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Center");
                    public static Sprite pivot                             = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Pivot");
                    public static Sprite local                             = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Local");
                    public static Sprite global                            = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Global");
                    public static Sprite play                              = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Play");
                    public static Sprite playActive                        = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PlayActive");
                    public static Sprite pause                             = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Pause");
                    public static Sprite pauseActive                       = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PauseActive");
                    public static Sprite step                              = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Step");
                    public static Sprite stepActive                        = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/StepActive");
                    public static Sprite popupButton                       = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PopupButton");
                    public static Sprite popupButtonDisabled               = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PopupButtonDisabled");
                    public static Sprite popupButtonHighlighted            = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PopupButtonHighlighted");
                    public static Sprite popupButtonPressed                = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PopupButtonPressed");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Scene/Background");
                    }

                    /// <summary>
                    /// Texture assets for scene dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Scene/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Game/Background");
                    }

                    /// <summary>
                    /// Texture assets for game dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Game/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Inspector/Background");
                    }

                    /// <summary>
                    /// Texture assets for inspector dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Inspector/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Hierarchy/Background");
                    }

                    /// <summary>
                    /// Texture assets for hierarchy dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Hierarchy/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Project/Background");
                    }

                    /// <summary>
                    /// Texture assets for project dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Project/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Animation/Background");
                    }

                    /// <summary>
                    /// Texture assets for animation dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Animation/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Profiler/Background");
                    }

                    /// <summary>
                    /// Texture assets for profiler dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Profiler/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/AudioMixer/Background");
                    }

                    /// <summary>
                    /// Texture assets for audio mixer dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/AudioMixer/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/AssetStore/Background");
                    }

                    /// <summary>
                    /// Texture assets for asset store dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/AssetStore/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/VersionControl/Background");
                    }

                    /// <summary>
                    /// Texture assets for version control dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/VersionControl/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/AnimatorParameter/Background");
                    }

                    /// <summary>
                    /// Texture assets for animator parameter dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/AnimatorParameter/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Animator/Background");
                    }

                    /// <summary>
                    /// Texture assets for animator dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Animator/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/SpritePacker/Background");
                    }

                    /// <summary>
                    /// Texture assets for sprite packer dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/SpritePacker/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Lighting/Background");
                    }

                    /// <summary>
                    /// Texture assets for lighting dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Lighting/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/OcclusionCulling/Background");
                    }

                    /// <summary>
                    /// Texture assets for occlusion culling dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/OcclusionCulling/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/FrameDebugger/Background");
                    }

                    /// <summary>
                    /// Texture assets for frame debugger dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/FrameDebugger/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Navigation/Background");
                    }

                    /// <summary>
                    /// Texture assets for navigation dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Navigation/Icon");
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
                        public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/MainWindow/DockWidgets/Console/Background");
                    }

                    /// <summary>
                    /// Texture assets for console dock widget.
                    /// </summary>
                    public static class Textures
                    {
                        public static Sprite icon = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/Console/Icon");
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
                public static Color background = AssetUtils.LoadColor("Colors/UI/Windows/AboutDialog/Background");
            }

            /// <summary>
            /// Text style assets for AboutDialog.
            /// </summary>
            public static class TextStyles
            {
                public static TextStyle version    = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Version");
                public static TextStyle credits    = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Credits");
                public static TextStyle monoLogo   = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/MonoLogo");
                public static TextStyle monoLogo2  = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/MonoLogo2");
                public static TextStyle physXLogo  = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/PhysXLogo");
                public static TextStyle physXLogo2 = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/PhysXLogo2");
                public static TextStyle copyright  = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/Copyright");
                public static TextStyle license    = AssetUtils.LoadTextStyle("TextStyles/UI/Windows/AboutDialog/License");
            }

            /// <summary>
            /// Texture assets for AboutDialog.
            /// </summary>
            public static class Textures
            {
                public static Sprite unity = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/Unity");
                public static Sprite mono  = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/Mono");
                public static Sprite physX = AssetUtils.LoadResource<Sprite>("Textures/UI/Windows/AboutDialog/PhysX");
            }
        }
        #endregion
    }
    #endregion
}
