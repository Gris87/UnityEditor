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

			int screenWidthDiv2  = Screen.width  / 2;
			int screenHeightDiv2 = Screen.height / 2;
		
			res[0].Set(vMin.x + screenWidthDiv2, -vMax.y + screenHeightDiv2, 0f);
			res[1].Set(vMax.x + screenWidthDiv2, -vMax.y + screenHeightDiv2, 0f);
			res[2].Set(vMin.x + screenWidthDiv2, -vMin.y + screenHeightDiv2, 0f);            
			res[3].Set(vMax.x + screenWidthDiv2, -vMin.y + screenHeightDiv2, 0f);

            return res;
        }

		/// <summary>
		/// Fits RectTransform to screen.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="left">Left edge of alternative position.</param>
		/// <param name="bottom">Bottom edge of alternative position.</param>
		public static void FitRectTransformToScreen(
												  	  RectTransform transform
													, float width
													, float height
													, float x      = 0
													, float y      = 0
													, float left   = -1
													, float bottom = -1
												   )
		{
			int   screenWidth  = Screen.width;
			int   screenHeight = Screen.height;
			
			if (width > screenWidth)
			{
				width = screenWidth;
			}
			
			if (height > screenHeight)
			{
				height = screenHeight;
			}
			
			if (x + width > screenWidth)
			{
				if (left != -1)
				{
					x = left - width;
					
					if (x < 0)
					{
						x = screenWidth - width;
					}
				}
				else
				{
					x = screenWidth - width;
				}
			}
			
			if (y + height > screenHeight)
			{
				if (bottom != -1)
				{
					y = bottom - height;
					
					if (y < 0)
					{
						y = screenHeight - height;
					}
				}
				else
				{
					y = screenHeight - height;
				}
			}

			Utils.AlignRectTransformTopLeft(transform, width, height, x, y);
		}

		/// <summary>
		/// Aligns RectTransform to top left corner.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public static void AlignRectTransformTopLeft(
													   RectTransform transform
													 , float width
													 , float height
													 , float x = 0
													 , float y = 0
		                                            )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 1f);
			transform.anchorMax          = new Vector2(0f, 1f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(x + width / 2, -(y + height / 2), 0f);
			transform.sizeDelta          = new Vector2(width, height);
		}

		/// <summary>
		/// Aligns RectTransform to top center.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetX">Offset by X axis.</param>
		/// <param name="offsetTop">Top offset.</param>
		public static void AlignRectTransformTopCenter(
		                                                 RectTransform transform
		                                               , float width
		                                               , float height
		                                               , float offsetX    = 0
		                                               , float offsetTop  = 0
		                                              )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0.5f, 1f);
			transform.anchorMax          = new Vector2(0.5f, 1f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(offsetX, -(offsetTop + height / 2), 0f);
			transform.sizeDelta          = new Vector2(width, height);
		}

		/// <summary>
		/// Aligns RectTransform to top right corner.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetRight">Right offset.</param>
		/// <param name="offsetTop">Top offset.</param>
		public static void AlignRectTransformTopRight(
													    RectTransform transform
													  , float width
													  , float height
													  , float offsetRight = 0
													  , float offsetTop   = 0
													 )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(1f, 1f);
			transform.anchorMax          = new Vector2(1f, 1f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(-offsetRight - width / 2, -(offsetTop + height / 2), 0f);
			transform.sizeDelta          = new Vector2(width, height);
		}

		/// <summary>
		/// Aligns RectTransform to top edge.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetTop">Top offset.</param>
		/// <param name="offsetLeft">Left offset.</param>
		/// <param name="offsetRight">Right offset.</param>
		public static void AlignRectTransformTopStretch(
													      RectTransform transform
													    , float height
														, float offsetTop   = 0
													    , float offsetLeft  = 0
													    , float offsetRight = 0
													   )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 1f);
			transform.anchorMax          = new Vector2(1f, 1f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
			transform.offsetMin          = new Vector2(offsetLeft,   -(offsetTop + height));
			transform.offsetMax          = new Vector2(-offsetRight, -(offsetTop));
		}

		/// <summary>
		/// Aligns RectTransform to middle left.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetLeft">Left offset.</param>
		/// <param name="offsetY">Offset by Y axis.</param>
		public static void AlignRectTransformMiddleLeft(
														  RectTransform transform
														, float width
														, float height
														, float offsetLeft = 0
														, float offsetY    = 0
													   )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0.5f);
			transform.anchorMax          = new Vector2(0f, 0.5f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(offsetLeft + width / 2, -offsetY, 0f);
			transform.sizeDelta          = new Vector2(width, height);
		}

		/// <summary>
		/// Aligns RectTransform to center.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetX">Offset by X axis.</param>
		/// <param name="offsetY">Offset by Y axis.</param>
		public static void AlignRectTransformMiddleCenter(
															RectTransform transform
														  , float width
														  , float height
														  , float offsetX = 0
														  , float offsetY = 0
														 )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0.5f, 0.5f);
			transform.anchorMax          = new Vector2(0.5f, 0.5f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(offsetX, -offsetY, 0f);
			transform.sizeDelta          = new Vector2(width, height);
		}

		/// <summary>
		/// Aligns RectTransform to middle right.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetRight">Right offset.</param>
		/// <param name="offsetY">Offset by Y axis.</param>
		public static void AlignRectTransformMiddleRight(
														   RectTransform transform
														 , float width
														 , float height
														 , float offsetRight = 0
														 , float offsetY     = 0
														)
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(1f, 0.5f);
			transform.anchorMax          = new Vector2(1f, 0.5f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(-offsetRight - width / 2, -offsetY, 0f);
			transform.sizeDelta          = new Vector2(width, height);
		}

		/// <summary>
		/// Aligns RectTransform to middle.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetY">Offset by Y axis.</param>
		/// <param name="offsetLeft">Left offset.</param>
		/// <param name="offsetRight">Right offset.</param>
		public static void AlignRectTransformMiddleStretch(
															 RectTransform transform
														   , float height
														   , float offsetY     = 0
														   , float offsetLeft  = 0
														   , float offsetRight = 0
														  )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0.5f);
			transform.anchorMax          = new Vector2(1f, 0.5f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
			transform.offsetMin          = new Vector2(offsetLeft,   -(offsetY + height / 2));
			transform.offsetMax          = new Vector2(-offsetRight, -(offsetY - height / 2));
		}

		/// <summary>
		/// Aligns RectTransform to bottom left corner.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetLeft">Left offset.</param>
		/// <param name="offsetBottom">Bottom offset.</param>
		public static void AlignRectTransformBottomLeft(
														  RectTransform transform
														, float width
														, float height
														, float offsetLeft   = 0
														, float offsetBottom = 0
													   )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0f);
			transform.anchorMax          = new Vector2(0f, 0f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(offsetLeft + width / 2, offsetBottom + height / 2, 0f);
			transform.sizeDelta          = new Vector2(width, height);
		}

		/// <summary>
		/// Aligns RectTransform to bottom center.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetX">Offset by X axis.</param>
		/// <param name="offsetBottom">Bottom offset.</param>
		public static void AlignRectTransformBottomCenter(
															RectTransform transform
														  , float width
														  , float height
														  , float offsetX      = 0
														  , float offsetBottom = 0
														 )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0.5f, 0f);
			transform.anchorMax          = new Vector2(0.5f, 0f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(offsetX, offsetBottom + height / 2, 0f);
			transform.sizeDelta          = new Vector2(width, height);
		}

		/// <summary>
		/// Aligns RectTransform to bottom right corner.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetRight">Right offset.</param>
		/// <param name="offsetBottom">Bottom offset.</param>
		public static void AlignRectTransformBottomRight(
														   RectTransform transform
														 , float width
														 , float height
														 , float offsetRight  = 0
														 , float offsetBottom = 0
														)
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(1f, 0f);
			transform.anchorMax          = new Vector2(1f, 0f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(-offsetRight - width / 2, offsetBottom + height / 2, 0f);
			transform.sizeDelta          = new Vector2(width, height);
		}

		/// <summary>
		/// Aligns RectTransform to bottom edge.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="height">Height.</param>
		/// <param name="offsetBottom">Bottom offset.</param>
		/// <param name="offsetLeft">Left offset.</param>
		/// <param name="offsetRight">Right offset.</param>
		public static void AlignRectTransformBottomStretch(
															 RectTransform transform
														   , float height
														   , float offsetBottom = 0
														   , float offsetLeft   = 0
														   , float offsetRight  = 0
														  )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0f);
			transform.anchorMax          = new Vector2(1f, 0f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
			transform.offsetMin          = new Vector2(offsetLeft,   offsetBottom);
			transform.offsetMax          = new Vector2(-offsetRight, offsetBottom + height);
		}

		/// <summary>
		/// Aligns RectTransform to left edge.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="offsetLeft">Left offset.</param>
		/// <param name="offsetTop">Top offset.</param>
		/// <param name="offsetBottom">Bottom offset.</param>
		public static void AlignRectTransformStretchLeft(
														   RectTransform transform
														 , float width
														 , float offsetLeft   = 0
														 , float offsetTop    = 0
														 , float offsetBottom = 0
														)
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0f);
			transform.anchorMax          = new Vector2(0f, 1f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
			transform.offsetMin          = new Vector2(offsetLeft,          offsetBottom);
			transform.offsetMax          = new Vector2(offsetLeft + width, -offsetTop);
		}

		/// <summary>
		/// Aligns RectTransform to center.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="offsetX">Offset by X axis.</param>
		/// <param name="offsetTop">Top offset.</param>
		/// <param name="offsetBottom">Bottom offset.</param>
		public static void AlignRectTransformStretchCenter(
															 RectTransform transform
														   , float width
														   , float offsetX      = 0
														   , float offsetTop    = 0
														   , float offsetBottom = 0
														  )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0.5f, 0f);
			transform.anchorMax          = new Vector2(0.5f, 1f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
			transform.offsetMin          = new Vector2(offsetX - width / 2,  offsetBottom);
			transform.offsetMax          = new Vector2(offsetX + width / 2, -offsetTop);
		}

		/// <summary>
		/// Aligns RectTransform to right edge.
		/// </summary>
		/// <param name="transform">Transform.</param>
		/// <param name="width">Width.</param>
		/// <param name="offsetRight">Right offset.</param>
		/// <param name="offsetTop">Top offset.</param>
		/// <param name="offsetBottom">Bottom offset.</param>
		public static void AlignRectTransformStretchRight(
															RectTransform transform
														  , float width
														  , float offsetRight  = 0
														  , float offsetTop    = 0
														  , float offsetBottom = 0
														 )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(1f, 0f);
			transform.anchorMax          = new Vector2(1f, 1f);
			transform.pivot              = new Vector2(0.5f, 0.5f);
			transform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
			transform.offsetMin          = new Vector2(-offsetRight - width,  offsetBottom);
			transform.offsetMax          = new Vector2(-offsetRight,         -offsetTop);
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
			transform.offsetMin          = new Vector2(offsetLeft,    offsetBottom);
			transform.offsetMax          = new Vector2(-offsetRight, -offsetTop);
		}
    }
}
