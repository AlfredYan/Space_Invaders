using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Missile : MissileCategory
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public Missile(GameObject.Name gameName, GameSprite.Name spriteName, float posX, float posY)
            : base(gameName, spriteName)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 15.0f;

            this.poCollisionObject.pCollisionSprite.setLineColor(0.0f, 1.0f, 0.0f);
        }
        ~Missile()
        {

        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void setPos(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitMissile(this);
        }
        public override void update()
        {
            base.update();
            this.y += delta;
        }
        public override void remove()
        {
            this.poCollisionObject.poCollisionRect.Set(0, 0, 0, 0);
            base.update();

            // update parent (missile root)
            GameObject pParent = (GameObject)this.pParent;
            pParent.update();

            // remove it
            base.remove();
        }
        public override void visitBombRoot(BombRoot bombRoot)
        {
            // Missile vs BombRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(bombRoot);
            CollisionPair.Collide(this, pGameObj);
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        public float delta;
    }
}
