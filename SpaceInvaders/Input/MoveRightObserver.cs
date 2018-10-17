using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MoveRightObserver : InputObserver
    {
        //-------------------------------------------------------------------------------
        // Override abstract methods
        //-------------------------------------------------------------------------------
        public override void notify()
        {
            Ship pShip = ShipMan.GetShip();
            pShip.moveRight();
        }
    }
}
