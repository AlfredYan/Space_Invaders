using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class RemoveBombObserver : CollisionObserver
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public RemoveBombObserver()
        {
            this.pBomb = null;
        }
        public RemoveBombObserver(RemoveBombObserver b)
        {
            this.pBomb = b.pBomb;
        }
        //----------------------------------------------------------------------
        // Override abstract class
        //----------------------------------------------------------------------
        public override void notify()
        {
            this.pBomb = (Bomb)this.pSubject.pObjA;
            Debug.Assert(this.pBomb != null);

            if (pBomb.bMarkForDeath == false)
            {
                pBomb.bMarkForDeath = true;

                // Delay
                RemoveBombObserver pObserver = new RemoveBombObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }
        public override void execute()
        {
            this.pBomb.remove();
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private GameObject pBomb;
    }
}
