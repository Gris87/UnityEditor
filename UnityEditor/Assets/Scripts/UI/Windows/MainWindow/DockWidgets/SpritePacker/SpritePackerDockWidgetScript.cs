using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.SpritePacker
{
    /// <summary>
    /// Script that realize spritePacker dock widget behaviour.
    /// </summary>
    public class SpritePackerDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.SpritePacker.SpritePackerDockWidgetScript"/> class.
        /// </summary>
        private SpritePackerDockWidgetScript()
            : base()
        {
            DebugEx.Verbose("Created SpritePackerDockWidgetScript object");

            image   = Assets.Windows.MainWindow.DockWidgets.SpritePacker.Textures.icon.sprite;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.sprite_packer;
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="UI.Windows.MainWindow.DockWidgets.SpritePacker.SpritePackerDockWidgetScript"/> class.
        /// </summary>
        public static SpritePackerDockWidgetScript Create()
        {
            DebugEx.Verbose("SpritePackerDockWidgetScript.Create()");

            if (Global.spritePackerDockWidgetScript == null)
            {
                //***************************************************************************
                // SpritePacker GameObject
                //***************************************************************************
                #region SpritePacker GameObject
                GameObject spritePacker = new GameObject("SpritePacker");
                Utils.InitUIObject(spritePacker, Global.dockingAreaScript.transform);

                //===========================================================================
                // SpritePackerDockWidgetScript Component
                //===========================================================================
                #region SpritePackerDockWidgetScript Component
                Global.spritePackerDockWidgetScript = spritePacker.AddComponent<SpritePackerDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.spritePackerDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
			DebugEx.VerboseFormat("SpritePackerDockWidgetScript.CreateContent(contentTransform = {0})", contentTransform);

            backgroundColor = Assets.Windows.MainWindow.DockWidgets.SpritePacker.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            DebugEx.Verbose("SpritePackerDockWidgetScript.OnDestroy()");

            if (Global.spritePackerDockWidgetScript == this)
            {
                Global.spritePackerDockWidgetScript = null;
            }
            else
            {
                DebugEx.Fatal("Unexpected behaviour in SpritePackerDockWidgetScript.OnDestroy()");
            }
        }
    }
}
