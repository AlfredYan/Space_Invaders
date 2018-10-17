using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class RemoveShieldObserver : CollisionObserver
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public RemoveShieldObserver(GameObject.Name name)
        {
            this.pBrick = null;
            this.pKiller = name;
        }
        public RemoveShieldObserver(RemoveShieldObserver b)
        {
            Debug.Assert(b != null);
            this.pBrick = b.pBrick;
        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------------------------------------------------------
        public override void notify()
        {
            if(this.pKiller == GameObject.Name.Missile)
            {
                this.pBrick = (ShieldBrick)this.pSubject.pObjA;
            }
            else if (this.pKiller == GameObject.Name.Bomb)
            {
                this.pBrick = (ShieldBrick)this.pSubject.pObjB;
            }
            
            Debug.Assert(this.pBrick != null);

            if (pBrick.bMarkForDeath == false)
            {
                pBrick.bMarkForDeath = true;
                //   Delay
                RemoveShieldObserver pObserver = new RemoveShieldObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }
        public override void execute()
        {
            //GameObject pA = (GameObject)this.pBrick;
            //GameObject pB = (GameObject)Iterator.GetParent(pA);

            //pA.remove();

            //// TODO: Need a better way... 
            //if (checkParent(pB) == true)
            //{
            //    GameObject pC = (GameObject)Iterator.GetParent(pB);
            //    pB.remove();

            //    if (checkParent(pC) == true)
            //    {
            //        pC.remove();
            //    }
            //}
            this.pBrick.getProxySprite().setGameSprite(GameSpriteMan.Find(GameSprite.Name.Missile_Explosion));
            ExplosionEvent pExplosionEvent = new ExplosionEvent(this.pBrick);
            TimerMan.Add(TimeEvent.Name.ExplosionEvent, pExplosionEvent, 0.1f);
        }
        //---------------------------------------------------------------------------------------------------------
        // Private method
        //---------------------------------------------------------------------------------------------------------
        private bool checkParent(GameObject pParent)
        {
            GameObject pChild = (GameObject)Iterator.GetChild(pParent);

            if (pChild == null)
            {
                return true;
            }

            return false;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private GameObject pBrick;
        private GameObject.Name pKiller;
    }
}
