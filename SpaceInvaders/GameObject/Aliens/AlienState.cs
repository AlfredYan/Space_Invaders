using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class AlienState
    {
        //---------------------------------------------------------
        // Abstract class
        //---------------------------------------------------------
        // state()
        public abstract void handle(AlienCategory pAlien);
        public virtual void dropBomb(AlienCategory pAlien)
        {

        }
    }
}
