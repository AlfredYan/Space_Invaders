using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipStateMostRight : ShipState
    {
        //---------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------
        public override void handle(Ship pShip)
        {
            pShip.setPositionState(ShipMan.State.Normal);
        }
        public override void moveLeft(Ship pShip)
        {
            pShip.x -= pShip.shipSpeed;

            // set back to normal
            this.handle(pShip);
        }
    }
}
