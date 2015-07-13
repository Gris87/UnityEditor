using UnityEngine;
using UnityEngine.UI;



namespace Common
{
    /// <summary>
    /// Class for usefull functions.
    /// </summary>
    public static class Utils
    {
        private static int sUiLayer;

		private static CanvasScaler sCanvasScaler;



		/// <summary>
		/// Gets the canvas scale.
		/// </summary>
		/// <value>The canvas scale.</value>
		public static float canvasScale
		{
			get
			{
				if (sCanvasScaler == null)
				{
					CanvasScaler[] scalers = GameObject.FindObjectsOfType<CanvasScaler>();

					if (scalers.Length > 0)
					{
						if (scalers.Length > 1)
						{
							Debug.LogWarning("Several CanvasScalers found: " + scalers.Length);
						}

						sCanvasScaler = scalers[0];
					}
					else
					{
						Debug.LogError("Failed to find CanvasScaler");
						return 1f;
					}
				}

				return sCanvasScaler.scaleFactor;
			}
		}

		/// <summary>
		/// Gets the scaled width of the screen.
		/// </summary>
		/// <value>The scaled width of the screen.</value>
		public static float scaledScreenWidth
		{
			get
			{
				return Screen.width / canvasScale;
			}
		}

		/// <summary>
		/// Gets the scaled height of the screen.
		/// </summary>
		/// <value>The scaled height of the screen.</value>
		public static float scaledScreenHeight
		{
			get
			{
				return Screen.height / canvasScale;
			}
		}



		/// <summary>
		/// Initializes the <see cref="Common.Utils"/> class.
		/// </summary>
		static Utils()
		{
			sUiLayer = LayerMask.NameToLayer("UI");
			
			sCanvasScaler = null;
		}



        /// <summary>
        /// Put UI object in specified transform and initialize this UI object.
        /// </summary>
        /// <param name="uiObject">User interface object.</param>
        /// <param name="parent">Parent transform.</param>
		/// <param name="worldPositionStays">If true, the parent-relative position, scale and rotation is modified such that the object keeps the same world space position, rotation and scale as before.</param>
		public static void InitUIObject(GameObject uiObject, Transform parent, bool worldPositionStays = false)
        {
            uiObject.transform.SetParent(parent, worldPositionStays);
			uiObject.layer = sUiLayer;
        }

		/// <summary>
		/// Search component in parents.
		/// </summary>
		/// <returns>Component with specified type if found in parents.</returns>
		/// <param name="gameObject">Game object.</param>
		/// <typeparam name="T">Type of component.</typeparam>
		public static T FindInParents<T>(GameObject gameObject) where T : Component
		{
			T component = gameObject.GetComponent<T>();
			
			if (component != null)
			{
				return component;
			}
			
			Transform curTransform = gameObject.transform.parent;
			
			while (curTransform != null && component == null)
			{
				component = curTransform.gameObject.GetComponent<T>();
				
				curTransform = curTransform.parent;
			}
			
			return component;
		}

		/// <summary>
		/// Takes screenshot and return it as Texture2D.
		/// </summary>
		/// <returns>Screenshot as Texture2D.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		public static Texture2D TakeScreenshot(int x = 0, int y = 0, int width = 0, int height = 0)
		{
			int screenWidth  = Screen.width;
			int screenHeight = Screen.height;

			if (
				width == 0
				||
				x + width > screenWidth
			   )
			{
				width = screenWidth - x;
			}
			
			if (
				height == 0
			    ||
			    y + height > screenHeight
			   )
			{
				height = screenHeight - y;
			}

			Texture2D texture = new Texture2D(width, height, TextureFormat.RGB24, false);

#if UNITY_PRO_LICENSE
			// TODO: [Minor] Try to use RenderTexture on Unity Pro
			RenderTexture rt = new RenderTexture(screenWidth, screenHeight, 24);
			
			//foreach(Camera cam in Camera.allCameras)
			//{
			//	cam.targetTexture = rt;
			//	cam.Render();
			//	cam.targetTexture = null;
			//}
			
			Camera.main.targetTexture = rt;
			Camera.main.Render();
			Camera.main.targetTexture = null;
			
			RenderTexture.active = rt;
			texture.ReadPixels(new Rect(x, screenHeight - 1 - y - height, width, height), 0, 0);
			RenderTexture.active = null;
			
			UnityEngine.Object.Destroy(rt);
#else
			texture.ReadPixels(new Rect(x, screenHeight - 1 - y - height, width, height), 0, 0);
			texture.Apply();
#endif

			return texture;
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
				RectTransform tempTransform = canvasTransform.parent.transform as RectTransform;

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
		/// <param name="shadowRight">Shadow right offset.</param>
		/// <param name="shadowBottom">Shadow bottom offset.</param>
		public static void FitRectTransformToScreen(
												  	  RectTransform transform
													, float width
													, float height
													, float x            = 0f
													, float y            = 0f
													, float left         = -1f
													, float bottom       = -1f
													, float shadowRight  = 0f
													, float shadowBottom = 0f
												   )
		{
			int screenWidth  = Screen.width;
			int screenHeight = Screen.height;
			
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
				if (left != -1f)
				{
					x = left - width + shadowRight;
					
					if (x < 0f)
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
				if (bottom != -1f)
				{
					y = bottom - height + shadowBottom;
					
					if (y < 0f)
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
													 , float x = 0f
													 , float y = 0f
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
		                                               , float offsetX    = 0f
		                                               , float offsetTop  = 0f
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
													  , float offsetRight = 0f
													  , float offsetTop   = 0f
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
		/// <param name="pivotX">The x coordinate of pivot.</param>
		/// <param name="pivotY">The y coordinate of pivot.</param>
		public static void AlignRectTransformTopStretch(
													      RectTransform transform
													    , float height
														, float offsetTop   = 0f
													    , float offsetLeft  = 0f
													    , float offsetRight = 0f
														, float pivotX      = 0.5f
														, float pivotY      = 0.5f
													   )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 1f);
			transform.anchorMax          = new Vector2(1f, 1f);
			transform.pivot              = new Vector2(pivotX, pivotY);
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
														, float offsetLeft = 0f
														, float offsetY    = 0f
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
														  , float offsetX = 0f
														  , float offsetY = 0f
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
														 , float offsetRight = 0f
														 , float offsetY     = 0f
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
		/// <param name="pivotX">The x coordinate of pivot.</param>
		/// <param name="pivotY">The y coordinate of pivot.</param>
		public static void AlignRectTransformMiddleStretch(
															 RectTransform transform
														   , float height
														   , float offsetY     = 0f
														   , float offsetLeft  = 0f
														   , float offsetRight = 0f
														   , float pivotX      = 0.5f
														   , float pivotY      = 0.5f
														  )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0.5f);
			transform.anchorMax          = new Vector2(1f, 0.5f);
			transform.pivot              = new Vector2(pivotX, pivotY);
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
														, float offsetLeft   = 0f
														, float offsetBottom = 0f
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
														  , float offsetX      = 0f
														  , float offsetBottom = 0f
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
														 , float offsetRight  = 0f
														 , float offsetBottom = 0f
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
		/// <param name="pivotX">The x coordinate of pivot.</param>
		/// <param name="pivotY">The y coordinate of pivot.</param>
		public static void AlignRectTransformBottomStretch(
															 RectTransform transform
														   , float height
														   , float offsetBottom = 0f
														   , float offsetLeft   = 0f
														   , float offsetRight  = 0f
														   , float pivotX       = 0.5f
														   , float pivotY       = 0.5f
														  )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0f);
			transform.anchorMax          = new Vector2(1f, 0f);
			transform.pivot              = new Vector2(pivotX, pivotY);
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
		/// <param name="pivotX">The x coordinate of pivot.</param>
		/// <param name="pivotY">The y coordinate of pivot.</param>
		public static void AlignRectTransformStretchLeft(
														   RectTransform transform
														 , float width
														 , float offsetLeft   = 0f
														 , float offsetTop    = 0f
														 , float offsetBottom = 0f
			         									 , float pivotX       = 0.5f
														 , float pivotY       = 0.5f
														)
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0f);
			transform.anchorMax          = new Vector2(0f, 1f);
			transform.pivot              = new Vector2(pivotX, pivotY);
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
		/// <param name="pivotX">The x coordinate of pivot.</param>
		/// <param name="pivotY">The y coordinate of pivot.</param>
		public static void AlignRectTransformStretchCenter(
															 RectTransform transform
														   , float width
														   , float offsetX      = 0f
														   , float offsetTop    = 0f
														   , float offsetBottom = 0f
														   , float pivotX       = 0.5f
														   , float pivotY       = 0.5f
														  )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0.5f, 0f);
			transform.anchorMax          = new Vector2(0.5f, 1f);
			transform.pivot              = new Vector2(pivotX, pivotY);
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
		/// <param name="pivotX">The x coordinate of pivot.</param>
		/// <param name="pivotY">The y coordinate of pivot.</param>
		public static void AlignRectTransformStretchRight(
															RectTransform transform
														  , float width
														  , float offsetRight  = 0f
														  , float offsetTop    = 0f
														  , float offsetBottom = 0f
														  , float pivotX       = 0.5f
														  , float pivotY       = 0.5f
														 )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(1f, 0f);
			transform.anchorMax          = new Vector2(1f, 1f);
			transform.pivot              = new Vector2(pivotX, pivotY);
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
		/// <param name="pivotX">The x coordinate of pivot.</param>
		/// <param name="pivotY">The y coordinate of pivot.</param>
		public static void AlignRectTransformStretchStretch(
															  RectTransform transform
															, float offsetLeft   = 0f
															, float offsetTop    = 0f
															, float offsetRight  = 0f
															, float offsetBottom = 0f
															, float pivotX       = 0.5f
															, float pivotY       = 0.5f
														   )
		{
			transform.localScale         = new Vector3(1f, 1f, 1f);
			transform.anchorMin          = new Vector2(0f, 0f);
			transform.anchorMax          = new Vector2(1f, 1f);
			transform.pivot              = new Vector2(pivotX, pivotY);
			transform.anchoredPosition3D = new Vector3(0f, 0f, 0f);
			transform.offsetMin          = new Vector2(offsetLeft,    offsetBottom);
			transform.offsetMax          = new Vector2(-offsetRight, -offsetTop);
		}
    }
}
