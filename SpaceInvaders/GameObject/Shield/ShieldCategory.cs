using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ShieldCategory : Leaf
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Type
        {
            Root,
            Grid,
            Column,
            Brick,
            
            LeftTop0,
            LeftTop1,
            LeftBottom,
            RightTop0,
            RightTop1,
            RightBottom,

            Unitialized
        }
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        protected ShieldCategory(GameObject.Name name, GameSprite.Name spriteName, ShieldCategory.Type shieldType)
            : base(name, spriteName)
        {
            this.type = shieldType;
        }
        ~ShieldCategory()
        {

        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public ShieldCategory.Type getCategoryType()
        {
            return this.type;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        protected ShieldCategory.Type type;
    }
}
