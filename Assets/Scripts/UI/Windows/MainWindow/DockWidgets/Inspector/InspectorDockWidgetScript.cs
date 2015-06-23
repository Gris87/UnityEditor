using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Inspector
{
	/// <summary>
	/// Script that realize inspector dock widget behaviour.
	/// </summary>
	public class InspectorDockWidgetScript : DockWidgetScript
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Inspector.InspectorDockWidgetScript"/> class.
		/// </summary>
		private InspectorDockWidgetScript()
		{
			// Nothing
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Inspector.InspectorDockWidgetScript"/> class.
		/// </summary>
		public static InspectorDockWidgetScript Create()
		{
			if (Global.inspectorDockWidgetScript == null)
			{
				//***************************************************************************
				// Inspector GameObject
				//***************************************************************************
				#region Inspector GameObject
				GameObject inspector = new GameObject("Inspector");
				Utils.InitUIObject(inspector, Global.dockingAreaScript.transform);
				
				//===========================================================================
				// InspectorDockWidgetScript Component
				//===========================================================================
				#region InspectorDockWidgetScript Component
				Global.inspectorDockWidgetScript = inspector.AddComponent<InspectorDockWidgetScript>();
				#endregion
				#endregion
			}
			
			return Global.inspectorDockWidgetScript;
		}
		
		/// <summary>
		/// Creates the content.
		/// </summary>
		/// <param name="contentTransform">Content transform.</param>
		protected override void CreateContent(Transform contentTransform)
		{
			tokenId = UnityTranslation.R.sections.DockWidgets.strings.inspector;

			// TODO: Implement
			backgroundColor = new Color(0f, 0f, 0.3f);
		}
		
		/// <summary>
		/// Handler for destroy event.
		/// </summary>
		void OnDestroy()
		{			
			if (Global.inspectorDockWidgetScript == this)
			{
				Global.inspectorDockWidgetScript = null;
			}
			else
			{
				Debug.LogError("Unexpected behaviour in InspectorDockWidgetScript.OnDestroy");
			}
		}
	}
}