using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.OcclusionCulling
{
	/// <summary>
	/// Script that realize occlusionCulling dock widget behaviour.
	/// </summary>
	public class OcclusionCullingDockWidgetScript : DockWidgetScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.OcclusionCulling.OcclusionCullingDockWidgetScript"/> class.
		/// </summary>
		private OcclusionCullingDockWidgetScript()
			: base()
		{
			image   = Assets.Windows.MainWindow.DockWidgets.OcclusionCulling.Textures.icon;
			tokenId = UnityTranslation.R.sections.DockWidgets.strings.occlusion_culling;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.OcclusionCulling.OcclusionCullingDockWidgetScript"/> class.
		/// </summary>
		public static OcclusionCullingDockWidgetScript Create()
		{
			if (Global.occlusionCullingDockWidgetScript == null)
			{
				//***************************************************************************
				// OcclusionCulling GameObject
				//***************************************************************************
				#region OcclusionCulling GameObject
				GameObject occlusionCulling = new GameObject("OcclusionCulling");
				Utils.InitUIObject(occlusionCulling, Global.dockingAreaScript.transform);
				
				//===========================================================================
				// OcclusionCullingDockWidgetScript Component
				//===========================================================================
				#region OcclusionCullingDockWidgetScript Component
				Global.occlusionCullingDockWidgetScript = occlusionCulling.AddComponent<OcclusionCullingDockWidgetScript>();
				#endregion
				#endregion
			}
			
			return Global.occlusionCullingDockWidgetScript;
		}
		
		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		protected override void CreateContent(Transform contentTransform)
		{
			backgroundColor = Assets.Windows.MainWindow.DockWidgets.OcclusionCulling.Colors.background;
			
			// TODO: Implement
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{			
			if (Global.occlusionCullingDockWidgetScript == this)
			{
				Global.occlusionCullingDockWidgetScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in OcclusionCullingDockWidgetScript.OnDestroy");
			}
		}
	}
}