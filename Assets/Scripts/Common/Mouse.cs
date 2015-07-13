using UnityEngine;



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



        private static float sX;
        private static float sY;
        private static int   sLastUpdate;



        /// <summary>
        /// Initializes the <see cref="Common.Mouse"/> class.
        /// </summary>
        static Mouse()
        {
            sX          = -1;
            sY          = -1;
            sLastUpdate = -1;
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
            }
        }
    }
}

