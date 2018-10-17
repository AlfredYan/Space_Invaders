using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumpLeft : BumpCategory
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public BumpLeft(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, BumpCategory.Type.Left)
        {
            this.poCollisionObject.poCollisionRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(1, 0, 0);
        }
        ~BumpLeft()
        {

        }
        //---------------------------------------------------------
        // Override abstract class
        //---------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitBumpLeft(this);
        }
        public override void update()
        {
            base.update();
        }
        public override void visitShipGroup(ShipGroup shipGroup)
        {
            // ShipGroup vs BumpLeft
            GameObject pGameObj = (GameObject)Iterator.GetChild(shipGroup);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitShip(Ship ship)
        {
            // ship vs BumpLeft
            //Debug.WriteLine("   --->DONE<----");

            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.setCollision(ship, this);
            pColPair.notifyListeners();
        }
    }
}
