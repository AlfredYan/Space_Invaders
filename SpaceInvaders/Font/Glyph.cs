﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Glyph : DLink
    {
        //----------------------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------------------
        public enum Name
        {
            Consolas36pt,

            NullObject,
            Uninitialized
        }
        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        public Glyph()
            : base()
        {
            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.pSubRect = new Azul.Rect();
            this.key = 0;
        }
        ~Glyph()
        {
            this.name = Name.Uninitialized;
            this.pSubRect = null;
            this.pTexture = null;
        }
        //----------------------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------------------
        public void set(Glyph.Name name, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            Debug.Assert(this.pSubRect != null);
            this.name = name;

            this.pTexture = TextureMan.Find(textName);
            Debug.Assert(this.pTexture != null);

            this.pSubRect.Set(x, y, width, height);

            this.key = key;

        }
        public void deepClear()
        {
            this.name = Name.Uninitialized;
            this.pTexture = null;
            this.pSubRect.Set(0, 0, 1, 1);
            this.key = 0;
        }
        public Azul.Rect getAzulSubRect()
        {
            Debug.Assert(this.pSubRect != null);
            return this.pSubRect;
        }
        public Azul.Texture getAzulTexture()
        {
            Debug.Assert(this.pTexture != null);
            return this.pTexture.GetAzulTexture();
        }
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        public Name name;
        public int key;
        private Azul.Rect pSubRect;
        private Texture pTexture;
    }
}
