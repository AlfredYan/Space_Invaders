using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ShipCategory : Leaf
    {
        //---------------------------------------------------------
        // Enum
        //---------------------------------------------------------
        public enum Type
        {
            Ship,
            ShipGroup,
            Unitialized
        }
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        protected ShipCategory(GameObject.Name name, GameSprite.Name spriteName, ShipCategory.Type shipType)
            : base(name, spriteName)
        {
            this.type = shipType;
        }
        ~ShipCategory()
        {

        }
        //---------------------------------------------------------
        // Data
        //---------------------------------------------------------
        protected ShipCategory.Type type;
    }
}
