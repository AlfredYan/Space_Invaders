using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class RemoveShipObserver : CollisionObserver
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public RemoveShipObserver()
        {
            this.pShip = null;
        }
        public RemoveShipObserver(RemoveShipObserver b)
        {
            this.pShip = b.pShip;
        }
        //----------------------------------------------------------------------
        // Override abstract class
        //----------------------------------------------------------------------
        public override void notify()
        {
            this.pShip = (Ship)this.pSubject.pObjB;
            Debug.Assert(this.pShip != null);

            if (pShip.bMarkForDeath == false)
            {
                pShip.bMarkForDeath = true;

                // Delay
                RemoveShipObserver pObserver = new RemoveShipObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }

        }
        public override void execute()
        {
            Ship pRealShip = (Ship)this.pShip;
            pRealShip.setState(ShipMan.State.End);
            pRealShip.setPositionState(ShipMan.State.Stay);
            pRealShip.getProxySprite().setGameSprite(GameSpriteMan.Find(GameSprite.Name.Ship_Explosion1));
            AnimationExplosion pAnimExplosion = new AnimationExplosion(pRealShip, 1.0f);
            pAnimExplosion.attach(Image.Name.Ship_Explosion2);
            pAnimExplosion.attach(Image.Name.Ship_Explosion1);
            TimerMan.Add(TimeEvent.Name.ExplosionEvent, pAnimExplosion, 0.3f);
            
            //this.pShip.remove();
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private GameObject pShip;
    }
}
