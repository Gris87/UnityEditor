using UnityEngine;
using UnityEngine.UI;

using Common;
using UI.Popups;
using UI.Toasts;
using UI.Tooltips;
using UI.Windows.Common;
using UI.Windows.MainWindow.DockWidgets;
using UI.Windows.MainWindow.MainMenu;
using UI.Windows.MainWindow.Toolbar;



namespace UI
{
	/// <summary>
	/// Master script.
	/// </summary>
	public class MasterScript : MonoBehaviour
	{
		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			CreateUI();
		}
		
		/// <summary>
		/// Creates user interface.
		/// </summary>
		private void CreateUI()
		{
			CreateMainWindow();


			
			//***************************************************************************
			// PopupMenuArea GameObject
			//***************************************************************************
			#region PopupMenuArea GameObject
			GameObject popupMenuArea = new GameObject("PopupMenuArea");
			Utils.InitUIObject(popupMenuArea, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform popupMenuAreaTransform = popupMenuArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(popupMenuAreaTransform);

			Global.popupMenuAreaTransform = popupMenuAreaTransform;
			#endregion
			
			//===========================================================================
			// PopupMenuAreaScript Component
			//===========================================================================
			#region PopupMenuAreaScript Component
			Global.popupMenuAreaScript = popupMenuArea.AddComponent<PopupMenuAreaScript>();
			#endregion
			#endregion



			//***************************************************************************
			// TooltipArea GameObject
			//***************************************************************************
			#region TooltipArea GameObject
			GameObject tooltipArea = new GameObject("TooltipArea");
			Utils.InitUIObject(tooltipArea, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform tooltipAreaTransform = tooltipArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(tooltipAreaTransform);
			#endregion
			
			//===========================================================================
			// TooltipAreaScript Component
			//===========================================================================
			#region TooltipAreaScript Component
			Global.tooltipAreaScript = tooltipArea.AddComponent<TooltipAreaScript>();
			#endregion
			#endregion



			//***************************************************************************
			// ToastArea GameObject
			//***************************************************************************
			#region ToastArea GameObject
			GameObject toastArea = new GameObject("ToastArea");
			Utils.InitUIObject(toastArea, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform toastAreaTransform = toastArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(toastAreaTransform);
			#endregion
			
			//===========================================================================
			// ToastAreaScript Component
			//===========================================================================
			#region ToastAreaScript Component
			Global.toastAreaScript = toastArea.AddComponent<ToastAreaScript>();
			#endregion
			#endregion
		}

		/// <summary>
		/// Creates the main window.
		/// </summary>
		private void CreateMainWindow()
		{
			//***************************************************************************
			// Windows GameObject
			//***************************************************************************
			#region Windows GameObject
			GameObject windows = new GameObject("Windows");
			Utils.InitUIObject(windows, transform);

			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform windowsTransform = windows.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(windowsTransform);
			#endregion

			//***************************************************************************
			// MainWindow GameObject
			//***************************************************************************
			#region MainWindow GameObject
			GameObject mainWindow = new GameObject("MainWindow");
			Utils.InitUIObject(mainWindow, windows.transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform mainWindowTransform = mainWindow.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(mainWindowTransform);
			#endregion

			//===========================================================================
			// WindowScript Component
			//===========================================================================
			#region WindowScript Component
			mainWindow.AddComponent<WindowScript>();
			#endregion



			//***************************************************************************
			// MainMenu GameObject
			//***************************************************************************
			#region MainMenu GameObject
			GameObject mainMenu = new GameObject("MainMenu");
			Utils.InitUIObject(mainMenu, mainWindow.transform);
			
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
			Utils.InitUIObject(toolbar, mainWindow.transform);
			
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
			Utils.InitUIObject(dockingArea, mainWindow.transform);
			
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
			#endregion
			#endregion
		}
	}
}
