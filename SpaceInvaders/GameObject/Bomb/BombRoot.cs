using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombRoot : Composite
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public BombRoot(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(1, 1, 1);
        }
        ~BombRoot()
        {
        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract method
        //---------------------------------------------------------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitBombRoot(this);
        }
        public override void update()
        {
            base.BaseUpdateBoundingBox(this);
            base.update();
        }
        public override void visitShipGroup(ShipGroup shipGroup)
        {
            // BombGroup vs ShipGroup
            GameObject pGameObj = (GameObject)Iterator.GetChild(shipGroup);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitShip(Ship ship)
        {
            // BombGroup vs Ship
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(ship, pGameObj);
        }
    }
}
