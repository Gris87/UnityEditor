using UnityEngine;

using Common;
using Common.UI.DockWidgets;



namespace UI.Windows.MainWindow.DockWidgets.Game
{
    /// <summary>
    /// Script that realize game dock widget behaviour.
    /// </summary>
    public class GameDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Game.GameDockWidgetScript"/> class.
        /// </summary>
        private GameDockWidgetScript()
            : base()
        {
            image   = Assets.Windows.MainWindow.DockWidgets.Game.Textures.icon.sprite;
            tokenId = UnityTranslation.R.sections.DockWidgets.strings.game;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UI.Windows.MainWindow.DockWidgets.Game.GameDockWidgetScript"/> class.
        /// </summary>
        public static GameDockWidgetScript Create()
        {
            if (Global.gameDockWidgetScript == null)
            {
                //***************************************************************************
                // Game GameObject
                //***************************************************************************
                #region Game GameObject
                GameObject game = new GameObject("Game");
                Utils.InitUIObject(game, Global.dockingAreaScript.transform);

                //===========================================================================
                // GameDockWidgetScript Component
                //===========================================================================
                #region GameDockWidgetScript Component
                Global.gameDockWidgetScript = game.AddComponent<GameDockWidgetScript>();
                #endregion
                #endregion
            }

            return Global.gameDockWidgetScript;
        }

        /// <summary>
        /// Creates the content.
        /// </summary>
        /// <param name="contentTransform">Content transform.</param>
        protected override void CreateContent(Transform contentTransform)
        {
            backgroundColor = Assets.Windows.MainWindow.DockWidgets.Game.Colors.background;

            // TODO: [Minor] Implement CreateContent
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            if (Global.gameDockWidgetScript == this)
            {
                Global.gameDockWidgetScript = null;
            }
            else
            {
                Debug.LogError("Unexpected behaviour in GameDockWidgetScript.OnDestroy");
            }
        }
    }
}
