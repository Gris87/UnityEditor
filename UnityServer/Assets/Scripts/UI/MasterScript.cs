using UnityEngine;
using UnityEngine.UI;

using Common;
using Common.App;
using Common.App.Net;
using Common.UI.Listeners;
using Common.UI.Popups;
using Common.UI.Tooltips;
using Net;
using UI.Windows.MainWindow;



namespace UI
{
    /// <summary>
    /// Master script.
    /// </summary>
    public class MasterScript : MonoBehaviour
    {
        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
			DebugEx.Verbose("MasterScript.Start()");

            SetupCanvas();

            CreateUI();
        }

        /// <summary>
        /// Setups the canvas.
        /// </summary>
        private void SetupCanvas()
        {
			DebugEx.Verbose("MasterScript.SetupCanvas()");

            float dpi = Screen.dpi;

            if (dpi != 0f)
            {
                CanvasScaler canvasScaler = GetComponent<CanvasScaler>();

                canvasScaler.scaleFactor = dpi / 96f;
            }
            else
            {
                DebugEx.Warning("Failed to determine DPI");
            }
        }

        /// <summary>
        /// Creates user interface.
        /// </summary>
        private void CreateUI()
        {
			DebugEx.Verbose("MasterScript.CreateUI()");

            CreateCommon();
            CreateWindows();
            CreateOverlap();

            MainWindowScript.Create().Show();
        }

        /// <summary>
        /// Creates common things.
        /// </summary>
        private void CreateCommon()
        {
			DebugEx.Verbose("MasterScript.CreateCommon()");

            //***************************************************************************
            // Common GameObject
            //***************************************************************************
            #region Common GameObject
            GameObject common = new GameObject("Common");
            Utils.InitUIObject(common, transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform commonTransform = common.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(commonTransform);
            #endregion
            #endregion

            CreateCommonListeners(common.transform);
            CreateCommonNetwork(common.transform);
        }

        /// <summary>
        /// Creates common listeners.
        /// </summary>
        /// <param name="parent">Parent transform.</param>
        private void CreateCommonListeners(Transform parent)
        {
			DebugEx.VerboseFormat("MasterScript.CreateCommonListeners(parent = {0})", parent);

            //***************************************************************************
            // Listeners GameObject
            //***************************************************************************
            #region Listeners GameObject
            GameObject listeners = new GameObject("Listeners");
            Utils.InitUIObject(listeners, parent);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform listenersTransform = listeners.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(listenersTransform);
            #endregion
            #endregion

            CreateResizeListener(listeners.transform);
            CreateEscapeButtonListener(listeners.transform);
        }

        /// <summary>
        /// Creates resize listener.
        /// </summary>
        /// <param name="parent">Parent transform.</param>
        private void CreateResizeListener(Transform parent)
        {
			DebugEx.VerboseFormat("MasterScript.CreateResizeListener(parent = {0})", parent);

            //***************************************************************************
            // ResizeListener GameObject
            //***************************************************************************
            #region ResizeListener GameObject
            GameObject resizeListener = new GameObject("ResizeListener");
            Utils.InitUIObject(resizeListener, parent);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform resizeListenerTransform = resizeListener.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(resizeListenerTransform);
            #endregion

            //===========================================================================
            // ResizeListenerScript Component
            //===========================================================================
            #region ResizeListenerScript Component
            resizeListener.AddComponent<ResizeListenerScript>();
            #endregion
            #endregion
        }

        /// <summary>
        /// Creates escape button listener.
        /// </summary>
        /// <param name="parent">Parent transform.</param>
        private void CreateEscapeButtonListener(Transform parent)
        {
			DebugEx.VerboseFormat("MasterScript.CreateEscapeButtonListener(parent = {0})", parent);

            //***************************************************************************
            // EscapeButtonListener GameObject
            //***************************************************************************
            #region EscapeButtonListener GameObject
            GameObject escapeButtonListener = new GameObject("EscapeButtonListener");
            Utils.InitUIObject(escapeButtonListener, parent);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform escapeButtonListenerTransform = escapeButtonListener.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(escapeButtonListenerTransform);
            #endregion

            //===========================================================================
            // EscapeButtonListenerScript Component
            //===========================================================================
            #region EscapeButtonListenerScript Component
            escapeButtonListener.AddComponent<EscapeButtonListenerScript>();
            #endregion
            #endregion
        }

        /// <summary>
        /// Creates common network.
        /// </summary>
        /// <param name="parent">Parent transform.</param>
        private void CreateCommonNetwork(Transform parent)
        {
			DebugEx.VerboseFormat("MasterScript.CreateCommonNetwork(parent = {0})", parent);

            //***************************************************************************
            // Network GameObject
            //***************************************************************************
            #region Network GameObject
            GameObject network = new GameObject("Network");
            Utils.InitUIObject(network, parent);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform networkTransform = network.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(networkTransform);
            #endregion
            #endregion

            CreateServerScript(network.transform);
            CreateClientScript(network.transform);
        }

        /// <summary>
        /// Creates server script.
        /// </summary>
        /// <param name="parent">Parent transform.</param>
        private void CreateServerScript(Transform parent)
        {
			DebugEx.VerboseFormat("MasterScript.CreateServerScript(parent = {0})", parent);

            //***************************************************************************
            // Server GameObject
            //***************************************************************************
            #region Server GameObject
            GameObject server = new GameObject("Server");
            Utils.InitUIObject(server, parent);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform serverTransform = server.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(serverTransform);
            #endregion

            //===========================================================================
            // ServerScript Component
            //===========================================================================
            #region ServerScript Component
            Global.serverScript = server.AddComponent<ServerScript>();
            #endregion
            #endregion
        }

        /// <summary>
        /// Creates client script.
        /// </summary>
        /// <param name="parent">Parent transform.</param>
        private void CreateClientScript(Transform parent)
        {
			DebugEx.VerboseFormat("MasterScript.CreateClientScript(parent = {0})", parent);

            //***************************************************************************
            // Client GameObject
            //***************************************************************************
            #region Client GameObject
            GameObject client = new GameObject("Client");
            Utils.InitUIObject(client, parent);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform clientTransform = client.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(clientTransform);
            #endregion

            //===========================================================================
            // ClientScript Component
            //===========================================================================
            #region ClientScript Component
            Global.clientScript = client.AddComponent<ClientScript>();
            #endregion
            #endregion
        }

        /// <summary>
        /// Creates windows container.
        /// </summary>
        private void CreateWindows()
        {
			DebugEx.Verbose("MasterScript.CreateWindows()");

            //***************************************************************************
            // Windows GameObject
            //***************************************************************************
            #region Windows GameObject
            GameObject windows = new GameObject("Windows");
            Utils.InitUIObject(windows, transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform windowsTransform = windows.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(windowsTransform);

            Global.windowsTransform = windowsTransform;
            #endregion
            #endregion
        }

        /// <summary>
        /// Creates overlap container.
        /// </summary>
        private void CreateOverlap()
        {
			DebugEx.Verbose("MasterScript.CreateOverlap()");

            //***************************************************************************
            // Overlap GameObject
            //***************************************************************************
            #region Overlap GameObject
            GameObject overlap = new GameObject("Overlap");
            Utils.InitUIObject(overlap, transform);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform overlapTransform = overlap.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(overlapTransform);
            #endregion
            #endregion

            CreatePopupMenuArea(overlap.transform);
            CreateTooltipArea(overlap.transform);
        }

        /// <summary>
        /// Creates popup menu area.
        /// </summary>
        /// <param name="parent">Parent transform.</param>
        private void CreatePopupMenuArea(Transform parent)
        {
			DebugEx.VerboseFormat("MasterScript.CreatePopupMenuArea(parent = {0})", parent);

            //***************************************************************************
            // PopupMenuArea GameObject
            //***************************************************************************
            #region PopupMenuArea GameObject
            GameObject popupMenuArea = new GameObject("PopupMenuArea");
            Utils.InitUIObject(popupMenuArea, parent);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform popupMenuAreaTransform = popupMenuArea.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(popupMenuAreaTransform);
            #endregion

            //===========================================================================
            // PopupMenuAreaScript Component
            //===========================================================================
            #region PopupMenuAreaScript Component
            popupMenuArea.AddComponent<PopupMenuAreaScript>();
            #endregion
            #endregion
        }

        /// <summary>
        /// Creates tooltip area.
        /// </summary>
        /// <param name="parent">Parent transform.</param>
        private void CreateTooltipArea(Transform parent)
        {
			DebugEx.VerboseFormat("MasterScript.CreateTooltipArea(parent = {0})", parent);

            //***************************************************************************
            // TooltipArea GameObject
            //***************************************************************************
            #region TooltipArea GameObject
            GameObject tooltipArea = new GameObject("TooltipArea");
            Utils.InitUIObject(tooltipArea, parent);

            //===========================================================================
            // RectTransform Component
            //===========================================================================
            #region RectTransform Component
            RectTransform tooltipAreaTransform = tooltipArea.AddComponent<RectTransform>();
            Utils.AlignRectTransformStretchStretch(tooltipAreaTransform);
            #endregion

            //===========================================================================
            // TooltipAreaScript Component
            //===========================================================================
            #region TooltipAreaScript Component
            tooltipArea.AddComponent<TooltipAreaScript>();
            #endregion
            #endregion
        }
    }
}
