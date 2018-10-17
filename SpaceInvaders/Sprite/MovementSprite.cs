using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class MovementSprite : Command
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public MovementSprite(GameObject pGameObject)
        {
            this.pGameObj = pGameObject;
            Debug.Assert(this.pGameObj != null);
        }
        ~MovementSprite()
        {
            this.pGameObj = null;
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        public override void execute(float deltaTime)
        {
            // move the grid
            ((AlienGroup)this.pGameObj).MoveGrid();

            // add itself back to TimerMan
            TimerMan.Add(TimeEvent.Name.MovementAnimation, this, deltaTime);
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private GameObject pGameObj;
    }
}
