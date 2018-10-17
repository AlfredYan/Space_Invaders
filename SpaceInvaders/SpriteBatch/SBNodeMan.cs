using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SBNodeMan_MLink : Manager
    {
        public SBNode_Link pActive = null;
        public SBNode_Link pReserved = null;
    }
    public class SBNodeMan : SBNodeMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public SBNodeMan(int reserveNum = 3, int growNum = 1)
            : base()
        {
            // At this point, SBNodeMan is created, now initialize the reserve list
            this.baseInitialize(reserveNum, growNum);
            this.poNodeForCompare = new SBNode();
        }
        ~SBNodeMan()
        {
            this.name = SpriteBatch.Name.Uninitialized;
            this.poNodeForCompare = null;
        }
        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public void set(SpriteBatch.Name name, int reserveNum, int growNum)
        {
            this.name = name;

            // ensure reserveNum and growNum are reasonable
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(growNum > 0);

            this.BaseSetReservedList(reserveNum, growNum);
        }
        public SBNode attach(SpriteBase pNode)
        {
            // get a node from reserve, add to active, return it
            SBNode pSBNode = (SBNode)this.baseAdd();
            Debug.Assert(pSBNode != null);

            // initialize SpriteBatchNode
            pSBNode.set(pNode, this);

            return pSBNode;
        }
        public void draw()
        {
            // get the active list
            SBNode pActiveList = (SBNode)this.baseGetActiveList();

            // walk through the list and render
            while(pActiveList != null)
            {
                Debug.Assert(pActiveList.getSpriteBase() != null);
                pActiveList.getSpriteBase().render();

                pActiveList = (SBNode)pActiveList.pNext;
            }
        }
        public void remove(SBNode pNode)
        {
            Debug.Assert(pNode != null);
            this.baseRemove(pNode);
        }
        public void destory()
        {
            this.baseDestory();

            this.name = SpriteBatch.Name.Uninitialized;
            this.poNodeForCompare = null;
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
            SBNode pDataA = (SBNode)pNodeA;
            SBNode pDataB = (SBNode)pNodeB;

            return false;
        }

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new SBNode();
            Debug.Assert(pNode != null);

            return pNode;
        }

        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);
            SBNode pNode = (SBNode)pLink;

            pNode.deepClear();
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private SBNode poNodeForCompare;
        private SpriteBatch.Name name;
    }
}
