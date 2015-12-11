using System.Collections.Generic;
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

                DebugEx.Debug("Server started");
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

                DebugEx.Debug("Server stopped");
            }
            else
            {
                DebugEx.Error("Server already stopped");
            }
        }

        /// <summary>
        /// Disconnects the client.
        /// </summary>
        /// <returns><c>true</c>, if client successfully disconnected, <c>false</c> otherwise.</returns>
        /// <param name="connectionId">Client.</param>
        public static bool DisconnectClient(int connectionId)
        {
            byte error;
            NetworkTransport.Disconnect(sHostId, connectionId, out error);

            bool res = (error == (byte)NetworkError.Ok);

            if (!res)
            {
                DebugEx.ErrorFormat("Impossible to disconnect client {0}, error: {1}({2})", connectionId, (NetworkError)error, error);
            }

            DebugEx.VerboseFormat("Server.DisconnectClient(connectionId = {0}) = {1}", connectionId, res);

            return res;
        }

        /// <summary>
        /// Sends byte array to specified client.
        /// </summary>
        /// <returns><c>true</c>, if successfully sent, <c>false</c> otherwise.</returns>
        /// <param name="connectionId">Client.</param>
        /// <param name="bytes">Byte array.</param>
        public static bool Send(int connectionId, byte[] bytes)
        {
            byte error;
            NetworkTransport.Send(sHostId, connectionId, sChannelId, bytes, bytes.Length, out error);

            bool res = (error == (byte)NetworkError.Ok);

            if (res)
            {
                DebugEx.DebugFormat("Message sent to client {0}: {1}", connectionId, Utils.BytesInHex(bytes));
            }
            else
            {
                DebugEx.ErrorFormat("Impossible to send message to client {0}, error: {1}({2})", connectionId, (NetworkError)error, error);
            }

            DebugEx.VerboseFormat("Server.Send(connectionId = {0}, bytes = {1}) = {2}", connectionId, Utils.BytesInHex(bytes), res);

            return res;
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
            writer.Write(RevisionChecker.revision);

            return stream.ToArray();
        }

		/// <summary>
		/// Builds MD5HashesResponse messages.
		/// </summary>
		/// <returns>Byte arrays that represents MD5HashesResponse messages.</returns>
        public static List<byte[]> BuildMD5HashesResponseMessages()
        {
			// TODO: Implement it

			return null;
		}
    }
}
