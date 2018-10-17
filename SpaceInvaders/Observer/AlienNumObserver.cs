using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienNumObserver : CollisionObserver
    {
        public AlienNumObserver(AlienGroup pAlienRoot, ShieldRoot pShieldRoot)
        {
            this.alienNum = 55;
            this.currAlienNum = 55;
            this.pAlienGroup = pAlienRoot;
            this.pShieldRoot = pShieldRoot;
        }
        ~AlienNumObserver()
        {
            this.pAlienGroup = null;
            this.pShieldRoot = null;
        }
        public override void notify()
        {
            this.currAlienNum--;

            if(this.currAlienNum % 11 == 0)
            {
                pAlienGroup.addDifficult();
            }

            if(this.currAlienNum == 0)
            {
                this.pAlienGroup.nextLevel();
                this.pShieldRoot.clearShield();
                this.pShieldRoot.storeShield();
                this.currAlienNum = this.alienNum;
            }
        }
        private int alienNum;
        private int currAlienNum;
        private AlienGroup pAlienGroup;
        private ShieldRoot pShieldRoot;
    }
}
