using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipStateReady : ShipState
    {
        //---------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------
        public override void handle(Ship pShip)
        {
            pShip.setState(ShipMan.State.MissileFlying);
        }

        public override void shootMissile(Ship pShip)
        {
            Missile pMissile = ShipMan.ActivateMissile();
            pMissile.setPos(pShip.x, pShip.y + 20);
            SoundMan.Play("shoot.wav");

            // switch states
            this.handle(pShip);
        }
    }
}
