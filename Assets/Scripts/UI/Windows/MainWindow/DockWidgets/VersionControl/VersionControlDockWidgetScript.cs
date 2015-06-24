using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.VersionControl
{
	/// <summary>
	/// Script that realize versionControl dock widget behaviour.
	/// </summary>
	public class VersionControlDockWidgetScript : DockWidgetScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.VersionControl.VersionControlDockWidgetScript"/> class.
		/// </summary>
		private VersionControlDockWidgetScript()
			: base()
		{
			image   = Assets.Windows.MainWindow.DockWidgets.VersionControl.Textures.icon;
			tokenId = UnityTranslation.R.sections.DockWidgets.strings.version_control;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.VersionControl.VersionControlDockWidgetScript"/> class.
		/// </summary>
		public static VersionControlDockWidgetScript Create()
		{
			if (Global.versionControlDockWidgetScript == null)
			{
				//***************************************************************************
				// VersionControl GameObject
				//***************************************************************************
				#region VersionControl GameObject
				GameObject versionControl = new GameObject("VersionControl");
				Utils.InitUIObject(versionControl, Global.dockingAreaScript.transform);
				
				//===========================================================================
				// VersionControlDockWidgetScript Component
				//===========================================================================
				#region VersionControlDockWidgetScript Component
				Global.versionControlDockWidgetScript = versionControl.AddComponent<VersionControlDockWidgetScript>();
				#endregion
				#endregion
			}
			
			return Global.versionControlDockWidgetScript;
		}
		
		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		protected override void CreateContent(Transform contentTransform)
		{
			// TODO: Implement
			backgroundColor = new Color(0f, 0.3f, 0f);
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{
			if (Global.versionControlDockWidgetScript == this)
			{
				Global.versionControlDockWidgetScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in VersionControlDockWidgetScript.OnDestroy");
			}
		}
	}
}