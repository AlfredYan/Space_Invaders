using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombExplosionObsever : CollisionObserver
    {
        public BombExplosionObsever()
        {
            this.pBomb = null;
        }
        public BombExplosionObsever(BombExplosionObsever b)
        {
            this.pBomb = b.pBomb;
        }

        public override void notify()
        {
            this.pBomb = this.pSubject.pObjA;
            Debug.Assert(this.pBomb != null);

            if (pBomb.bMarkForDeath == false)
            {
                pBomb.bMarkForDeath = true;
                //   Delay
                BombExplosionObsever pObserver = new BombExplosionObsever(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }

        public override void execute()
        {
            this.pBomb.getProxySprite().setGameSprite(GameSpriteMan.Find(GameSprite.Name.Bomb_Explosion));
            ExplosionEvent pExplosionEvent = new ExplosionEvent(this.pBomb);
            TimerMan.Add(TimeEvent.Name.ExplosionEvent, pExplosionEvent, 0.1f);
        }

        private GameObject pBomb;
    }
}
