using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipReadyObserver : CollisionObserver
    {
        //----------------------------------------------------------------------
        // Override abstract class
        //----------------------------------------------------------------------
        public override void notify()
        {
            Ship pShip = ShipMan.GetShip();
            pShip.setState(ShipMan.State.Ready);
        }
    }
}
