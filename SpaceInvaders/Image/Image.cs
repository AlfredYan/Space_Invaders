using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Image_Link : DLink
    {

    }
    public class Image : Image_Link
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Name
        {
            Octopus,
            OctopusMovement,
            Crab,
            CrabMovement,
            Squid,
            SquidMovement,

            Missile,
            Ship,

            Brick,
            BrickLeft_Top0,
            BrickLeft_Top1,
            BrickLeft_Bottom,
            BrickRight_Top0,
            BrickRight_Top1,
            BrickRight_Bottom,

            BombStraight,
            BombZigZag,
            BombCross,

            Ship_Explosion1,
            Ship_Explosion2,
            Missile_Explosion,
            Alien_Explosion,
            UFO_Explosion,
            Bomb_Explosion,

            UFO,

            Default,
            NullObject,
            Uninitialized
        }
        //---------------------------------------------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------------------------------------------
        public Image()
            : base()
        {
            // initialize pAzulRect
            this.poAzulRect = new Azul.Rect();
            Debug.Assert(poAzulRect != null);

            this.clear();
        }
        ~Image()
        {
            this.name = Image.Name.Uninitialized;
            this.poAzulRect = null;
            this.poAzulRect = null;
        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void set(Image.Name name, Texture pTexture, float x, float y, float width, float height)
        {
            // ensure pTexture(parameter) is not null
            Debug.Assert(pTexture != null);

            this.name = name;
            this.pTexture = pTexture;
            this.poAzulRect.Set(x, y, width, height);
        }
        public Azul.Rect GetAzulRect()
        {
            Debug.Assert(this.poAzulRect != null);
            return this.poAzulRect;
        }
        public Azul.Texture GetAzulTexture()
        {
            Debug.Assert(this.pTexture != null);
            return this.pTexture.GetAzulTexture();
        }
        public new void clear()
        {
            this.name = Image.Name.Uninitialized;
            this.pTexture = null;
            this.poAzulRect.Clear();
        }
        public void deepClear()
        {
            base.clear();
            this.clear();
        }
        public void setName(Image.Name name)
        {
            this.name = name;
        }
        public Image.Name getName()
        {
            return this.name;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private Image.Name name;
        private Texture pTexture;
        private Azul.Rect poAzulRect;
    }
}
