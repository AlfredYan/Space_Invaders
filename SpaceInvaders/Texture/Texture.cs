using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Texture_Link : DLink
    {

    }
    public class Texture : Texture_Link
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Name
        {
            SpaceInvaders,
            Shields,
            Consolas36pt,

            Default,
            NullObject,
            Uninitialized
        }

        //---------------------------------------------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------------------------------------------
        public Texture()
            : base()
        {
            Debug.Assert(Texture.psDefaultAzulTexture != null);

            // set default texture for pAzulTexture
            this.poAzulTexture = Texture.psDefaultAzulTexture;
            Debug.Assert(poAzulTexture != null);

            // set default value for name
            this.name = Texture.Name.Default;
        }
        ~Texture()
        {
            this.name = Texture.Name.Uninitialized;
            this.poAzulTexture = null;
        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void set(Texture.Name name, string pTextureFile)
        {
            this.name = name;

            // ensure pTextureFile is not null
            Debug.Assert(pTextureFile != null);

            // ensure pAzulTexture has default texture
            Debug.Assert(this.poAzulTexture != null);

            // load pTextureFile
            this.poAzulTexture = new Azul.Texture(pTextureFile);
            Debug.Assert(this.poAzulTexture != null);
        }
        public Azul.Texture GetAzulTexture()
        {
            Debug.Assert(this.poAzulTexture != null);
            return this.poAzulTexture;
        }
        public new void clear()
        {
            // Do not clear the poAzulTexture it is created once in Default then replaced in Set

            this.name = Texture.Name.Uninitialized;
        }
        public void deepClear()
        {
            // clear the entire hierarchy
            base.clear();
            this.clear();
        }
        public void setName(Texture.Name name)
        {
            this.name = name;
        }
        public Texture.Name getName()
        {
            return this.name;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private Texture.Name name;
        private Azul.Texture poAzulTexture;

        //---------------------------------------------------------------------------------------------------------
        // Static Data
        //---------------------------------------------------------------------------------------------------------
        private static Azul.Texture psDefaultAzulTexture = new Azul.Texture("HotPink.tga", Azul.Texture_Filter.NEAREST, Azul.Texture_Filter.NEAREST);
    }
}
