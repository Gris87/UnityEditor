using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using common;



namespace ui
{
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
			//***************************************************************************
			// MainMenu GameObject
			//***************************************************************************
			#region MainMenu GameObject
			Global.mainMenu = new GameObject("MainMenu");
			Utils.InitUIObject(Global.mainMenu, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform mainMenuTransform = Global.mainMenu.AddComponent<RectTransform>();
			Utils.AlignRectTransformTopStretch(mainMenuTransform, 20f);
			
			Global.mainMenuTransform = mainMenuTransform;
			#endregion
			
			//===========================================================================
			// MainMenuScript Component
			//===========================================================================
			#region MainMenuScript Component
			Global.mainMenuScript = Global.mainMenu.AddComponent<MainMenuScript>();
			#endregion
			#endregion
			
			
			
			//***************************************************************************
			// Toolbar GameObject
			//***************************************************************************
			#region Toolbar GameObject
			Global.toolbar = new GameObject("Toolbar");
			Utils.InitUIObject(Global.toolbar, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform toolbarTransform = Global.toolbar.AddComponent<RectTransform>();
			Utils.AlignRectTransformTopStretch(toolbarTransform, 32f, 20f);
			
			Global.toolbarTransform = toolbarTransform;
			#endregion

			//===========================================================================
			// ToolbarScript Component
			//===========================================================================
			#region ToolbarScript Component
			Global.toolbarScript = Global.toolbar.AddComponent<ToolbarScript>();
			#endregion
			#endregion
			
			
			
			//***************************************************************************
			// DockingArea GameObject
			//***************************************************************************
			#region DockingArea GameObject
			Global.dockingArea = new GameObject("DockingArea");
			Utils.InitUIObject(Global.dockingArea, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform dockingAreaTransform = Global.dockingArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(dockingAreaTransform, 0f, 52f, 0f, 0f);
			
			Global.dockingAreaTransform = dockingAreaTransform;
			#endregion
			
			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			Global.dockingArea.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
			#region Image Component
			Image dockingAreaImage = Global.dockingArea.AddComponent<Image>();
			
			dockingAreaImage.sprite = Assets.DockingArea.Textures.background;
			dockingAreaImage.type   = Image.Type.Sliced;
			#endregion

			//===========================================================================
			// DockingAreaScript Component
			//===========================================================================
			#region DockingAreaScript Component
			Global.dockingAreaScript = Global.dockingArea.AddComponent<DockingAreaScript>();
			#endregion
			#endregion
			
			
			
			//***************************************************************************
			// PopupMenuArea GameObject
			//***************************************************************************
			#region PopupMenuArea GameObject
			Global.popupMenuArea = new GameObject("PopupMenuArea");
			Utils.InitUIObject(Global.popupMenuArea, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform popupMenuAreaTransform = Global.popupMenuArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(popupMenuAreaTransform);
			
			Global.popupMenuAreaTransform = popupMenuAreaTransform;
			#endregion
			
			//===========================================================================
			// PopupMenuAreaScript Component
			//===========================================================================
			#region PopupMenuAreaScript Component
			Global.popupMenuAreaScript = Global.popupMenuArea.AddComponent<PopupMenuAreaScript>();
			#endregion
			#endregion
		}
	}
}
