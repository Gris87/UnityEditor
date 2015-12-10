using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using Common;
using Common.App.Net;



namespace Net
{
    /// <summary>
    /// Server script.
    /// </summary>
    public class ServerScript : MonoBehaviour
    {
		private Dictionary<int, ClientContext> mClients;
		private byte[]                         mBuffer;



        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
            DebugEx.Verbose("ServerScript.Start()");

			mClients = new Dictionary<int, ClientContext>();
			mBuffer  = new byte[4096];

			Server.Start();
        }

		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
		{
			DebugEx.VeryVeryVerbose("ServerScript.Update()");

			RevisionChecker.Update();
			
			int hostId; 
			int connectionId; 
			int channelId;
			int dataSize;
			byte error;

			NetworkEventType eventType = NetworkTransport.Receive(out hostId, out connectionId, out channelId, mBuffer, 4096, out dataSize, out error);

			switch (eventType)
			{
				case NetworkEventType.Nothing:        
				{
					// Nothing
				}
				break;

				case NetworkEventType.ConnectEvent:   
				{
					DebugEx.DebugFormat("Client {0} connected", connectionId);

					mClients.Add(connectionId, new ClientContext(connectionId));
	            }
                break;

				case NetworkEventType.DataEvent:      
				{
					ClientContext client;

					if (mClients.TryGetValue(connectionId, out client))
					{
						client.OnMessageReceivedFromClient(mBuffer, dataSize);
					}
					else
					{
						DebugEx.ErrorFormat("Client {0} not found", connectionId);
					}
				}
                break;

            	case NetworkEventType.DisconnectEvent:
				{
					DebugEx.DebugFormat("Client {0} disconnected, error: {1}", connectionId, error);

					mClients.Remove(connectionId);
	            }
                break;

				case NetworkEventType.BroadcastEvent:
				{
					DebugEx.ErrorFormat("Unexpected event type: {0}", eventType);
				}
				break;
				
				default:
				{
					DebugEx.ErrorFormat("Unknown event type: {0}", eventType);
	            }
                break;
            }
        }
        
        /// <summary>
        /// Handler for message received from client.
		/// </summary>
		/// <param name="connectionId">Client.</param>
		/// <param name="bytes">Byte array.</param>
		/// <param name="dataSize">Data size.</param>
		public void OnMessageReceivedFromClient(int connectionId, byte[] bytes, int dataSize)
		{
			// TODO: Remove it
			DebugEx.VerboseFormat("ServerScript.OnMessageReceivedFromClient(connectionId = {0}, bytes = {1}, dataSize = {2})", connectionId, Utils.BytesInHex(bytes, dataSize), dataSize);

			DebugEx.DebugFormat("Message received from client {0}: {1}", connectionId, Utils.BytesInHex(bytes, dataSize));

			MemoryStream stream = new MemoryStream(bytes);
			BinaryReader reader = new BinaryReader(stream);

			MessageType messageType = NetUtils.ReadMessageHeader(reader);

			DebugEx.DebugFormat("Message type = {0}", messageType);

			switch (messageType)
			{
				case MessageType.RevisionRequest:
				{
					HandleRevisionRequest(connectionId);
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
		/// <param name="connectionId">Client.</param>
		private void HandleRevisionRequest(int connectionId)
		{
			DebugEx.VerboseFormat("ServerScript.HandleRevisionRequest(connectionId = {0})", connectionId);

			Server.Send(connectionId, Server.BuildRevisionResponseMessage());
		}
    }
}
