using UnityEngine;
using UnityEngine.UI;

using Common;
using Common.UI;
using UI.Popups;
using UI.Tooltips;
using UI.Windows.MainWindow;



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
			//***************************************************************************
			// ResizeListener GameObject
			//***************************************************************************
			#region ResizeListener GameObject
			GameObject resizeListener = new GameObject("ResizeListener");
			Utils.InitUIObject(resizeListener, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform resizeListenerTransform = resizeListener.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(resizeListenerTransform);
			#endregion

			//===========================================================================
			// PopupMenuAreaScript Component
			//===========================================================================
			#region PopupMenuAreaScript Component
			Global.resizeListenerScript = resizeListener.AddComponent<ResizeListenerScript>();
			#endregion
			#endregion



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
			
			Global.windowsTransform = windowsTransform;
			#endregion
			#endregion


			
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
		


			MainWindowScript.Create().Show();
		}
	}
}
