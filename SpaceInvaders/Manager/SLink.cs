using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SLink
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        protected SLink()
        {
            this.pNext = null;
        }
        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void AddToFront(ref SLink pHead, SLink pNode)
        {
            // ensure pNode is not null
            Debug.Assert(pNode != null);

            // add node to front
            if(pNode == null)
            {
                pHead = pNode;
                pNode.pNext = null;
            }
            else
            {
                pNode.pNext = pHead;
                pHead = pNode;
            }
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        public SLink pNext;
    }
}
