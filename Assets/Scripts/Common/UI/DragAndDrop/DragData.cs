using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



namespace Common.UI.DragAndDrop
{
	/// <summary>
	/// Class for holding drag data.
	/// </summary>
	public static class DragData
	{
		/// <summary>
		/// Gets dragging type.
		/// </summary>
		/// <value>Dragging type.</value>
		public static DraggingType type
		{
			get { return mType; }
		}

		/// <summary>
		/// Gets dragging image object.
		/// </summary>
		/// <value>Dragging image object.</value>
		public static GameObject draggingImage
		{
			get { return mDraggingImage; }
        }

		/// <summary>
		/// Gets the x coordinate.
		/// </summary>
		/// <value>The x coordinate.</value>
		public static float x
		{
			get
			{
				if (mDraggingImage != null)
				{
					RectTransform imageTransform = mDraggingImage.transform as RectTransform;

					return imageTransform.offsetMin.x;
				}

				return 0f;
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
				if (mDraggingImage != null)
				{
					RectTransform imageTransform = mDraggingImage.transform as RectTransform;
					
					return -imageTransform.offsetMax.y;
				}
				
				return 0f;
			}
		}

		/// <summary>
		/// Gets the width.
		/// </summary>
		/// <value>Width.</value>
		public static float width
		{
			get { return mWidth; }
        }

		/// <summary>
		/// Gets the height.
		/// </summary>
		/// <value>Height.</value>
		public static float height
		{
			get { return mHeight; }
        }
        

        
        private static DraggingType mType;
		private static GameObject   mDraggingImage;
		private static float        mWidth;
		private static float        mHeight;
		private static float        mDragPosX;
		private static float        mDragPosY;



		/// <summary>
		/// Initializes the <see cref="Common.UI.DragAndDrop.DragData"/> class.
		/// </summary>
		static DragData()
		{
			mType          = DraggingType.None;
			mDraggingImage = null;
			mWidth         = 0f;
			mHeight        = 0f;
			mDragPosX      = 0f;
			mDragPosY      = 0f;
		}

		/// <summary>
		/// Begins dragging according to specified parameters.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		/// <param name="draggingType">Dragging type.</param>
		/// <param name="gameObject">Game object.</param>
		/// <param name="sprite">Sprite image.</param>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		/// <param name="dragPosX">Mouse dragged position X.</param>
		/// <param name="dragPosY">Mouse dragged position Y.</param>
		public static void BeginDrag(
									   PointerEventData eventData
									 , DraggingType draggingType
									 , GameObject gameObject
									 , Sprite sprite
									 , float width
									 , float height
									 , float dragPosX = 0f
									 , float dragPosY = 0f
									)
		{
			if (draggingType == DraggingType.None)
			{
				Debug.LogError("Invalid dragging type value: " + draggingType);
				return;
			}

			if (mType == DraggingType.None)
			{
				Canvas canvas = Utils.FindInParents<Canvas>(gameObject);
				
				if (canvas != null)
				{			
					mType     = draggingType;
					mWidth    = width;
					mHeight   = height;
					mDragPosX = dragPosX;
					mDragPosY = dragPosY;
					
					//===========================================================================
					// Image GameObject
					//===========================================================================
					#region Image GameObject
					mDraggingImage = new GameObject("DraggingImage");
					Utils.InitUIObject(mDraggingImage, canvas.transform);
					
					//===========================================================================
					// RectTransform Component
					//===========================================================================
					#region RectTransform Component
					RectTransform imageTransform = mDraggingImage.AddComponent<RectTransform>();
					Utils.AlignRectTransformTopLeft(imageTransform, mWidth, mHeight);
					#endregion
					
					//===========================================================================
					// CanvasRenderer Component
					//===========================================================================
					#region CanvasRenderer Component
					mDraggingImage.AddComponent<CanvasRenderer>();
					#endregion
					
					//===========================================================================
					// Image Component
					//===========================================================================
					#region Image Component
					Image image = mDraggingImage.AddComponent<Image>();
					
					image.sprite = sprite;
					image.type   = Image.Type.Sliced;
					#endregion

					//===========================================================================
					// IgnoreRaycast Component
					//===========================================================================
					#region IgnoreRaycast Component
					mDraggingImage.AddComponent<IgnoreRaycast>();
                    #endregion
					#endregion

					SetDraggedPosition(eventData);
				}
				else
				{
					Debug.LogError("Canvas not found");
				}
			}
			else
			{
				Debug.LogError("Dragging in progress already");
            }
		}

		/// <summary>
		/// Process dragging.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		public static void Drag(PointerEventData eventData)
		{
			if (mType != DraggingType.None)
			{
				SetDraggedPosition(eventData);
			}
        }
        
		/// <summary>
		/// Ends dragging.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
        public static void EndDrag(PointerEventData eventData)
		{
			if (mType != DraggingType.None)
			{
				UnityEngine.Object.DestroyObject(mDraggingImage);

				mType          = DraggingType.None;
				mDraggingImage = null;
				mWidth         = 0f;
				mHeight        = 0f;
                mDragPosX      = 0f;
                mDragPosY      = 0f;
			}
        }

		/// <summary>
		/// Sets the dragged position.
		/// </summary>
		/// <param name="eventData">Pointer data.</param>
		private static void SetDraggedPosition(PointerEventData eventData)
		{
			float screenHeight = Screen.height;

			RectTransform imageTransform = mDraggingImage.transform as RectTransform;

			float mouseX = eventData.position.x;
			float mouseY = -screenHeight + eventData.position.y;

			imageTransform.offsetMin = new Vector2(mouseX - mDragPosX,          mouseY + mDragPosY - mHeight);
			imageTransform.offsetMax = new Vector2(mouseX - mDragPosX + mWidth, mouseY + mDragPosY);
		}

		/// <summary>
		/// Hides the image.
		/// </summary>
		public static void HideImage()
		{
			if (mDraggingImage != null)
			{
				mDraggingImage.SetActive(false);
			}
		}

		/// <summary>
		/// Shows the image.
		/// </summary>
		public static void ShowImage()
		{
			if (mDraggingImage != null)
			{
				mDraggingImage.SetActive(true);
            }
        }
    }
}