using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
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
            config.PacketSize       = 32000;
            sChannelId              = config.AddChannel(QosType.ReliableSequenced);

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
                DebugEx.VeryVerboseFormat("Message sent to the client {0}: {1}", connectionId, Utils.BytesInHex(bytes));
            }
            else
            {
                DebugEx.ErrorFormat("Impossible to send message to the client {0}, error: {1}({2})", connectionId, (NetworkError)error, error);
            }

            DebugEx.VerboseFormat("Server.Send(connectionId = {0}, bytes = {1}) = {2}", connectionId, bytes, res);

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
            BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8);

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
			ReadOnlyCollection<string> files       = RevisionsCache.files;
			string                     revisionDir = Application.persistentDataPath + "/Revisions/" + RevisionChecker.revision.ToString();

			List<byte[]> res = new List<byte[]>();

			MemoryStream stream = new MemoryStream();
			BinaryWriter writer = new BinaryWriter(stream, Encoding.UTF8);

			NetUtils.WriteMessageHeader(writer, MessageType.MD5HashesResponse);
			writer.Write(false); // To be continued?

			for (int i = 0; i < files.Count; ++i)
			{
				string file = files[i];

				if (stream.Length > 30000)
				{
					res.Add(stream.ToArray());

					stream = new MemoryStream();
					writer = new BinaryWriter(stream, Encoding.UTF8);
					
					NetUtils.WriteMessageHeader(writer, MessageType.MD5HashesResponse);
					writer.Write(false); // To be continued?
				}

				writer.Write(file); // Name of file

				if (Directory.Exists(revisionDir + "/" + file))
				{
					writer.Write(true); // Is it a folder
				}
				else
				{
					writer.Write(false); // Is it a folder

					if (!File.Exists(revisionDir + "/" + file))
					{
						DebugEx.FatalFormat("File {0} not found", revisionDir + "/" + file);

						return null;
					}

					if (!File.Exists(revisionDir + "/" + file + ".md5"))
					{
						RevisionChecker.CalculateMD5ForFile(revisionDir + "/" + file);
					}

					writer.Write(File.ReadAllText(revisionDir + "/" + file + ".md5", Encoding.UTF8)); // MD5 Hash of file
				}
			}

			res.Add(stream.ToArray());

			for (int i = 0; i < res.Count - 1; ++i)
			{
				stream = new MemoryStream(res[i]);
				writer = new BinaryWriter(stream, Encoding.UTF8);
								
				NetUtils.WriteMessageHeader(writer, MessageType.MD5HashesResponse);
				writer.Write(true); // To be continued?
			}

			return res;
		}
    }
}
