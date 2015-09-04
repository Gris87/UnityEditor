#define LOOPBACK_SERVER



using UnityEngine;

using Common.App;



namespace Net
{
    /// <summary>
    /// Server script.
    /// </summary>
    public class ServerScript : MonoBehaviour
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="ServerScript"/> is started.
        /// </summary>
        /// <value><c>true</c> if is started; otherwise, <c>false</c>.</value>
        public bool isStarted
        {
            get { return mStarted; }
        }



        private bool mStarted;



        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
            mStarted = false;

#if LOOPBACK_SERVER
            MasterServer.ipAddress     = "127.0.0.1";
            MasterServer.port          = 23466;
            Network.natFacilitatorIP   = "127.0.0.1";
            Network.natFacilitatorPort = 50005;
#endif

            if (Network.InitializeServer(10000, 52794, !Network.HavePublicAddress()) != NetworkConnectionError.NoError)
            {
                Debug.LogError("Server initialization failed");
            }
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        public void StartServer()
        {
            if (!mStarted)
            {
                MasterServer.RegisterHost(CommonConstants.SERVER_NAME, "Server_1");
                mStarted = true;
            }
            else
            {
                Debug.LogError("Server already started");
            }
        }

        /// <summary>
        /// Stops the server.
        /// </summary>
        public void StopServer()
        {
            if (mStarted)
            {
                MasterServer.UnregisterHost();
                mStarted = false;
            }
            else
            {
                Debug.LogError("Server already stopped");
            }
		}
		
		/// <summary>
		/// Handler for server initialized event.
		/// </summary>
		void OnServerInitialized()
		{
			StartServer();
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
				case MasterServerEvent.HostListReceived:
				{
					// Nothing
				}
				break;

				case MasterServerEvent.RegistrationFailedGameName:
				case MasterServerEvent.RegistrationFailedGameType:
				case MasterServerEvent.RegistrationFailedNoServer:
				{
					Debug.LogError("Registration failed: " + msEvent);

					mStarted = false;
				}
				break;

				default:
				{
					Debug.LogError("Unknown master server event: " + msEvent);
				}
				break;
			}
		}
    }
}
