#pragma warning disable 618



using UnityEngine;

using Common;
using Common.App;



namespace Net
{
    /// <summary>
    /// Class that represents server.
    /// </summary>
    public static class Server
    {
        /// <summary>
        /// Gets or sets server state.
        /// </summary>
        /// <value>Server state.</value>
        public static ServerState state
        {
            get
            {
                return sState;
            }

            set
            {
                DebugEx.Verbose("sState: " + sState + " => " + value);

                sState = value;
            }
        }



        private static ServerState sState;



        /// <summary>
        /// Initializes the <see cref="Net.Server"/> class.
        /// </summary>
        static Server()
        {
            DebugEx.Verbose("Static class Server initialized");

            sState = ServerState.Stopped;
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        public static void Start()
        {
            DebugEx.Verbose("Server.Start()");

            if (sState == ServerState.Stopped)
            {
                MasterServer.RegisterHost(CommonConstants.SERVER_NAME, "Server_1");
                sState = ServerState.Starting;
            }
            else
            {
                DebugEx.Error("Server already started");
            }
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        public static void Stop()
        {
            DebugEx.Verbose("Server.Stop()");

            if (sState != ServerState.Stopped)
            {
                MasterServer.UnregisterHost();
                sState = ServerState.Stopped;
            }
            else
            {
                DebugEx.Error("Server already stopped");
            }
        }
    }
}
