using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameSprite_Base : SpriteBase
    {
        // make UML clearly
    }
    public class GameSprite : GameSprite_Base
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Name
        {
            Octopus,
            Crab,
            Squid,

            Missile,
            Ship,

            Brick,
            Brick_LeftTop0,
            Brick_LeftTop1,
            Brick_LeftBottom,
            Brick_RightTop0,
            Brick_RightTop1,
            Brick_RightBottom,

            BombDagger,
            BombStraight,
            BombZigZag,

            Ship_Explosion1,
            Ship_Explosion2,
            Missile_Explosion,
            Alien_Explosion,
            UFO_Explosion,
            Bomb_Explosion,

            UFO,

            NullObject,
            Uninitialized
        }
        //---------------------------------------------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------------------------------------------
        public GameSprite()
            : base()
        {
            this.name = GameSprite.Name.Uninitialized;

            // set default image to pImage, it will be replace in the set()
            this.pImage = ImageMan.Find(Image.Name.Default);
            Debug.Assert(this.pImage != null);

            // set static Azul.Rect and static Azul.Color - as defalt value of GameSprite
            Debug.Assert(GameSprite.psAzulColor != null);
            GameSprite.psAzulColor.Set(1, 1, 1);

            // only new Azul.Rect here
            this.poScreenRect = new Azul.Rect();
            Debug.Assert(this.poScreenRect != null);
            this.poScreenRect.Clear();

            // only new Azul.Sprite here
            this.poAzulSprite = new Azul.Sprite(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.poScreenRect, GameSprite.psAzulColor);
            Debug.Assert(this.poAzulSprite != null);

            // only new Azul.color here
            this.poAzulColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.poAzulColor != null);

            this.x = this.poAzulSprite.x;
            this.y = this.poAzulSprite.y;
            this.sx = this.poAzulSprite.sx;
            this.sy = this.poAzulSprite.sy;
            this.angle = this.poAzulSprite.angle;
        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void set(GameSprite.Name name, Image pImage, float x, float y, float width, float height, Azul.Color pColor)
        {
            // ensure parameters are reasonable
            Debug.Assert(pImage != null);
            Debug.Assert(this.poScreenRect != null);
            Debug.Assert(this.poAzulSprite != null);

            this.poScreenRect.Set(x, y, width, height);
            this.pImage = pImage;
            this.name = name;

            if (pColor != null)
            {
                this.poAzulColor.Set(pColor);
            }
            else
            {
                Debug.Assert(GameSprite.psAzulColor != null);
                GameSprite.psAzulColor.Set(1,1,1);

                this.poAzulColor.Set(GameSprite.psAzulColor);
            }

            this.poAzulSprite.Swap(pImage.GetAzulTexture(), pImage.GetAzulRect(), this.poScreenRect, this.poAzulColor);

            this.x = poAzulSprite.x;
            this.y = poAzulSprite.y;
            this.sx = poAzulSprite.sx;
            this.sy = poAzulSprite.sy;
            this.angle = poAzulSprite.angle;
        }
        public void swapImage(Image pNewImage)
        {
            Debug.Assert(this.poAzulSprite != null);
            Debug.Assert(pNewImage != null);
            this.pImage = pNewImage;

            this.poAzulSprite.SwapTexture(this.pImage.GetAzulTexture());
            this.poAzulSprite.SwapTextureRect(this.pImage.GetAzulRect());
        }
        public new void clear()
        {
            // Do not clear the poAzulSprite it is created once in Default then reused

            this.name = GameSprite.Name.Uninitialized;
            this.pImage = null;

            this.poAzulColor.Set(1, 1, 1);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }
        public void deepClear()
        {
            base.clear();
            this.clear();
        }
        public void setName(GameSprite.Name name)
        {
            this.name = name;
        }
        public GameSprite.Name getName()
        {
            return this.name;
        }
        public void setImage(Image pImage)
        {
            this.pImage = pImage;
        }
        public Image getImage()
        {
            return this.pImage;
        }
        public Azul.Rect getScreenRect()
        {
            return this.poScreenRect;
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        public override void update()
        {
            this.poAzulSprite.x = this.x;
            this.poAzulSprite.y = this.y;
            this.poAzulSprite.sx = this.sx;
            this.poAzulSprite.sy = this.sy;
            this.poAzulSprite.angle = this.angle;

            // update the sprite
            this.poAzulSprite.Update();
        }
        public override void render()
        {
            // render sprite to screen
            this.poAzulSprite.Render();
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private GameSprite.Name name;
        private Image pImage;
        private Azul.Sprite poAzulSprite;
        private Azul.Rect poScreenRect;
        private Azul.Color poAzulColor;

        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;
        //---------------------------------------------------------------------------------------------------------
        // Static Data - prevent unecessary "new" in the above methods
        //---------------------------------------------------------------------------------------------------------
        //static private Azul.Rect psAzulRect = new Azul.Rect();
        static private Azul.Color psAzulColor = new Azul.Color(1, 1, 1);
    }
}
