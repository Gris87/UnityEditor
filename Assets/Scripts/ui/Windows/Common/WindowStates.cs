namespace UI.Windows.Common
{
	/// <summary>
	/// This enum type is used to specify the current state of window.
	/// </summary>
	public enum WindowStates
	{
		/// <summary>
		/// The window has no state set.
		/// </summary>
		NoState
		,
		/// <summary>
		/// The window is minimized
		/// </summary>
		Minimized
		,
		/// <summary>
		/// The window is maximized with a frame around it.
		/// </summary>
		Maximized
		,
		/// <summary>
		/// The window fills the entire screen without any frame around it.
		/// </summary>
		FullScreen
	}
}

