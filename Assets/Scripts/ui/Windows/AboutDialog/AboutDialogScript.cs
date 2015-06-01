using UnityEngine;

using Common;
using UI.Windows.Common;



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
				Global.aboutDialogScript.width  = 100f;
				Global.aboutDialogScript.height = 50f;
				#endregion
				#endregion
			}

			return Global.aboutDialogScript;
		}

		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
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
			width  = 200f;
			height = 100f;
		}
	}
}

