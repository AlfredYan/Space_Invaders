using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SoundHolder : SLink
    {
        public SoundHolder(String pSound)
            : base()
        {
            this.pSound = pSound;
        }
        ~SoundHolder()
        {
            this.pSound = null;
        }
        public void setSound(String pSound)
        {
            this.pSound = pSound;
        }
        public String getSound()
        {
            return this.pSound;
        }
        private String pSound;
    }
}
