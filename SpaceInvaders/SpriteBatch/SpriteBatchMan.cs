using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SpriteBatchMan_MLink : Manager
    {
        // make UML clearly
        public SpriteBatch_Link pActive;
        public SpriteBatch_Link pReserved;
    }
    public class SpriteBatchMan : SpriteBatchMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private SpriteBatchMan(int reserveNum = 3, int growNum = 1)
            : base()
        {
            // At this point, SpriteBatchMan is created, now initialize the reserve list
            this.baseInitialize(reserveNum, growNum);
            this.poNodeForCompare = new SpriteBatch();
        }
        ~SpriteBatchMan()
        {
            this.poNodeForCompare = null;
            SpriteBatchMan.pInstance = null;
        }
        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int growNum = 1)
        {
            // ensure reserveNum and growNum are reasonable
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(growNum > 0);

            // ensure the instance of SpriteBatchMan has not been created
            Debug.Assert(SpriteBatchMan.pInstance == null);

            if(SpriteBatchMan.pInstance == null)
            {
                pInstance = new SpriteBatchMan(reserveNum, growNum);
            }
        }
        public static SpriteBatch Add(SpriteBatch.Name name, int reserveNum = 3, int numGrow = 1)
        {
            //ensure call Create() first
            SpriteBatchMan pMan = SpriteBatchMan.GetInstance();
            Debug.Assert(pMan != null);

            SpriteBatch pSpriteBatch = (SpriteBatch)pMan.baseAdd();
            Debug.Assert(pSpriteBatch != null);

            pSpriteBatch.set(name, reserveNum, numGrow);
            return pSpriteBatch;
        }
        public static void Draw()
        {
            //ensure call Create() first
            SpriteBatchMan pMan = SpriteBatchMan.GetInstance();
            Debug.Assert(pMan != null);

            // get the active list
            SpriteBatch pSpriteBatch = (SpriteBatch)pMan.baseGetActiveList();

            // walk through the list and render
            while(pSpriteBatch != null)
            {
                if (pSpriteBatch.getIsDraw())
                {
                    SBNodeMan pSBNodeMan = pSpriteBatch.getSBNodeMan();
                    Debug.Assert(pSBNodeMan != null);

                    pSBNodeMan.draw();
                }

                pSpriteBatch = (SpriteBatch)pSpriteBatch.pNext;
            }
        }
        public static SpriteBatch Find(SpriteBatch.Name name)
        {
            //ensure call Create() first
            SpriteBatchMan pMan = SpriteBatchMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.poNodeForCompare.setName(name);

            SpriteBatch pData = (SpriteBatch)pMan.baseFind(pMan.poNodeForCompare);
            return pData;
        }
        public static void Remove(SpriteBatch pSpriteBatch)
        {
            //ensure call Create() first
            SpriteBatchMan pMan = SpriteBatchMan.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pSpriteBatch != null);
            pMan.baseRemove(pSpriteBatch);
        }
        public static void Remove(SBNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            SBNodeMan pSBNodeMan = pSpriteBatchNode.getSBNodeMan();

            Debug.Assert(pSBNodeMan != null);
            pSBNodeMan.remove(pSpriteBatchNode);
        }
        public static void Destory()
        {
            //ensure call Create() first
            SpriteBatchMan pMan = SpriteBatchMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDestory();

            pMan.poNodeForCompare = null;
            SpriteBatchMan.pInstance = null;
        }
        public static void Reset()
        {
            //ensure call Create() first
            SpriteBatchMan pMan = SpriteBatchMan.GetInstance();
            Debug.Assert(pMan != null);

            SpriteBatch pSpriteBatch = (SpriteBatch)pMan.pActive;
            while(pSpriteBatch != null)
            {
                pSpriteBatch.deepClear();
                pSpriteBatch = (SpriteBatch)pSpriteBatch.pNext;
            }

            pMan.baseSetActiveHead(null);
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        protected override bool derivedCompare(DLink pNodeA, DLink pNodeB)
        {
            // ensure pNodeA & pNodeB are not null
            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);

            // cast DLink to concrete type BoxSprite
            SpriteBatch pDataA = (SpriteBatch)pNodeA;
            SpriteBatch pDataB = (SpriteBatch)pNodeB;

            return pDataA.getName() == pDataB.getName();
        }
        protected override DLink derivedCreateNode()
        {
            DLink pSpriteBatch = new SpriteBatch();
            Debug.Assert(pSpriteBatch != null);

            return pSpriteBatch;
        }
        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);
            SpriteBatch pSpriteBatch = (SpriteBatch)pLink;
            pSpriteBatch.deepClear();
        }
        protected override void derivedDestory(DLink pLink)
        {
            SpriteBatch pNode = (SpriteBatch)pLink;
            Debug.Assert(pNode != null);
            pNode.destory();
        }
        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static SpriteBatchMan GetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private static SpriteBatchMan pInstance;
        private SpriteBatch poNodeForCompare;
    }
}
