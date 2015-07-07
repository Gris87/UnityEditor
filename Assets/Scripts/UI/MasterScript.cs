using UnityEngine;
using UnityEngine.UI;

using Common;
using Common.UI.Listeners;
using Common.UI.Popups;
using Common.UI.Tooltips;
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
			SetupCanvas();

			CreateUI();
		}
		
		/// <summary>
		/// Creates user interface.
		/// </summary>
		private void CreateUI()
		{
			CreateCommon();
			CreateWindows();
			CreateOverlap();

			MainWindowScript.Create().Show();
		}

		/// <summary>
		/// Setups the canvas.
		/// </summary>
		private void SetupCanvas()
		{
			float dpi = Screen.dpi;

			if (dpi != 0f)
			{
				CanvasScaler canvasScaler = GetComponent<CanvasScaler>();

				canvasScaler.scaleFactor = dpi / 96f;
			}
			else
			{
				Debug.LogWarning("Failed to determine DPI");
			}
		}

		/// <summary>
		/// Creates common things.
		/// </summary>
		private void CreateCommon()
		{
			//***************************************************************************
			// Common GameObject
			//***************************************************************************
			#region Common GameObject
			GameObject common = new GameObject("Common");
			Utils.InitUIObject(common, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform commonTransform = common.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(commonTransform);
			#endregion
            #endregion

			CreateCommonListeners(common.transform);
		}

		/// <summary>
		/// Creates common listeners.
		/// </summary>
		/// <param name="parent">Parent transform.</param>
		private void CreateCommonListeners(Transform parent)
		{
			//***************************************************************************
			// Listeners GameObject
			//***************************************************************************
			#region Listeners GameObject
			GameObject listeners = new GameObject("Listeners");
			Utils.InitUIObject(listeners, parent);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform listenersTransform = listeners.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(listenersTransform);
            #endregion
            #endregion


            
            //***************************************************************************
			// ResizeListener GameObject
			//***************************************************************************
			#region ResizeListener GameObject
			GameObject resizeListener = new GameObject("ResizeListener");
			Utils.InitUIObject(resizeListener, listeners.transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform resizeListenerTransform = resizeListener.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(resizeListenerTransform);
			#endregion
			
			//===========================================================================
			// ResizeListenerScript Component
			//===========================================================================
			#region ResizeListenerScript Component
			resizeListener.AddComponent<ResizeListenerScript>();
			#endregion
			#endregion
		}

		/// <summary>
		/// Creates windows container.
		/// </summary>
		private void CreateWindows()
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
			
			Global.windowsTransform = windowsTransform;
			#endregion
			#endregion
		}

		/// <summary>
		/// Creates overlap container.
		/// </summary>
		private void CreateOverlap()
		{
			//***************************************************************************
			// Overlap GameObject
			//***************************************************************************
			#region Overlap GameObject
			GameObject overlap = new GameObject("Overlap");
			Utils.InitUIObject(overlap, transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform overlapTransform = overlap.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(overlapTransform);
            #endregion
            #endregion
            

            
            //***************************************************************************
			// PopupMenuArea GameObject
			//***************************************************************************
			#region PopupMenuArea GameObject
			GameObject popupMenuArea = new GameObject("PopupMenuArea");
			Utils.InitUIObject(popupMenuArea, overlap.transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform popupMenuAreaTransform = popupMenuArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(popupMenuAreaTransform);
			#endregion
			
			//===========================================================================
			// PopupMenuAreaScript Component
			//===========================================================================
			#region PopupMenuAreaScript Component
			popupMenuArea.AddComponent<PopupMenuAreaScript>();
			#endregion
			#endregion
			
			
			
			//***************************************************************************
			// TooltipArea GameObject
			//***************************************************************************
			#region TooltipArea GameObject
			GameObject tooltipArea = new GameObject("TooltipArea");
			Utils.InitUIObject(tooltipArea, overlap.transform);
			
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
			tooltipArea.AddComponent<TooltipAreaScript>();
			#endregion
			#endregion
		}
	}
}
