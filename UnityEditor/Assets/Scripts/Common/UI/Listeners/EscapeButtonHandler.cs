namespace Common.UI.Listeners
{
	/// <summary>
	/// Interface for escape button handler.
	/// </summary>
	public interface EscapeButtonHandler
	{
		/// <summary>
		/// Handles escape button press event.
		/// </summary>
		/// <returns><c>true</c>, if escape button was handled, <c>false</c> otherwise.</returns>
		bool OnEscapeButtonPressed();
	}
}

