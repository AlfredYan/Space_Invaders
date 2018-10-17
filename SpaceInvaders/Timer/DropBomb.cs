using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DropBomb : Command
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public DropBomb(GameObject pGameObject)
        {
            this.pGameObj = pGameObject;
            Debug.Assert(this.pGameObj != null);
        }
        ~DropBomb()
        {
            this.pGameObj = null;
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        public override void execute(float deltaTime)
        {
            // move the grid
            ((AlienGroup)this.pGameObj).dropBomb();

            // add itself back to TimerMan
            TimerMan.Add(TimeEvent.Name.DropBombAnination, this, deltaTime);
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private GameObject pGameObj;
    }
}
