using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumpRight : BumpCategory
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public BumpRight(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, BumpCategory.Type.Right)
        {
            this.poCollisionObject.poCollisionRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(1, 0, 0);
        }
        ~BumpRight()
        {

        }
        //---------------------------------------------------------
        // Override abstract class
        //---------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitBumpRight(this);
        }
        public override void update()
        {
            base.update();
        }
        public override void visitShipGroup(ShipGroup shipGroup)
        {
            // ShipGroup vs BumpRight
            GameObject pGameObj = (GameObject)Iterator.GetChild(shipGroup);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitShip(Ship ship)
        {
            // ship vs BumpRight
            //Debug.WriteLine("   --->DONE<----");

            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.setCollision(ship, this);
            pColPair.notifyListeners();
        }
    }
}
