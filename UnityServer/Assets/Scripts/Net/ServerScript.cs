using System.IO;
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
		private byte[] mBuffer;



        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
            DebugEx.Verbose("ServerScript.Start()");

			mBuffer = new byte[4096]; ;

			Server.Start();
        }

		/// <summary>
		/// Update is called once per frame.
		/// </summary>
		void Update()
		{
			DebugEx.VeryVeryVerbose("ServerScript.Update()");
			
			int recHostId; 
			int connectionId; 
			int channelId;
			int dataSize;
			byte error;

			NetworkEventType eventType = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, mBuffer, 4096, out dataSize, out error);

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
	            }
                break;

				case NetworkEventType.DataEvent:      
				{
					OnMessageReceivedFromClient(connectionId, mBuffer);
	            }
                break;

            	case NetworkEventType.DisconnectEvent:
				{
					DebugEx.DebugFormat("Client {0} disconnected, error: {1}", connectionId, error);
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
		public void OnMessageReceivedFromClient(int connectionId, byte[] bytes)
		{
			DebugEx.VerboseFormat("ServerScript.OnMessageReceivedFromClient(connectionId = {0}, bytes = {1})", connectionId, Utils.BytesInHex(bytes));

			DebugEx.DebugFormat("Message received from client {0}: {1}", connectionId, Utils.BytesInHex(bytes));

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
