using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class InputSubject
    {
        //-------------------------------------------------------------------------------
        // Methods
        //-------------------------------------------------------------------------------
        public void attach(InputObserver observer)
        {
            Debug.Assert(observer != null);

            observer.pSubject = this;

            // add to front
            if(this.pHead == null)
            {
                this.pHead = observer;
                observer.pPrev = null;
                observer.pNext = null;
            }
            else
            {
                observer.pPrev = null;
                observer.pNext = this.pHead;
                this.pHead.pPrev = observer;
                this.pHead = observer;
            }
        }
        public void notify()
        {
            InputObserver pNode = this.pHead;

            while(pNode != null)
            {
                // notify observers
                pNode.notify();

                pNode = (InputObserver)pNode.pNext;
            }
        }
        //-------------------------------------------------------------------------------
        // Data
        //-------------------------------------------------------------------------------
        private InputObserver pHead;
    }
}
