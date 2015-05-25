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
	}
}