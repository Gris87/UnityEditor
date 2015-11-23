#pragma warning disable 618



using System.IO;
using UnityEngine;

using Common;
using Common.App;
using Common.App.Net;



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
                DebugEx.VeryVeryVerboseFormat("Server.state = {0}", sState);

                return sState;
            }

            set
            {
                DebugEx.VeryVerboseFormat("Server.state: {0} => {1}", sState, value);

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

		/// <summary>
		/// Fills the message header.
		/// </summary>
		/// <param name="writer">Binary writer.</param>
		/// <param name="type">Message type.</param>
		private static void FillMessageHeader(BinaryWriter writer, MessageType type)
		{
			DebugEx.VerboseFormat("Server.FillMessageHeader(writer = {0}, type = {1})", writer, type);
			
			writer.Write((byte)type);
		}
		
		/// <summary>
		/// Builds RevisionResponse message.
		/// </summary>
		/// <returns>Byte array that represents RevisionResponse message.</returns>
		public static byte[] BuildRevisionResponseMessage()
		{
			DebugEx.Verbose("Server.BuildRevisionResponseMessage()");
			
			MemoryStream stream = new MemoryStream();
			BinaryWriter writer = new BinaryWriter(stream);
			
			FillMessageHeader(writer, MessageType.RevisionResponse);
			
			return stream.ToArray();
		}
    }
}
