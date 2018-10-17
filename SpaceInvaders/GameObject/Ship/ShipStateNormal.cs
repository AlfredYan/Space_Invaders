using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipStateNormal : ShipState
    {
        //---------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------
        public override void handle(Ship pShip)
        {

        }
        public override void moveLeft(Ship pShip)
        {
            pShip.x -= pShip.shipSpeed;
        }
        public override void moveRight(Ship pShip)
        {
            pShip.x += pShip.shipSpeed;
        }
    }
}
