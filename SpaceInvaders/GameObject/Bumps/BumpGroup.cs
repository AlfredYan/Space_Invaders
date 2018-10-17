using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumpGroup : Composite
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public BumpGroup(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(0, 0, 1);
        }
        ~BumpGroup()
        {

        }
        //---------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------
        public override void update()
        {
            base.BaseUpdateBoundingBox(this);
            base.update();
        }
        public override void accept(CollisionVisitor other)
        {
            other.visitBumpGroup(this);
        }
    }
}
