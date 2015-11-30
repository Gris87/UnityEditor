#pragma warning disable 618



#define LOOPBACK_SERVER



using System.IO;
using UnityEngine;

using Common;
using Common.App.Net;



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
		/// Handler for player connected event.
		/// </summary>
		/// <param name="player">Client.</param>
		void OnPlayerConnected(NetworkPlayer player)
		{
			DebugEx.VerboseFormat("ServerScript.OnPlayerConnected(player = {0})", player);

			DebugEx.DebugFormat("Client {0}:{1} connected", player.externalIP, player.externalPort);
			DebugEx.ErrorFormat("Client GUID {0}", player.guid);
		}

		/// <summary>
		/// Handler for player disconnected event.
		/// </summary>
		/// <param name="player">Client.</param>
		void OnPlayerDisconnected(NetworkPlayer player)
		{
			DebugEx.VerboseFormat("ServerScript.OnPlayerDisconnected(player = {0})", player);
			
			DebugEx.DebugFormat("Client {0}:{1} disconnected", player.externalIP, player.externalPort);
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
		/// Handler for message received from client.
		/// </summary>
		/// <param name="client">Client.</param>
		/// <param name="bytes">Byte array.</param>
		public void OnMessageReceivedFromClient(NetworkPlayer client, byte[] bytes)
		{
			DebugEx.VerboseFormat("ServerScript.OnMessageReceivedFromClient(client = {0}, bytes = {1})", client, Utils.BytesInHex(bytes));

			DebugEx.DebugFormat("Message received from client {0}:{1}", client.externalIP, client.externalPort);
			DebugEx.Debug(Utils.BytesInHex(bytes));

			MemoryStream stream = new MemoryStream(bytes);
			BinaryReader reader = new BinaryReader(stream);

			MessageType messageType = NetUtils.ReadMessageHeader(reader);

			DebugEx.DebugFormat("Message type = {0}", messageType);

			switch (messageType)
			{
				case MessageType.RevisionRequest:
				{
					HandleRevisionRequest(client);
				}
				break;

				case MessageType.RevisionResponse:
				{
					DebugEx.ErrorFormat("Unexpected message type: {0}", messageType);
				}
				break;

				default:
				{
					DebugEx.ErrorFormat("Unknown message type: {0}", messageType);
				}
				break;
			}
		}

		/// <summary>
		/// Handles RevisionRequest message.
		/// </summary>
		/// <param name="client">Client.</param>
		private void HandleRevisionRequest(NetworkPlayer client)
		{
			DebugEx.VerboseFormat("ServerScript.HandleRevisionRequest(client = {0})", client);

			Send(client, Server.BuildRevisionResponseMessage());
		}

        /// <summary>
        /// RPC for receiving message from client.
        /// </summary>
        /// <param name="id">Network view ID.</param>
        /// <param name="bytes">Byte array.</param>
        [RPC]
        private void RPC_SendToServer(string guid, byte[] bytes)
        {
			DebugEx.VerboseFormat("ServerScript.RPC_SendToServer(guid = {0}, bytes = {1})", guid, Utils.BytesInHex(bytes));

			DebugEx.DebugFormat("Message from GUID = {0}", guid);

            //NetworkView   view   = NetworkView.Find(id);
            //NetworkPlayer player = view.owner;

            // TODO: Remove it
			//DebugEx.DebugFormat("Server = {0}:{1}", mNetworkView.owner.externalIP, mNetworkView.owner.externalPort);
			//DebugEx.DebugFormat("Player = {0}:{1}", player.externalIP, player.externalPort);

            //OnMessageReceivedFromClient(player, bytes);
        }

		/*
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
        */
    }
}
