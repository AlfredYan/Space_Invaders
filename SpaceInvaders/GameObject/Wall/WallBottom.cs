using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallBottom : WallCategory
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public WallBottom(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, WallCategory.Type.Top)
        {
            this.poCollisionObject.poCollisionRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(1, 0, 0);
        }
        ~WallBottom()
        {

        }
        //---------------------------------------------------------
        // Override abstract class
        //---------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitWallBottom(this);
        }
        public override void update()
        {
            base.update();
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
