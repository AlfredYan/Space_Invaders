using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Manager
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Name
        {
            TextureMan,
            ImageMan,
            GameSpriteMan,
            BoxSpriteMan,
            SpriteBatchMan,
            TimerMan,
            ProxySpriteMan,
            GameObjectMan,
            CollisionPairMan,
            ShipMan,
            BombMan,
            SoundMan,
            AlienMan,
            GlyphMan,
            FontMan,
            UFOMan,
            SceneMan,
            Uninitializated
        }
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        protected Manager()
        {

            this.mNumReserved = 0;
            this.mNumGrow = 0;
            this.mTotalNumNodes = 0;
            this.mNumActive = 0;
            this.pActive = null;
            this.pReserved = null;
        }

        //----------------------------------------------------------------------
        // Base methods - called in Derived class but lives in Base
        //----------------------------------------------------------------------
        protected void baseInitialize(int reserveNum, int growNum)
        {
            // ensure reservedNum and growNum is reasonable
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(growNum >= 0);

            this.mNumGrow = growNum;

            this.fillNodesToReservedList(reserveNum);
        }
        protected DLink baseAdd()
        {
            // when there is no reversed node
            if(this.pReserved == null)
            {
                // refill reversed list
                this.fillNodesToReservedList(this.mNumGrow);
            }

            // get the node to add from the reserve list and update states
            DLink newNode = DLink.PullFromFront(ref this.pReserved);
            Debug.Assert(newNode != null);
            this.mNumReserved--;

            // reset the node
            this.derivedReset(newNode);

            // add the node to active list and update states
            DLink.AddToFront(ref this.pActive, newNode);
            this.mNumActive++;

            return newNode;

        }
        protected DLink getNewNode()
        {
            // when there is no reversed node
            if (this.pReserved == null)
            {
                // refill reversed list
                this.fillNodesToReservedList(this.mNumGrow);
            }

            // get the node to add from the reserve list and update states
            DLink newNode = DLink.PullFromFront(ref this.pReserved);
            Debug.Assert(newNode != null);
            this.mNumReserved--;

            // reset the node
            this.derivedReset(newNode);

            return newNode;

        }
        protected void baseRemove(DLink pNode)
        {
            Debug.Assert(pNode != null);

            // remove the node from active list and update states
            DLink.RemoveNode(ref this.pActive, pNode);
            this.mNumActive--;

            // reset the node
            this.derivedReset(pNode);

            // add back to reserved list
            DLink.AddToFront(ref this.pReserved, pNode);
            this.mNumReserved++;

        }
        protected DLink baseFind(DLink pTargetNode)
        {
            DLink pCurrNode = this.pActive;

            while(pCurrNode != null)
            {
                if(this.derivedCompare(pCurrNode, pTargetNode))
                {
                    break;
                }
                pCurrNode = pCurrNode.pNext;
            }

            return pCurrNode;
        }
        protected void baseDestory()
        {
            DLink pNode;
            DLink pTmpNode;

            // active list
            pNode = this.pActive;
            while(pNode != null)
            {
                pTmpNode = pNode;
                pNode = pNode.pNext;

                // cleanup the node
                Debug.Assert(pTmpNode != null);
                this.derivedDestory(pTmpNode);
                DLink.RemoveNode(ref this.pActive, pTmpNode);
                pTmpNode = null;

                this.mNumActive--;
                this.mTotalNumNodes--;
            }

            // reserve list
            pNode = this.pReserved;
            while(pNode != null)
            {
                pTmpNode = pNode;
                pNode = pNode.pNext;

                // cleanup the node
                Debug.Assert(pTmpNode != null);
                this.derivedDestory(pTmpNode);
                DLink.RemoveNode(ref this.pReserved, pTmpNode);
                pTmpNode = null;

                this.mNumReserved--;
                this.mTotalNumNodes--;
            }
        }
        public DLink baseGetActiveList()
        {
            return this.pActive;
        }
        public void baseSetActiveHead(DLink pHead)
        {
            this.pActive = pHead;
        }
        protected void BaseSetReservedList(int reserveNum, int reserveGrow)
        {
            this.mNumGrow = reserveGrow;

            if(reserveNum > this.mNumReserved)
            {
                this.fillNodesToReservedList(reserveNum - mNumReserved);
            }
        }
        //----------------------------------------------------------------------
        // Abstract methods
        //----------------------------------------------------------------------
        protected abstract DLink derivedCreateNode();
        protected abstract void derivedReset(DLink pLink);
        protected abstract Boolean derivedCompare(DLink pNodeA, DLink pNodeB);
        protected virtual void derivedDestory(DLink pLink)
        {
            pLink = null;
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private void fillNodesToReservedList(int numNode)
        {
            int numAddedNode = 0;
            DLink currNode = null;
            while (numAddedNode < numNode)
            {
                // create a specific node
                currNode = this.derivedCreateNode();
                Debug.Assert(currNode != null);

                DLink.AddToFront(ref pReserved, currNode);
                this.mNumReserved++;
                this.mTotalNumNodes++;
                numAddedNode++;
            }
        }

        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private DLink pActive;
        private DLink pReserved;
        private int mNumGrow;
        private int mTotalNumNodes;
        private int mNumReserved;
        private int mNumActive;
    }
}
