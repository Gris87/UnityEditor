using UnityEngine;
using UnityEngine.UI;
using UnityTranslation;

using Common;
using Common.UI.Tooltips;



namespace UI.Windows.MainWindow.Toolbar
{
    /// <summary>
    /// Toolbar user interface.
    /// </summary>
    public class ToolbarUI
    {
        private ToolbarScript mScript;

        private RectTransform mScrollAreaContentTransform;
        private RectTransform mToolsTransform;
        private RectTransform mBasePointTransform;
        private RectTransform mPointTransform;
        private Text          mPointText;
        private RectTransform mCoordinateSystemTransform;
        private Text          mCoordinateSystemText;
        private RectTransform mPlaybackTransform;
        private RectTransform mPopupsTransform;
        private RectTransform mLayersTransform;
        private Text          mLayersText;
        private RectTransform mLayoutTransform;
        private Text          mLayoutText;



        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.Toolbar.ToolbarUI"/> class.
        /// </summary>
        /// <param name="script">Toolbar script.</param>
        public ToolbarUI(ToolbarScript script)
        {
            DebugEx.VerboseFormat("Created ToolbarUI(script = {0}) object", script);

            mScript = script;

            mScrollAreaContentTransform = null;
            mToolsTransform             = null;
            mBasePointTransform         = null;
            mPointTransform             = null;
            mPointText                  = null;
            mCoordinateSystemTransform  = null;
            mCoordinateSystemText       = null;
            mPlaybackTransform          = null;
            mPopupsTransform            = null;
            mLayersTransform            = null;
            mLayersText                 = null;
            mLayoutTransform            = null;
            mLayoutText                 = null;
        }

        /// <summary>
        /// Setup user interface.
        /// </summary>
        public void SetupUI()
        {
            DebugEx.Verbose("ToolbarUI.SetupUI()");

            CreateUI();
        }

        /// <summary>
        /// Release this instance.
        /// </summary>
        public void Release()
        {
			DebugEx.Verbose("ToolbarUI.Release()");

            Translator.RemoveLanguageChangedListener(OnLanguageChanged);
        }

        /// <summary>
        /// Creates user interface.
        /// </summary>
        private void CreateUI()
        {
			DebugEx.Verbose("ToolbarUI.CreateUI()");

            //***************************************************************************
            // ScrollArea GameObject
            //***************************************************************************
            #region ScrollArea GameObject
            GameObject scrollArea = new GameObject("ScrollArea");
            Utils.InitUIObject(scrollArea, mScript.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform scrollAreaTransform = scrollArea.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(scrollAreaTransform);
            #endregion

            //***************************************************************************
            // Content GameObject
            //***************************************************************************
            #region Content GameObject
            GameObject scrollAreaContent = new GameObject("Content");
            Utils.InitUIObject(scrollAreaContent, scrollArea.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mScrollAreaContentTransform = scrollAreaContent.AddComponent<RectTransform>();
            #endregion

            float contentWidth = 10f; // Offset from the left

            //===========================================================================
            // Fill content
            //===========================================================================
            #region Fill content
            CreateToolsGameObject(    scrollAreaContent.transform, ref contentWidth);
            CreateBasePointGameObject(scrollAreaContent.transform, ref contentWidth);
            CreatePopupsGameObject(   scrollAreaContent.transform, ref contentWidth);
            CreatePlaybackGameObject( scrollAreaContent.transform, ref contentWidth);
            #endregion

            Utils.AlignRectTransformStretchLeft(mScrollAreaContentTransform, contentWidth, 0f, 0f, 0f, 0f, 0.5f);
            #endregion

            //===========================================================================
            // ScrollRect Component
            //===========================================================================
            #region ScrollRect Component
            ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>();

            scrollAreaScrollRect.content  = mScrollAreaContentTransform;
            scrollAreaScrollRect.vertical = false;
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            scrollArea.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image scrollAreaImage = scrollArea.AddComponent<Image>();

            scrollAreaImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.background.sprite;
            scrollAreaImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Mask Component
            //===========================================================================
            #region Mask Component
            scrollArea.AddComponent<Mask>();
            #endregion
            #endregion

            Translator.AddLanguageChangedListener(OnLanguageChanged);
        }

        /// <summary>
        /// Creates Tools GameObject.
        /// </summary>
        /// <param name="parentTransform">Parent transform.</param>
        /// <param name="contentWidth">Content width.</param>
        private void CreateToolsGameObject(Transform parentTransform, ref float contentWidth)
        {
			DebugEx.VerboseFormat("ToolbarUI.CreateToolsGameObject(parentTransform = {0}, contentWidth = {1})", parentTransform, contentWidth);

            //***************************************************************************
            // Tools GameObject
            //***************************************************************************
            #region Tools GameObject
            GameObject tools = new GameObject("Tools");
            Utils.InitUIObject(tools, parentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mToolsTransform = tools.AddComponent<RectTransform>();
            #endregion

            float width = 0f;

            //===========================================================================
            // Fill content
            //===========================================================================
            #region Fill content
            float buttonWidth = 32f;

            //***************************************************************************
            // ToolHand GameObject
            //***************************************************************************
            #region ToolHand GameObject
            GameObject toolHand = new GameObject("ToolHand");
            Utils.InitUIObject(toolHand, tools.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform toolHandTransform = toolHand.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchLeft(toolHandTransform, buttonWidth + 1, width); // One button overlaps another one
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            toolHand.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image toolHandImage = toolHand.AddComponent<Image>();

            toolHandImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolLeftButton.sprite;
            toolHandImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button toolHandButton = toolHand.AddComponent<Button>();

            toolHandButton.targetGraphic = toolHandImage;
            toolHandButton.transition    = Selectable.Transition.SpriteSwap;
            toolHandButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.leftButton.spriteState;
            toolHandButton.onClick.AddListener(mScript.OnToolHandClicked);
            #endregion

            //***************************************************************************
            // HandImage GameObject
            //***************************************************************************
            #region HandImage GameObject
            GameObject handImage = new GameObject("Image");
            Utils.InitUIObject(handImage, toolHand.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform handImageTransform = handImage.AddComponent<RectTransform>();
            Utils.AlignRectTransformMiddleCenter(handImageTransform, 16f, 16f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            handImage.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image handImageImage = handImage.AddComponent<Image>();

            handImageImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolHand.sprite;
            handImageImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            width += buttonWidth;
            #endregion

            //***************************************************************************
            // ToolMove GameObject
            //***************************************************************************
            #region ToolMove GameObject
            GameObject toolMove = new GameObject("ToolMove");
            Utils.InitUIObject(toolMove, tools.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform toolMoveTransform = toolMove.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchLeft(toolMoveTransform, buttonWidth + 1, width); // One button overlaps another one
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            toolMove.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image toolMoveImage = toolMove.AddComponent<Image>();

            toolMoveImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolMiddleButton.sprite;
            toolMoveImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button toolMoveButton = toolMove.AddComponent<Button>();

            toolMoveButton.targetGraphic = toolMoveImage;
            toolMoveButton.transition    = Selectable.Transition.SpriteSwap;
            toolMoveButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.middleButton.spriteState;
            toolMoveButton.onClick.AddListener(mScript.OnToolMoveClicked);
            #endregion

            //***************************************************************************
            // MoveImage GameObject
            //***************************************************************************
            #region MoveImage GameObject
            GameObject moveImage = new GameObject("Image");
            Utils.InitUIObject(moveImage, toolMove.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform moveImageTransform = moveImage.AddComponent<RectTransform>();
            Utils.AlignRectTransformMiddleCenter(moveImageTransform, 16f, 16f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            moveImage.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image moveImageImage = moveImage.AddComponent<Image>();

            moveImageImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolMove.sprite;
            moveImageImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            width += buttonWidth;
            #endregion

            //***************************************************************************
            // ToolRotate GameObject
            //***************************************************************************
            #region ToolRotate GameObject
            GameObject toolRotate = new GameObject("ToolRotate");
            Utils.InitUIObject(toolRotate, tools.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform toolRotateTransform = toolRotate.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchLeft(toolRotateTransform, buttonWidth + 1, width); // One button overlaps another one
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            toolRotate.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image toolRotateImage = toolRotate.AddComponent<Image>();

            toolRotateImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolMiddleButton.sprite;
            toolRotateImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button toolRotateButton = toolRotate.AddComponent<Button>();

            toolRotateButton.targetGraphic = toolRotateImage;
            toolRotateButton.transition    = Selectable.Transition.SpriteSwap;
            toolRotateButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.middleButton.spriteState;
            toolRotateButton.onClick.AddListener(mScript.OnToolRotateClicked);
            #endregion

            //***************************************************************************
            // RotateImage GameObject
            //***************************************************************************
            #region RotateImage GameObject
            GameObject rotateImage = new GameObject("Image");
            Utils.InitUIObject(rotateImage, toolRotate.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform rotateImageTransform = rotateImage.AddComponent<RectTransform>();
            Utils.AlignRectTransformMiddleCenter(rotateImageTransform, 16f, 16f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            rotateImage.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image rotateImageImage = rotateImage.AddComponent<Image>();

            rotateImageImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolRotate.sprite;
            rotateImageImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            width += buttonWidth;
            #endregion

            //***************************************************************************
            // ToolScale GameObject
            //***************************************************************************
            #region ToolScale GameObject
            GameObject toolScale = new GameObject("ToolScale");
            Utils.InitUIObject(toolScale, tools.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform toolScaleTransform = toolScale.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchLeft(toolScaleTransform, buttonWidth + 1, width); // One button overlaps another one
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            toolScale.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image toolScaleImage = toolScale.AddComponent<Image>();

            toolScaleImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolMiddleButton.sprite;
            toolScaleImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button toolScaleButton = toolScale.AddComponent<Button>();

            toolScaleButton.targetGraphic = toolScaleImage;
            toolScaleButton.transition    = Selectable.Transition.SpriteSwap;
            toolScaleButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.middleButton.spriteState;
            toolScaleButton.onClick.AddListener(mScript.OnToolScaleClicked);
            #endregion

            //***************************************************************************
            // ScaleImage GameObject
            //***************************************************************************
            #region ScaleImage GameObject
            GameObject scaleImage = new GameObject("Image");
            Utils.InitUIObject(scaleImage, toolScale.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform scaleImageTransform = scaleImage.AddComponent<RectTransform>();
            Utils.AlignRectTransformMiddleCenter(scaleImageTransform, 16f, 16f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            scaleImage.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image scaleImageImage = scaleImage.AddComponent<Image>();

            scaleImageImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolScale.sprite;
            scaleImageImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            width += buttonWidth;
            #endregion

            //***************************************************************************
            // ToolRectTransform GameObject
            //***************************************************************************
            #region ToolRectTransform GameObject
            GameObject toolRectTransform = new GameObject("ToolRectTransform");
            Utils.InitUIObject(toolRectTransform, tools.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform toolRectTransformTransform = toolRectTransform.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchLeft(toolRectTransformTransform, buttonWidth, width);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            toolRectTransform.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image toolRectTransformImage = toolRectTransform.AddComponent<Image>();

            toolRectTransformImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolRightButton.sprite;
            toolRectTransformImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button toolRectTransformButton = toolRectTransform.AddComponent<Button>();

            toolRectTransformButton.targetGraphic = toolRectTransformImage;
            toolRectTransformButton.transition    = Selectable.Transition.SpriteSwap;
            toolRectTransformButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.rightButton.spriteState;
            toolRectTransformButton.onClick.AddListener(mScript.OnToolRectTransformClicked);
            #endregion

            //***************************************************************************
            // RectTransformImage GameObject
            //***************************************************************************
            #region RectTransformImage GameObject
            GameObject rectTransformImage = new GameObject("Image");
            Utils.InitUIObject(rectTransformImage, toolRectTransform.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform rectTransformImageTransform = rectTransformImage.AddComponent<RectTransform>();
            Utils.AlignRectTransformMiddleCenter(rectTransformImageTransform, 16f, 16f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            rectTransformImage.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image rectTransformImageImage = rectTransformImage.AddComponent<Image>();

            rectTransformImageImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolRectTransform.sprite;
            rectTransformImageImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            width += buttonWidth;
            #endregion
            #endregion

            Utils.AlignRectTransformStretchLeft(mToolsTransform, width, contentWidth, 5f, 5f);

            contentWidth += width + 20f;
            #endregion
        }

        /// <summary>
        /// Creates BasePoint GameObject.
        /// </summary>
        /// <param name="parentTransform">Parent transform.</param>
        /// <param name="contentWidth">Content width.</param>
        private void CreateBasePointGameObject(Transform parentTransform, ref float contentWidth)
        {
			DebugEx.VerboseFormat("ToolbarUI.CreateBasePointGameObject(parentTransform = {0}, contentWidth = {1})", parentTransform, contentWidth);

            //***************************************************************************
            // BasePoint GameObject
            //***************************************************************************
            #region BasePoint GameObject
            GameObject basePoint = new GameObject("BasePoint");
            Utils.InitUIObject(basePoint, parentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mBasePointTransform = basePoint.AddComponent<RectTransform>();
            #endregion

            //===========================================================================
            // Fill content
            //===========================================================================
            #region Fill content
            //***************************************************************************
            // Point GameObject
            //***************************************************************************
            #region Point GameObject
            GameObject point = new GameObject("Point");
            Utils.InitUIObject(point, basePoint.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mPointTransform = point.AddComponent<RectTransform>();
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            point.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image pointImage = point.AddComponent<Image>();

            pointImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolLeftButton.sprite;
            pointImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button pointButton = point.AddComponent<Button>();

            pointButton.targetGraphic = pointImage;
            pointButton.transition    = Selectable.Transition.SpriteSwap;
            pointButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.leftButton.spriteState;
            pointButton.onClick.AddListener(mScript.OnBasePointClicked);
            #endregion

            //===========================================================================
            // TooltipOwnerScript Component
            //===========================================================================
            #region TooltipOwnerScript Component
            TooltipOwnerScript pointTooltip = point.AddComponent<TooltipOwnerScript>();

            pointTooltip.tokenId = R.sections.Tooltips.strings.center;
            #endregion

            //***************************************************************************
            // PointImage GameObject
            //***************************************************************************
            #region PointImage GameObject
            GameObject pointImageObject = new GameObject("Image");
            Utils.InitUIObject(pointImageObject, point.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform pointImageTransform = pointImageObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchLeft(pointImageTransform, 12f, 8f, 4f, 4f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            pointImageObject.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image pointImageImage = pointImageObject.AddComponent<Image>();

            // TODO: [Trivial] Display button image according to state
            pointImageImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.center.sprite;
            pointImageImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            //***************************************************************************
            // PointText GameObject
            //***************************************************************************
            #region PointText GameObject
            GameObject pointTextObject = new GameObject("Text");
            Utils.InitUIObject(pointTextObject, point.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform pointTextTransform = pointTextObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(pointTextTransform, 24f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mPointText = pointTextObject.AddComponent<Text>();

            Assets.Windows.MainWindow.Toolbar.TextStyles.point.Apply(mPointText);
            #endregion
            #endregion
            #endregion

            //***************************************************************************
            // CoordinateSystem GameObject
            //***************************************************************************
            #region CoordinateSystem GameObject
            GameObject coordinateSystem = new GameObject("CoordinateSystem");
            Utils.InitUIObject(coordinateSystem, basePoint.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mCoordinateSystemTransform = coordinateSystem.AddComponent<RectTransform>();
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            coordinateSystem.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image coordinateSystemImage = coordinateSystem.AddComponent<Image>();

            coordinateSystemImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolRightButton.sprite;
            coordinateSystemImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button coordinateSystemButton = coordinateSystem.AddComponent<Button>();

            coordinateSystemButton.targetGraphic = coordinateSystemImage;
            coordinateSystemButton.transition    = Selectable.Transition.SpriteSwap;
            coordinateSystemButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.rightButton.spriteState;
            coordinateSystemButton.onClick.AddListener(mScript.OnCoordinateSystemClicked);
            #endregion

            //===========================================================================
            // TooltipOwnerScript Component
            //===========================================================================
            #region TooltipOwnerScript Component
            TooltipOwnerScript coordinateSystemTooltip = coordinateSystem.AddComponent<TooltipOwnerScript>();

            coordinateSystemTooltip.tokenId = R.sections.Tooltips.strings.local;
            #endregion

            //***************************************************************************
            // CoordinateSystemImage GameObject
            //***************************************************************************
            #region CoordinateSystemImage GameObject
            GameObject coordinateSystemImageObject = new GameObject("Image");
            Utils.InitUIObject(coordinateSystemImageObject, coordinateSystem.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform coordinateSystemImageTransform = coordinateSystemImageObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchLeft(coordinateSystemImageTransform, 12f, 8f, 4f, 4f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            coordinateSystemImageObject.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image coordinateSystemImageImage = coordinateSystemImageObject.AddComponent<Image>();

            // TODO: [Trivial] Display button image according to state
            coordinateSystemImageImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.local.sprite;
            coordinateSystemImageImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            //***************************************************************************
            // CoordinateSystemText GameObject
            //***************************************************************************
            #region CoordinateSystemText GameObject
            GameObject coordinateSystemTextObject = new GameObject("Text");
            Utils.InitUIObject(coordinateSystemTextObject, coordinateSystem.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform coordinateSystemTextTransform = coordinateSystemTextObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(coordinateSystemTextTransform, 24f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mCoordinateSystemText = coordinateSystemTextObject.AddComponent<Text>();

            Assets.Windows.MainWindow.Toolbar.TextStyles.coordinateSystem.Apply(mCoordinateSystemText);
            #endregion
            #endregion
            #endregion
            #endregion

            UpdateBasePointGameObject(ref contentWidth);
            #endregion
        }

        /// <summary>
        /// Updates BasePoint GameObject.
        /// </summary>
        /// <param name="contentWidth">Content width.</param>
        private void UpdateBasePointGameObject(ref float contentWidth)
        {
			DebugEx.VerboseFormat("ToolbarUI.UpdateBasePointGameObject(contentWidth = {0})", contentWidth);

            float width = 0f;
            float buttonWidth;
            float maxButtonWidth = 0f;

            mPointText.text            = Translator.GetString(R.sections.Toolbar.strings.pivot);
            mCoordinateSystemText.text = Translator.GetString(R.sections.Toolbar.strings.global);

            buttonWidth = mPointText.preferredWidth + 32f;

            if (buttonWidth > maxButtonWidth)
            {
                maxButtonWidth = buttonWidth;
            }

            buttonWidth = mCoordinateSystemText.preferredWidth + 32f;

            if (buttonWidth > maxButtonWidth)
            {
                maxButtonWidth = buttonWidth;
            }

            mPointText.text            = Translator.GetString(R.sections.Toolbar.strings.center);
            mCoordinateSystemText.text = Translator.GetString(R.sections.Toolbar.strings.local);

            buttonWidth = mPointText.preferredWidth + 32f;

            if (buttonWidth > maxButtonWidth)
            {
                maxButtonWidth = buttonWidth;
            }

            buttonWidth = mCoordinateSystemText.preferredWidth + 32f;

            if (buttonWidth > maxButtonWidth)
            {
                maxButtonWidth = buttonWidth;
            }

            // TODO: [Trivial] Display button text according to state

            Utils.AlignRectTransformStretchLeft(mPointTransform,            maxButtonWidth + 1, width); // One button overlaps another one
            width += maxButtonWidth;

            Utils.AlignRectTransformStretchLeft(mCoordinateSystemTransform, maxButtonWidth,     width);
            width += maxButtonWidth;

            Utils.AlignRectTransformStretchLeft(mBasePointTransform, width, contentWidth, 8f, 6f);

            contentWidth += width;
        }

        /// <summary>
        /// Creates Popups GameObject.
        /// </summary>
        /// <param name="parentTransform">Parent transform.</param>
        /// <param name="contentWidth">Content width.</param>
        private void CreatePopupsGameObject(Transform parentTransform, ref float contentWidth)
        {
			DebugEx.VerboseFormat("ToolbarUI.CreatePopupsGameObject(parentTransform = {0}, contentWidth = {1})", parentTransform, contentWidth);

            //***************************************************************************
            // Popups GameObject
            //***************************************************************************
            #region Popups GameObject
            GameObject popups = new GameObject("Popups");
            Utils.InitUIObject(popups, parentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mPopupsTransform = popups.AddComponent<RectTransform>();
            #endregion

            //===========================================================================
            // Fill content
            //===========================================================================
            #region Fill content
            //***************************************************************************
            // Layers GameObject
            //***************************************************************************
            #region Layers GameObject
            GameObject layers = new GameObject("Layers");
            Utils.InitUIObject(layers, popups.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mLayersTransform = layers.AddComponent<RectTransform>();
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            layers.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image layersImage = layers.AddComponent<Image>();

            layersImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.popupButton.sprite;
            layersImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button layersButton = layers.AddComponent<Button>();

            layersButton.targetGraphic = layersImage;
            layersButton.transition    = Selectable.Transition.SpriteSwap;
            layersButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.popup.spriteState;
            layersButton.onClick.AddListener(mScript.OnLayersClicked);
            #endregion

            //===========================================================================
            // TooltipOwnerScript Component
            //===========================================================================
            #region TooltipOwnerScript Component
            TooltipOwnerScript layersTooltip = layers.AddComponent<TooltipOwnerScript>();

            layersTooltip.tokenId = R.sections.Tooltips.strings.layers;
            #endregion

            //***************************************************************************
            // LayersText GameObject
            //***************************************************************************
            #region LayersText GameObject
            GameObject layersTextObject = new GameObject("Text");
            Utils.InitUIObject(layersTextObject, layers.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform layersTextTransform = layersTextObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(
                                                     layersTextTransform
                                                   , layersImage.sprite.border.x + 4f
                                                   , layersImage.sprite.border.w
                                                   , layersImage.sprite.border.z + 4f
                                                   , layersImage.sprite.border.y
                                                  );
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mLayersText = layersTextObject.AddComponent<Text>();

            Assets.Windows.MainWindow.Toolbar.TextStyles.layers.Apply(mLayersText);
            #endregion
            #endregion
            #endregion

            //***************************************************************************
            // Layout GameObject
            //***************************************************************************
            #region Layout GameObject
            GameObject layout = new GameObject("Layout");
            Utils.InitUIObject(layout, popups.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mLayoutTransform = layout.AddComponent<RectTransform>();
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            layout.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image layoutImage = layout.AddComponent<Image>();

            layoutImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.popupButton.sprite;
            layoutImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button layoutButton = layout.AddComponent<Button>();

            layoutButton.targetGraphic = layoutImage;
            layoutButton.transition    = Selectable.Transition.SpriteSwap;
            layoutButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.popup.spriteState;
            layoutButton.onClick.AddListener(mScript.OnLayoutClicked);
            #endregion

            //***************************************************************************
            // LayoutText GameObject
            //***************************************************************************
            #region LayoutText GameObject
            GameObject layoutTextObject = new GameObject("Text");
            Utils.InitUIObject(layoutTextObject, layout.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform layoutTextTransform = layoutTextObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(
                                                     layoutTextTransform
                                                   , layoutImage.sprite.border.x + 4f
                                                   , layoutImage.sprite.border.w
                                                   , layoutImage.sprite.border.z + 4f
                                                   , layoutImage.sprite.border.y
                                                  );
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mLayoutText = layoutTextObject.AddComponent<Text>();

            Assets.Windows.MainWindow.Toolbar.TextStyles.layout.Apply(mLayoutText);
            #endregion
            #endregion
            #endregion
            #endregion

            UpdatePopupsGameObject(ref contentWidth);
            #endregion
        }

        /// <summary>
        /// Updates Popups GameObject.
        /// </summary>
        /// <param name="contentWidth">Content width.</param>
        private void UpdatePopupsGameObject(ref float contentWidth)
        {
			DebugEx.VerboseFormat("ToolbarUI.UpdatePopupsGameObject(contentWidth = {0})", contentWidth);

            float width = 0f;
            float buttonWidth;
            float maxButtonWidth = 0f;

            mLayersText.text = Translator.GetString(R.sections.Toolbar.strings.layers);
            mLayoutText.text = Translator.GetString(R.sections.Toolbar.strings.layout);

            buttonWidth = mLayersText.preferredWidth + 32f;

            if (buttonWidth > maxButtonWidth)
            {
                maxButtonWidth = buttonWidth;
            }

            buttonWidth = mLayoutText.preferredWidth + 32f;

            if (buttonWidth > maxButtonWidth)
            {
                maxButtonWidth = buttonWidth;
            }

            Utils.AlignRectTransformStretchLeft(mLayersTransform, maxButtonWidth, width);
            width += maxButtonWidth + 10f;

            Utils.AlignRectTransformStretchLeft(mLayoutTransform, maxButtonWidth, width);
            width += maxButtonWidth;

            Utils.AlignRectTransformStretchRight(mPopupsTransform, width, 10f, 7f, 7f);

            contentWidth += width + 10f;
        }

        /// <summary>
        /// Creates Playback GameObject.
        /// </summary>
        /// <param name="parentTransform">Parent transform.</param>
        /// <param name="contentWidth">Content width.</param>
        private void CreatePlaybackGameObject(Transform parentTransform, ref float contentWidth)
        {
			DebugEx.VerboseFormat("ToolbarUI.CreatePlaybackGameObject(parentTransform = {0}, contentWidth = {1})", parentTransform, contentWidth);

            //***************************************************************************
            // Playback GameObject
            //***************************************************************************
            #region Playback GameObject
            GameObject playback = new GameObject("Playback");
            Utils.InitUIObject(playback, parentTransform);
            playback.transform.SetSiblingIndex(parentTransform.childCount - 2);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            mPlaybackTransform = playback.AddComponent<RectTransform>();
            #endregion

            float width = 0f;

            //===========================================================================
            // Fill content
            //===========================================================================
            #region Fill content
            float buttonWidth = 32f;

            //***************************************************************************
            // Play GameObject
            //***************************************************************************
            #region Play GameObject
            GameObject play = new GameObject("Play");
            Utils.InitUIObject(play, playback.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform playTransform = play.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchLeft(playTransform, buttonWidth + 1, width); // One button overlaps another one
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            play.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image playImage = play.AddComponent<Image>();

            playImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolLeftButton.sprite;
            playImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button playButton = play.AddComponent<Button>();

            playButton.targetGraphic = playImage;
            playButton.transition    = Selectable.Transition.SpriteSwap;
            playButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.leftButton.spriteState;
            playButton.onClick.AddListener(mScript.OnPlayClicked);
            #endregion

            //***************************************************************************
            // PlayImage GameObject
            //***************************************************************************
            #region PlayImage GameObject
            GameObject playImageObject = new GameObject("Image");
            Utils.InitUIObject(playImageObject, play.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform playImageTransform = playImageObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformMiddleCenter(playImageTransform, 16f, 16f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            playImageObject.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image playImageImage = playImageObject.AddComponent<Image>();

            playImageImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.play.sprite;
            playImageImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            width += buttonWidth;
            #endregion

            //***************************************************************************
            // Pause GameObject
            //***************************************************************************
            #region Pause GameObject
            GameObject pause = new GameObject("Pause");
            Utils.InitUIObject(pause, playback.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform pauseTransform = pause.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchLeft(pauseTransform, buttonWidth + 1, width); // One button overlaps another one
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            pause.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image pauseImage = pause.AddComponent<Image>();

            pauseImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolMiddleButton.sprite;
            pauseImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button pauseButton = pause.AddComponent<Button>();

            pauseButton.targetGraphic = pauseImage;
            pauseButton.transition    = Selectable.Transition.SpriteSwap;
            pauseButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.middleButton.spriteState;
            pauseButton.onClick.AddListener(mScript.OnPauseClicked);
            #endregion

            //***************************************************************************
            // PauseImage GameObject
            //***************************************************************************
            #region PauseImage GameObject
            GameObject pauseImageObject = new GameObject("Image");
            Utils.InitUIObject(pauseImageObject, pause.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform pauseImageTransform = pauseImageObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformMiddleCenter(pauseImageTransform, 16f, 16f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            pauseImageObject.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image pauseImageImage = pauseImageObject.AddComponent<Image>();

            pauseImageImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.pause.sprite;
            pauseImageImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            width += buttonWidth;
            #endregion

            //***************************************************************************
            // Step GameObject
            //***************************************************************************
            #region Step GameObject
            GameObject step = new GameObject("Step");
            Utils.InitUIObject(step, playback.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform stepTransform = step.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchLeft(stepTransform, buttonWidth, width);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            step.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image stepImage = step.AddComponent<Image>();

            stepImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.toolRightButton.sprite;
            stepImage.type   = Image.Type.Sliced;
            #endregion

            //===========================================================================
            // Button Component
            //===========================================================================
            #region Button Component
            Button stepButton = step.AddComponent<Button>();

            stepButton.targetGraphic = stepImage;
            stepButton.transition    = Selectable.Transition.SpriteSwap;
            stepButton.spriteState   = Assets.Windows.MainWindow.Toolbar.SpriteStates.rightButton.spriteState;
            stepButton.onClick.AddListener(mScript.OnStepClicked);
            #endregion

            //***************************************************************************
            // StepImage GameObject
            //***************************************************************************
            #region StepImage GameObject
            GameObject stepImageObject = new GameObject("Image");
            Utils.InitUIObject(stepImageObject, step.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform stepImageTransform = stepImageObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformMiddleCenter(stepImageTransform, 16f, 16f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            stepImageObject.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image stepImageImage = stepImageObject.AddComponent<Image>();

            stepImageImage.sprite = Assets.Windows.MainWindow.Toolbar.Textures.step.sprite;
            stepImageImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            width += buttonWidth;
            #endregion
            #endregion

            float windowWidth = Global.mainWindowScript.contentWidth;

            if (contentWidth + width + 40f > windowWidth)
            {
                contentWidth += width + 40f;
            }
            else
            {
                contentWidth = windowWidth;
            }

            float leftEdge  = mBasePointTransform.anchoredPosition.x + mBasePointTransform.sizeDelta.x / 2;
            float rightEdge = contentWidth - mPopupsTransform.sizeDelta.x;

            float offsetX = (rightEdge + leftEdge) / 2 - contentWidth / 2;

            Utils.AlignRectTransformMiddleCenter(mPlaybackTransform, width, 22f, offsetX);
            #endregion
        }

        /// <summary>
        /// Handler for language changed event.
        /// </summary>
        public void OnLanguageChanged()
        {
			DebugEx.Verbose("ToolbarUI.OnLanguageChanged()");

            float contentWidth = mToolsTransform.sizeDelta.x + 30f;

            UpdateBasePointGameObject(ref contentWidth);
            UpdatePopupsGameObject(ref contentWidth);

            OnResize();
        }

        /// <summary>
        /// Handler for resize event.
        /// </summary>
        public void OnResize()
        {
			DebugEx.Verbose("ToolbarUI.OnResize()");

            float contentWidth = mToolsTransform.sizeDelta.x + mBasePointTransform.sizeDelta.x + mPopupsTransform.sizeDelta.x + 40f;
            float width = mPlaybackTransform.sizeDelta.x;

            float windowWidth = Global.mainWindowScript.contentWidth;

            if (contentWidth + width + 40f > windowWidth)
            {
                contentWidth += width + 40f;
            }
            else
            {
                contentWidth = windowWidth;
            }

            float leftEdge  = mBasePointTransform.anchoredPosition.x + mBasePointTransform.sizeDelta.x / 2;
            float rightEdge = contentWidth - mPopupsTransform.sizeDelta.x;

            float offsetX = (rightEdge + leftEdge) / 2 - contentWidth / 2;

            Utils.AlignRectTransformMiddleCenter(mPlaybackTransform, width, 22f, offsetX);

            mScrollAreaContentTransform.offsetMax = new Vector2(mScrollAreaContentTransform.offsetMin.x + contentWidth, mScrollAreaContentTransform.offsetMax.y);
        }
    }
}

