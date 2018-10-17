using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class InputObserver : DLink
    {
        //-------------------------------------------------------------------------------
        // Abstract methods
        //-------------------------------------------------------------------------------
        public abstract void notify();

        //-------------------------------------------------------------------------------
        // Data
        //-------------------------------------------------------------------------------
        public InputSubject pSubject;
    }
}
