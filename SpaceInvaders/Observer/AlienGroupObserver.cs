using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGroupObserver : CollisionObserver
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public AlienGroupObserver()
        {

        }
        //---------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------
        public override void notify()
        {
            //Debug.WriteLine("Grid_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            AlienGroup pGird = (AlienGroup)this.pSubject.pObjA;
            WallCategory pWall = (WallCategory)this.pSubject.pObjB;

            if (pWall.GetCategoryType() == WallCategory.Type.Right && pGird.getMoveForward())
            {
                pGird.setMoveForward(false);
            }
            else if (pWall.GetCategoryType() == WallCategory.Type.Left && !pGird.getMoveForward())
            {
                pGird.setMoveForward(true);
            }
            //else
            //{
            //    Debug.Assert(false);
            //}

            if(pGird.poCollisionObject.pCollisionSprite.y >= 450.0f)
            {
                pGird.setGoingDown(true);
            }

        }
    }
}
