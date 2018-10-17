using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ShipState
    {
        //---------------------------------------------------------
        // Abstract class
        //---------------------------------------------------------
        // state()
        public abstract void handle(Ship pShip);

        // strategy()
        public virtual void moveRight(Ship pShip)
        {

        }
        public virtual void moveLeft(Ship pShip)
        {

        }
        public virtual void shootMissile(Ship pShip)
        {

        }
    }
}
