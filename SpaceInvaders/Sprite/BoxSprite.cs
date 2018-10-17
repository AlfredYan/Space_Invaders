using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class BoxSprite_Base : SpriteBase
    {
        // make UML clearly
    }
    public class BoxSprite : BoxSprite_Base
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Name
        {
            Box,
            Box1,
            Box2,
            Uninitialized
        }
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public BoxSprite()
            : base()
        {
            this.name = BoxSprite.Name.Uninitialized;

            // set psAzulRect and psAzulColor
            Debug.Assert(BoxSprite.psAzulRect != null);
            BoxSprite.psAzulRect.Set(0, 0, 1, 1);

            // actual new for poAzulBoxSprite and poAzulColor
            this.poAzulColor = new Azul.Color(1, 1, 1);
            Debug.Assert(poAzulColor != null);
            this.poAzulBoxSprite = new Azul.SpriteBox(BoxSprite.psAzulRect, this.poAzulColor);
            Debug.Assert(this.poAzulBoxSprite != null);

            this.x = poAzulBoxSprite.x;
            this.y = poAzulBoxSprite.y;
            this.sx = poAzulBoxSprite.sx;
            this.sy = poAzulBoxSprite.sy;
            this.angle = poAzulBoxSprite.angle;
        }
        ~BoxSprite()
        {
            this.name = BoxSprite.Name.Uninitialized;
            this.poAzulColor = null;
            this.poAzulBoxSprite = null;
        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void set(BoxSprite.Name name, float x, float y, float width, float height, Azul.Color pColor)
        {
            Debug.Assert(this.poAzulBoxSprite != null);
            Debug.Assert(this.poAzulColor != null);

            Debug.Assert(psAzulRect != null);
            BoxSprite.psAzulRect.Set(x, y, width, height);

            this.name = name;

            if(pColor == null)
            {
                this.poAzulColor.Set(1, 1, 1);
            }
            else
            {
                this.poAzulColor.Set(pColor);
            }

            this.poAzulBoxSprite.Swap(psAzulRect, this.poAzulColor);
            Debug.Assert(this.poAzulBoxSprite != null);

            this.x = poAzulBoxSprite.x;
            this.y = poAzulBoxSprite.y;
            this.sx = poAzulBoxSprite.sx;
            this.sy = poAzulBoxSprite.sy;
            this.angle = poAzulBoxSprite.angle;
        }
        public void set(BoxSprite.Name name, float x, float y, float width, float height)
        {
            Debug.Assert(this.poAzulBoxSprite != null);
            Debug.Assert(this.poAzulColor != null);

            Debug.Assert(psAzulRect != null);
            BoxSprite.psAzulRect.Set(x, y, width, height);

            this.name = name;

            this.poAzulBoxSprite.Swap(psAzulRect, this.poAzulColor);
            Debug.Assert(this.poAzulBoxSprite != null);

            this.x = poAzulBoxSprite.x;
            this.y = poAzulBoxSprite.y;
            this.sx = poAzulBoxSprite.sx;
            this.sy = poAzulBoxSprite.sy;
            this.angle = poAzulBoxSprite.angle;
        }
        public void swapColor(Azul.Color pColor)
        {
            Debug.Assert(pColor != null);
            this.poAzulColor.Set(pColor);
            this.poAzulBoxSprite.SwapColor(pColor);
        }
        public void setLineColor(float red, float green, float blue, float alpha = 1.0f)
        {
            Debug.Assert(this.poAzulColor != null);
            this.poAzulColor.Set(red, green, blue, alpha);
            this.poAzulBoxSprite.SwapColor(this.poAzulColor);
        }
        public void setScreenRect(float x, float y, float width, float height)
        {
            this.set(this.name, x, y, width, height);
        }
        public new void clear()
        {
            // Do not null the poAzulSpriteBox it is created once in Default then reused
            // Do not null the poLineColor it is created once in Default then reused

            this.name = BoxSprite.Name.Uninitialized;
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
        public void setName(BoxSprite.Name name)
        {
            this.name = name;
        }
        public BoxSprite.Name getName()
        {
            return this.name;
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        public override void update()
        {
            this.poAzulBoxSprite.x = this.x;
            this.poAzulBoxSprite.y = this.y;
            this.poAzulBoxSprite.sx = this.sx;
            this.poAzulBoxSprite.sy = this.sy;
            this.poAzulBoxSprite.angle = this.angle;

            this.poAzulBoxSprite.Update();
        }
        public override void render()
        {
            this.poAzulBoxSprite.Render();
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private Name name;
        private Azul.Color poAzulColor;
        private Azul.SpriteBox poAzulBoxSprite;

        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;

        //---------------------------------------------------------------------------------------------------------
        // Static Data - prevent unecessary "new" in the above methods
        //---------------------------------------------------------------------------------------------------------
        private static Azul.Rect psAzulRect = new Azul.Rect();
        private static Azul.Color psAzulColor = new Azul.Color(1, 1, 1);
    }
}
