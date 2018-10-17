using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldGrid : Composite
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public ShieldGrid(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }
        ~ShieldGrid()
        {

        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitShieldGrid(this);
        }
        public override void update()
        {
            base.BaseUpdateBoundingBox(this);
            base.update();
        }
        public override void visitMissile(Missile missile)
        {
            // Missile vs ShieldGrid
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(missile, pGameObj);
        }
        public override void visitBomb(Bomb bomb)
        {
            // Bomb vs ShieldGrid
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(bomb, pGameObj);
        }
    }
}
