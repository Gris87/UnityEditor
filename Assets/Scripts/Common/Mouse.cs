using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



namespace Common
{
    /// <summary>
    /// Class that provide mouse position in normal coordinate system.
    /// </summary>
    public static class Mouse
    {
        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        /// <value>The x coordinate.</value>
        public static float x
        {
            get
            {
                UpdatePosition();

                return sX;
            }
        }

        /// <summary>
        /// Gets the y coordinate.
        /// </summary>
        /// <value>The y coordinate.</value>
        public static float y
        {
            get
            {
                UpdatePosition();

                return sY;
            }
        }

        /// <summary>
        /// Gets the scaled x coordinate.
        /// </summary>
        /// <value>The scaled x coordinate.</value>
        public static float scaledX
        {
            get	{ return x / Utils.canvasScale;	}
        }

        /// <summary>
        /// Gets the scaled y coordinate.
        /// </summary>
        /// <value>The scaled y coordinate.</value>
        public static float scaledY
        {
            get { return y / Utils.canvasScale;	}
        }



		private static int                 sLastUpdate;
        private static float               sX;
        private static float               sY;
		private static List<RaycastResult> sHits;
        


        /// <summary>
        /// Initializes the <see cref="Common.Mouse"/> class.
        /// </summary>
        static Mouse()
        {
			sLastUpdate = -1;
            sX          = -1;
            sY          = -1;
			sHits       = null;
        }

        /// <summary>
        /// Updates position if needed.
        /// </summary>
        private static void UpdatePosition()
        {
            if (sLastUpdate != Time.frameCount)
            {
                sLastUpdate = Time.frameCount;

                Vector3 mousePos = InputControl.mousePosition;

                sX = mousePos.x;
                sY = Screen.height - mousePos.y;

				sHits = null;
            }
        }

		/// <summary>
		/// Raycasts all.
		/// </summary>
		/// <param name="hits">List of raycast results.</param>
		public static void RaycastAll(List<RaycastResult> hits)
		{
			UpdatePosition();

			if (sHits == null)
			{
				PointerEventData pointerEvent = new PointerEventData(EventSystem.current);
				pointerEvent.position = InputControl.mousePosition;
				
				sHits = new List<RaycastResult>();
				EventSystem.current.RaycastAll(pointerEvent, sHits);
			}

			hits.AddRange(sHits);
		}
    }
}

