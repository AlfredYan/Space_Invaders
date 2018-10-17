using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class UFOCategory : Leaf
    {
        public enum Type
        {
            UFO,
            UFOGroup,
            Unitialized
        }
        protected UFOCategory(GameObject.Name name, GameSprite.Name spriteName, UFOCategory.Type UFOType)
            : base(name, spriteName)
        {
            this.type = UFOType;
        }
        ~UFOCategory()
        {

        }

        protected UFOCategory.Type type;
    }
}
