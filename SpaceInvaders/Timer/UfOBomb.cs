using System;

namespace SpaceInvaders
{
    public class UfOBomb : Command
    {
        public override void execute(float deltaTime)
        {
            UFO pUFO = UFOMan.getUFO();
            if(pUFO != null)
            {
                pUFO.dropBomb();
            }
        }
    }
}
