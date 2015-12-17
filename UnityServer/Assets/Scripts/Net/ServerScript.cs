using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using Common;



namespace Net
{
    /// <summary>
    /// Server script.
    /// </summary>
    public class ServerScript : MonoBehaviour
    {
        private List<ClientContext> mClients;
        private byte[]              mBuffer;



        /// <summary>
        /// Script starting callback.
        /// </summary>
        void Start()
        {
            DebugEx.Verbose("ServerScript.Start()");

            mClients = new List<ClientContext>();
            mBuffer  = new byte[30000];

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

            NetworkEventType eventType = NetworkTransport.Receive(out hostId, out connectionId, out channelId, mBuffer, 30000, out dataSize, out error);

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

                    if (connectionId == mClients.Count + 1)
                    {
                        mClients.Add(new ClientContext(connectionId));
                    }
                    else
                    {
                        if (connectionId > 0 && connectionId <= mClients.Count && mClients[connectionId - 1] == null)
                        {
                            mClients[connectionId - 1] = new ClientContext(connectionId);
                        }
                        else
                        {
                            DebugEx.FatalFormat("Incorrect behaviour on handling connected client. connectionId = {0} mClients.Count = {1}", connectionId, mClients.Count);

                            Server.DisconnectClient(connectionId);
                        }
                    }
                }
                break;

                case NetworkEventType.DataEvent:
                {
                    if (connectionId > 0 && connectionId <= mClients.Count && mClients[connectionId - 1] != null)
                    {
                        mClients[connectionId - 1].OnMessageReceivedFromClient(mBuffer, dataSize);
                    }
                    else
                    {
                        DebugEx.FatalFormat("Incorrect behaviour on handling data from client. connectionId = {0} mClients.Count = {1}", connectionId, mClients.Count);

                        Server.DisconnectClient(connectionId);
                    }
                }
                break;

                case NetworkEventType.DisconnectEvent:
                {
                    DebugEx.DebugFormat("Client {0} disconnected, error: {1}({2})", connectionId, (NetworkError)error, error);

                    if (connectionId > 0 && connectionId <= mClients.Count && mClients[connectionId - 1] != null)
                    {
                        mClients[connectionId - 1] = null;
                    }
                    else
                    {
                        DebugEx.FatalFormat("Incorrect behaviour on handling disconnected client. connectionId = {0} mClients.Count = {1}", connectionId, mClients.Count);
                    }
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
    }
}
