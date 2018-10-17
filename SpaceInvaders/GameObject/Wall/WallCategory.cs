using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class WallCategory : Leaf
    {
        //---------------------------------------------------------
        // Enum
        //---------------------------------------------------------
        public enum Type
        {
            WallGroup,
            Right,
            Left,
            Bottom,
            Top,
            Unitialized
        }
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        protected WallCategory(GameObject.Name name, GameSprite.Name spriteName, WallCategory.Type type)
            : base(name, spriteName)
        {
            this.type = type;
        }
        ~WallCategory()
        {

        }
        //---------------------------------------------------------
        // Methods
        //---------------------------------------------------------
        public WallCategory.Type GetCategoryType()
        {
            return this.type;
        }
        //---------------------------------------------------------
        // Data
        //---------------------------------------------------------
        protected WallCategory.Type type;
    }
}
