using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallLeft : WallCategory
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public WallLeft(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, WallCategory.Type.Left)
        {
            this.poCollisionObject.poCollisionRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(1, 0, 0);
        }
        ~WallLeft()
        {

        }
        //---------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitWallLeft(this);
        }
        public override void update()
        {
            base.update();
        }
        public override void visitAlienGroup(AlienGroup alienGroup)
        {
            // AlienGroup vs WallLeft
            //Debug.WriteLine("   --->DONE<----");

            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.setCollision(alienGroup, this);
            pColPair.notifyListeners();
        }
        public override void visitBomb(Bomb bomb)
        {
            // bomb vs WallBottom
            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            pColPair.setCollision(bomb, this);
            pColPair.notifyListeners();
        }
    }
}
