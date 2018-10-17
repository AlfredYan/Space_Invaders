using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class RemoveAlienObserver : CollisionObserver
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public RemoveAlienObserver()
        {
            this.pAlien = null;
        }
        public RemoveAlienObserver(RemoveAlienObserver b)
        {
            this.pAlien = b.pAlien;
        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract method
        //---------------------------------------------------------------------------------------------------------
        public override void notify()
        {
            //Debug.WriteLine("RemoveAlien_Observer: {0} {1}", this.pSubject.pObjA, this.pSubject.pObjB);

            this.pAlien = this.pSubject.pObjA;
            Debug.Assert(this.pAlien != null);

            if (pAlien.bMarkForDeath == false)
            {
                pAlien.bMarkForDeath = true;
                //   Delay
                RemoveAlienObserver pObserver = new RemoveAlienObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }
        public override void execute()
        {
            //GameObject pA = (GameObject)this.pAlien;

            //GameObject pB = (GameObject)Iterator.GetParent(pA);
            //pA.remove();

            //if (checkParent(pB) == true)
            //{
            //    GameObject pC = (GameObject)Iterator.GetParent(pB);
            //    pB.remove();
            //}

            //pA.getProxySprite().setGameSprite(GameSpriteMan.Find(GameSprite.Name.Alien_Explosion));
            //GameObjectMan.Find(GameObject.Name.ExplosionGroup).add(pA);
            //SpriteBatchMan.Find(SpriteBatch.Name.Explosions).attach(pA.getProxySprite());
            //pA.activateCollisionSprite(SpriteBatchMan.Find(SpriteBatch.Name.Boxes));

            GameSprite pGameSprite = this.pAlien.getProxySprite().getGameSprite();
            Scene pScene = SceneMan.GetScene();
            if(pGameSprite.getName() == GameSprite.Name.Squid)
            {
                pScene.addScoreOne(30);
            }
            else if (pGameSprite.getName() == GameSprite.Name.Crab)
            {
                pScene.addScoreOne(20);
            }
            else if (pGameSprite.getName() == GameSprite.Name.Octopus)
            {
                pScene.addScoreOne(10);
            }

            FontMan.Find(Font.Name.ScoreOne).updateMessage(pScene.getScoreOne().ToString("D4"));

            if(pScene.getScoreOne() > pScene.getHighestScore())
            {
                pScene.setHighstScore(pScene.getScoreOne());
                FontMan.Find(Font.Name.HighestScore).updateMessage(pScene.getHighestScore().ToString("D4"));
            }

            this.pAlien.getProxySprite().setGameSprite(GameSpriteMan.Find(GameSprite.Name.Alien_Explosion));
            ExplosionEvent pExplosionEvent = new ExplosionEvent(this.pAlien);
            TimerMan.Add(TimeEvent.Name.ExplosionEvent, pExplosionEvent, 0.1f);

        }
        //---------------------------------------------------------------------------------------------------------
        // Private method
        //---------------------------------------------------------------------------------------------------------
        private bool checkParent(GameObject pParent)
        {
            GameObject pChild = (GameObject)Iterator.GetChild(pParent);

            if(pChild == null)
            {
                return true;
            }

            return false;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private GameObject pAlien;
    }
}
