using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ToggleBoxObserver : InputObserver
    {
        //-------------------------------------------------------------------------------
        // Override abstract methods
        //-------------------------------------------------------------------------------
        public override void notify()
        {
            SpriteBatch pSB_box = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);
            SpriteBatch pSB_ShieldBox = SpriteBatchMan.Find(SpriteBatch.Name.ShieldBoxes);
            if (pSB_box.getIsDraw())
            {
                pSB_box.setIsDraw(false);
                pSB_ShieldBox.setIsDraw(false);
            }
            else
            {
                pSB_box.setIsDraw(true);
                pSB_ShieldBox.setIsDraw(true);
            }
            
        }
    }
}
