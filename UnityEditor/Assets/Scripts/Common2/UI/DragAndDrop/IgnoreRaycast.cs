using UnityEngine;



namespace Common.UI.DragAndDrop
{
    /// <summary>
    /// Ignore raycast component.
    /// </summary>
    public class IgnoreRaycast : MonoBehaviour, ICanvasRaycastFilter
    {
        /// <summary>
        /// Handler for raycast validation.
        /// </summary>
        /// <returns><c>true</c> if raycast handled by this window; otherwise, <c>false</c>.</returns>
        /// <param name="sp">Screen point</param>
        /// <param name="eventCamera">Event camera.</param>
        public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
        {
            return false;
        }
    }
}
