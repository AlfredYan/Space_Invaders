using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class CollisionObserver : DLink
    {
        //-------------------------------------------------------------------------------
        // Abstract methods
        //-------------------------------------------------------------------------------
        public abstract void notify();
        public virtual void execute()
        {
            // default implement
        }

        //-------------------------------------------------------------------------------
        // Data
        //-------------------------------------------------------------------------------
        public CollisionSubject pSubject;
    }
}
