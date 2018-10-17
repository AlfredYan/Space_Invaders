using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFOExplosionObserver : CollisionObserver
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public UFOExplosionObserver()
        {
            this.pUFO = null;
        }
        public UFOExplosionObserver(UFOExplosionObserver b)
        {
            this.pUFO = b.pUFO;
        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract method
        //---------------------------------------------------------------------------------------------------------
        public override void notify()
        {
            //Debug.WriteLine("RemoveAlien_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.pUFO = this.pSubject.pObjA;
            Debug.Assert(this.pUFO != null);

            if (pUFO.bMarkForDeath == false)
            {
                pUFO.bMarkForDeath = true;
                //   Delay
                UFOExplosionObserver pObserver = new UFOExplosionObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }
        public override void execute()
        {
            Scene pScene = SceneMan.GetScene();
            pScene.addScoreOne(200);

            FontMan.Find(Font.Name.ScoreOne).updateMessage(pScene.getScoreOne().ToString("D4"));

            if (pScene.getScoreOne() > pScene.getHighestScore())
            {
                pScene.setHighstScore(pScene.getScoreOne());
                FontMan.Find(Font.Name.HighestScore).updateMessage(pScene.getHighestScore().ToString("D4"));
            }

            this.pUFO.getProxySprite().setGameSprite(GameSpriteMan.Find(GameSprite.Name.UFO_Explosion));
            ExplosionEvent pExplosionEvent = new ExplosionEvent(this.pUFO);
            TimerMan.Add(TimeEvent.Name.ExplosionEvent, pExplosionEvent, 0.1f);

            UFOEvent pUFOEvent = new UFOEvent();
            TimerMan.Add(TimeEvent.Name.MovementAnimation, pUFOEvent, UFOMan.getDeltaTime());
        }

        private GameObject pUFO;
    }
}
