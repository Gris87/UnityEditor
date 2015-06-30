using UnityEngine;
using UnityEngine.UI;



namespace Common.UI.ResourceTypes
{
	/// <summary>
	/// Font style resource.
	/// </summary>
	public class FontStyleResource
	{
		/// <summary>
		/// Gets or sets the font.
		/// </summary>
		/// <value>Font.</value>
		public Font font
		{
			get { return mFont;  }
			set { mFont = value; }
		}

		/// <summary>
		/// Gets or sets the size of the font.
		/// </summary>
		/// <value>The size of the font.</value>
		public int fontSize
		{
			get
			{
				return mFontSize; 
			}

			set 
			{
				if (value < 0)
				{
					value = 0;
				}

				mFontSize = value; 
			}
        }

		/// <summary>
		/// Gets or sets the text anchor.
		/// </summary>
		/// <value>The text anchor.</value>
		public TextAnchor textAnchor
		{
			get { return mTextAnchor;  }
			set { mTextAnchor = value; }
        }
        
		/// <summary>
		/// Gets or sets the font color.
		/// </summary>
		/// <value>Font color.</value>
		public Color color
		{
			get { return mColor;  }
			set { mColor = value; }
        }
        


		private Font       mFont;
		private int        mFontSize;
		private TextAnchor mTextAnchor;
		private Color      mColor;



		/// <summary>
		/// Initializes a new instance of the <see cref="Common.UI.ResourceTypes.FontStyleResource"/> class.
		/// </summary>
		public FontStyleResource()
		{
			mFont       = null;
			mFontSize   = 12;
			mTextAnchor = TextAnchor.UpperLeft;
			mColor      = new Color(0f, 0f, 0f);
		}

		/// <summary>
		/// Apply font style to specified text component.
		/// </summary>
		/// <param name="text">Text component.</param>
		public void Apply(Text text)
		{
			text.font      = mFont;
			text.fontSize  = mFontSize;
			text.alignment = mTextAnchor;
			text.color     = mColor;
		}
	}
}
