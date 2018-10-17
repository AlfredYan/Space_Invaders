using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class RemoveMissileObserver : CollisionObserver
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public RemoveMissileObserver()
        {
            this.pMissile = null;
        }
        public RemoveMissileObserver(RemoveMissileObserver removeMissileObserver)
        {
            this.pMissile = removeMissileObserver.pMissile;
        }
        //----------------------------------------------------------------------
        // Override abstract class
        //----------------------------------------------------------------------
        public override void notify()
        {
            this.pMissile = (Missile)this.pSubject.pObjB;
            Debug.Assert(this.pMissile != null);

            if(pMissile.bMarkForDeath == false)
            {
                pMissile.bMarkForDeath = true;

                // Delay
                RemoveMissileObserver pObserver = new RemoveMissileObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }
        public override void execute()
        {
            this.pMissile.remove();
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private GameObject pMissile;
    }
}
