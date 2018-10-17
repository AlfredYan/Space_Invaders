using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Crab : AlienCategory
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public Crab(GameObject.Name gameName, GameSprite.Name spriteName, float posX, float posY)
            : base(gameName, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }
        ~Crab()
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
            other.visitCrab(this);
        }
        public override void visitMissileGroup(MissileGroup missileGroup)
        {
            // crab vs missile group
            //Debug.WriteLine("         collide:  {0} <-> {1}", missileGroup.getName(), this.getName());

            // crab vs missile
            GameObject pGameObj = (GameObject)Iterator.GetChild(missileGroup);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitMissile(Missile missile)
        {
            // crab vs missile
            //Debug.WriteLine("         collide:  {0} <-> {1}", missile.getName(), this.getName());
            //Debug.WriteLine("-------> Done  <--------");

            CollisionPair pColPair = CollisionPairMan.GetActiveColPair();
            Debug.Assert(pColPair != null);

            pColPair.setCollision(this, missile);
            pColPair.notifyListeners();
        }
    }
}
