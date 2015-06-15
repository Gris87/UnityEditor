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
			Utils.AlignRectTransformTopLeft(unityLogoTransform, 128f, 64f);
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
		}
	}
}

