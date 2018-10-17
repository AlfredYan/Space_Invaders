using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFOEvent : Command
    {
        public UFOEvent()
        {
            //this.pMan = pMan;
        }
        ~UFOEvent()
        {
            //this.pMan = null;
        }
        
        public override void execute(float deltaTime)
        {
            UFOMan.ActiveUFO();
            SoundMan.Play("ufo_lowpitch.wav");
            UfOBomb pUFOBomb = new UfOBomb();
            TimerMan.Add(TimeEvent.Name.UFOBombAnination, pUFOBomb, UFOMan.getShootTime());
        }

        //private UFOMan pMan;
    }
}
