using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class CollisionPairMan_MLink : Manager
    {
        public CollisionPair_Link pActive;
        public CollisionPair_Link pReserved;
    }
    public class CollisionPairMan : CollisionPairMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private CollisionPairMan(int reserveNum = 3, int growNum = 1)
            : base()
        {
            this.baseInitialize(reserveNum, growNum);

            this.pActiveColPair = null;

            this.poNodeForCompare = new CollisionPair();
        }
        ~CollisionPairMan()
        {
            this.pActiveColPair = null;
        }
        //----------------------------------------------------------------------
        // Static methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int growNum = 1)
        {
            // ensure reserveNum and growNum are reasonable
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(growNum > 0);

            Debug.Assert(pInstance == null);

            if(pInstance == null)
            {
                // initialize
                pInstance = new CollisionPairMan(reserveNum, growNum);
            }
        }
        public static CollisionPair Add(CollisionPair.Name colPairName, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            // ensure call Create() first
            CollisionPairMan pMan = CollisionPairMan.GetInstance();
            Debug.Assert(pMan != null);

            CollisionPair pColPair = (CollisionPair)pMan.baseAdd();
            Debug.Assert(pColPair != null);

            // initialize collision pair
            pColPair.set(colPairName, pTreeRootA, pTreeRootB);

            return pColPair;
        }
        public static void Process()
        {
            // ensure call Create() first
            CollisionPairMan pMan = CollisionPairMan.GetInstance();
            Debug.Assert(pMan != null);

            CollisionPair pColPair = (CollisionPair)pMan.baseGetActiveList();

            while(pColPair != null)
            {
                // set the current active collision pair
                pMan.pActiveColPair = pColPair;

                // cheak collision pair
                pColPair.process();

                // go to next collision pair
                pColPair = (CollisionPair)pColPair.pNext;
            }
        }
        public static CollisionPair Find(CollisionPair.Name name)
        {
            // ensure call Create() first
            CollisionPairMan pMan = CollisionPairMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.poNodeForCompare.setName(name);

            CollisionPair pData = (CollisionPair)pMan.baseFind(pMan.poNodeForCompare);
            return pData;
        }
        public static void Remove(CollisionPair pNode)
        {
            // ensure call Create() first
            CollisionPairMan pMan = CollisionPairMan.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }
        public static void Reset()
        {
            // ensure call Create() first
            CollisionPairMan pMan = CollisionPairMan.GetInstance();
            Debug.Assert(pMan != null);

            CollisionPair pCollisionPair = (CollisionPair)pMan.pActive;
            while (pCollisionPair != null)
            {
                pCollisionPair.deepClean();
                pCollisionPair = (CollisionPair)pCollisionPair.pNext;
            }

            pMan.baseSetActiveHead(null);
        }
        public static CollisionPair GetActiveColPair()
        {
            // ensure call Create() first
            CollisionPairMan pMan = CollisionPairMan.GetInstance();
            Debug.Assert(pMan != null);

            return pMan.pActiveColPair;
        }
        public static void Destory()
        {
            // ensure call Create() first
            CollisionPairMan pMan = CollisionPairMan.GetInstance();
            Debug.Assert(pMan != null);

            // to do...
        }
        //----------------------------------------------------------------------
        // Override abstract methods
        //----------------------------------------------------------------------
        protected override bool derivedCompare(DLink pNodeA, DLink pNodeB)
        {
            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);

            CollisionPair pDataA = (CollisionPair)pNodeA;
            CollisionPair pDataB = (CollisionPair)pNodeB;

            Boolean status = false;

            if (pDataA.getName() == pDataB.getName())
            {
                status = true;
            }

            return status;
        }

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new CollisionPair();
            Debug.Assert(pNode != null);

            return pNode;
        }

        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);
            CollisionPair pNode = (CollisionPair)pLink;
            pNode.deepClean();
        }
        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static CollisionPairMan GetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private static CollisionPairMan pInstance = null;
        private CollisionPair poNodeForCompare;
        private CollisionPair pActiveColPair;
    }
}
