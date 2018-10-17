using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissileGroup : Composite
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public MissileGroup(GameObject.Name gameName, GameSprite.Name spriteName, float posX, float posY)
            : base(gameName, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(1, 1, 0);
        }

        ~MissileGroup()
        {

        }
        //----------------------------------------------------------------------
        // Override abstract methods
        //----------------------------------------------------------------------
        public override void update()
        {

            base.BaseUpdateBoundingBox(this);

            base.update();
        }
        public override void accept(CollisionVisitor other)
        {
            other.visitMissileGroup(this);
        }
        public override void visitBombRoot(BombRoot bombRoot)
        {
            // MissileGroup vs BombRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(bombRoot, pGameObj);
        }
    }
}
