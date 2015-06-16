using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityTranslation;

using Common;
using Common.UI.Windows;



namespace UI.Windows.AboutDialog
{
	/// <summary>
	/// Script that realize about dialog behaviour.
	/// </summary>
	public class AboutDialogScript : WindowScript
	{
		private static readonly float  SCROLL_SPEED   = 0.02f;
		private static readonly string CREDITS        = string.Join(", ", AboutDialogNames.names);        
		private static readonly string SPECIAL_THANKS = "Thanks to Forest 'Yoggy' Johnson, Graham McAllister, David Janik-Jones, Raimund Schumacher, Alan J. Dickins and Emil 'Humus' Persson";




		private ScrollRect mCreditsScrollRect;
		private bool       mIsCreditsDragging;



		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.AboutDialog.AboutDialogScript"/> class.
		/// </summary>
		private AboutDialogScript()
		{
			mCreditsScrollRect = null;
			mIsCreditsDragging = false;
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
			frame           = WindowFrameType.Drawer;
			tokenId         = UnityTranslation.R.sections.WindowTitles.strings.about_unity;
			backgroundColor = new Color(0.6f, 0.6f, 0.6f);
			resizable       = false;
			allowMaximize   = false;

			width  = 570f;
			height = 340f;
			
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
			Text versionText = version.AddComponent<Text>();
			
			versionText.font      = Assets.Common.Fonts.microsoftSansSerif;
			versionText.fontSize  = 11;
			versionText.alignment = TextAnchor.MiddleLeft;
			versionText.color     = new Color(0f, 0f, 0f, 1f);
			versionText.text      = Translator.getString(R.sections.AboutDialog.strings.version, Utils.version()); // TODO: Try to autotranslate somehow
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
			Utils.AlignRectTransformTopStretch(contentsTransform, 0f);
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
			
			creditsText.font      = Assets.Common.Fonts.microsoftSansSerif;
			creditsText.fontSize  = 11;
			creditsText.alignment = TextAnchor.UpperLeft;
			creditsText.color     = new Color(0f, 0f, 0f, 1f);
			creditsText.text      = CREDITS + "\n" + SPECIAL_THANKS;
			#endregion
			#endregion

			Utils.AlignRectTransformTopStretch(contentsTransform, 1600f, 0f, 0f, 0f, 0.5f, 1f);
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

			creditsEventTrigger.delegates = new List<EventTrigger.Entry>();

			EventTrigger.Entry beginDragEvent = new EventTrigger.Entry();
			beginDragEvent.eventID = EventTriggerType.BeginDrag;
			beginDragEvent.callback.AddListener(OnCreditsBeginDrag);
			creditsEventTrigger.delegates.Add(beginDragEvent);

			EventTrigger.Entry endDragEvent = new EventTrigger.Entry();
			endDragEvent.eventID = EventTriggerType.EndDrag;
			endDragEvent.callback.AddListener(OnCreditsEndDrag);
			creditsEventTrigger.delegates.Add(endDragEvent);
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
			Utils.AlignRectTransformTopLeft(monoLogoTextTransform, 200f, 20f, 73f, 217f);
			#endregion
			
			//===========================================================================
			// Text Component
			//===========================================================================
			#region Text Component
			Text monoLogoText = monoLogoTextObject.AddComponent<Text>();
			
			monoLogoText.font      = Assets.Common.Fonts.microsoftSansSerif;
			monoLogoText.fontSize  = 11;
			monoLogoText.alignment = TextAnchor.UpperLeft;
			monoLogoText.color     = new Color(0f, 0f, 0f, 1f);
			monoLogoText.text      = Translator.getString(R.sections.AboutDialog.strings.scripting_powered_by); // TODO: Try to autotranslate somehow
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
			Utils.AlignRectTransformTopLeft(monoLogoTextTransform2, 200f, 20f, 73f, 239f);
			#endregion
			
			//===========================================================================
			// Text Component
			//===========================================================================
			#region Text Component
			Text monoLogoText2 = monoLogoTextObject2.AddComponent<Text>();
			
			monoLogoText2.font      = Assets.Common.Fonts.microsoftSansSerif;
			monoLogoText2.fontSize  = 11;
			monoLogoText2.alignment = TextAnchor.UpperLeft;
			monoLogoText2.color     = new Color(0f, 0f, 0f, 1f);
			monoLogoText2.text      = Translator.getString(R.sections.AboutDialog.strings.novell_copyright); // TODO: Try to autotranslate somehow
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
			Utils.AlignRectTransformTopLeft(physXLogoTextTransform, 165f, 20f, 405f, 217f);
			#endregion
			
			//===========================================================================
			// Text Component
			//===========================================================================
			#region Text Component
			Text physXLogoText = physXLogoTextObject.AddComponent<Text>();
			
			physXLogoText.font      = Assets.Common.Fonts.microsoftSansSerif;
			physXLogoText.fontSize  = 11;
			physXLogoText.alignment = TextAnchor.UpperLeft;
			physXLogoText.color     = new Color(0f, 0f, 0f, 1f);
			physXLogoText.text      = Translator.getString(R.sections.AboutDialog.strings.physics_powered_by); // TODO: Try to autotranslate somehow
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
			Utils.AlignRectTransformTopLeft(physXLogoTextTransform2, 165f, 20f, 405f, 239f);
			#endregion
			
			//===========================================================================
			// Text Component
			//===========================================================================
			#region Text Component
			Text physXLogoText2 = physXLogoTextObject2.AddComponent<Text>();
			
			physXLogoText2.font      = Assets.Common.Fonts.microsoftSansSerif;
			physXLogoText2.fontSize  = 11;
			physXLogoText2.alignment = TextAnchor.UpperLeft;
			physXLogoText2.color     = new Color(0f, 0f, 0f, 1f);
			physXLogoText2.text      = Translator.getString(R.sections.AboutDialog.strings.nvidia_copyright); // TODO: Try to autotranslate somehow
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
			Utils.AlignRectTransformTopLeft(copyrightTransform, 280f, 20f, 8f, 312f);
			#endregion
			
			//===========================================================================
			// Text Component
			//===========================================================================
			#region Text Component
			Text copyrightText = copyright.AddComponent<Text>();
			
			copyrightText.font      = Assets.Common.Fonts.microsoftSansSerif;
			copyrightText.fontSize  = 11;
			copyrightText.alignment = TextAnchor.LowerLeft;
			copyrightText.color     = new Color(0f, 0f, 0f, 1f);
			copyrightText.text      = Translator.getString(R.sections.AboutDialog.strings.unity_copyright); // TODO: Try to autotranslate somehow
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
			Text licenseText = license.AddComponent<Text>();
			
			licenseText.font      = Assets.Common.Fonts.microsoftSansSerif;
			licenseText.fontSize  = 11;
			licenseText.alignment = TextAnchor.LowerLeft;
			licenseText.color     = new Color(0f, 0f, 0f, 1f);
			licenseText.text      = Translator.getString(R.sections.AboutDialog.strings.license, License.type, License.serialNumber); // TODO: Try to autotranslate somehow
			#endregion
			#endregion
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		public override void OnDestroy()
		{
			base.OnDestroy();
			
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
		public override void Update()
		{
			base.Update();

			if (!mIsCreditsDragging)
			{
				mCreditsScrollRect.verticalNormalizedPosition -= SCROLL_SPEED * Time.deltaTime;

				if (mCreditsScrollRect.verticalNormalizedPosition < 0f)
				{
					mCreditsScrollRect.verticalNormalizedPosition = 1f;
				}
			}

			// TODO: Internal Mode
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
	}
}

