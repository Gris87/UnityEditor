using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.FrameDebugger
{
	/// <summary>
	/// Script that realize frameDebugger dock widget behaviour.
	/// </summary>
	public class FrameDebuggerDockWidgetScript : DockWidgetScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.FrameDebugger.FrameDebuggerDockWidgetScript"/> class.
		/// </summary>
		private FrameDebuggerDockWidgetScript()
			: base()
		{
			image   = Assets.Windows.MainWindow.DockWidgets.FrameDebugger.Textures.icon;
			tokenId = UnityTranslation.R.sections.DockWidgets.strings.frame_debugger;
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.FrameDebugger.FrameDebuggerDockWidgetScript"/> class.
		/// </summary>
		public static FrameDebuggerDockWidgetScript Create()
		{
			if (Global.frameDebuggerDockWidgetScript == null)
			{
				//***************************************************************************
				// FrameDebugger GameObject
				//***************************************************************************
				#region FrameDebugger GameObject
				GameObject frameDebugger = new GameObject("FrameDebugger");
				Utils.InitUIObject(frameDebugger, Global.dockingAreaScript.transform);
				
				//===========================================================================
				// FrameDebuggerDockWidgetScript Component
				//===========================================================================
				#region FrameDebuggerDockWidgetScript Component
				Global.frameDebuggerDockWidgetScript = frameDebugger.AddComponent<FrameDebuggerDockWidgetScript>();
				#endregion
				#endregion
			}
			
			return Global.frameDebuggerDockWidgetScript;
		}
		
		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		protected override void CreateContent(Transform contentTransform)
		{
			backgroundColor = Assets.Windows.MainWindow.DockWidgets.FrameDebugger.Colors.background;
			
			// TODO: [Minor] Implement CreateContent
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{			
			if (Global.frameDebuggerDockWidgetScript == this)
			{
				Global.frameDebuggerDockWidgetScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in FrameDebuggerDockWidgetScript.OnDestroy");
			}
		}
	}
}