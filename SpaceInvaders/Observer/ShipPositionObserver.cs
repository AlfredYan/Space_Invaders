using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipPositionObserver : CollisionObserver
    {
        //----------------------------------------------------------------------
        // Override abstract class
        //----------------------------------------------------------------------
        public override void notify()
        {
            //Debug.WriteLine("Ship_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);
            Ship pShip = (Ship)this.pSubject.pObjA;
            BumpCategory pBump = (BumpCategory)this.pSubject.pObjB;

            if(pBump.GetCategoryType() == BumpCategory.Type.Left)
            {
                pShip.setPositionState(ShipMan.State.MostLeft);
            }
            else if(pBump.GetCategoryType() == BumpCategory.Type.Right)
            {
                pShip.setPositionState(ShipMan.State.MostRight);
            }
            else
            {
                Debug.Assert(false);
            }
        }
    }
}
