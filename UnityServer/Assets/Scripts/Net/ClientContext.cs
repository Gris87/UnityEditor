using System.Collections.Generic;
using System.IO;

using Common;
using Common.App.Net;



namespace Net
{
	/// <summary>
	/// Client context.
	/// </summary>
    public class ClientContext
    {
        #region States
        /// <summary>
        /// Client state.
        /// </summary>
        private class IClientState
        {
            /// <summary>
            /// Handler for enter event.
            /// </summary>
            /// <param name="context">Context.</param>
            /// <param name="previousState">Previous state.</param>
            public virtual void OnEnter(ClientContext context, ClientState previousState)
            {
                DebugEx.VerboseFormat("ClientContext.IClientState.OnEnter(context = {0}, previousState = {1}) in {2} state", context, previousState, context.mState);
            }

            /// <summary>
            /// Handler for exit event.
            /// </summary>
            /// <param name="context">Context.</param>
            /// <param name="nextState">Next state.</param>
            public virtual void OnExit(ClientContext context, ClientState nextState)
            {
                DebugEx.VerboseFormat("ClientContext.IClientState.OnExit(context = {0}, nextState = {1}) in {2} state", context, nextState, context.mState);
            }

            /// <summary>
            /// Handler for message received from the client.
            /// </summary>
            /// <param name="context">Context.</param>
            /// <param name="bytes">Byte array.</param>
            /// <param name="dataSize">Data size.</param>
            public virtual void OnMessageReceivedFromClient(ClientContext context, byte[] bytes, int dataSize)
            {
                DebugEx.VerboseFormat("ClientContext.IClientState.OnMessageReceivedFromClient(context = {0}, bytes = {1}, dataSize = {2}) in {3} state", context, Utils.BytesInHex(bytes, dataSize), dataSize, context.mState);

                DebugEx.FatalFormat("Unexpected OnMessageReceivedFromClient() in {0} state", context.mState);
            }
        }

        /// <summary>
        /// Client state when client disconnected from the host.
        /// </summary>
        private class DisconnectedState: IClientState
        {
            /// <summary>
            /// Handler for enter event.
            /// </summary>
            /// <param name="context">Context.</param>
            /// <param name="previousState">Previous state.</param>
            public override void OnEnter(ClientContext context, ClientState previousState)
            {
                DebugEx.VerboseFormat("ClientContext.DisconnectedState.OnEnter(context = {0}, previousState = {1})", context, previousState);

                Server.DisconnectClient(context.mConnectionId);
            }
        }

        /// <summary>
        /// Client state when client connected to the host.
        /// </summary>
        private class ConnectedState: IClientState
        {
            /// <summary>
            /// Handler for message received from the client.
            /// </summary>
            /// <param name="context">Context.</param>
            /// <param name="bytes">Byte array.</param>
            /// <param name="dataSize">Data size.</param>
            public override void OnMessageReceivedFromClient(ClientContext context, byte[] bytes, int dataSize)
            {
                DebugEx.VerboseFormat("ClientContext.ConnectedState.OnMessageReceivedFromClient(context = {0}, bytes = {1}, dataSize = {2})", context, Utils.BytesInHex(bytes, dataSize), dataSize);

                DebugEx.DebugFormat("Message received from client {0}: {1}", context.mConnectionId, Utils.BytesInHex(bytes, dataSize));

                MemoryStream stream = new MemoryStream(bytes);
                BinaryReader reader = new BinaryReader(stream);

                MessageType messageType = NetUtils.ReadMessageHeader(reader);

                DebugEx.DebugFormat("Message type = {0}", messageType);

                switch (messageType)
                {
                    case MessageType.RevisionRequest:
                    {
                        HandleRevisionRequest(context);
                    }
                    break;

                    case MessageType.RevisionResponse:
                    case MessageType.MD5HashesRequest:
                    case MessageType.MD5HashesResponse:
                    {
                        DebugEx.ErrorFormat("Unexpected message type: {0}", messageType);

                        context.state = ClientState.Disconnected;
                    }
                    break;

                    default:
                    {
                        DebugEx.ErrorFormat("Unknown message type: {0}", messageType);

                        context.state = ClientState.Disconnected;
                    }
                    break;
                }
            }

            /// <summary>
            /// Handles RevisionRequest message.
            /// </summary>
            /// <param name="context">Context.</param>
            private void HandleRevisionRequest(ClientContext context)
            {
                DebugEx.VerboseFormat("ServerScript.HandleRevisionRequest(context = {0})", context);

                if (Server.Send(context.mConnectionId, Server.BuildRevisionResponseMessage()))
				{
					context.state = ClientState.RequestingMD5Hashes;
				}
				else
				{
					DebugEx.ErrorFormat("Failed to send RevisionResponse message");
					
					context.state = ClientState.Disconnected;
                }
            }
        }

        /// <summary>
        /// Client state when client requesting MD5 hashes for files from the host.
        /// </summary>
        private class RequestingMD5HashesState: IClientState
        {
            /// <summary>
            /// Handler for message received from the client.
            /// </summary>
            /// <param name="context">Context.</param>
            /// <param name="bytes">Byte array.</param>
            /// <param name="dataSize">Data size.</param>
            public override void OnMessageReceivedFromClient(ClientContext context, byte[] bytes, int dataSize)
            {
                DebugEx.VerboseFormat("ClientContext.ConnectedState.OnMessageReceivedFromClient(context = {0}, bytes = {1}, dataSize = {2})", context, Utils.BytesInHex(bytes, dataSize), dataSize);

                DebugEx.DebugFormat("Message received from client {0}: {1}", context.mConnectionId, Utils.BytesInHex(bytes, dataSize));

                MemoryStream stream = new MemoryStream(bytes);
                BinaryReader reader = new BinaryReader(stream);

                MessageType messageType = NetUtils.ReadMessageHeader(reader);

                DebugEx.DebugFormat("Message type = {0}", messageType);

                switch (messageType)
                {
                    case MessageType.MD5HashesRequest:
                    {
                        HandleMD5HashesRequest(context);
                    }
                    break;

                    case MessageType.RevisionRequest:
                    case MessageType.RevisionResponse:
                    case MessageType.MD5HashesResponse:
                    {
                        DebugEx.ErrorFormat("Unexpected message type: {0}", messageType);

                        context.state = ClientState.Disconnected;
                    }
                    break;

                    default:
                    {
                        DebugEx.ErrorFormat("Unknown message type: {0}", messageType);

                        context.state = ClientState.Disconnected;
                    }
                    break;
                }
            }

            /// <summary>
            /// Handles MD5HashesRequest message.
            /// </summary>
            /// <param name="context">Context.</param>
            private void HandleMD5HashesRequest(ClientContext context)
            {
                DebugEx.VerboseFormat("ServerScript.HandleMD5HashesRequest(context = {0})", context);

				context.mRevision = RevisionsCache.LockRevision();

				// TODO: Need to unlock revision in destructor
				// TODO: Need to and take files

				List<byte[]> messages = RevisionsCache.md5HashesResponseMessages;

				if (messages.Count > 0)
				{
					for (int i = 0; i < messages.Count; ++i)
					{
						if (!Server.Send(context.mConnectionId, messages[i]))
						{
							DebugEx.ErrorFormat("Failed to send MD5HashesResponse message");
                            
                            context.state = ClientState.Disconnected;

							return;
                        }
					}

					context.state = ClientState.Downloading;
				}
				else
				{
					DebugEx.FatalFormat("Incorrect behaviour in HandleMD5HashesRequest");

					context.state = ClientState.Disconnected;
				}
            }
        }

        /// <summary>
        /// Client state when client downloading files from the host.
        /// </summary>
        private class DownloadingState: IClientState
        {
            // TODO: Implement
        }
        #endregion

        // =======================================================================

        /// <summary>
        /// Gets or sets client state.
        /// </summary>
        /// <value>Client state.</value>
        public ClientState state
        {
            get
            {
                DebugEx.VeryVeryVerboseFormat("ClientContext.state = {0}", mState);

                return mState;
            }

            set
            {
                DebugEx.VeryVerboseFormat("ClientContext.state: {0} => {1}", mState, value);

                if (mState != value)
                {
                    mCurrentState.OnExit(this, value);



                    ClientState oldState = mState;
                    mState = value;

                    DebugEx.DebugFormat("Client {0} state changed: {1} => {2}", mConnectionId, oldState, mState);



                    mCurrentState = sAllStates[(int)mState];
                    mCurrentState.OnEnter(this, oldState);
                }
            }
        }



        private static IClientState[] sAllStates = null;



        private ClientState  mState;
        private IClientState mCurrentState;

        private int          mConnectionId;
		private int          mRevision;



        /// <summary>
        /// Initializes a new instance of the <see cref="Net.ClientContext"/> class.
        /// </summary>
        /// <param name="connectionId">Client.</param>
        public ClientContext(int connectionId)
        {
            DebugEx.VerboseFormat("ClientContext(connectionId = {0}) created", connectionId);

            if (sAllStates == null)
            {
                sAllStates                                       = new IClientState[(int)ClientState.Count];
                sAllStates[(int)ClientState.Disconnected]        = new DisconnectedState();
                sAllStates[(int)ClientState.Connecting]          = null;
                sAllStates[(int)ClientState.Connected]           = new ConnectedState();
                sAllStates[(int)ClientState.RequestingMD5Hashes] = new RequestingMD5HashesState();
                sAllStates[(int)ClientState.Downloading]         = new DownloadingState();
            }

            mState        = ClientState.Connected;
            mCurrentState = sAllStates[(int)mState];

            mConnectionId = connectionId;
			mRevision     = -1;



            mCurrentState.OnEnter(this, ClientState.Count);
        }

        /// <summary>
        /// Handler for message received from the client.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <param name="dataSize">Data size.</param>
        public void OnMessageReceivedFromClient(byte[] bytes, int dataSize)
        {
            DebugEx.VerboseFormat("ClientContext.OnMessageReceivedFromClient(bytes = {0}, dataSize = {1})", Utils.BytesInHex(bytes, dataSize), dataSize);

            mCurrentState.OnMessageReceivedFromClient(this, bytes, dataSize);
        }
    }
}

