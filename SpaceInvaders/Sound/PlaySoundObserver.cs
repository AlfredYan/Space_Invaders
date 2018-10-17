using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class PlaySoundObserver : CollisionObserver
    {
        //-------------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------------
        public PlaySoundObserver(String soundPath)
        {
            this.soundPath = soundPath;
        }
        //-------------------------------------------------------------------------------
        // Override abstract methods
        //-------------------------------------------------------------------------------
        public override void notify()
        {
            SoundMan.Play(this.soundPath);
        }
        //-------------------------------------------------------------------------------
        // Data
        //-------------------------------------------------------------------------------
        String soundPath;
    }
}
