using UnityEngine;
using UnityTranslation;

using Common.UI.Toasts;



namespace UI.Windows.MainWindow.Toolbar
{
	/// <summary>
	/// Script that realize toolbar behaviour.
	/// </summary>
	public class ToolbarScript : MonoBehaviour
	{
		private ToolbarUI mUi;



		/// <summary>
		/// Script starting callback.
		/// </summary>
		void Start()
		{
			mUi = new ToolbarUI(this);

			mUi.SetupUI();
		}

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			mUi.Release();
		}

		/// <summary>
		/// Handler for resize event.
		/// </summary>
		public void OnResize()
		{
			mUi.OnResize();
		}

		/// <summary>
		/// Handler for Hand tool selection.
		/// </summary>
		public void OnToolHandClicked()
		{
			Debug.Log("ToolbarScript.OnToolHandClicked");
			// TODO: Implement ToolbarScript.OnToolHandClicked

			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}

		/// <summary>
		/// Handler for Move tool selection.
		/// </summary>
		public void OnToolMoveClicked()
		{
			Debug.Log("ToolbarScript.OnToolMoveClicked");
			// TODO: Implement ToolbarScript.OnToolMoveClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}

		/// <summary>
		/// Handler for Rotate tool selection.
		/// </summary>
		public void OnToolRotateClicked()
		{
			Debug.Log("ToolbarScript.OnToolRotateClicked");
			// TODO: Implement ToolbarScript.OnToolRotateClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}

		/// <summary>
		/// Handler for Scale tool selection.
		/// </summary>
		public void OnToolScaleClicked()
		{
			Debug.Log("ToolbarScript.OnToolScaleClicked");
			// TODO: Implement ToolbarScript.OnToolScaleClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}

		/// <summary>
		/// Handler for RectTransform tool selection.
		/// </summary>
		public void OnToolRectTransformClicked()
		{
			Debug.Log("ToolbarScript.OnToolRectTransformClicked");
			// TODO: Implement ToolbarScript.OnToolRectTransformClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}
		
		/// <summary>
		/// Handler for base point selection.
		/// </summary>
		public void OnBasePointClicked()
		{
			Debug.Log("ToolbarScript.OnBasePointClicked");
			// TODO: Implement ToolbarScript.OnBasePointClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}
		
		/// <summary>
		/// Handler for coordinate system selection.
		/// </summary>
		public void OnCoordinateSystemClicked()
		{
			Debug.Log("ToolbarScript.OnCoordinateSystemClicked");
			// TODO: Implement ToolbarScript.OnCoordinateSystemClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}
		
		/// <summary>
		/// Handler for play button.
		/// </summary>
		public void OnPlayClicked()
		{
			Debug.Log("ToolbarScript.OnPlayClicked");
			// TODO: Implement ToolbarScript.OnPlayClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}
		
		/// <summary>
		/// Handler for pause button.
		/// </summary>
		public void OnPauseClicked()
		{
			Debug.Log("ToolbarScript.OnPauseClicked");
			// TODO: Implement ToolbarScript.OnPauseClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}
		
		/// <summary>
		/// Handler for step button.
		/// </summary>
		public void OnStepClicked()
		{
			Debug.Log("ToolbarScript.OnStepClicked");
			// TODO: Implement ToolbarScript.OnStepClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}
				
		/// <summary>
		/// Handler for layers popup button.
		/// </summary>
		public void OnLayersClicked()
		{
			Debug.Log("ToolbarScript.OnLayersClicked");
			// TODO: Implement ToolbarScript.OnLayersClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}
				
		/// <summary>
		/// Handler for layout popup button.
		/// </summary>
		public void OnLayoutClicked()
		{
			Debug.Log("ToolbarScript.OnLayoutClicked");
			// TODO: Implement ToolbarScript.OnLayoutClicked
			
			Toast.ShowContributeMessage(Global.mainWindowScript.contentTransform);
		}
	}
}