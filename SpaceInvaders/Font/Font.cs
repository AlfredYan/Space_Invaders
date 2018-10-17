using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Font : DLink
    {
        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
            Score,
            ScoreOne,
            HighestScore,
            ScoreTwo,
            Texts,

            NullObject,
            Uninitialized
        };
        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Font()
            : base()
        {
            this.name = Name.Uninitialized;
            this.pFontSprite = new FontSprite();
        }
        ~Font()
        {
            this.name = Name.Uninitialized;
            this.pFontSprite = null;
        }
        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public void updateMessage(String pMessage)
        {
            Debug.Assert(pMessage != null);
            Debug.Assert(this.pFontSprite != null);
            this.pFontSprite.updateMessage(pMessage);
        }
        public void set(Font.Name name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            Debug.Assert(pMessage != null);

            this.name = name;
            this.pFontSprite.set(name, pMessage, glyphName, xStart, yStart);
        }
        public void deepClear()
        {
            this.name = Name.Uninitialized;
            this.pFontSprite.set(Font.Name.NullObject, pNullString, Glyph.Name.NullObject, 0.0f, 0.0f);
        }
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public Name name;
        public FontSprite pFontSprite;
        static private String pNullString = "null";
    }
}
