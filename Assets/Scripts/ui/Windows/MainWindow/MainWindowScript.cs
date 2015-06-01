using UnityEngine;
using UnityEngine.UI;

using Common;
using UI.Windows.Common;
using UI.Windows.MainWindow.DockWidgets;
using UI.Windows.MainWindow.MainMenu;
using UI.Windows.MainWindow.Toolbar;



namespace UI.Windows.MainWindow
{
	/// <summary>
	/// Script that realize main window behaviour.
	/// </summary>
	public class MainWindowScript : WindowScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.MainWindowScript"/> class.
		/// </summary>
		public MainWindowScript()
			: base()
		{
			frame = WindowFrameTypes.Frameless;
			state = WindowStates.FullScreen;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.MainWindowScript"/> class.
		/// </summary>
		public static MainWindowScript Create()
		{
			if (Global.mainWindowScript == null)
			{
				//***************************************************************************
				// MainWindow GameObject
				//***************************************************************************
				#region MainWindow GameObject
				GameObject mainWindow = new GameObject("MainWindow");
				Utils.InitUIObject(mainWindow, Global.windowsTransform);
				
				//===========================================================================
				// MainWindowScript Component
				//===========================================================================
				#region MainWindowScript Component
				Global.mainWindowScript = mainWindow.AddComponent<MainWindowScript>();
				#endregion
				#endregion
			}
			
			return Global.mainWindowScript;
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			if (Global.mainWindowScript == this)
			{
				Global.mainWindowScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in MainWindowScript.OnDestroy");
			}
		}

		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		/// <param name="width">Width of content.</param>
		/// <param name="height">Height of content.</param>
		protected override void CreateContent(Transform contentTransform, out float width, out float height)
		{
			width  = 0f;
			height = 0f;

			//***************************************************************************
			// MainMenu GameObject
			//***************************************************************************
			#region MainMenu GameObject
			GameObject mainMenu = new GameObject("MainMenu");
			Utils.InitUIObject(mainMenu, contentTransform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform mainMenuTransform = mainMenu.AddComponent<RectTransform>();
			Utils.AlignRectTransformTopStretch(mainMenuTransform, 20f);
			#endregion
			
			//===========================================================================
			// MainMenuScript Component
			//===========================================================================
			#region MainMenuScript Component
			Global.mainMenuScript = mainMenu.AddComponent<MainMenuScript>();
			#endregion
			#endregion
			
			
			
			//***************************************************************************
			// Toolbar GameObject
			//***************************************************************************
			#region Toolbar GameObject
			GameObject toolbar = new GameObject("Toolbar");
			Utils.InitUIObject(toolbar, contentTransform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform toolbarTransform = toolbar.AddComponent<RectTransform>();
			Utils.AlignRectTransformTopStretch(toolbarTransform, 32f, 20f);
			#endregion
			
			//===========================================================================
			// ToolbarScript Component
			//===========================================================================
			#region ToolbarScript Component
			Global.toolbarScript = toolbar.AddComponent<ToolbarScript>();
			#endregion
			#endregion
			
			
			
			//***************************************************************************
			// DockingArea GameObject
			//***************************************************************************
			#region DockingArea GameObject
			GameObject dockingArea = new GameObject("DockingArea");
			Utils.InitUIObject(dockingArea, contentTransform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform dockingAreaTransform = dockingArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(dockingAreaTransform, 0f, 52f, 0f, 0f);
			#endregion
			
			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			dockingArea.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
			#region Image Component
			Image dockingAreaImage = dockingArea.AddComponent<Image>();
			
			dockingAreaImage.sprite = Assets.Windows.MainWindow.DockWidgets.DockingArea.Textures.background;
			dockingAreaImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// DockingAreaScript Component
			//===========================================================================
			#region DockingAreaScript Component
			Global.dockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();
			#endregion
			#endregion
		}
	}
}

