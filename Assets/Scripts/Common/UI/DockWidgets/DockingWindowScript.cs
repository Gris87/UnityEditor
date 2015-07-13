using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Common.UI.Windows;



namespace Common.UI.DockWidgets
{
    #region Internal namespace
    namespace Internal
    {
        /// <summary>
        /// Docking window common things.
        /// </summary>
        static class DockingWindowCommon
        {
            public static SpriteState maximizeButtonSpriteState;
            public static SpriteState closeButtonSpriteState;



            /// <summary>
            /// Initializes the <see cref="Common.UI.DockWidgets.Internal.DockingWindowCommon"/> class.
            /// </summary>
            static DockingWindowCommon()
            {
                maximizeButtonSpriteState = new SpriteState();
                closeButtonSpriteState    = new SpriteState();

                maximizeButtonSpriteState.disabledSprite    = Assets.DockWidgets.Textures.maximizeButtonDisabled;
                maximizeButtonSpriteState.highlightedSprite = Assets.DockWidgets.Textures.maximizeButtonHighlighted;
                maximizeButtonSpriteState.pressedSprite     = Assets.DockWidgets.Textures.maximizeButtonPressed;

                closeButtonSpriteState.disabledSprite       = Assets.DockWidgets.Textures.closeButtonDisabled;
                closeButtonSpriteState.highlightedSprite    = Assets.DockWidgets.Textures.closeButtonHighlighted;
                closeButtonSpriteState.pressedSprite        = Assets.DockWidgets.Textures.closeButtonPressed;
            }
        }
    }
    #endregion



    /// <summary>
    /// Script that realize docking window behaviour.
    /// </summary>
    public class DockingWindowScript : WindowScript, IPointerDownHandler
    {
        /// <summary>
        /// Gets or sets the dock widget.
        /// </summary>
        /// <value>The dock widget.</value>
        public DockWidgetScript dockWidget
        {
            get { return mDockWidget;  }
            set { mDockWidget = value; }
        }



        private DockWidgetScript  mDockWidget;

        private DockingAreaScript mDockingAreaScript;



        /// <summary>
        /// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DockingWindowScript"/> class.
        /// </summary>
        private DockingWindowScript()
            : base()
        {
            mDockWidget        = null;

            mDockingAreaScript = null;

            frame           = WindowFrameType.SingleFrame;
            backgroundColor = Assets.DockWidgets.Colors.dockingWindow;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        /// <param name="width">Width of content.</param>
        /// <param name="height">Height of content.</param>
        protected override void CreateContent(Transform contentTransform, out float width, out float height)
        {
            width  = 200f;
            height = 200f;

            //***************************************************************************
            // Header GameObject
            //***************************************************************************
            #region Header GameObject
            GameObject header = new GameObject("Header");
            Utils.InitUIObject(header, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform headerTransform = header.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopStretch(headerTransform, 5f);
            #endregion

            //***************************************************************************
            // Close GameObject
            //***************************************************************************
            #region Close GameObject
            GameObject closeGameObject = new GameObject("Close");
            Utils.InitUIObject(closeGameObject, header.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform closeTransform = closeGameObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopRight(closeTransform, 13f, 13f, 4f, 0f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            closeGameObject.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image closeImage = closeGameObject.AddComponent<Image>();

            closeImage.sprite = Assets.DockWidgets.Textures.closeButton;
            closeImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button closeButton = closeGameObject.AddComponent<Button>();

            closeButton.targetGraphic = closeImage;
            closeButton.transition    = Selectable.Transition.SpriteSwap;
            closeButton.spriteState   = Internal.DockingWindowCommon.closeButtonSpriteState;
            closeButton.onClick.AddListener(Close);
            #endregion
            #endregion

            //***************************************************************************
            // Maximize GameObject
            //***************************************************************************
            #region Maximize GameObject
            GameObject maximizeGameObject = new GameObject("Maximize");
            Utils.InitUIObject(maximizeGameObject, header.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform maximizeTransform = maximizeGameObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopRight(maximizeTransform, 13f, 13f, 20f, 0f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            maximizeGameObject.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image maximizeImage = maximizeGameObject.AddComponent<Image>();

            maximizeImage.sprite = Assets.DockWidgets.Textures.maximizeButton;
            maximizeImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button maximizeButton = maximizeGameObject.AddComponent<Button>();

            maximizeButton.targetGraphic = maximizeImage;
            maximizeButton.transition    = Selectable.Transition.SpriteSwap;
            maximizeButton.spriteState   = Internal.DockingWindowCommon.maximizeButtonSpriteState;
            maximizeButton.onClick.AddListener(OnMaximizeClicked);
            #endregion
            #endregion
            #endregion

            //***************************************************************************
            // DockingArea GameObject
            //***************************************************************************
            #region DockingArea GameObject
            GameObject dockingArea = new GameObject("DockingArea");
            Utils.InitUIObject(dockingArea, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform dockingAreaTransform = dockingArea.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(dockingAreaTransform, 0f, 5f, 0f, 0f);
            #endregion

            //===========================================================================
            // DockingAreaScript Component
            //===========================================================================
            #region DockingAreaScript Component
            mDockingAreaScript = dockingArea.AddComponent<DockingAreaScript>();

            mDockingAreaScript.AddChildlessListener(Close);
            mDockWidget.InsertToDockingArea(mDockingAreaScript);
            #endregion
            #endregion
        }

        /// <summary>
        /// Handler for pointer down event.
        /// </summary>
        /// <param name="eventData">Pointer data.</param>
        public void OnPointerDown(PointerEventData eventData)
        {
            float mouseX = eventData.position.x;
            float mouseY = Screen.height - eventData.position.y;

            float headerX      = contentX;
            float headerY      = contentY;
            float headerWidth  = contentWidth;
            float headerHeight = 21f; // 16f + 5f

            if (
                (mouseX >= headerX) && (mouseX <= headerX + headerWidth)
                &&
                (mouseY >= headerY) && (mouseY <= headerY + headerHeight)
               )
            {
                StartDragging();
            }
        }

        /// <summary>
        /// Handler for resize event.
        /// </summary>
        protected override void OnResize()
        {
            if (mDockingAreaScript != null)
            {
                mDockingAreaScript.OnResize();
            }
        }
    }
}

