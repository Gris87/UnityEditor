using UnityEngine;

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
			get { return sState;  }
			set { sState = value; }
		}
		
		
		
		private static ServerState sState;



		/// <summary>
		/// Initializes the <see cref="Net.Server"/> class.
		/// </summary>
		static Server()
		{
			sState = ServerState.Stopped;
		}

		/// <summary>
		/// Starts the server.
		/// </summary>
		public static void Start()
		{
			if (sState == ServerState.Stopped)
			{
				MasterServer.RegisterHost(CommonConstants.SERVER_NAME, "Server_1");
				sState = ServerState.Starting;
			}
			else
			{
				Debug.LogError("Server already started");
			}
		}
		
		/// <summary>
		/// Stops the server.
		/// </summary>
		public static void Stop()
		{
			if (sState != ServerState.Stopped)
			{
				MasterServer.UnregisterHost();
				sState = ServerState.Stopped;
			}
			else
			{
				Debug.LogError("Server already stopped");
			}
		}
	}
}

