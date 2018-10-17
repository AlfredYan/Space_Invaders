using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipLifeGroup : Composite
    {
        public ShipLifeGroup(Name gameName, GameSprite.Name spriteName, float posX, float posY) 
            : base(gameName, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(0, 0, 1);
        }

        public override void accept(CollisionVisitor other)
        {
            throw new NotImplementedException();
        }
    }
}
