using UnityEngine;
using UnityEngine.EventSystems;



namespace Common.UI.Windows
{
    /// <summary>
    /// Button glow script.
    /// </summary>
    public class ButtonGlowScript : MonoBehaviour, ICanvasRaycastFilter
    {
        public RectTransform rectTransform = null;



        /// <summary>
        /// Handler for raycast validation.
        /// </summary>
        /// <returns><c>true</c> if raycast handled by this window; otherwise, <c>false</c>.</returns>
        /// <param name="sp">Screen point</param>
        /// <param name="eventCamera">Event camera.</param>
        public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
        {
            return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, sp, eventCamera);
        }
    }
}
