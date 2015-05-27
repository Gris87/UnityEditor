using UnityEngine;
using UnityEngine.UI;
using UnityTranslation;

using common;



namespace ui
{
	/// <summary>
	/// Toolbar user interface.
	/// </summary>
	public class ToolbarUI
	{
		private ToolbarScript mScript;

		private SpriteState mLeftButtonSpriteState;
		private SpriteState mLeftButtonActiveSpriteState;
		private SpriteState mMiddleButtonSpriteState;
		private SpriteState mMiddleButtonActiveSpriteState;
		private SpriteState mRightButtonSpriteState;
		private SpriteState mRightButtonActiveSpriteState;
		private SpriteState mPopupSpriteState;

		private RectTransform mBasePointTransform;
		private RectTransform mPopupsTransform;



		/// <summary>
		/// Initializes a new instance of the <see cref="ui.ToolbarUI"/> class.
		/// </summary>
		/// <param name="script">Script.</param>
		public ToolbarUI(ToolbarScript script)
		{
			mScript = script;

			mLeftButtonSpriteState         = new SpriteState();
			mLeftButtonActiveSpriteState   = new SpriteState();
			mMiddleButtonSpriteState       = new SpriteState();
			mMiddleButtonActiveSpriteState = new SpriteState();
			mRightButtonSpriteState        = new SpriteState();
			mRightButtonActiveSpriteState  = new SpriteState();
			mPopupSpriteState              = new SpriteState();

			mBasePointTransform = null;
			mPopupsTransform    = null;



			mLeftButtonSpriteState.disabledSprite            = Assets.Toolbar.Textures.toolLeftButton;
			mLeftButtonSpriteState.highlightedSprite         = Assets.Toolbar.Textures.toolLeftButton;
			mLeftButtonSpriteState.pressedSprite             = Assets.Toolbar.Textures.toolLeftButtonPressed;

			mLeftButtonActiveSpriteState.disabledSprite      = Assets.Toolbar.Textures.toolLeftButtonActive;
			mLeftButtonActiveSpriteState.highlightedSprite   = Assets.Toolbar.Textures.toolLeftButtonActive;
			mLeftButtonActiveSpriteState.pressedSprite       = Assets.Toolbar.Textures.toolLeftButtonActivePressed;

			mMiddleButtonSpriteState.disabledSprite          = Assets.Toolbar.Textures.toolMiddleButton;
			mMiddleButtonSpriteState.highlightedSprite       = Assets.Toolbar.Textures.toolMiddleButton;
			mMiddleButtonSpriteState.pressedSprite           = Assets.Toolbar.Textures.toolMiddleButtonPressed;
			
			mMiddleButtonActiveSpriteState.disabledSprite    = Assets.Toolbar.Textures.toolMiddleButtonActive;
			mMiddleButtonActiveSpriteState.highlightedSprite = Assets.Toolbar.Textures.toolMiddleButtonActive;
			mMiddleButtonActiveSpriteState.pressedSprite     = Assets.Toolbar.Textures.toolMiddleButtonActivePressed;
			  
			mRightButtonSpriteState.disabledSprite           = Assets.Toolbar.Textures.toolRightButton;
			mRightButtonSpriteState.highlightedSprite        = Assets.Toolbar.Textures.toolRightButton;
			mRightButtonSpriteState.pressedSprite            = Assets.Toolbar.Textures.toolRightButtonPressed;
			
			mRightButtonActiveSpriteState.disabledSprite     = Assets.Toolbar.Textures.toolRightButtonActive;
			mRightButtonActiveSpriteState.highlightedSprite  = Assets.Toolbar.Textures.toolRightButtonActive;
			mRightButtonActiveSpriteState.pressedSprite      = Assets.Toolbar.Textures.toolRightButtonActivePressed;

			mPopupSpriteState.disabledSprite                 = Assets.Toolbar.Textures.popupButton;
			mPopupSpriteState.highlightedSprite              = Assets.Toolbar.Textures.popupButton;
			mPopupSpriteState.pressedSprite                  = Assets.Toolbar.Textures.popupButton;
		}

		/// <summary>
		/// Setup user interface.
		/// </summary>
		public void SetupUI()
		{
			CreateUI();
		}

		/// <summary>
		/// Creates user interface.
		/// </summary>
		private void CreateUI()
		{
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
			RectTransform scrollAreaContentTransform = scrollAreaContent.AddComponent<RectTransform>();
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
			
			Utils.AlignRectTransformStretchLeft(scrollAreaContentTransform, contentWidth);
			scrollAreaContentTransform.pivot = new Vector2(0f, 0.5f); // TODO: Try to do it in AlignRectTransformStretchLeft
			#endregion

			//===========================================================================
			// ScrollRect Component
			//===========================================================================
			#region ScrollRect Component
			ScrollRect scrollAreaScrollRect = scrollArea.AddComponent<ScrollRect>();
			
			scrollAreaScrollRect.content  = scrollAreaContentTransform;
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
			
			scrollAreaImage.sprite = Assets.Toolbar.Textures.background;
			scrollAreaImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Mask Component
			//===========================================================================
			#region Mask Component
			scrollArea.AddComponent<Mask>();
			#endregion
			#endregion
		}

		/// <summary>
		/// Creates Tools GameObject.
		/// </summary>
		/// <param name="parentTransform">Parent transform.</param>
		/// <param name="contentWidth">Content width.</param>
		private void CreateToolsGameObject(Transform parentTransform, ref float contentWidth)
		{
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
			RectTransform toolsTransform = tools.AddComponent<RectTransform>();
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
			
			toolHandImage.sprite = Assets.Toolbar.Textures.toolLeftButton;
			toolHandImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button toolHandButton = toolHand.AddComponent<Button>();
			
			toolHandButton.targetGraphic = toolHandImage;
			toolHandButton.transition    = Selectable.Transition.SpriteSwap;
			toolHandButton.spriteState   = mLeftButtonSpriteState;
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
			
			handImageImage.sprite = Assets.Toolbar.Textures.toolHand;
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
			
			toolMoveImage.sprite = Assets.Toolbar.Textures.toolMiddleButton;
			toolMoveImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button toolMoveButton = toolMove.AddComponent<Button>();
			
			toolMoveButton.targetGraphic = toolMoveImage;
			toolMoveButton.transition    = Selectable.Transition.SpriteSwap;
			toolMoveButton.spriteState   = mMiddleButtonSpriteState;
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
			
			moveImageImage.sprite = Assets.Toolbar.Textures.toolMove;
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
			
			toolRotateImage.sprite = Assets.Toolbar.Textures.toolMiddleButton;
			toolRotateImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button toolRotateButton = toolRotate.AddComponent<Button>();
			
			toolRotateButton.targetGraphic = toolRotateImage;
			toolRotateButton.transition    = Selectable.Transition.SpriteSwap;
			toolRotateButton.spriteState   = mMiddleButtonSpriteState;
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
			
			rotateImageImage.sprite = Assets.Toolbar.Textures.toolRotate;
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
			
			toolScaleImage.sprite = Assets.Toolbar.Textures.toolMiddleButton;
			toolScaleImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button toolScaleButton = toolScale.AddComponent<Button>();
			
			toolScaleButton.targetGraphic = toolScaleImage;
			toolScaleButton.transition    = Selectable.Transition.SpriteSwap;
			toolScaleButton.spriteState   = mMiddleButtonSpriteState;
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
			
			scaleImageImage.sprite = Assets.Toolbar.Textures.toolScale;
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
			
			toolRectTransformImage.sprite = Assets.Toolbar.Textures.toolRightButton;
			toolRectTransformImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button toolRectTransformButton = toolRectTransform.AddComponent<Button>();
			
			toolRectTransformButton.targetGraphic = toolRectTransformImage;
			toolRectTransformButton.transition    = Selectable.Transition.SpriteSwap;
			toolRectTransformButton.spriteState   = mRightButtonSpriteState;
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
			
			rectTransformImageImage.sprite = Assets.Toolbar.Textures.toolRectTransform;
			rectTransformImageImage.type   = Image.Type.Sliced;
			#endregion
			#endregion
			
			width += buttonWidth;
			#endregion
			#endregion
			
			Utils.AlignRectTransformStretchLeft(toolsTransform, width, contentWidth, 5f, 5f);
			
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

			float width = 0f;
			
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
			RectTransform pointTransform = point.AddComponent<RectTransform>();
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
			
			pointImage.sprite = Assets.Toolbar.Textures.toolLeftButton;
			pointImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button pointButton = point.AddComponent<Button>();
			
			pointButton.targetGraphic = pointImage;
			pointButton.transition    = Selectable.Transition.SpriteSwap;
			pointButton.spriteState   = mLeftButtonSpriteState;
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
            
			pointImageImage.sprite = Assets.Toolbar.Textures.center;
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
            Text pointText = pointTextObject.AddComponent<Text>();
            
			pointText.font      = Assets.Common.Fonts.microsoftSansSerif;
			pointText.fontSize  = 11;
			pointText.alignment = TextAnchor.MiddleLeft;
			pointText.color     = new Color(0f, 0f, 0f, 1f);
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
			RectTransform coordinateSystemTransform = coordinateSystem.AddComponent<RectTransform>();
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
			
			coordinateSystemImage.sprite = Assets.Toolbar.Textures.toolRightButton;
			coordinateSystemImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button coordinateSystemButton = coordinateSystem.AddComponent<Button>();
			
			coordinateSystemButton.targetGraphic = coordinateSystemImage;
			coordinateSystemButton.transition    = Selectable.Transition.SpriteSwap;
			coordinateSystemButton.spriteState   = mRightButtonSpriteState;
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
            
            coordinateSystemImageImage.sprite = Assets.Toolbar.Textures.local;
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
			Text coordinateSystemText = coordinateSystemTextObject.AddComponent<Text>();
            
			coordinateSystemText.font      = Assets.Common.Fonts.microsoftSansSerif;
			coordinateSystemText.fontSize  = 11;
			coordinateSystemText.alignment = TextAnchor.MiddleLeft;
			coordinateSystemText.color     = new Color(0f, 0f, 0f, 1f);
            #endregion
            #endregion
            #endregion
            
            #region Calculate geometry
			float buttonWidth;
			float maxButtonWidth = 0f;

			pointText.text            = Translator.getString(R.sections.Toolbar.strings.pivot);
			coordinateSystemText.text = Translator.getString(R.sections.Toolbar.strings.global);

			buttonWidth = pointText.preferredWidth + 32f;

			if (buttonWidth > maxButtonWidth)
			{
				maxButtonWidth = buttonWidth;
			}

			buttonWidth = coordinateSystemText.preferredWidth + 32f;
			
			if (buttonWidth > maxButtonWidth)
			{
				maxButtonWidth = buttonWidth;
            }

			pointText.text            = Translator.getString(R.sections.Toolbar.strings.center);
			coordinateSystemText.text = Translator.getString(R.sections.Toolbar.strings.local);

			buttonWidth = pointText.preferredWidth + 32f;
			
			if (buttonWidth > maxButtonWidth)
			{
				maxButtonWidth = buttonWidth;
			}
			
			buttonWidth = coordinateSystemText.preferredWidth + 32f;
			
			if (buttonWidth > maxButtonWidth)
            {
				maxButtonWidth = buttonWidth;
            }
            
            Utils.AlignRectTransformStretchLeft(pointTransform,            maxButtonWidth + 1, width); // One button overlaps another one
			width += maxButtonWidth;

			Utils.AlignRectTransformStretchLeft(coordinateSystemTransform, maxButtonWidth,     width);
			width += maxButtonWidth;
			#endregion
			#endregion

			Utils.AlignRectTransformStretchLeft(mBasePointTransform, width, contentWidth, 8f, 6f);
			
			contentWidth += width;
			#endregion
		}

		/// <summary>
		/// Creates Popups GameObject.
		/// </summary>
		/// <param name="parentTransform">Parent transform.</param>
		/// <param name="contentWidth">Content width.</param>
		private void CreatePopupsGameObject(Transform parentTransform, ref float contentWidth)
		{
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
			
			float width = 0f;
			
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
			RectTransform layersTransform = layers.AddComponent<RectTransform>();
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
			
			layersImage.sprite = Assets.Toolbar.Textures.popupButton;
			layersImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button layersButton = layers.AddComponent<Button>();
			
			layersButton.targetGraphic = layersImage;
			layersButton.transition    = Selectable.Transition.SpriteSwap;
			layersButton.spriteState   = mPopupSpriteState;
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
			Utils.AlignRectTransformStretchStretch(layersTextTransform, 8f, 0f, 16f, 0f);
			#endregion
			
			//===========================================================================
			// Text Component
			//===========================================================================
			#region Text Component
			Text layersText = layersTextObject.AddComponent<Text>();
			
			layersText.font      = Assets.Common.Fonts.microsoftSansSerif;
			layersText.fontSize  = 11;
			layersText.alignment = TextAnchor.MiddleLeft;
			layersText.color     = new Color(0f, 0f, 0f, 1f);
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
			RectTransform layoutTransform = layout.AddComponent<RectTransform>();
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
			
			layoutImage.sprite = Assets.Toolbar.Textures.popupButton;
			layoutImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button layoutButton = layout.AddComponent<Button>();
			
			layoutButton.targetGraphic = layoutImage;
			layoutButton.transition    = Selectable.Transition.SpriteSwap;
			layoutButton.spriteState   = mPopupSpriteState;
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
			Utils.AlignRectTransformStretchStretch(layoutTextTransform, 8f, 0f, 16f, 0f);
			#endregion
			
			//===========================================================================
			// Text Component
			//===========================================================================
			#region Text Component
			Text layoutText = layoutTextObject.AddComponent<Text>();
			
			layoutText.font      = Assets.Common.Fonts.microsoftSansSerif;
			layoutText.fontSize  = 11;
			layoutText.alignment = TextAnchor.MiddleLeft;
			layoutText.color     = new Color(0f, 0f, 0f, 1f);
			#endregion
			#endregion
			#endregion
			
			#region Calculate geometry
			float buttonWidth;
			float maxButtonWidth = 0f;
			
			layersText.text = Translator.getString(R.sections.Toolbar.strings.layers);
			layoutText.text = Translator.getString(R.sections.Toolbar.strings.layout);
			
			buttonWidth = layersText.preferredWidth + 32f;
			
			if (buttonWidth > maxButtonWidth)
			{
				maxButtonWidth = buttonWidth;
			}
			
			buttonWidth = layoutText.preferredWidth + 32f;
			
			if (buttonWidth > maxButtonWidth)
			{
				maxButtonWidth = buttonWidth;
			}
			
			Utils.AlignRectTransformStretchLeft(layersTransform, maxButtonWidth, width); // One button overlaps another one
			width += maxButtonWidth + 10f;
			
			Utils.AlignRectTransformStretchLeft(layoutTransform, maxButtonWidth, width);
			width += maxButtonWidth;
			#endregion
			#endregion

			Utils.AlignRectTransformStretchRight(mPopupsTransform, width, 10f, 7f, 7f);
			
			contentWidth += width + 10f;
			#endregion
		}

		/// <summary>
		/// Creates Playback GameObject.
		/// </summary>
		/// <param name="parentTransform">Parent transform.</param>
		/// <param name="contentWidth">Content width.</param>
		private void CreatePlaybackGameObject(Transform parentTransform, ref float contentWidth)
		{
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
			RectTransform playbackTransform = playback.AddComponent<RectTransform>();
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
			
			playImage.sprite = Assets.Toolbar.Textures.toolLeftButton;
			playImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button playButton = play.AddComponent<Button>();
			
			playButton.targetGraphic = playImage;
			playButton.transition    = Selectable.Transition.SpriteSwap;
			playButton.spriteState   = mLeftButtonSpriteState;
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
			
			playImageImage.sprite = Assets.Toolbar.Textures.play;
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
			
			pauseImage.sprite = Assets.Toolbar.Textures.toolMiddleButton;
			pauseImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button pauseButton = pause.AddComponent<Button>();
			
			pauseButton.targetGraphic = pauseImage;
			pauseButton.transition    = Selectable.Transition.SpriteSwap;
			pauseButton.spriteState   = mMiddleButtonSpriteState;
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
			
			pauseImageImage.sprite = Assets.Toolbar.Textures.pause;
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
			
			stepImage.sprite = Assets.Toolbar.Textures.toolRightButton;
			stepImage.type   = Image.Type.Sliced;
			#endregion
			
			//===========================================================================
			// Button Component
			//===========================================================================
			#region Button Component
			Button stepButton = step.AddComponent<Button>();
			
			stepButton.targetGraphic = stepImage;
			stepButton.transition    = Selectable.Transition.SpriteSwap;
			stepButton.spriteState   = mRightButtonSpriteState;
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
			
			stepImageImage.sprite = Assets.Toolbar.Textures.step;
			stepImageImage.type   = Image.Type.Sliced;
			#endregion
			#endregion
			
			width += buttonWidth;
			#endregion
			#endregion

			int screenWidth = Screen.width;

			if (contentWidth + 40f > screenWidth)
			{
				contentWidth += width + 40f;
			}
			else
			{
				contentWidth = screenWidth;
			}

			float leftEdge  = mBasePointTransform.anchoredPosition.x + mBasePointTransform.sizeDelta.x / 2;
			float rightEdge = contentWidth - mPopupsTransform.sizeDelta.x;

			float offsetX = (rightEdge + leftEdge) / 2 - contentWidth / 2;
			
			Utils.AlignRectTransformMiddleCenter(playbackTransform, width, 22f, offsetX);
			#endregion
		}
	}
}

