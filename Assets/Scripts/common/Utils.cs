using System;
using UnityEngine;
using UnityEngine.UI;



namespace common
{
    /// <summary>
    /// Class for Unity Editor usefull functions.
    /// </summary>
    public static class Utils
    {
        private static int UI_LAYER = LayerMask.NameToLayer("UI");

        /// <summary>
        /// Put UI object in specified transform and initialize this UI object.
        /// </summary>
        /// <param name="uiObject">User interface object.</param>
        /// <param name="parent">Parent transform.</param>
        public static void InitUIObject(GameObject uiObject, Transform parent)
        {
            uiObject.transform.SetParent(parent);
            uiObject.layer = UI_LAYER;
        }

        /// <summary>
        /// Gets the local coordinates for corners of specified transform.
        /// </summary>
        /// <returns>The local coordinates for corners of specified transform.</returns>
        /// <param name="transform">RectTransform instance.</param>
        public static Vector3[] GetWindowCorners(RectTransform transform)
        {
            RectTransform canvasTransform = transform;

            do
            {
                RectTransform tempTransform = canvasTransform.parent.GetComponent<RectTransform>();

                if (tempTransform == null)
                {
                    break;
                }

                canvasTransform = tempTransform;
            } while (true);

            Vector3[] res = new Vector3[4];

            Vector3 vMin = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 vMax = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            Matrix4x4 toLocal = canvasTransform.worldToLocalMatrix;
            transform.GetWorldCorners(res);

            for (int j = 0; j < 4; j++)
            {
                Vector3 v = toLocal.MultiplyPoint3x4(res[j]);
                vMin = Vector3.Min(v, vMin);
                vMax = Vector3.Max(v, vMax);
            }

            res[0].Set(vMin.x, vMin.y, 0f);
            res[1].Set(vMin.x, vMax.y, 0f);
            res[2].Set(vMax.x, vMax.y, 0f);
            res[3].Set(vMax.x, vMin.y, 0f);

            return res;
        }

		public static void AlignRectTransformTopLeft()
		{
			// TODO: Implement Utils.AlignRectTransformTopLeft
		}

		public static void AlignRectTransformTopCenter()
		{
			// TODO: Implement Utils.AlignRectTransformTopCenter
		}

		public static void AlignRectTransformTopRight()
		{
			// TODO: Implement Utils.AlignRectTransformTopRight
		}

		public static void AlignRectTransformTopStretch()
		{
			// TODO: Implement Utils.AlignRectTransformTopStretch
		}

		public static void AlignRectTransformMiddleLeft()
		{
			// TODO: Implement Utils.AlignRectTransformMiddleLeft
		}

		public static void AlignRectTransformMiddleCenter()
		{
			// TODO: Implement Utils.AlignRectTransformMiddleCenter
		}

		public static void AlignRectTransformMiddleRight()
		{
			// TODO: Implement Utils.AlignRectTransformMiddleRight
		}

		public static void AlignRectTransformMiddleStretch()
		{
			// TODO: Implement Utils.AlignRectTransformMiddleStretch
		}

		public static void AlignRectTransformBottomLeft()
		{
			// TODO: Implement Utils.AlignRectTransformBottomLeft
		}

		public static void AlignRectTransformBottomCenter()
		{
			// TODO: Implement Utils.AlignRectTransformBottomCenter
		}

		public static void AlignRectTransformBottomRight()
		{
			// TODO: Implement Utils.AlignRectTransformBottomRight
		}

		public static void AlignRectTransformBottomStretch()
		{
			// TODO: Implement Utils.AlignRectTransformBottomStretch
		}

		public static void AlignRectTransformStretchLeft()
		{
			// TODO: Implement Utils.AlignRectTransformStretchLeft
		}

		public static void AlignRectTransformStretchCenter()
		{
			// TODO: Implement Utils.AlignRectTransformStretchCenter
		}

		public static void AlignRectTransformStretchRight()
		{
			// TODO: Implement Utils.AlignRectTransformStretchRight
		}

		/// <summary>
		/// Setup RectTransform to fill whole space of parent RectTransform.
		/// </summary>
		/// <param name="transform">RectTransform instance.</param>
		/// <param name="offsetLeft">Left offset.</param>
		/// <param name="offsetTop">Top offset.</param>
		/// <param name="offsetRight">Right offset.</param>
		/// <param name="offsetBottom">Bottom offset.</param>
		public static void AlignRectTransformStretchStretch(
															  RectTransform transform
															, float offsetLeft = 0
															, float offsetTop = 0
															, float offsetRight = 0
															, float offsetBottom = 0
														   )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0f);
			transform.anchorMax          = new Vector2(1f, 1f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
			transform.offsetMin          = new Vector2(offsetLeft,    offsetTop);
			transform.offsetMax          = new Vector2(-offsetRight, -offsetBottom);
		}
    }
}
