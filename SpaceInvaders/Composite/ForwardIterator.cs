using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ForwardIterator : Iterator
    {
        //-------------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------------
        public ForwardIterator(Component pStart)
        {
            Debug.Assert(pStart != null);
            Debug.Assert(pStart.holder == Component.Container.Composite);

            this.pCurr = pStart;
            this.pRoot = pStart;
        }
        //-------------------------------------------------------------------------------
        // Override abstract methods
        //-------------------------------------------------------------------------------
        public override Component first()
        {
            Debug.Assert(this.pRoot != null);
            Component pNode = this.pRoot;

            Debug.Assert(pNode != null);
            this.pCurr = pNode;

            //Debug.WriteLine("---> {0} ", this.pCurr.GetHashCode());
            return this.pCurr;
        }
        public override Component next()
        {
            Debug.Assert(this.pCurr != null);

            Component pNode = this.pCurr;

            Component pChild = GetChild(pNode);
            Component pSibling = GetSibling(pNode);
            Component pParent = GetParent(pNode);

            // start depth first iteration
            pNode = nextStep(pNode, pParent, pChild, pSibling);

            this.pCurr = pNode;

            //if (this.pCurr != null)
            //{
            //    Debug.WriteLine("---> {0}", this.pCurr.GetHashCode());
            //}
            //else
            //{
            //    Debug.WriteLine("---> null");
            //}

            return this.pCurr;
        }
        public override bool isDone()
        {
            return (this.pCurr == null);
        }
        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private Component nextStep(Component pNode, Component pParent, Component pChild, Component pSibling)
        {
            pNode = null;

            if(pChild != null)
            {
                pNode = pChild;
            }
            else
            {
                if (pSibling != null)
                {
                    pNode = pSibling;
                }
                else
                {
                    // no more children or siblings, go back to parent
                    while (pParent != null)
                    {
                        pNode = GetSibling(pParent);
                        if (pNode != null)
                        {
                            break;
                        }
                        else
                        {
                            // go up a level
                            pParent = GetParent(pParent);
                        }
                    }
                }
            }

            return pNode;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private Component pCurr;
        private Component pRoot;
    }
}
