using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Squid : AlienCategory
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public Squid(GameObject.Name gameName, GameSprite.Name spriteName, float posX, float posY)
            : base(gameName, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }
        ~Squid()
        {

        }
        //----------------------------------------------------------------------
        // Override abstract methods
        //----------------------------------------------------------------------
        public override void update()
        {
            base.update();
        }
        public override void accept(CollisionVisitor other)
        {
            other.visitSquid(this);
        }
        public override void visitMissileGroup(MissileGroup missileGroup)
        {
            // Squid vs missile group
            //Debug.WriteLine("         collide:  {0} <-> {1}", missileGroup.getName(), this.getName());

            // Squid vs missile
            GameObject pGameObj = (GameObject)Iterator.GetChild(missileGroup);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitMissile(Missile missile)
        {
            // Squid vs missile
            //Debug.WriteLine("         collide:  {0} <-> {1}", missile.getName(), this.getName());
            //Debug.WriteLine("-------> Done  <--------");

            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.setCollision(this, missile);
            pColPair.notifyListeners();

            //missile.hit();
        }
    }
}
