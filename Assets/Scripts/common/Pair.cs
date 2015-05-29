namespace Common
{
	/// <summary>
	/// Combination of two types in one.
	/// </summary>
	public class Pair<T1, T2>
	{
		/// <summary>
		/// The first value.
		/// </summary>
		public T1 first;

		/// <summary>
		/// The second value.
		/// </summary>
		public T2 second;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.Pair`2"/> class.
		/// </summary>
		/// <param name="v1">First value.</param>
		/// <param name="v2">Second value.</param>
		public Pair(T1 v1, T2 v2)
		{
			first  = v1;
			second = v2;
		}
	}
}

