using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipGroup: Composite
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public ShipGroup(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(0, 0, 1);
        }
        ~ShipGroup()
        {

        }
        //---------------------------------------------------------
        // Override abstract class
        //---------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitShipGroup(this);
        }
        public override void update()
        {
            base.BaseUpdateBoundingBox(this);
            base.update();
        }
        public override void visitBumpGroup(BumpGroup bumpGroup)
        {
            // ShipGroup vs BumpGroup
            GameObject pGameObj = (GameObject)Iterator.GetChild(bumpGroup);
            CollisionPair.Collide(this, pGameObj);
        }
    }
}
