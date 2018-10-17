using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallTop : WallCategory
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public WallTop(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, float width, float height)
            : base(name, spriteName, WallCategory.Type.Top)
        {
            this.poCollisionObject.poCollisionRect.Set(posX, posY, width, height);

            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(1, 0, 0);
        }
        ~WallTop()
        {

        }
        //---------------------------------------------------------
        // Override abstract class
        //---------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitWallTop(this);
        }
        public override void update()
        {
            base.update();
        }
        public override void visitMissile(Missile missile)
        {
            // Missile vs WallTop
            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            pColPair.setCollision(this, missile);
            pColPair.notifyListeners();
        }
    }
}
