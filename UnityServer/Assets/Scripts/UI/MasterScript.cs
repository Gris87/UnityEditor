using UnityEngine;
using UnityEngine.UI;



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
			Server.Start();

            SetupCanvas();

            CreateUI();
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
		/// Creates user interface.
		/// </summary>
		private void CreateUI()
		{
		}
    }
}
