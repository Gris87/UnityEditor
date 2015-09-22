using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Animation
{
    /// <summary>
    /// Script that realize animation dock widget behaviour.
    /// </summary>
    public class AnimationDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Animation.AnimationDockWidgetScript"/> class.
        /// </summary>
        private AnimationDockWidgetScript()
            : base()
        {
            DebugEx.Verbose("Created AnimationDockWidgetScript object");

            image   = Assets.Windows.MainWindow.DockWidgets.Animation.Textures.icon.sprite;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.animation;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.Animation.AnimationDockWidgetScript"/> class.
        /// </summary>
        public static AnimationDockWidgetScript Create()
        {
            DebugEx.Verbose("AnimationDockWidgetScript.Create()");

            if (Global.animationDockWidgetScript == null)
            {
                //***************************************************************************
                // Animation GameObject
                //***************************************************************************
                #region Animation GameObject
                GameObject animation = new GameObject("Animation");
                Utils.InitUIObject(animation, Global.dockingAreaScript.transform);

                //===========================================================================
                // AnimationDockWidgetScript Component
                //===========================================================================
                #region AnimationDockWidgetScript Component
                Global.animationDockWidgetScript = animation.AddComponent<AnimationDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.animationDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
			DebugEx.VerboseFormat("AnimationDockWidgetScript.CreateContent(contentTransform = {0})", contentTransform);

            backgroundColor = Assets.Windows.MainWindow.DockWidgets.Animation.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            DebugEx.Verbose("AnimationDockWidgetScript.OnDestroy()");

            if (Global.animationDockWidgetScript == this)
            {
                Global.animationDockWidgetScript = null;
            }
            else
            {
                DebugEx.Fatal("Unexpected behaviour in AnimationDockWidgetScript.OnDestroy()");
            }
        }
    }
}
