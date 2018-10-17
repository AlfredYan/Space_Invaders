using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FallStraight : FallStrategy
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public FallStraight()
        {
            this.oldPosY = 0.0f;
        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------------------------------------------------------
        public override void reset(float posY)
        {
            this.oldPosY = posY;
        }
        public override void fall(Bomb pBomb)
        {
            Debug.Assert(pBomb != null);

            // Do nothing for this strategy
        }
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        private float oldPosY;
    }
}
