using UnityEngine;



namespace Common.UI.DockWidgets
{
    /// <summary>
    /// Dummy dock widget.
    /// </summary>
    public class DummyDockWidgetScript : DockWidgetScript
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static DummyDockWidgetScript instance
        {
            get { return sInstance; }
        }



        private static DummyDockWidgetScript sInstance = null;



        /// <summary>
        /// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DummyDockWidgetScript"/> class.
        /// </summary>
        private DummyDockWidgetScript()
        {
            // Nothing
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Common.UI.DockWidgets.DummyDockWidgetScript"/> class.
        /// </summary>
        /// <param name="baseScript">Base script.</param>
        public static DummyDockWidgetScript Create(DockWidgetScript baseScript)
        {
            DestroyInstance();

            //***************************************************************************
            // Dummy GameObject
            //***************************************************************************
            #region Dummy GameObject
            GameObject dummy = new GameObject("Dummy");
            Utils.InitUIObject(dummy, Global.dockingAreaScript.transform);

            //===========================================================================
            // DummyDockWidgetScript Component
            //===========================================================================
            #region DummyDockWidgetScript Component
            sInstance = dummy.AddComponent<DummyDockWidgetScript>();

            sInstance.image           = baseScript.image;
            sInstance.tokenId         = baseScript.tokenId;
            sInstance.backgroundColor = Assets.DockWidgets.Colors.dummyBackground;
            #endregion
            #endregion

            return sInstance;
        }

        /// <summary>
        /// Destroies the instance.
        /// </summary>
        public static void DestroyInstance()
        {
            if (sInstance != null)
            {
                sInstance.Destroy();
                sInstance = null;
            }
        }

        /// <summary>
        /// Handler for destroy event.
        /// </summary>
        void OnDestroy()
        {
            if (sInstance == this)
            {
                sInstance = null;
            }
        }
    }
}

