using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class BumpCategory : Leaf
    {
        //---------------------------------------------------------
        // Enum
        //---------------------------------------------------------
        public enum Type
        {
            BumpGroup,
            Right,
            Left,
            Unitialized
        }
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        protected BumpCategory(GameObject.Name name, GameSprite.Name spriteName, BumpCategory.Type type)
            : base(name, spriteName)
        {
            this.type = type;
        }
        ~BumpCategory()
        {

        }
        //---------------------------------------------------------
        // Methods
        //---------------------------------------------------------
        public BumpCategory.Type GetCategoryType()
        {
            return this.type;
        }
        //---------------------------------------------------------
        // Data
        //---------------------------------------------------------
        protected BumpCategory.Type type;
    }
}
