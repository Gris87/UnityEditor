using UnityEngine;
using UnityEngine.UI;

using common;



namespace ui
{
	public class ToolbarUI
	{
		private ToolbarScript mScript;



		/// <summary>
		/// Initializes a new instance of the <see cref="ui.ToolbarUI"/> class.
		/// </summary>
		/// <param name="script">Script.</param>
		public ToolbarUI(ToolbarScript script)
		{
			mScript = script;
		}

		/// <summary>
		/// Setup user interface.
		/// </summary>
		public void SetupUI()
		{
			CreateUI();
		}

		/// <summary>
		/// Creates user interface.
		/// </summary>
		private void CreateUI()
		{
			//***************************************************************************
			// ScrollArea GameObject
			//***************************************************************************
			#region ScrollArea GameObject
			GameObject scrollArea = new GameObject("ScrollArea");
			Utils.InitUIObject(scrollArea, mScript.transform);
			
			//===========================================================================
			// RectTransform Component
			//===========================================================================
			#region RectTransform Component
			RectTransform scrollAreaTransform = scrollArea.AddComponent<RectTransform>();
			Utils.AlignRectTransformStretchStretch(scrollAreaTransform);
			#endregion
			
			// TODO: Implement ToolbarUI.CreateUI
			
			//===========================================================================
			// CanvasRenderer Component
			//===========================================================================
			#region CanvasRenderer Component
			scrollArea.AddComponent<CanvasRenderer>();
			#endregion
			
			//===========================================================================
			// Image Component
			//===========================================================================
			#region Image Component
			Image scrollAreaImage = scrollArea.AddComponent<Image>();
			
			scrollAreaImage.sprite = Assets.Toolbar.Textures.background;
			scrollAreaImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Mask Component
			//===========================================================================
			#region Mask Component
			scrollArea.AddComponent<Mask>();
			#endregion
			#endregion
		}
	}
}

