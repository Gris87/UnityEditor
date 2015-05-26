using UnityEngine;



namespace ui
{
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
		/// Handler for Hand tool selection.
		/// </summary>
		public void OnToolHandClicked()
		{
			Debug.Log("ToolbarScript.OnToolHandClicked");
			// TODO: Implement ToolbarScript.OnToolHandClicked
		}

		/// <summary>
		/// Handler for Move tool selection.
		/// </summary>
		public void OnToolMoveClicked()
		{
			Debug.Log("ToolbarScript.OnToolMoveClicked");
			// TODO: Implement ToolbarScript.OnToolMoveClicked
		}

		/// <summary>
		/// Handler for Rotate tool selection.
		/// </summary>
		public void OnToolRotateClicked()
		{
			Debug.Log("ToolbarScript.OnToolRotateClicked");
			// TODO: Implement ToolbarScript.OnToolRotateClicked
		}

		/// <summary>
		/// Handler for Scale tool selection.
		/// </summary>
		public void OnToolScaleClicked()
		{
			Debug.Log("ToolbarScript.OnToolScaleClicked");
			// TODO: Implement ToolbarScript.OnToolScaleClicked
		}

		/// <summary>
		/// Handler for RectTransform tool selection.
		/// </summary>
		public void OnToolRectTransformClicked()
		{
			Debug.Log("ToolbarScript.OnToolRectTransformClicked");
			// TODO: Implement ToolbarScript.OnToolRectTransformClicked
		}
		
		/// <summary>
		/// Handler for base point selection.
		/// </summary>
		public void OnBasePointClicked()
		{
			Debug.Log("ToolbarScript.OnBasePointClicked");
			// TODO: Implement ToolbarScript.OnBasePointClicked
		}
		
		/// <summary>
		/// Handler for coordinate system selection.
		/// </summary>
		public void OnCoordinateSystemClicked()
		{
			Debug.Log("ToolbarScript.OnCoordinateSystemClicked");
			// TODO: Implement ToolbarScript.OnCoordinateSystemClicked
		}
	}
}