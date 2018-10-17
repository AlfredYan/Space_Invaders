using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FontSprite : SpriteBase
    {
        //--------------------------------------------------------------------------------
        // Constructors
        //--------------------------------------------------------------------------------
        public FontSprite()
            : base()
        {
            // Create a dummy sprite, it will get correctly linked in Set()

            this.pAzulSprite = new Azul.Sprite();
            this.pScreenRect = new Azul.Rect();
            this.pColor = new Azul.Color(1.0f, 1.0f, 1.0f);

            this.pMessage = null;
            this.glyphName = Glyph.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;

        }
        ~FontSprite()
        {
            this.pAzulSprite = null;
            this.pScreenRect = null;
            this.pColor = null;
            this.pMessage = null;
        }
        //---------------------------------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------------------------------
        public override void update()
        {
            Debug.Assert(this.pAzulSprite != null);
        }
        public override void render()
        {
            Debug.Assert(this.pAzulSprite != null);
            Debug.Assert(this.pColor != null);
            Debug.Assert(this.pScreenRect != null);
            Debug.Assert(this.pMessage != null);
            Debug.Assert(this.pMessage.Length > 0);

            float xTmp = this.x;
            float yTmp = this.y;

            float xEnd = this.x;

            for (int i = 0; i < this.pMessage.Length; i++)
            {
                int key = Convert.ToByte(pMessage[i]);

                Glyph pGlyph = GlyphMan.Find(this.glyphName, key);
                Debug.Assert(pGlyph != null);

                xTmp = xEnd + pGlyph.getAzulSubRect().width / 2;
                this.pScreenRect.Set(xTmp, yTmp, pGlyph.getAzulSubRect().width, pGlyph.getAzulSubRect().height);

                pAzulSprite.Swap(pGlyph.getAzulTexture(), pGlyph.getAzulSubRect(), this.pScreenRect, this.pColor);

                pAzulSprite.Update();
                pAzulSprite.Render();

                // move the starting to the next character
                xEnd = pGlyph.getAzulSubRect().width / 2 + xTmp;

            }
        }
        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public void set(Font.Name name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            Debug.Assert(pMessage != null);
            this.pMessage = pMessage;

            this.x = xStart;
            this.y = yStart;

            this.name = name;
            this.glyphName = glyphName;

            // Force color to white
            Debug.Assert(this.pColor != null);
            this.pColor.Set(1.0f, 1.0f, 1.0f);
        }
        public void updateMessage(String pMessage)
        {
            Debug.Assert(pMessage != null);
            this.pMessage = pMessage;
        }
        public void setColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.pColor != null);
            this.pColor.Set(red, green, blue, alpha);
        }
        public Glyph.Name getGlyphName()
        {
            return this.glyphName;
        }
        // ---------------------------------------------------------------------------------
        // Data
        // ---------------------------------------------------------------------------------
        public Font.Name name;
        private Azul.Sprite pAzulSprite;
        private Azul.Rect pScreenRect;
        private Azul.Color pColor;   // this color is multplied by the texture

        private String pMessage;
        public Glyph.Name glyphName;

        public float x;
        public float y;

        
    }
}
