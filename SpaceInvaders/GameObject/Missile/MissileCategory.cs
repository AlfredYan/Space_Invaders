using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class MissileCategory : Leaf
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Type
        {
            Missile,
            Group,
            Unitialized
        }
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public MissileCategory(GameObject.Name gameObjName, GameSprite.Name spriteName)
            : base(gameObjName, spriteName)
        {

        }
    }
}
