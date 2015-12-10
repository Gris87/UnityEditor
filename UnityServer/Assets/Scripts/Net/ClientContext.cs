using Common;
using Common.App.Net;



namespace Net
{
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
				DebugEx.VerboseFormat("ClientContext.IClientState.OnEnter(context = {0}, previousState = {1})", context, previousState);
			}
			
			/// <summary>
			/// Handler for exit event.
			/// </summary>
			/// <param name="context">Context.</param>
			/// <param name="nextState">Next state.</param>
			public virtual void OnExit(ClientContext context, ClientState nextState)
			{
				DebugEx.VerboseFormat("ClientContext.IClientState.OnExit(context = {0}, nextState = {1})", context, nextState);
			}

			/// <summary>
			/// Handler for message received from the client.
			/// </summary>
			/// <param name="context">Context.</param>
			/// <param name="bytes">Byte array.</param>
			/// <param name="dataSize">Data size.</param>
			public virtual void OnMessageReceivedFromClient(ClientContext context, byte[] bytes, int dataSize)
			{
				DebugEx.VerboseFormat("ClientContext.IClientState.OnMessageReceivedFromClient(context = {0}, bytes = {1}, dataSize = {2})", context, Utils.BytesInHex(bytes, dataSize), dataSize);
				
				DebugEx.FatalFormat("Unexpected OnMessageReceivedFromClient() in {0} state", context.mState);
			}
		}

		/// <summary>
		/// Client state when client connected to the host.
		/// </summary>
		private class ConnectedState: IClientState
		{
		}
		
		/// <summary>
		/// Client state when client requesting MD5 hashes for files from the host.
		/// </summary>
		private class RequestingMD5HashesState: IClientState
		{
		}
		
		/// <summary>
		/// Client state when client downloading files from the host.
		/// </summary>
		private class DownloadingState: IClientState
		{
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
					ClientState oldState = mState;
					mState = value;
					
					DebugEx.DebugFormat("Client #{0} state changed: {1} => {2}", mConnectionId, oldState, mState);
					
					mCurrentState.OnExit(this, mState);
					mCurrentState = sAllStates[(int)mState];
					mCurrentState.OnEnter(this, oldState);
				}
			}
		}



		private static IClientState[] sAllStates = null;



		private ClientState  mState;
		private IClientState mCurrentState;

		private int          mConnectionId;



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
				sAllStates[(int)ClientState.Disconnected]        = null;
				sAllStates[(int)ClientState.Connecting]          = null;
				sAllStates[(int)ClientState.Connected]           = new ConnectedState();
				sAllStates[(int)ClientState.RequestingMD5Hashes] = new RequestingMD5HashesState();
				sAllStates[(int)ClientState.Downloading]         = new DownloadingState();
			}

			mState        = ClientState.Connected;
			mCurrentState = sAllStates[(int)mState];

			mConnectionId = connectionId;


			
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

