using System.IO;
using UnityEngine;
using UnityEngine.Networking;

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
		private static byte         sChannelId;
		private static HostTopology sTopology;
		private static int          sHostId;



        /// <summary>
        /// Initializes the <see cref="Net.Server"/> class.
        /// </summary>
        static Server()
        {
            DebugEx.Verbose("Static class Server initialized");

			NetworkTransport.Init();

			ConnectionConfig config = new ConnectionConfig();
			sChannelId = config.AddChannel(QosType.ReliableSequenced);

			sTopology = new HostTopology(config, 10000);
			sHostId   = -1;
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        public static void Start()
        {
            DebugEx.Verbose("Server.Start()");

			if (sHostId == -1)
            {
				sHostId = NetworkTransport.AddHost(sTopology, CommonConstants.SERVER_PORT);
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

			if (sHostId != -1)
            {
				NetworkTransport.RemoveHost(sHostId);

				sHostId = -1;
            }
            else
            {
                DebugEx.Error("Server already stopped");
            }
        }

		/// <summary>
		/// Sends byte array to specified client.
		/// </summary>
		/// <returns><c>true</c>, if successfully sent, <c>false</c> otherwise.</returns>
		/// <param name="connectionId">Client.</param>
		/// <param name="bytes">Byte array.</param>
		public static bool Send(int connectionId, byte[] bytes)
		{
			DebugEx.VerboseFormat("Server.Send(connectionId = {0}, bytes = {1})", connectionId, Utils.BytesInHex(bytes));

			byte error;
			NetworkTransport.Send(sHostId, connectionId, sChannelId, bytes, bytes.Length, out error);

			if (error == 0)
			{
				DebugEx.DebugFormat("Message sent to client {0}: {1}", connectionId, Utils.BytesInHex(bytes));
			}
			else
			{
				DebugEx.ErrorFormat("Impossible to send message to client {0}, error: {1}", connectionId, error);
			}

			return (error == 0);
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
			
			NetUtils.WriteMessageHeader(writer, MessageType.RevisionResponse);
			
			return stream.ToArray();
		}
    }
}
