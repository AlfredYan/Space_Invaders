using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameSpriteMan_MLink : Manager
    {
        public GameSprite_Base pActive;
        public GameSprite_Base pReserved;
    }
    public class GameSpriteMan : GameSpriteMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private GameSpriteMan(int reverseNum = 3, int growNum = 1)
            : base()
        {
            // At this point, GameSpriteMan is created, now initialize the reserve list
            this.baseInitialize(reverseNum, growNum);

            this.poNodeForCompare = new GameSprite();
        }
        ~GameSpriteMan()
        {
            this.poNodeForCompare = null;
            GameSpriteMan.pInstance = null;
        }
        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reverseNum = 3, int growNum = 1)
        {
            Debug.Assert(reverseNum >= 0);
            Debug.Assert(growNum > 0);

            // ensure the instance of GameSpriteMan has not been created
            Debug.Assert(GameSpriteMan.pInstance == null);

            // initialize the GameSpriteMan
            if(GameSpriteMan.pInstance == null)
            {
                pInstance = new GameSpriteMan(reverseNum, growNum);

                GameSprite pGameSprite = GameSpriteMan.Add(GameSprite.Name.NullObject, Image.Name.NullObject, 0, 0, 0, 0);
                Debug.Assert(pGameSprite != null);
            }
        }
        public static GameSprite Add(GameSprite.Name gameSpriteName, Image.Name imageName, float x, float y, float width, float height, Azul.Color pAzulColor = null)
        {
            //ensure call Create() first
            GameSpriteMan pMan = GameSpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            // add GameSprite to active list
            GameSprite pGameSprite = (GameSprite)pMan.baseAdd();
            Debug.Assert(pGameSprite != null);

            // find the image by image name
            Image pImage = ImageMan.Find(imageName);
            Debug.Assert(pImage != null);

            // set new GameSprite
            pGameSprite.set(gameSpriteName, pImage, x, y, width, height, pAzulColor);

            return pGameSprite;
        }
        public static GameSprite Find(GameSprite.Name name)
        {
            //ensure call Create() first
            GameSpriteMan pMan = GameSpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.poNodeForCompare.setName(name);
            GameSprite pData = (GameSprite)pMan.baseFind(pMan.poNodeForCompare);
            return pData;
        }
        public static void Remove(GameSprite pGameSprite)
        {
            //ensure call Create() first
            GameSpriteMan pMan = GameSpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            // ensure pGameSprite is not null
            Debug.Assert(pGameSprite != null);
            pMan.baseRemove(pGameSprite);
        }
        public static void Destory()
        {
            //ensure call Create() first
            GameSpriteMan pMan = GameSpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDestory();

            pMan.poNodeForCompare = null;
            GameSpriteMan.pInstance = null;
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        protected override bool derivedCompare(DLink pNodeA, DLink pNodeB)
        {
            // ensure pNodeA & pNodeB are not null
            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);

            // cast DLink to concrete type GameSprite
            GameSprite pDataA = (GameSprite)pNodeA;
            GameSprite pDataB = (GameSprite)pNodeB;

            return (pDataA.getName() == pDataB.getName());
        }

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new GameSprite();
            Debug.Assert(pNode != null);

            return pNode;
        }
        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);

            GameSprite pGameSprite = (GameSprite)pLink;
            pGameSprite.deepClear();
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static GameSpriteMan GetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }

        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private GameSprite poNodeForCompare;
        private static GameSpriteMan pInstance = null;

    }
}
