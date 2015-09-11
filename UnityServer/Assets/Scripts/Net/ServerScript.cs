#pragma warning disable 618



#define LOOPBACK_SERVER



using UnityEngine;



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
                Debug.LogError("Server initialization failed");
            }
        }

		/// <summary>
		/// Handler for server initialized event.
		/// </summary>
		void OnServerInitialized()
		{
			Server.Start();
		}
		
		/// <summary>
		/// Handler for connecting failure event to the master server.
		/// </summary>
		/// <param name="error">Error description.</param>
		void OnFailedToConnectToMasterServer(NetworkConnectionError error)
		{
			Debug.LogError("Could not connect to master server: " + error);
		}
		
		/// <summary>
		/// Handler for master server event.
		/// </summary>
		/// <param name="msEvent">Master server event.</param>
		void OnMasterServerEvent(MasterServerEvent msEvent)
		{
			switch (msEvent)
			{
				case MasterServerEvent.RegistrationSucceeded:
				{
					if (Server.state == ServerState.Starting)
					{
						Debug.Log("Server registered");

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
                    	Debug.LogError("Registration failed: " + msEvent);

						Server.state = ServerState.Stopped;
                	}
				}
				break;

				default:
				{
					Debug.LogError("Unknown master server event: " + msEvent);
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
			NetworkView   view   = NetworkView.Find(id);
			NetworkPlayer player = view.owner;

			Debug.Log("Message received from client: " + player.externalIP + ":" + player.externalPort);

			// TODO: Handle it
		}

		/// <summary>
		/// RPC for sending message to client.
		/// </summary>
		/// <param name="bytes">Byte array.</param>
		[RPC]
		private void RPC_SendToClient(byte[] bytes)
		{
			// Nothing
		}
    }
}
