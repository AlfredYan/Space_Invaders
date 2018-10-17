using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienStateReady : AlienState
    {
        //---------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------
        public override void handle(AlienCategory pAlien)
        {
            pAlien.setState(AlienMan.State.BombDroping);
        }
        public override void dropBomb(AlienCategory pAlien)
        {
            Bomb pBomb = BombMan.ActiveBomb();
            pBomb.setPos(pAlien.x + 5, pAlien.y - 40);
            pBomb.setShooter(pAlien);

            // switch states
            this.handle(pAlien);
        }
    }
}
