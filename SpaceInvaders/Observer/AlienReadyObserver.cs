using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienReadyObserver : CollisionObserver
    {
        //----------------------------------------------------------------------
        // Override abstract class
        //----------------------------------------------------------------------
        public override void notify()
        {
            Bomb pBomb = (Bomb)this.pSubject.pObjA;
            if(pBomb.getShooter() != null)
                pBomb.getShooter().setState(AlienMan.State.Ready);
        }
    }
}
