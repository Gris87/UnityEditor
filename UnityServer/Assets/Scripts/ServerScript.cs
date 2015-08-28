using UnityEngine;



/// <summary>
/// Server script.
/// </summary>
public class ServerScript : MonoBehaviour
{
	/// <summary>
	/// Gets a value indicating whether this <see cref="ServerScript"/> is started.
	/// </summary>
	/// <value><c>true</c> if is started; otherwise, <c>false</c>.</value>
	public bool isStarted
	{
		get { return mStarted; }
	}



	private bool mStarted;



    /// <summary>
    /// Script starting callback.
    /// </summary>
    void Start()
    {
		mStarted = false;

		Network.InitializeServer(10000, 52794, !Network.HavePublicAddress());
		StartServer();
    }

	/// <summary>
	/// Starts the server.
	/// </summary>
	public void StartServer()
	{
		if (!mStarted)
		{
			MasterServer.RegisterHost("UnityEditor", "Server #1");
			mStarted = true;
		}
		else
		{
			Debug.LogError("Server already started");
		}
	}

	/// <summary>
	/// Stops the server.
	/// </summary>
	public void StopServer()
	{
		if (mStarted)
		{
			MasterServer.UnregisterHost();
			mStarted = false;
		}
		else
		{
			Debug.LogError("Server already stopped");
		}
	}
}
