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

	#region Assets for MainMenu
	/// <summary>
	/// Assets for MainMenu.
	/// </summary>
	public static class MainMenu
	{
		/// <summary>
		/// Prefabs for MainMenu.
		/// </summary>
		public static class Prefabs
		{
			public static GameObject button;



			/// <summary>
			/// Initializes the <see cref="Assets+MainMenu+Prefabs"/> class.
			/// </summary>
			static Prefabs()
			{
				button = LoadResource<GameObject>("Prefabs/ui/MainMenu/Button");
			}
		}

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
			/// Initializes the <see cref="Assets+MainMenu+Textures"/> class.
			/// </summary>
			static Textures()
			{
				background        = LoadResource<Sprite>("Textures/ui/MainMenu/Background");
				button            = LoadResource<Sprite>("Textures/ui/MainMenu/Button");
				buttonHighlighted = LoadResource<Sprite>("Textures/ui/MainMenu/ButtonHighlighted");
				buttonPressed     = LoadResource<Sprite>("Textures/ui/MainMenu/ButtonPressed");
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
			/// Initializes the <see cref="Assets+Toolbar+Textures"/> class.
			/// </summary>
			static Textures()
			{
				background                    = LoadResource<Sprite>("Textures/ui/Toolbar/Background");
				toolLeftButton                = LoadResource<Sprite>("Textures/ui/Toolbar/ToolLeftButton");
				toolLeftButtonPressed         = LoadResource<Sprite>("Textures/ui/Toolbar/ToolLeftButtonPressed");
				toolLeftButtonActive          = LoadResource<Sprite>("Textures/ui/Toolbar/ToolLeftButtonActive");
				toolLeftButtonActivePressed   = LoadResource<Sprite>("Textures/ui/Toolbar/ToolLeftButtonActivePressed");
				toolMiddleButton              = LoadResource<Sprite>("Textures/ui/Toolbar/ToolMiddleButton");
				toolMiddleButtonPressed       = LoadResource<Sprite>("Textures/ui/Toolbar/ToolMiddleButtonPressed");
				toolMiddleButtonActive        = LoadResource<Sprite>("Textures/ui/Toolbar/ToolMiddleButtonActive");
				toolMiddleButtonActivePressed = LoadResource<Sprite>("Textures/ui/Toolbar/ToolMiddleButtonActivePressed");
				toolRightButton               = LoadResource<Sprite>("Textures/ui/Toolbar/ToolRightButton");
				toolRightButtonPressed        = LoadResource<Sprite>("Textures/ui/Toolbar/ToolRightButtonPressed");
				toolRightButtonActive         = LoadResource<Sprite>("Textures/ui/Toolbar/ToolRightButtonActive");
				toolRightButtonActivePressed  = LoadResource<Sprite>("Textures/ui/Toolbar/ToolRightButtonActivePressed");
				toolHand                      = LoadResource<Sprite>("Textures/ui/Toolbar/ToolHand");
				toolHandActive                = LoadResource<Sprite>("Textures/ui/Toolbar/ToolHandActive");
				toolMove                      = LoadResource<Sprite>("Textures/ui/Toolbar/ToolMove");
				toolMoveActive                = LoadResource<Sprite>("Textures/ui/Toolbar/ToolMoveActive");
				toolRotate                    = LoadResource<Sprite>("Textures/ui/Toolbar/ToolRotate");
				toolRotateActive              = LoadResource<Sprite>("Textures/ui/Toolbar/ToolRotateActive");
				toolScale                     = LoadResource<Sprite>("Textures/ui/Toolbar/ToolScale");
				toolScaleActive               = LoadResource<Sprite>("Textures/ui/Toolbar/ToolScaleActive");
				toolRectTransform             = LoadResource<Sprite>("Textures/ui/Toolbar/ToolRectTransform");
				toolRectTransformActive       = LoadResource<Sprite>("Textures/ui/Toolbar/ToolRectTransformActive");
				center                        = LoadResource<Sprite>("Textures/ui/Toolbar/Center");
				pivot                         = LoadResource<Sprite>("Textures/ui/Toolbar/Pivot");
				local                         = LoadResource<Sprite>("Textures/ui/Toolbar/Local");
				global                        = LoadResource<Sprite>("Textures/ui/Toolbar/Global");
				play                          = LoadResource<Sprite>("Textures/ui/Toolbar/Play");
				playActive                    = LoadResource<Sprite>("Textures/ui/Toolbar/PlayActive");
				pause                         = LoadResource<Sprite>("Textures/ui/Toolbar/Pause");
				pauseActive                   = LoadResource<Sprite>("Textures/ui/Toolbar/PauseActive");
				step                          = LoadResource<Sprite>("Textures/ui/Toolbar/Step");
				stepActive                    = LoadResource<Sprite>("Textures/ui/Toolbar/StepActive");
				popupButton                   = LoadResource<Sprite>("Textures/ui/Toolbar/PopupButton");
			}
		}
	}
	#endregion
	
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
			/// Initializes the <see cref="Assets+DockingArea+Textures"/> class.
			/// </summary>
			static Textures()
			{
				background = LoadResource<Sprite>("Textures/ui/DockingArea/Background");
			}
		}
	}
	#endregion
	
	#region Assets for PopupMenuArea
	/// <summary>
	/// Assets for PopupMenuArea.
	/// </summary>
	public static class PopupMenuArea
	{
		/// <summary>
		/// Prefabs for PopupMenuArea.
		/// </summary>
		public static class Prefabs
		{
			public static GameObject button;
			public static GameObject buttonDisabled;


			
			/// <summary>
			/// Initializes the <see cref="Assets+PopupMenuArea+Prefabs"/> class.
			/// </summary>
			static Prefabs()
			{
				button         = LoadResource<GameObject>("Prefabs/ui/PopupMenuArea/Button");
				buttonDisabled = LoadResource<GameObject>("Prefabs/ui/PopupMenuArea/ButtonDisabled");
			}
		}
		
		/// <summary>
		/// Texture assets for PopupMenuArea.
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
			/// Initializes the <see cref="Assets+PopupMenuArea+Textures"/> class.
			/// </summary>
			static Textures()
			{
				popupBackground   = LoadResource<Sprite>("Textures/ui/PopupMenuArea/PopupBackground");
				background        = LoadResource<Sprite>("Textures/ui/PopupMenuArea/Background");
				separator         = LoadResource<Sprite>("Textures/ui/PopupMenuArea/Separator");
				button            = LoadResource<Sprite>("Textures/ui/PopupMenuArea/Button");
				buttonDisabled    = LoadResource<Sprite>("Textures/ui/PopupMenuArea/ButtonDisabled");
				buttonHighlighted = LoadResource<Sprite>("Textures/ui/PopupMenuArea/ButtonHighlighted");
				arrow             = LoadResource<Sprite>("Textures/ui/PopupMenuArea/Arrow");
				checkbox          = LoadResource<Sprite>("Textures/ui/PopupMenuArea/Checkbox");
			}
		}
	}
	#endregion

	#region Assets for TooltipArea
	/// <summary>
	/// Assets for TooltipArea.
	/// </summary>
	public static class TooltipArea
	{		
		/// <summary>
		/// Texture assets for TooltipArea.
		/// </summary>
		public static class Textures
		{
			public static Sprite tooltipBackground;
			
			
			
			/// <summary>
			/// Initializes the <see cref="Assets+TooltipArea+Textures"/> class.
			/// </summary>
			static Textures()
			{
				tooltipBackground = LoadResource<Sprite>("Textures/ui/TooltipArea/TooltipBackground");
            }
        }
    }
	#endregion
}