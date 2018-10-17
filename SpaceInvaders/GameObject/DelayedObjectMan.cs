using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DelayedObjectMan
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        private DelayedObjectMan()
        {
            this.head = null;
        }
        //---------------------------------------------------------------------------------------------------------
        // Static methods
        //---------------------------------------------------------------------------------------------------------
        static public void Attach(CollisionObserver observer)
        {
            // protection
            Debug.Assert(observer != null);

            DelayedObjectMan pDelayMan = DelayedObjectMan.PrivGetInstance();

            // add to front
            if (pDelayMan.head == null)
            {
                pDelayMan.head = observer;
                observer.pNext = null;
                observer.pPrev = null;
            }
            else
            {
                observer.pNext = pDelayMan.head;
                observer.pPrev = null;
                pDelayMan.head.pPrev = observer;
                pDelayMan.head = observer;
            }
        }
        static public void Process()
        {
            DelayedObjectMan pDelayMan = DelayedObjectMan.PrivGetInstance();

            CollisionObserver pNode = pDelayMan.head;

            while (pNode != null)
            {
                // Fire off listener
                pNode.execute();

                pNode = (CollisionObserver)pNode.pNext;
            }

            // remove
            pNode = pDelayMan.head;
            CollisionObserver pTmp = null;

            while (pNode != null)
            {
                pTmp = pNode;
                pNode = (CollisionObserver)pNode.pNext;

                // remove
                pDelayMan.PrivDetach(pTmp, ref pDelayMan.head);
            }
        }
        public static void Reset()
        {
            DelayedObjectMan pDelayMan = DelayedObjectMan.PrivGetInstance();
            pDelayMan.head = null;
        }
        //---------------------------------------------------------------------------------------------------------
        // Private methods
        //---------------------------------------------------------------------------------------------------------
        private static DelayedObjectMan PrivGetInstance()
        {
            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new DelayedObjectMan();
            }

            // Safety - this forces users to call create first
            Debug.Assert(pInstance != null);

            return pInstance;
        }
        private void PrivDetach(CollisionObserver node, ref CollisionObserver head)
        {
            // protection
            Debug.Assert(node != null);

            if (node.pPrev != null)
            {	// middle or last node
                node.pPrev.pNext = node.pNext;
            }
            else
            {  // first
                head = (CollisionObserver)node.pNext;
            }

            if (node.pNext != null)
            {	// middle node
                node.pNext.pPrev = node.pPrev;
            }
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private CollisionObserver head;
        private static DelayedObjectMan pInstance = null;
    }
}
