using UnityEngine;



namespace Common
{
	/// <summary>
	/// Class that provide mouse position in normal coordinate system.
	/// </summary>
	public static class Mouse
	{
		/// <summary>
		/// Gets the x coordinate.
		/// </summary>
		/// <value>The x coordinate.</value>
		public static float x
		{
			get
			{
				UpdatePosition();

				return mX;
			}
		}

		/// <summary>
		/// Gets the y coordinate.
		/// </summary>
		/// <value>The y coordinate.</value>
		public static float y
		{
			get
			{
				UpdatePosition();
				
				return mY;
			}
		}

		/// <summary>
		/// Gets the scaled x coordinate.
		/// </summary>
		/// <value>The scaled x coordinate.</value>
		public static float scaledX
		{
			get	{ return x / Utils.canvasScale;	}
		}

		/// <summary>
		/// Gets the scaled y coordinate.
		/// </summary>
		/// <value>The scaled y coordinate.</value>
		public static float scaledY
		{
			get { return y / Utils.canvasScale;	}
		}



		private static float mX;
		private static float mY;
		private static int   mLastUpdate;



		/// <summary>
		/// Initializes the <see cref="Common.Mouse"/> class.
		/// </summary>
		static Mouse()
		{
			mX          = -1;
			mY          = -1;
			mLastUpdate = -1;
		}

		/// <summary>
		/// Updates position if needed.
		/// </summary>
		private static void UpdatePosition()
		{
			if (mLastUpdate != Time.frameCount)
			{
				mLastUpdate = Time.frameCount;

				Vector3 mousePos = InputControl.mousePosition;
				
				mX = mousePos.x;
				mY = Screen.height - mousePos.y;
			}
		}
	}
}

