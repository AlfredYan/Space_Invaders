using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ProxySpriteMan_MLink : Manager
    {
        public ProxySprite_Base pActive;
        public ProxySprite_Base pReserved;
    }
    class ProxySpriteMan : ProxySpriteMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private ProxySpriteMan(int reservedNum = 3, int growNum = 1)
            : base()
        {
            this.baseInitialize(reservedNum, growNum);
            this.poNodeForCompare = new ProxySprite();
        }
        ~ProxySpriteMan()
        {
            this.poNodeForCompare = null;
            ProxySpriteMan.pInstance = null;
        }
        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int growNum = 1)
        {
            // ensure reserveNum and growNum are reasonable
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(growNum > 0);

            Debug.Assert(pInstance == null);
            if(pInstance == null)
            {
                pInstance = new ProxySpriteMan(reserveNum, growNum);
            }
        }
        public static ProxySprite Add(GameSprite.Name name)
        {
            //ensure call Create() first
            ProxySpriteMan pMan = ProxySpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            ProxySprite pProxySprite = (ProxySprite)pMan.baseAdd();
            Debug.Assert(pProxySprite != null);

            pProxySprite.set(name);
            return pProxySprite;
        }
        public static ProxySprite Find(ProxySprite.Name name)
        {
            //ensure call Create() first
            ProxySpriteMan pMan = ProxySpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.poNodeForCompare.setName(name);

            ProxySprite pData = (ProxySprite)pMan.baseFind(pMan.poNodeForCompare);
            return pData;
        }
        public static void Remove(GameSprite pNode)
        {
            //ensure call Create() first
            ProxySpriteMan pMan = ProxySpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }
        public static void Destory()
        {
            //ensure call Create() first
            ProxySpriteMan pMan = ProxySpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDestory();

            pMan.poNodeForCompare = null;
            ProxySpriteMan.pInstance = null;
        }
        public static void Reset()
        {
            //ensure call Create() first
            ProxySpriteMan pMan = ProxySpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            ProxySprite pProxySprite = (ProxySprite)pMan.pActive;
            while (pProxySprite != null)
            {
                pProxySprite.deepClear();
                pProxySprite = (ProxySprite)pProxySprite.pNext;
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

            // cast DLink to concrete type GameSprite
            ProxySprite pDataA = (ProxySprite)pNodeA;
            ProxySprite pDataB = (ProxySprite)pNodeB;

            return (pDataA.getName() == pDataB.getName());
        }

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new ProxySprite();
            Debug.Assert(pNode != null);

            return pNode;
        }

        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);
            ProxySprite pProxySprite = (ProxySprite)pLink;
            pProxySprite.deepClear();
        }
        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static ProxySpriteMan GetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private static ProxySpriteMan pInstance = null;
        private ProxySprite poNodeForCompare;
    }
}
