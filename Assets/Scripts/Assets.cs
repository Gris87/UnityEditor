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
	public static T LoadResource<T>(string path) where T : Object
	{
		T res = Resources.Load<T>(path);
		
		if (res == null)
		{
			Debug.LogError("Resource \"" + path + "\" is not found");
		}
		
		return res;
	}

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


			
			/// <summary>
			/// Initializes the <see cref="Assets+Toolbar+Textures"/> class.
			/// </summary>
			static Textures()
			{
				background = LoadResource<Sprite>("Textures/ui/Toolbar/Background");
			}
		}
	}

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
			public static Sprite arrow;
			public static Sprite background;
			public static Sprite button;
			public static Sprite buttonDisabled;
			public static Sprite buttonHighlighted;
			public static Sprite checkbox;
			public static Sprite popupBackground; // TODO: Looks bad
			public static Sprite separator;


			
			/// <summary>
			/// Initializes the <see cref="Assets+PopupMenuArea+Textures"/> class.
			/// </summary>
			static Textures()
			{
				arrow             = LoadResource<Sprite>("Textures/ui/PopupMenuArea/Arrow");
				background        = LoadResource<Sprite>("Textures/ui/PopupMenuArea/Background");
				button            = LoadResource<Sprite>("Textures/ui/PopupMenuArea/Button");
				buttonDisabled    = LoadResource<Sprite>("Textures/ui/PopupMenuArea/ButtonDisabled");
				buttonHighlighted = LoadResource<Sprite>("Textures/ui/PopupMenuArea/ButtonHighlighted");
				checkbox          = LoadResource<Sprite>("Textures/ui/PopupMenuArea/Checkbox");
				popupBackground   = LoadResource<Sprite>("Textures/ui/PopupMenuArea/PopupBackground");
				separator         = LoadResource<Sprite>("Textures/ui/PopupMenuArea/Separator");
			}
		}
	}
}