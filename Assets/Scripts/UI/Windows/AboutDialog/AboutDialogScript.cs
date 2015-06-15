using UnityEngine;
using UnityEngine.UI;

using Common;
using Common.UI.Windows;



namespace UI.Windows.AboutDialog
{
	/// <summary>
	/// Script that realize about dialog behaviour.
	/// </summary>
	public class AboutDialogScript : WindowScript
	{
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
		/// Handler for destroy event.
		/// </summary>
		public void OnDestroy()
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
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		/// <param name="width">Width of content.</param>
		/// <param name="height">Height of content.</param>
		protected override void CreateContent(Transform contentTransform, out float width, out float height)
		{
			frame           = WindowFrameType.Drawer;
			tokenId         = UnityTranslation.R.sections.WindowTitles.strings.about_unity;
			backgroundColor = new Color(0.75f, 0.75f, 0.75f);
			resizable       = false;
			allowMaximize   = false;

			width  = 576f;
			height = 364f;
			
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
			versionText.text      = "Version 5.0.2f1 Personal"; // TODO: Try to autotranslate somehow
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
			monoLogoText.text      = "Scripting powered by The Mono Project"; // TODO: Try to autotranslate somehow
			#endregion
			#endregion
		}
	}
}

