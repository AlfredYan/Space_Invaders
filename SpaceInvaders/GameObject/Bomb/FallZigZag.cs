using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FallZigZag : FallStrategy
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public FallZigZag()
        {
            this.oldPosY = 0.0f;
            this.count = 0;
        }
        ~FallZigZag()
        {

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
            count++;
            if (count > 10)
            {
                pBomb.multiplyScale(-1.0f, 1.0f);
                this.count = 0;
            }

            //float targetY = oldPosY - 1.0f * pBomb.getBoundingBoxHeight();

            //if(pBomb.y < targetY)
            //{
            //    pBomb.multiplyScale(-1.0f, 1.0f);
            //    oldPosY = targetY;
            //}
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private float oldPosY;
        private int count;
    }
}
