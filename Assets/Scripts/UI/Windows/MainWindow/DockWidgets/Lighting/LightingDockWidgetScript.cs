using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Lighting
{
	/// <summary>
	/// Script that realize lighting dock widget behaviour.
	/// </summary>
	public class LightingDockWidgetScript : DockWidgetScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Lighting.LightingDockWidgetScript"/> class.
		/// </summary>
		private LightingDockWidgetScript()
			: base()
		{
			image   = Assets.Windows.MainWindow.DockWidgets.Lighting.Textures.icon;
			tokenId = UnityTranslation.R.sections.DockWidgets.strings.lighting;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Lighting.LightingDockWidgetScript"/> class.
		/// </summary>
		public static LightingDockWidgetScript Create()
		{
			if (Global.lightingDockWidgetScript == null)
			{
				//***************************************************************************
				// Lighting GameObject
				//***************************************************************************
				#region Lighting GameObject
				GameObject lighting = new GameObject("Lighting");
				Utils.InitUIObject(lighting, Global.dockingAreaScript.transform);
				
				//===========================================================================
				// LightingDockWidgetScript Component
				//===========================================================================
				#region LightingDockWidgetScript Component
				Global.lightingDockWidgetScript = lighting.AddComponent<LightingDockWidgetScript>();
				#endregion
				#endregion
			}
			
			return Global.lightingDockWidgetScript;
		}
		
		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		protected override void CreateContent(Transform contentTransform)
		{
			backgroundColor = Assets.Windows.MainWindow.DockWidgets.Lighting.Colors.background;
			
			// TODO: Implement
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{			
			if (Global.lightingDockWidgetScript == this)
			{
				Global.lightingDockWidgetScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in LightingDockWidgetScript.OnDestroy");
			}
		}
	}
}