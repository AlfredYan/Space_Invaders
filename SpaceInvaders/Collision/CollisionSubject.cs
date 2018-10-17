using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionSubject
    {
        //-------------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------------
        public CollisionSubject()
        {
            this.pObjA = null;
            this.pObjB = null;
            this.pHead = null;
        }
        ~CollisionSubject()
        {
            this.pObjA = null;
            this.pObjB = null;
            this.pHead = null;
        }
        //-------------------------------------------------------------------------------
        // Methods
        //-------------------------------------------------------------------------------
        public void attach(CollisionObserver observer)
        {
            Debug.Assert(observer != null);
            observer.pSubject = this;

            // add to front
            if(pHead == null)
            {
                pHead = observer;
                observer.pNext = null;
                observer.pPrev = null;
            }
            else
            {
                observer.pNext = pHead;
                pHead.pPrev = observer;
                pHead = observer;
            }
        }
        public void notify()
        {
            CollisionObserver pNode = this.pHead;

            while(pNode != null)
            {
                pNode.notify();

                pNode = (CollisionObserver)pNode.pNext;
            }
        }
        //-------------------------------------------------------------------------------
        // Data
        //-------------------------------------------------------------------------------
        private CollisionObserver pHead;
        public GameObject pObjA;
        public GameObject pObjB;
    }
}
