using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class BombCategory : Leaf
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Type
        {
            Bomb,
            BombRoot,
            Unitialized
        }
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        protected BombCategory(GameObject.Name name, GameSprite.Name spriteName, BombCategory.Type bombType)
            : base(name, spriteName)
        {
            this.type = bombType;
        }
        ~BombCategory()
        {

        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        protected BombCategory.Type type;
    }
}
