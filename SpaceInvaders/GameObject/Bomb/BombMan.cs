using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombMan
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        private BombMan()
        {
            this.randNum = new Random();
        }
        ~BombMan()
        {
            randNum = null;
        }
        //---------------------------------------------------------
        // Static methods
        //---------------------------------------------------------
        public static void Create()
        {
            Debug.Assert(pInstance == null);

            if(pInstance == null)
            {
                pInstance = new BombMan();
            }

            Debug.Assert(pInstance != null);
        }
        public static Bomb ActiveBomb()
        {
            //ensure call Create() first
            BombMan pMan = BombMan.GetInstance();
            Debug.Assert(pMan != null);

            GameSprite.Name spriteName = GameSprite.Name.BombDagger + pMan.randNum.Next(3);
            FallStrategy pFallStrategy = pMan.chooseFallStrategy(spriteName);
            Debug.Assert(pFallStrategy != null);

            // create Bomb
            Bomb pBomb = new Bomb(GameObject.Name.Bomb, spriteName, pFallStrategy, 100, 100);

            // activate collision sprite and game sprite
            pBomb.activateGameSprite(SpriteBatchMan.Find(SpriteBatch.Name.Bombs));
            pBomb.activateCollisionSprite(SpriteBatchMan.Find(SpriteBatch.Name.Boxes));

            //attach Bomb to BombGroup
            GameObject pBombGroup = GameObjectMan.Find(GameObject.Name.BombGroup);
            Debug.Assert(pBombGroup != null);

            // add to GameObject
            pBombGroup.add(pBomb);

            return pBomb;
        }
        //---------------------------------------------------------
        // Private methods
        //---------------------------------------------------------
        private static BombMan GetInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }
        private FallStrategy chooseFallStrategy(GameSprite.Name spriteName)
        {
            FallStrategy pFallStrategy = null;

            switch(spriteName)
            {
                case GameSprite.Name.BombDagger:
                    pFallStrategy = new FallDagger();
                    break;

                case GameSprite.Name.BombStraight:
                    pFallStrategy = new FallStraight();
                    break;

                case GameSprite.Name.BombZigZag:
                    pFallStrategy = new FallZigZag();
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pFallStrategy;
                    
        }
        //---------------------------------------------------------
        // Data
        //---------------------------------------------------------
        private static BombMan pInstance = null;
        private Random randNum;
    }
}
