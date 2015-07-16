using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityTranslation;

using Common;
using Common.UI.Listeners;
using Common.UI.Toasts;
using Common.UI.Windows;



namespace UI.Windows.AboutDialog
{
    /// <summary>
    /// Script that realize about dialog behaviour.
    /// </summary>
    public class AboutDialogScript : WindowScript, EscapeButtonHandler
    {
        private const string WINDOW_KEY           = "AboutDialog";
		private const float  WINDOW_WIDTH         = 570f;
		private const float  WINDOW_HEIGHT        = 340f;
		private const string SCRIPTING_POWERED_BY = "The Mono Project";
		private const string PHYSICS_POWERED_BY   = "PhysX";
        private const string SECRET_CODE          = "internal";
        private const float  SCROLL_SPEED         = 0.02f;



        private static readonly string CREDITS        = string.Join(", ", AboutDialogNames.names);
        private static readonly string SPECIAL_THANKS = "Thanks to Forest 'Yoggy' Johnson, Graham McAllister, David Janik-Jones, Raimund Schumacher, Alan J. Dickins and Emil 'Humus' Persson";



		private ScreenOrientation mScreenOrientation;
        private bool              mIsCreditsDragging;
        private byte              mCurrentSecretChar;

        private Text       mVersionText;
        private ScrollRect mCreditsScrollRect;
        private Text       mMonoLogoText;
        private Text       mMonoLogoText2;
        private Text       mPhysXLogoText;
        private Text       mPhysXLogoText2;
        private Text       mCopyrightText;
        private Text       mLicenseText;



        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.AboutDialog.AboutDialogScript"/> class.
        /// </summary>
        private AboutDialogScript()
            : base()
        {
			mScreenOrientation = ScreenOrientation.Unknown;
            mIsCreditsDragging = false;
            mCurrentSecretChar = 0;

            mVersionText       = null;
            mCreditsScrollRect = null;
            mMonoLogoText      = null;
            mMonoLogoText2     = null;
            mPhysXLogoText     = null;
            mPhysXLogoText2    = null;
            mCopyrightText     = null;
            mLicenseText       = null;

			if (
				WINDOW_WIDTH  <= Utils.scaledScreenWidth
				&&
				WINDOW_HEIGHT <= Utils.scaledScreenHeight
			   )
			{
				frame           = WindowFrameType.Drawer;
				tokenId         = UnityTranslation.R.sections.WindowTitles.strings.about_unity;
				resizable       = false;
				allowMaximize   = false;
			}
			else
			{
				frame = WindowFrameType.Frameless;
				state = WindowState.FullScreen;
			}

			backgroundColor = Assets.Windows.AboutDialog.Colors.background;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.AboutDialog.AboutDialogScript"/> class.
        /// </summary>
        public static AboutDialogScript Create()
        {
            if (Global.aboutDialogScript == null)
            {
                //***************************************************************************
                // AboutDialog GameObject
                //***************************************************************************
                #region AboutDialog GameObject
                GameObject aboutDialog = new GameObject("AboutDialog");
                Utils.InitUIObject(aboutDialog, Global.windowsTransform);

                //===========================================================================
                // AboutDialogScript Component
                //===========================================================================
                #region AboutDialogScript Component
                Global.aboutDialogScript = aboutDialog.AddComponent<AboutDialogScript>();
                #endregion
                #endregion
            }

            return Global.aboutDialogScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        /// <param name="width">Width of content.</param>
        /// <param name="height">Height of content.</param>
        protected override void CreateContent(Transform contentTransform, out float width, out float height)
        {
			width  = WINDOW_WIDTH;
			height = WINDOW_HEIGHT;

            //***************************************************************************
            // UnityLogo GameObject
            //***************************************************************************
            #region UnityLogo GameObject
            GameObject unityLogo = new GameObject("UnityLogo");
            Utils.InitUIObject(unityLogo, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform unityLogoTransform = unityLogo.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopLeft(unityLogoTransform, 123f, 46f, 6f, 14f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            unityLogo.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image unityLogoImage = unityLogo.AddComponent<Image>();

            unityLogoImage.sprite = Assets.Windows.AboutDialog.Textures.unity;
            unityLogoImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            //***************************************************************************
            // Version GameObject
            //***************************************************************************
            #region Version GameObject
            GameObject version = new GameObject("Version");
            Utils.InitUIObject(version, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform versionTransform = version.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopStretch(versionTransform, 12f, 64f, 59f, 4f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mVersionText = version.AddComponent<Text>();

            Assets.Windows.AboutDialog.TextStyles.version.Apply(mVersionText);
            #endregion
            #endregion

            //***************************************************************************
            // Credits GameObject
            //***************************************************************************
            #region Credits GameObject
            GameObject credits = new GameObject("Credits");
            Utils.InitUIObject(credits, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform creditsTransform = credits.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopStretch(creditsTransform, 120f, 87f, 7f, 7f);
            #endregion

            //***************************************************************************
            // Contents GameObject
            //***************************************************************************
            #region Contents GameObject
            GameObject contents = new GameObject("Contents");
            Utils.InitUIObject(contents, credits.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform contentsTransform = contents.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopStretch(contentsTransform, 1600f, 0f, 0f, 0f, 0.5f, 1f);
            #endregion

            //***************************************************************************
            // CreditsText GameObject
            //***************************************************************************
            #region CreditsText GameObject
            GameObject creditsTextObject = new GameObject("CreditsText");
            Utils.InitUIObject(creditsTextObject, contents.transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform creditsTextTransform = creditsTextObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(creditsTextTransform, 0f, 120f, 0f, 120f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            Text creditsText = creditsTextObject.AddComponent<Text>();

            Assets.Windows.AboutDialog.TextStyles.credits.Apply(creditsText);

            creditsText.text = CREDITS + "\n" + SPECIAL_THANKS;
            #endregion
            #endregion
            #endregion

            //===========================================================================
            // ScrollRect Component
            //===========================================================================
            #region ScrollRect Component
            mCreditsScrollRect = credits.AddComponent<ScrollRect>();

            mCreditsScrollRect.content     = contentsTransform;
            mCreditsScrollRect.horizontal  = false;
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            credits.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image creditsImage = credits.AddComponent<Image>();

            creditsImage.color = backgroundColor;
            #endregion

            //===========================================================================
            // Mask Component
            //===========================================================================
            #region Mask Component
            credits.AddComponent<Mask>();
            #endregion

            //===========================================================================
            // EventTrigger Component
            //===========================================================================
            #region EventTrigger Component
            EventTrigger creditsEventTrigger = credits.AddComponent<EventTrigger>();

            creditsEventTrigger.triggers = new List<EventTrigger.Entry>();

            EventTrigger.Entry beginDragEvent = new EventTrigger.Entry();
            beginDragEvent.eventID = EventTriggerType.BeginDrag;
            beginDragEvent.callback.AddListener(OnCreditsBeginDrag);
            creditsEventTrigger.triggers.Add(beginDragEvent);

            EventTrigger.Entry endDragEvent = new EventTrigger.Entry();
            endDragEvent.eventID = EventTriggerType.EndDrag;
            endDragEvent.callback.AddListener(OnCreditsEndDrag);
            creditsEventTrigger.triggers.Add(endDragEvent);
            #endregion
            #endregion

            //***************************************************************************
            // MonoLogo GameObject
            //***************************************************************************
            #region MonoLogo GameObject
            GameObject monoLogo = new GameObject("MonoLogo");
            Utils.InitUIObject(monoLogo, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform monoLogoTransform = monoLogo.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopLeft(monoLogoTransform, 57f, 69f, 9f, 215f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            monoLogo.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image monoLogoImage = monoLogo.AddComponent<Image>();

            monoLogoImage.sprite = Assets.Windows.AboutDialog.Textures.mono;
            monoLogoImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            //***************************************************************************
            // MonoLogoText GameObject
            //***************************************************************************
            #region MonoLogoText GameObject
            GameObject monoLogoTextObject = new GameObject("MonoLogoText");
            Utils.InitUIObject(monoLogoTextObject, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform monoLogoTextTransform = monoLogoTextObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopLeft(monoLogoTextTransform, 200f, 30f, 73f, 217f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mMonoLogoText = monoLogoTextObject.AddComponent<Text>();

            Assets.Windows.AboutDialog.TextStyles.monoLogo.Apply(mMonoLogoText);

			if (state == WindowState.FullScreen)
			{
				mMonoLogoText.text = SCRIPTING_POWERED_BY; 
			}
            #endregion
            #endregion

            //***************************************************************************
            // MonoLogoText2 GameObject
            //***************************************************************************
            #region MonoLogoText2 GameObject
            GameObject monoLogoTextObject2 = new GameObject("MonoLogoText2");
            Utils.InitUIObject(monoLogoTextObject2, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform monoLogoTextTransform2 = monoLogoTextObject2.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopLeft(monoLogoTextTransform2, 200f, 30f, 73f, 249f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mMonoLogoText2 = monoLogoTextObject2.AddComponent<Text>();

            Assets.Windows.AboutDialog.TextStyles.monoLogo2.Apply(mMonoLogoText2);
            #endregion
            #endregion

            //***************************************************************************
            // PhysXLogo GameObject
            //***************************************************************************
            #region PhysXLogo GameObject
            GameObject physXLogo = new GameObject("PhysXLogo");
            Utils.InitUIObject(physXLogo, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform physXLogoTransform = physXLogo.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopLeft(physXLogoTransform, 120f, 42f, 276f, 215f);
            #endregion

            //===========================================================================
            // CanvasRenderer Component
            //===========================================================================
            #region CanvasRenderer Component
            physXLogo.AddComponent<CanvasRenderer>();
            #endregion

            //===========================================================================
            // Image Component
            //===========================================================================
            #region Image Component
            Image physXLogoImage = physXLogo.AddComponent<Image>();

            physXLogoImage.sprite = Assets.Windows.AboutDialog.Textures.physX;
            physXLogoImage.type   = Image.Type.Sliced;
            #endregion
            #endregion

            //***************************************************************************
            // PhysXLogoText GameObject
            //***************************************************************************
            #region PhysXLogoText GameObject
            GameObject physXLogoTextObject = new GameObject("PhysXLogoText");
            Utils.InitUIObject(physXLogoTextObject, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform physXLogoTextTransform = physXLogoTextObject.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopLeft(physXLogoTextTransform, 165f, 30f, 405f, 217f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mPhysXLogoText = physXLogoTextObject.AddComponent<Text>();

            Assets.Windows.AboutDialog.TextStyles.physXLogo.Apply(mPhysXLogoText);

			if (state == WindowState.FullScreen)
			{
				mPhysXLogoText.text = PHYSICS_POWERED_BY;
			}
            #endregion
            #endregion

            //***************************************************************************
            // PhysXLogoText2 GameObject
            //***************************************************************************
            #region PhysXLogoText2 GameObject
            GameObject physXLogoTextObject2 = new GameObject("PhysXLogoText2");
            Utils.InitUIObject(physXLogoTextObject2, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform physXLogoTextTransform2 = physXLogoTextObject2.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopLeft(physXLogoTextTransform2, 165f, 30f, 405f, 249f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mPhysXLogoText2 = physXLogoTextObject2.AddComponent<Text>();

            Assets.Windows.AboutDialog.TextStyles.physXLogo2.Apply(mPhysXLogoText2);
            #endregion
            #endregion

            //***************************************************************************
            // Copyright GameObject
            //***************************************************************************
            #region Copyright GameObject
            GameObject copyright = new GameObject("Copyright");
            Utils.InitUIObject(copyright, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform copyrightTransform = copyright.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopLeft(copyrightTransform, 280f, 30f, 8f, 302f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mCopyrightText = copyright.AddComponent<Text>();

            Assets.Windows.AboutDialog.TextStyles.copyright.Apply(mCopyrightText);
            #endregion
            #endregion

            //***************************************************************************
            // License GameObject
            //***************************************************************************
            #region License GameObject
            GameObject license = new GameObject("License");
            Utils.InitUIObject(license, contentTransform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform licenseTransform = license.AddComponent<RectTransform>();
            Utils.AlignRectTransformTopLeft(licenseTransform, 270f, 40f, 295f, 292f);
            #endregion

            //===========================================================================
            // Text Component
            //===========================================================================
            #region Text Component
            mLicenseText = license.AddComponent<Text>();

            Assets.Windows.AboutDialog.TextStyles.license.Apply(mLicenseText);
            #endregion
            #endregion

			EscapeButtonListenerScript.PushHandlerToTop(this);
            Translator.AddLanguageChangedListener(OnLanguageChanged);
            OnLanguageChanged();

			if (state != WindowState.FullScreen)
			{
				Load(WINDOW_KEY);
			}
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        protected override void OnDestroy()
        {
            base.OnDestroy();

			if (state != WindowState.FullScreen)
			{
	            Save(WINDOW_KEY);
			}

			EscapeButtonListenerScript.RemoveHandler(this);
            Translator.RemoveLanguageChangedListener(OnLanguageChanged);

            if (Global.aboutDialogScript == this)
            {
                Global.aboutDialogScript = null;
            }
            else
            {
                Debug.LogError("Unexpected behaviour in AboutDialogScript.OnDestroy");
            }
        }

        /// <summary>
        /// Update is called once per frame.
        /// </summary>
        protected override void Update()
        {
            base.Update();

            if (!mIsCreditsDragging)
            {
                mCreditsScrollRect.verticalNormalizedPosition -= SCROLL_SPEED * Time.deltaTime;

                if (mCreditsScrollRect.verticalNormalizedPosition < 0f)
                {
                    mCreditsScrollRect.verticalNormalizedPosition = 1f;
                }

                if (selected && InputControl.GetKeyDown((KeyCode)(KeyCode.A + SECRET_CODE[mCurrentSecretChar] - 'a')))
                {
                    ++mCurrentSecretChar;

                    if (mCurrentSecretChar >= SECRET_CODE.Length)
                    {
                        mCurrentSecretChar = 0;

                        Settings.internalMode = !Settings.internalMode;

                        Debug.Log("Internal mode: " + (Settings.internalMode ? "ON" : "OFF"));
                        Toast.Show(contentTransform, R.sections.Toasts.strings.internal_mode, Toast.LENGTH_LONG, Settings.internalMode ? "ON" : "OFF");
                    }
                }
            }
        }

        /// <summary>
        /// Handler for begin drag event.
        /// </summary>
        public void OnCreditsBeginDrag(BaseEventData eventData)
        {
            mIsCreditsDragging = true;
        }

        /// <summary>
        /// Handler for end drag event.
        /// </summary>
        public void OnCreditsEndDrag(BaseEventData eventData)
        {
            mIsCreditsDragging = false;
        }

		/// <summary>
		/// Handler for select event.
		/// </summary>
		protected override void OnSelected()
		{
			EscapeButtonListenerScript.PushHandlerToTop(this);
		}

		/// <summary>
		/// Handles escape button press event.
		/// </summary>
		/// <returns><c>true</c>, if escape button was handled, <c>false</c> otherwise.</returns>
		public bool OnEscapeButtonPressed()
		{
			if (selected)
			{
				Close();

				return true;
			}

			return false;
		}

		/// <summary>
		/// Handler for resize event.
		/// </summary>
		protected override void OnResize()
		{
			if (state == WindowState.FullScreen)
			{
				ScreenOrientation orientation = ScreenOrientation.Unknown;
				
				if (Screen.width > Screen.height)
				{
					orientation = ScreenOrientation.Landscape;
				}
				else
				{
					orientation = ScreenOrientation.Portrait;
				}
				
				if (mScreenOrientation != orientation)
				{
					mScreenOrientation = orientation;
					
					// TODO: [Major] Change widgets geometry
				}
			}
		}

        /// <summary>
        /// Handler for language changed event.
        /// </summary>
        public void OnLanguageChanged()
        {
            mVersionText.text = Translator.GetString(R.sections.AboutDialog.strings.version, AppUtils.GetVersionString());

			if (state != WindowState.FullScreen)
			{
				mMonoLogoText.text = Translator.GetString(R.sections.AboutDialog.strings.scripting_powered_by, SCRIPTING_POWERED_BY);
			}

            mMonoLogoText2.text = "(c) 2011 Novell, Inc.";

			if (state != WindowState.FullScreen)
			{
				mPhysXLogoText.text = Translator.GetString(R.sections.AboutDialog.strings.physics_powered_by, PHYSICS_POWERED_BY);
			}

            mPhysXLogoText2.text = "(c) 2011 NVIDIA Corporation.";
            mCopyrightText.text  = "(c) 2015 Unity Technologies ApS. " + Translator.GetString(R.sections.AboutDialog.strings.all_rights_reserved);
            mLicenseText.text    = Translator.GetString(R.sections.AboutDialog.strings.license, License.TYPE, License.serialNumber);
        }
    }
}

