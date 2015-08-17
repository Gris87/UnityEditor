using UnityEngine;
using UnityEngine.Networking;



/// <summary>
/// Server.
/// </summary>
public static class Server
{
	private static int mHostId;



	/// <summary>
	/// Initializes the <see cref="Server"/> class.
	/// </summary>
	static Server()
	{
		mHostId = -1;
	}

	/// <summary>
	/// Start server.
	/// </summary>
	public static void Start()
	{
		if (mHostId == -1)
		{
			ConnectionConfig config = new ConnectionConfig();
			config.AddChannel(QosType.ReliableSequenced);

			NetworkTransport.Init();

			HostTopology hostTopology = new HostTopology(config, 10000);
			mHostId = NetworkTransport.AddHost(hostTopology);

			if (mHostId == -1)
			{
				Debug.LogError("Failed to start server");
			}
		}
		else
		{
			Debug.LogError("Server already started");
		}
	}

	/// <summary>
	/// Stop server.
	/// </summary>
	public static void Stop()
	{
		if (mHostId != -1)
		{
			if (NetworkTransport.RemoveHost(mHostId))
			{
				mHostId = -1;
			}
			else
			{
				Debug.LogError("Failed to stop server");
			}
		}
		else
		{
			Debug.LogError("Server already stopped");
		}
	}
}