using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.AnimatorParameter
{
    /// <summary>
    /// Script that realize animatorParameter dock widget behaviour.
    /// </summary>
    public class AnimatorParameterDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.AnimatorParameter.AnimatorParameterDockWidgetScript"/> class.
        /// </summary>
        private AnimatorParameterDockWidgetScript()
            : base()
        {
			image   = Assets.Windows.MainWindow.DockWidgets.AnimatorParameter.Textures.icon.sprite;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.animator_parameter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.AnimatorParameter.AnimatorParameterDockWidgetScript"/> class.
        /// </summary>
        public static AnimatorParameterDockWidgetScript Create()
        {
            if (Global.animatorParameterDockWidgetScript == null)
            {
                //***************************************************************************
                // AnimatorParameter GameObject
                //***************************************************************************
                #region AnimatorParameter GameObject
                GameObject animatorParameter = new GameObject("AnimatorParameter");
                Utils.InitUIObject(animatorParameter, Global.dockingAreaScript.transform);

                //===========================================================================
                // AnimatorParameterDockWidgetScript Component
                //===========================================================================
                #region AnimatorParameterDockWidgetScript Component
                Global.animatorParameterDockWidgetScript = animatorParameter.AddComponent<AnimatorParameterDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.animatorParameterDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
            backgroundColor = Assets.Windows.MainWindow.DockWidgets.AnimatorParameter.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            if (Global.animatorParameterDockWidgetScript == this)
            {
                Global.animatorParameterDockWidgetScript = null;
            }
            else
            {
                Debug.LogError("Unexpected behaviour in AnimatorParameterDockWidgetScript.OnDestroy");
            }
        }
    }
}
