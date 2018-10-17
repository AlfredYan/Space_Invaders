using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ReverseIterator : Iterator
    {
        //-------------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------------
        public ReverseIterator(Component pStart)
        {
            Debug.Assert(pStart != null);
            Debug.Assert(pStart.holder == Component.Container.Composite);

            ForwardIterator pForward = new ForwardIterator(pStart);

            this.pRoot = pStart;
            this.pCurr = this.pRoot;
            this.pPrev = null;

            // initialize reverse pointer
            Component pPrevNode = this.pRoot;
            Component pNode = pForward.first();

            while (!pForward.isDone())
            {
                pPrevNode = pNode;

                // go to next node
                pNode = pForward.next();

                if(pNode != null)
                {
                    pNode.pReverse = pPrevNode;
                }
            }

            pRoot.pReverse = pPrevNode;
        }
        //-------------------------------------------------------------------------------
        // Override abstract methods
        //-------------------------------------------------------------------------------
        public override Component first()
        {
            Debug.Assert(this.pRoot != null);
            this.pCurr = this.pRoot.pReverse;
            return this.pCurr;
        }
        public override bool isDone()
        {
            return (this.pPrev == this.pRoot);
        }
        public override Component next()
        {
            Debug.Assert(this.pCurr != null);

            this.pPrev = this.pCurr;
            this.pCurr = this.pCurr.pReverse;
            return this.pCurr;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private Component pCurr;
        private Component pRoot;
        private Component pPrev;
    }
}
