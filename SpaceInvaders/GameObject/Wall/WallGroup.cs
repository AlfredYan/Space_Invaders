using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallGroup: Composite
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public WallGroup(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(0, 0, 1);
        }
        ~WallGroup()
        {

        }
        //---------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------
        public override void update()
        {
            base.BaseUpdateBoundingBox(this);
            base.update();
        }
        public override void accept(CollisionVisitor other)
        {
            other.visitWallGroup(this);
        }
        public override void visitMissileGroup(MissileGroup missileGroup)
        {
            // MissileRoot vs WallRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(missileGroup);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitMissile(Missile missile)
        {
            // Missile vs WallRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(missile, pGameObj);
        }
        public override void visitAlienGroup(AlienGroup alienGroup)
        {
            // AlienGroup vs WallGroup
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(alienGroup, pGameObj);
        }
        public override void visitBombRoot(BombRoot bombRoot)
        {
            // BombRoot vs WallRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(bombRoot);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitBomb(Bomb bomb)
        {
            // Bomb vs WallRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(bomb, pGameObj);
        }
    }
}
