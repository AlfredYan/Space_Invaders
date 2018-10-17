using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    //----------------------------------------------------------------------
    // Constructor
    //----------------------------------------------------------------------
    public abstract class DLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public DLink()
        {
            this.clear();
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public void clear()
        {
            this.pPrev = null;
            this.pNext = null;
        }

        //----------------------------------------------------------------------
        // Static methods
        //----------------------------------------------------------------------
        public static void AddToFront(ref DLink pHead, DLink pNode)
        {
            // ensure pNode is not null
            Debug.Assert(pNode != null);

            // add the node to the list
            if(pHead == null)
            {
                pNode.pPrev = null;
                pNode.pNext = null;
                pHead = pNode;
            }
            else
            {
                pNode.pPrev = null;
                pNode.pNext = pHead;

                // fix pHead previous node
                pHead.pPrev = pNode;
                pHead = pNode;
            }
        }
        public static void AddToLast(ref DLink pHead, ref DLink pLast, DLink pNode)
        {
            // ensure pNode is not null
            Debug.Assert(pNode != null);

            // add node to the list
            if(pLast == pHead && pHead == null)
            {
                pNode.pPrev = null;
                pNode.pNext = null;
                pHead = pNode;
                pLast = pNode;
            }
            else
            {
                Debug.Assert(pLast != null);

                // add to end
                pNode.pPrev = pLast;
                pNode.pNext = null;

                // fix pLast next node
                pLast.pNext = pNode;
                pLast = pNode;
            }
        }
        public static DLink PullFromFront(ref DLink pHead)
        {
            // ensure the removed node is not null
            Debug.Assert(pHead != null);

            DLink removedNode = pHead;

            // get new pHead
            pHead = pHead.pNext;
            if(pHead != null)
            {
                // fix the previous node of new pHead
                pHead.pPrev = null;
            }

            removedNode.clear();

            return removedNode;
        }
        public static void RemoveNode(ref DLink pHead, DLink pNode)
        {
            // protection
            Debug.Assert(pNode != null);

            // 4 different conditions... 
            if (pNode.pPrev != null)
            {	// middle or last node
                pNode.pPrev.pNext = pNode.pNext;
            }
            else
            {  // first
                pHead = pNode.pNext;
            }

            if (pNode.pNext != null)
            {	// middle node
                pNode.pNext.pPrev = pNode.pPrev;
            }
        }
        public static void RemoveNode(ref DLink pHead, ref DLink pLast, DLink pNode)
        {
            Debug.Assert(pNode != null);

            if(pNode.pPrev != null)
            {
                // middle or last node
                pNode.pPrev.pNext = pNode.pNext;

                if(pNode == pLast)
                {
                    pLast = pNode.pPrev;
                }
            }
            else
            {
                // first
                pHead = pNode.pNext;

                if(pNode == pLast)
                {
                    // only one node
                    pLast = pNode.pNext;
                }
            }

            if(pNode.pNext != null)
            {
                // middle node
                pNode.pNext.pPrev = pNode.pPrev;
            }
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        public DLink pPrev;
        public DLink pNext;

    }
}
