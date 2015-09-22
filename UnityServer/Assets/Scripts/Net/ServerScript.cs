#pragma warning disable 618



#define LOOPBACK_SERVER



using UnityEngine;

using Common;



namespace Net
{
    /// <summary>
    /// Server script.
    /// </summary>
    public class ServerScript : MonoBehaviour
    {
        private NetworkView mNetworkView;



        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
            DebugEx.Verbose("ServerScript.Start()");

#if LOOPBACK_SERVER
            MasterServer.ipAddress     = "127.0.0.1";
            MasterServer.port          = 23466;
            Network.natFacilitatorIP   = "127.0.0.1";
            Network.natFacilitatorPort = 50005;
#else
            Network.InitializeSecurity();
#endif

            mNetworkView = gameObject.AddComponent<NetworkView>();

            if (Network.InitializeServer(10000, 52794, !Network.HavePublicAddress()) != NetworkConnectionError.NoError)
            {
                DebugEx.Error("Server initialization failed");
            }
        }

        /// <summary>
        /// Handler for server initialized event.
        /// </summary>
        void OnServerInitialized()
        {
            DebugEx.Verbose("ServerScript.OnServerInitialized()");

            Server.Start();
        }

        /// <summary>
        /// Handler for connecting failure event to the master server.
        /// </summary>
        /// <param name="error">Error description.</param>
        void OnFailedToConnectToMasterServer(NetworkConnectionError error)
        {
            DebugEx.VerboseFormat("ServerScript.OnFailedToConnectToMasterServer(error = {0})", error);

			DebugEx.ErrorFormat("Could not connect to master server: {0}", error);
        }

        /// <summary>
        /// Handler for master server event.
        /// </summary>
        /// <param name="msEvent">Master server event.</param>
        void OnMasterServerEvent(MasterServerEvent msEvent)
        {
            DebugEx.VerboseFormat("ServerScript.OnMasterServerEvent(msEvent = {0})", msEvent);

            switch (msEvent)
            {
                case MasterServerEvent.RegistrationSucceeded:
                {
                    if (Server.state == ServerState.Starting)
                    {
                        DebugEx.Info("Server registered");

                        Server.state = ServerState.Started;
                    }
                }
                break;

                case MasterServerEvent.HostListReceived:
                {
                    // Nothing
                }
                break;

                case MasterServerEvent.RegistrationFailedGameName:
                case MasterServerEvent.RegistrationFailedGameType:
                case MasterServerEvent.RegistrationFailedNoServer:
                {
                    if (Server.state == ServerState.Starting)
                    {
						DebugEx.ErrorFormat("Registration failed: {0}", msEvent);

                        Server.state = ServerState.Stopped;
                    }
                }
                break;

                default:
                {
					DebugEx.ErrorFormat("Unknown master server event: {0}", msEvent);
                }
                break;
            }
        }

        /// <summary>
        /// Sends byte array to specified client.
        /// </summary>
        /// <param name="client">Client.</param>
        /// <param name="bytes">Byte array.</param>
        public void Send(NetworkPlayer client, byte[] bytes)
        {
            DebugEx.VerboseFormat("ServerScript.Send(client = {0}, bytes = {1})", client, Utils.BytesInHex(bytes));

            mNetworkView.RPC("RPC_SendToClient", client, bytes);
        }

        /// <summary>
        /// RPC for receiving message from client.
        /// </summary>
        /// <param name="id">Network view ID.</param>
        /// <param name="bytes">Byte array.</param>
        [RPC]
        private void RPC_SendToServer(NetworkViewID id, byte[] bytes)
        {
            DebugEx.VerboseFormat("ServerScript.RPC_SendToServer(id = {0}, bytes = {1})", id, Utils.BytesInHex(bytes));

            NetworkView   view   = NetworkView.Find(id);
            NetworkPlayer player = view.owner;

			DebugEx.DebugFormat("Message received from client {0}:{1}", player.externalIP, player.externalPort);
            DebugEx.Debug(Utils.BytesInHex(bytes));

            // TODO: [Major] Handle incoming message
        }

        /// <summary>
        /// RPC for sending message to client.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        [RPC]
        private void RPC_SendToClient(byte[] bytes)
        {
            DebugEx.VerboseFormat("ServerScript.RPC_SendToClient(bytes = {0})", Utils.BytesInHex(bytes));

            DebugEx.Fatal("Unexpected behaviour in ServerScript.RPC_SendToClient()");
        }
    }
}
