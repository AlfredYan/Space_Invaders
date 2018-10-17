using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFO : UFOCategory
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public UFO(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY, bool stopSign = false)
            : base(name, spriteName, UFOCategory.Type.UFO)
        {
            this.x = posX;
            this.y = posY;

            this.UFOSpeed = 3.0f;
            this.stopSign = stopSign;
            //this.state = null;

        }
        
        public void dropBomb()
        {
            Bomb pBomb = BombMan.ActiveBomb();
            pBomb.setPos(this.x + 5, this.y - 40);
        }
        public override void accept(CollisionVisitor other)
        {
            other.visitUFO(this);
        }
        public override void update()
        {
            if(!this.stopSign)
                this.x += UFOSpeed;
            base.update();
        }
        public override void visitWallGroup(WallGroup wallGroup)
        {
            // wallGroup vs UFO
            GameObject pGameObj = (GameObject)Iterator.GetChild(wallGroup);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitWallRight(WallRight wallRight)
        {
            // WallRight vs UFO
            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.setCollision(wallRight, this);
            pColPair.notifyListeners();
        }
        public override void visitWallLeft(WallLeft wallLeft)
        {

        }
        public override void visitMissileGroup(MissileGroup missileGroup)
        {
            // UFO vs missile group
            //Debug.WriteLine("         collide:  {0} <-> {1}", missileGroup.getName(), this.getName());

            // crab vs missile
            GameObject pGameObj = (GameObject)Iterator.GetChild(missileGroup);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitMissile(Missile missile)
        {
            // UFO vs missile
            //Debug.WriteLine("         collide:  {0} <-> {1}", missile.getName(), this.getName());
            //Debug.WriteLine("-------> Done  <--------");

            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.setCollision(this, missile);
            pColPair.notifyListeners();
        }

        public float UFOSpeed;
        public bool stopSign;
        //private ShipState state;
    }
}
