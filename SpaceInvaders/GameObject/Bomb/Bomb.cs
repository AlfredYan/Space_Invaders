using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Bomb : BombCategory
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public Bomb(GameObject.Name name, GameSprite.Name spriteName, FallStrategy strategy, float posX, float posY)
            : base(name, spriteName, BombCategory.Type.Bomb)
        {
            this.x = posX;
            this.y = posY;
            this.delta = 5.0f;

            Debug.Assert(strategy != null);
            this.pStrategy = strategy;

            this.pStrategy.reset(this.y);

            this.poCollisionObject.pCollisionSprite.setLineColor(1, 1, 0);
        }
        ~Bomb()
        {

        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract method
        //---------------------------------------------------------------------------------------------------------
        public override void remove()
        {
            // the root object is being drawn

            // 1. set size to zero
            this.poCollisionObject.poCollisionRect.Set(0, 0, 0, 0);
            base.update();

            // 2. update the parent
            GameObject pParent = (GameObject)this.pParent;
            pParent.update();

            // remove it
            base.remove();
        }
        public override void update()
        {
            base.update();
            this.y -= delta;

            // strategy
            this.pStrategy.fall(this);
        }
        public override void accept(CollisionVisitor other)
        {
            other.visitBomb(this);
        }
        public override void visitMissile(Missile missile)
        {
            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.setCollision(this, missile);
            pColPair.notifyListeners();
        }
        public override void visitShip(Ship ship)
        {
            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.setCollision(this, ship);
            pColPair.notifyListeners();
        }
        //---------------------------------------------------------------------------------------------------------
        // Method
        //---------------------------------------------------------------------------------------------------------
        public void setPos(float posX, float posY)
        {
            this.x = posX;
            this.y = posY;
        }
        public void multiplyScale(float sx, float sy)
        {
            Debug.Assert(this.getProxySprite() != null);

            this.getProxySprite().sx *= sx;
            this.getProxySprite().sy *= sy;
        }
        public void reset()
        {
            this.y = 700.0f;
            this.pStrategy.reset(this.y);
        }
        public float getBoundingBoxHeight()
        {
            return this.poCollisionObject.poCollisionRect.height;
        }
        public void setShooter(AlienCategory pAlien)
        {
            this.pShooter = pAlien;
        }
        public AlienCategory getShooter()
        {
            return this.pShooter;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        public float delta;
        private FallStrategy pStrategy;
        private AlienCategory pShooter;
    }
}
