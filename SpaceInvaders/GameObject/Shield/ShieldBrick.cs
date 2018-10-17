using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldBrick : ShieldCategory
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public ShieldBrick(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName, ShieldCategory.Type.Brick)
        {
            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(0.0f, 1.0f, 0.0f);
        }
        ~ShieldBrick() 
        {

        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract class
        //---------------------------------------------------------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitShieldBrick(this);
        }
        public override void update()
        {
            base.update();
        }
        public override void visitMissile(Missile missile)
        {
            // Missile vs ShieldBrick
            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            pColPair.setCollision(this, missile);
            pColPair.notifyListeners();
        }

        public override void visitBomb(Bomb bomb)
        {
            // Bomb vs ShieldBrick
            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            pColPair.setCollision(bomb, this);
            pColPair.notifyListeners();
        }
    }
}
