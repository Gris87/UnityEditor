using UnityEngine;
using UnityEngine.UI;



namespace Common.UI.ResourceTypes
{
    /// <summary>
    /// Text style.
    /// </summary>
    public class TextStyle
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
        /// Gets or sets the font style.
        /// </summary>
        /// <value>The font style.</value>
        public FontStyle fontStyle
        {
            get { return mFontStyle;  }
            set { mFontStyle = value; }
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
        /// Gets or sets the line spacing.
        /// </summary>
        /// <value>The line spacing.</value>
        public float lineSpacing
        {
            get
            {
                return mLineSpacing;
            }

            set
            {
                if (value < 0f)
                {
                    value = 0f;
                }

                mLineSpacing = value;
            }
        }

        /// <summary>
        /// Gets or sets the alignment.
        /// </summary>
        /// <value>The alignment.</value>
        public TextAnchor alignment
        {
            get { return mAlignment;  }
            set { mAlignment = value; }
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
        private FontStyle  mFontStyle;
        private int        mFontSize;
        private float      mLineSpacing;
        private TextAnchor mAlignment;
        private Color      mColor;



        /// <summary>
        /// Initializes a new instance of the <see cref="Common.UI.ResourceTypes.TextStyle"/> class.
        /// </summary>
        public TextStyle()
        {
            mFont        = null;
            mFontStyle   = FontStyle.Normal;
            mFontSize    = 12;
            mLineSpacing = 1f;
            mAlignment   = TextAnchor.UpperLeft;
            mColor       = new Color(0f, 0f, 0f);
        }

        /// <summary>
        /// Apply text style to specified text component.
        /// </summary>
        /// <param name="text">Text component.</param>
        public void Apply(Text text)
        {
            text.font        = mFont;
            text.fontStyle   = mFontStyle;
            text.fontSize    = mFontSize;
            text.lineSpacing = mLineSpacing;
            text.alignment   = mAlignment;
            text.color       = mColor;
        }
    }
}
