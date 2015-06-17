using UnityEngine;
using UnityEngine.UI;

using Common;
using Common.UI.Windows;
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
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		/// <param name="width">Width of content.</param>
		/// <param name="height">Height of content.</param>
		protected override void CreateContent(Transform contentTransform, out float width, out float height)
		{
			frame = WindowFrameType.Frameless;
			state = WindowState.FullScreen;

			width  = 0f;
			height = 0f;

			float mainMenuHeight = 20f;
			float toolbarHeight  = 32f;

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
			Utils.AlignRectTransformTopStretch(mainMenuTransform, mainMenuHeight);
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
			Utils.AlignRectTransformTopStretch(toolbarTransform, toolbarHeight, mainMenuHeight);
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
			Utils.AlignRectTransformStretchStretch(dockingAreaTransform, 0f, mainMenuHeight + toolbarHeight, 0f, 0f);
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

			enabled = false;
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		public override void OnDestroy()
		{
			base.OnDestroy();

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
		/// Handler for resize event.
		/// </summary>
		public override void OnResize()
		{
			if (Global.toolbarScript != null)
			{
				Global.toolbarScript.OnResize();
			}
		}
	}
}

