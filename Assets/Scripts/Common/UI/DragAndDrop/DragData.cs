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
            get { return sType; }
        }

        /// <summary>
        /// Gets dragging image object.
        /// </summary>
        /// <value>Dragging image object.</value>
        public static GameObject draggingImage
        {
            get { return sDraggingImage; }
        }

        /// <summary>
        /// Gets the x coordinate.
        /// </summary>
        /// <value>The x coordinate.</value>
        public static float x
        {
            get
            {
                if (sDraggingImage != null)
                {
                    RectTransform imageTransform = sDraggingImage.transform as RectTransform;

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
                if (sDraggingImage != null)
                {
                    RectTransform imageTransform = sDraggingImage.transform as RectTransform;

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
            get { return sWidth; }
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>Height.</value>
        public static float height
        {
            get { return sHeight; }
        }



        private static DraggingType sType;
        private static GameObject   sDraggingImage;
        private static float        sWidth;
        private static float        sHeight;
        private static float        sDragPosX;
        private static float        sDragPosY;



        /// <summary>
        /// Initializes the <see cref="Common.UI.DragAndDrop.DragData"/> class.
        /// </summary>
        static DragData()
        {
            sType          = DraggingType.None;
            sDraggingImage = null;
            sWidth         = 0f;
            sHeight        = 0f;
            sDragPosX      = 0f;
            sDragPosY      = 0f;
        }

        /// <summary>
        /// Begins dragging according to specified parameters.
        /// </summary>
        /// <param name="draggingType">Dragging type.</param>
        /// <param name="gameObject">Game object.</param>
        /// <param name="sprite">Sprite image.</param>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        /// <param name="dragPosX">Mouse dragged position X.</param>
        /// <param name="dragPosY">Mouse dragged position Y.</param>
        public static void BeginDrag(
                                       DraggingType draggingType
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

            if (sType == DraggingType.None)
            {
                Canvas canvas = Utils.FindInParents<Canvas>(gameObject);

                if (canvas != null)
                {
                    sType     = draggingType;
                    sWidth    = width;
                    sHeight   = height;
                    sDragPosX = dragPosX;
                    sDragPosY = dragPosY;

                    //===========================================================================
                    // Image GameObject
                    //===========================================================================
                    #region Image GameObject
                    sDraggingImage = new GameObject("DraggingImage");
                    Utils.InitUIObject(sDraggingImage, canvas.transform);

                    //===========================================================================
                    // RectTransform Component
                    //===========================================================================
                    #region RectTransform Component
                    RectTransform imageTransform = sDraggingImage.AddComponent<RectTransform>();
                    Utils.AlignRectTransformTopLeft(imageTransform, sWidth, sHeight);
                    #endregion

                    //===========================================================================
                    // CanvasRenderer Component
                    //===========================================================================
                    #region CanvasRenderer Component
                    sDraggingImage.AddComponent<CanvasRenderer>();
                    #endregion

                    //===========================================================================
                    // Image Component
                    //===========================================================================
                    #region Image Component
                    Image image = sDraggingImage.AddComponent<Image>();

                    image.sprite = sprite;
                    image.type   = Image.Type.Sliced;
                    #endregion

                    //===========================================================================
                    // IgnoreRaycast Component
                    //===========================================================================
                    #region IgnoreRaycast Component
                    sDraggingImage.AddComponent<IgnoreRaycast>();
                    #endregion
                    #endregion

                    SetDraggedPosition();
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
        public static void Drag()
        {
            if (sType != DraggingType.None)
            {
                SetDraggedPosition();
            }
        }

        /// <summary>
        /// Ends dragging.
        /// </summary>
        public static void EndDrag()
        {
            if (sType != DraggingType.None)
            {
                UnityEngine.Object.DestroyObject(sDraggingImage);

                sType          = DraggingType.None;
                sDraggingImage = null;
                sWidth         = 0f;
                sHeight        = 0f;
                sDragPosX      = 0f;
                sDragPosY      = 0f;
            }
        }

        /// <summary>
        /// Sets the dragged position.
        /// </summary>
        private static void SetDraggedPosition()
        {
            float screenHeight = Screen.height;

            RectTransform imageTransform = sDraggingImage.transform as RectTransform;

            float mouseX = Mouse.scaledX;
            float mouseY = Mouse.scaledY;

            imageTransform.offsetMin = new Vector2(mouseX - sDragPosX,          -mouseY + sDragPosY - sHeight);
            imageTransform.offsetMax = new Vector2(mouseX - sDragPosX + sWidth, -mouseY + sDragPosY);
        }

        /// <summary>
        /// Hides the image.
        /// </summary>
        public static void HideImage()
        {
            if (sDraggingImage != null)
            {
                sDraggingImage.SetActive(false);
            }
        }

        /// <summary>
        /// Shows the image.
        /// </summary>
        public static void ShowImage()
        {
            if (sDraggingImage != null)
            {
                sDraggingImage.SetActive(true);
            }
        }
    }
}
