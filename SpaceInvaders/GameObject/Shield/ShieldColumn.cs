using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldColumn : Composite
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public ShieldColumn(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }
        ~ShieldColumn()
        {

        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitShieldColumn(this);
        }
        public override void update()
        {
            BaseUpdateBoundingBox(this);
            base.update();
        }
        public override void visitMissile(Missile missile)
        {
            // Missile vs ShieldColumn
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(missile, pGameObj);
        }
        public override void visitBomb(Bomb bomb)
        {
            // Bomb vs ShieldColumn
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(bomb, pGameObj);
        }
    }
}
