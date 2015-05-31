using UnityEngine;



/// <summary>
/// Class for loading assets of UnityEditor project.
/// </summary>
public static class Assets
{
	/// <summary>
	/// Loads an asset stored at path in a Resources folder.
	/// </summary>
	/// <returns>The asset at path if it can be found otherwise returns null.</returns>
	/// <param name="path">Pathname of the target folder.</param>
	/// <typeparam name="T">Type of resource.</typeparam>
	public static T LoadResource<T>(string path) where T : UnityEngine.Object
	{
		T res = Resources.Load<T>(path);
		
		if (res == null)
		{
			Debug.LogError("Resource \"" + path + "\" is not found");
		}
		
		return res;
	}

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
			public static Font microsoftSansSerif;
			
			
			
			/// <summary>
			/// Initializes the <see cref="Assets+Common+Fonts"/> class.
			/// </summary>
			static Fonts()
            {
				microsoftSansSerif = LoadResource<Font>("Fonts/micross");
			}
        }
	}
	#endregion

	#region Assets for Windows
	/// <summary>
	/// Assets for Windows.
	/// </summary>
	public static class Windows
	{
		#region Common assets for windows
		/// <summary>
		/// Common assets for windows.
		/// </summary>
		public static class Common
		{
			/// <summary>
			/// Common texture assets for windows.
			/// </summary>
			public static class Textures
			{
				public static Sprite window;
				public static Sprite subWindow;
				public static Sprite drawer;
				public static Sprite minimizeButton;
				public static Sprite minimizeButtonHighlighted;
				public static Sprite minimizeButtonPressed;
				public static Sprite maximizeButton;
				public static Sprite maximizeButtonHighlighted;
				public static Sprite maximizeButtonPressed;
				public static Sprite normalizeButton;
				public static Sprite normalizeButtonHighlighted;
				public static Sprite normalizeButtonPressed;
				public static Sprite closeButton;
				public static Sprite closeButtonHighlighted;
				public static Sprite closeButtonPressed;
				public static Sprite toolCloseButton;
				public static Sprite toolCloseButtonHighlighted;
				public static Sprite toolCloseButtonPressed;



				/// <summary>
				/// Initializes the <see cref="Assets+Windows+Common+Textures"/> class.
				/// </summary>
				static Textures()
				{
					window                     = LoadResource<Sprite>("Textures/UI/Windows/Common/Window");
					subWindow                  = LoadResource<Sprite>("Textures/UI/Windows/Common/SubWindow");
					drawer                     = LoadResource<Sprite>("Textures/UI/Windows/Common/Drawer");
					minimizeButton             = LoadResource<Sprite>("Textures/UI/Windows/Common/MinimizeButton");
					minimizeButtonHighlighted  = LoadResource<Sprite>("Textures/UI/Windows/Common/MinimizeButtonHighlighted");
					minimizeButtonPressed      = LoadResource<Sprite>("Textures/UI/Windows/Common/MinimizeButtonPressed");
					maximizeButton             = LoadResource<Sprite>("Textures/UI/Windows/Common/MaximizeButton");
					maximizeButtonHighlighted  = LoadResource<Sprite>("Textures/UI/Windows/Common/MaximizeButtonHighlighted");
					maximizeButtonPressed      = LoadResource<Sprite>("Textures/UI/Windows/Common/MaximizeButtonPressed");
					normalizeButton            = LoadResource<Sprite>("Textures/UI/Windows/Common/NormalizeButton");
					normalizeButtonHighlighted = LoadResource<Sprite>("Textures/UI/Windows/Common/NormalizeButtonHighlighted");
					normalizeButtonPressed     = LoadResource<Sprite>("Textures/UI/Windows/Common/NormalizeButtonPressed");
					closeButton                = LoadResource<Sprite>("Textures/UI/Windows/Common/CloseButton");
					closeButtonHighlighted     = LoadResource<Sprite>("Textures/UI/Windows/Common/CloseButtonHighlighted");
					closeButtonPressed         = LoadResource<Sprite>("Textures/UI/Windows/Common/CloseButtonPressed");
					toolCloseButton            = LoadResource<Sprite>("Textures/UI/Windows/Common/ToolCloseButton");
					toolCloseButtonHighlighted = LoadResource<Sprite>("Textures/UI/Windows/Common/ToolCloseButtonHighlighted");
					toolCloseButtonPressed     = LoadResource<Sprite>("Textures/UI/Windows/Common/ToolCloseButtonPressed");
				}
			}
		}
		#endregion

		#region Assets for MainWindow
		/// <summary>
		/// Assets for MainWindow.
		/// </summary>
		public static class MainWindow
		{
			#region Assets for MainMenu
			/// <summary>
			/// Assets for MainMenu.
			/// </summary>
			public static class MainMenu
			{
				/// <summary>
				/// Texture assets for MainMenu.
				/// </summary>
				public static class Textures
				{
					public static Sprite background;
					public static Sprite button;
					public static Sprite buttonHighlighted;
					public static Sprite buttonPressed;
					
					
					
					/// <summary>
					/// Initializes the <see cref="Assets+Windows+MainWindow+MainMenu+Textures"/> class.
					/// </summary>
					static Textures()
					{
						background        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Background");
						button            = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/Button");
						buttonHighlighted = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonHighlighted");
						buttonPressed     = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/MainMenu/ButtonPressed");
					}
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
				/// Texture assets for Toolbar.
				/// </summary>
				public static class Textures
				{
					public static Sprite background;
					public static Sprite toolLeftButton;
					public static Sprite toolLeftButtonPressed;
					public static Sprite toolLeftButtonActive;
					public static Sprite toolLeftButtonActivePressed;
					public static Sprite toolMiddleButton;
					public static Sprite toolMiddleButtonPressed;
					public static Sprite toolMiddleButtonActive;
					public static Sprite toolMiddleButtonActivePressed;
					public static Sprite toolRightButton;
					public static Sprite toolRightButtonPressed;
					public static Sprite toolRightButtonActive;
					public static Sprite toolRightButtonActivePressed;
					public static Sprite toolHand;
					public static Sprite toolHandActive;
					public static Sprite toolMove;
					public static Sprite toolMoveActive;
					public static Sprite toolRotate;
					public static Sprite toolRotateActive;
					public static Sprite toolScale;
					public static Sprite toolScaleActive;
					public static Sprite toolRectTransform;
					public static Sprite toolRectTransformActive;
					public static Sprite center;
					public static Sprite pivot;
					public static Sprite local;
					public static Sprite global;
					public static Sprite play;
					public static Sprite playActive;
					public static Sprite pause;
					public static Sprite pauseActive;
					public static Sprite step;
					public static Sprite stepActive;
					public static Sprite popupButton;
					
					
					
					/// <summary>
					/// Initializes the <see cref="Assets+Windows+MainWindow+Toolbar+Textures"/> class.
					/// </summary>
					static Textures()
					{
						background                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Background");
						toolLeftButton                = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButton");
						toolLeftButtonPressed         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonPressed");
						toolLeftButtonActive          = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActive");
						toolLeftButtonActivePressed   = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolLeftButtonActivePressed");
						toolMiddleButton              = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButton");
						toolMiddleButtonPressed       = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonPressed");
						toolMiddleButtonActive        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActive");
						toolMiddleButtonActivePressed = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMiddleButtonActivePressed");
						toolRightButton               = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButton");
						toolRightButtonPressed        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonPressed");
						toolRightButtonActive         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActive");
						toolRightButtonActivePressed  = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRightButtonActivePressed");
						toolHand                      = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolHand");
						toolHandActive                = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolHandActive");
						toolMove                      = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMove");
						toolMoveActive                = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolMoveActive");
						toolRotate                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRotate");
						toolRotateActive              = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRotateActive");
						toolScale                     = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolScale");
						toolScaleActive               = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolScaleActive");
						toolRectTransform             = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRectTransform");
						toolRectTransformActive       = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/ToolRectTransformActive");
						center                        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Center");
						pivot                         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Pivot");
						local                         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Local");
						global                        = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Global");
						play                          = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Play");
						playActive                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PlayActive");
						pause                         = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Pause");
						pauseActive                   = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PauseActive");
						step                          = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/Step");
						stepActive                    = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/StepActive");
						popupButton                   = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/Toolbar/PopupButton");
					}
				}
			}
			#endregion

			#region Assets for DockWidgets
			/// <summary>
			/// Assets for DockWidgets.
			/// </summary>
			public static class DockWidgets
			{
				#region Assets for DockingArea
				/// <summary>
				/// Assets for DockingArea.
				/// </summary>
				public static class DockingArea
				{
					/// <summary>
					/// Texture assets for DockingArea.
					/// </summary>
					public static class Textures
					{
						public static Sprite background;
						
						
						
						/// <summary>
						/// Initializes the <see cref="Assets+Windows+MainWindow+DockWidgets+DockingArea+Textures"/> class.
						/// </summary>
						static Textures()
						{
							background = LoadResource<Sprite>("Textures/UI/Windows/MainWindow/DockWidgets/DockingArea/Background");
						}
					}
				}
				#endregion
			}
			#endregion
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
		/// Texture assets for Popups.
		/// </summary>
		public static class Textures
		{
			public static Sprite popupBackground; // TODO: Looks bad
			public static Sprite background;
			public static Sprite separator;
			public static Sprite button;
			public static Sprite buttonDisabled;
			public static Sprite buttonHighlighted;
			public static Sprite arrow;
			public static Sprite checkbox;


			
			/// <summary>
			/// Initializes the <see cref="Assets+Popups+Textures"/> class.
			/// </summary>
			static Textures()
			{
				popupBackground   = LoadResource<Sprite>("Textures/UI/Popups/PopupBackground");
				background        = LoadResource<Sprite>("Textures/UI/Popups/Background");
				separator         = LoadResource<Sprite>("Textures/UI/Popups/Separator");
				button            = LoadResource<Sprite>("Textures/UI/Popups/Button");
				buttonDisabled    = LoadResource<Sprite>("Textures/UI/Popups/ButtonDisabled");
				buttonHighlighted = LoadResource<Sprite>("Textures/UI/Popups/ButtonHighlighted");
				arrow             = LoadResource<Sprite>("Textures/UI/Popups/Arrow");
				checkbox          = LoadResource<Sprite>("Textures/UI/Popups/Checkbox");
			}
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
		/// Texture assets for Tooltips.
		/// </summary>
		public static class Textures
		{
			public static Sprite tooltipBackground;
			
			
			
			/// <summary>
			/// Initializes the <see cref="Assets+Tooltips+Textures"/> class.
			/// </summary>
			static Textures()
			{
				tooltipBackground = LoadResource<Sprite>("Textures/UI/Tooltips/TooltipBackground");
            }
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
		/// Texture assets for Toasts.
		/// </summary>
		public static class Textures
		{
			public static Sprite toastBackground;
			
			
			
			/// <summary>
			/// Initializes the <see cref="Assets+Toasts+Textures"/> class.
			/// </summary>
			static Textures()
			{
				toastBackground = LoadResource<Sprite>("Textures/UI/Toasts/ToastBackground");
            }
        }
    }
    #endregion
}