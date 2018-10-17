using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class TimerMan_MLink : Manager
    {
        public TimeEvent_Link pActive;
        public TimeEvent_Link pReserved;
    }
    class TimerMan : TimerMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private TimerMan(int reserveNum = 3, int reserveGrow = 1)
            : base()
        {
            this.baseInitialize(reserveNum, reserveGrow);
            this.poNodeForCompare = new TimeEvent();
        }
        ~TimerMan()
        {
            
            this.poNodeForCompare = null;
            TimerMan.pInstance = null;
        }
        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int numGrow = 1)
        {
            // ensure reserveNum and numGrow are reasonable
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(numGrow > 0);

            Debug.Assert(pInstance == null);
            if(pInstance == null)
            {
                pInstance = new TimerMan(reserveNum, numGrow);
            }
        }
        public static TimeEvent Add(TimeEvent.Name name, Command pCommand, float deltaTimeToTrigger)
        {

            // ensure call Create() first
            TimerMan pMan = TimerMan.GetInstance();
            Debug.Assert(pMan != null);

            TimeEvent pTimeEvent = (TimeEvent)pMan.getNewNode();
            Debug.Assert(pTimeEvent != null);

            Debug.Assert(pCommand != null);
            Debug.Assert(deltaTimeToTrigger >= 0.0f);

            pTimeEvent.set(name, pCommand, deltaTimeToTrigger);
            pMan.sortTimeEventList(pTimeEvent);
            return pTimeEvent;
        }
        public static TimeEvent Find(TimeEvent.Name name)
        {
            // ensure call Create() first
            TimerMan pMan = TimerMan.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pMan.poNodeForCompare != null);
            pMan.poNodeForCompare.setName(name);

            TimeEvent pData = (TimeEvent)pMan.baseFind(pMan.poNodeForCompare);
            return pData;
        }
        public static void Remove(TimeEvent pNode)
        {
            // ensure call Create() first
            TimerMan pMan = TimerMan.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pNode != null);
            pMan.baseRemove(pNode);
        }
        public static void Update(float totalTime)
        {
            // ensure call Create() first
            TimerMan pMan = TimerMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.mCurrTime = totalTime;

            // get the active list
            TimeEvent pEvent = (TimeEvent)pMan.baseGetActiveList();
            TimeEvent pNextEvent = null;

            // walk the list until there is no more list or currtime is greater than timeEvent
            while(pEvent != null && (pMan.mCurrTime >= pEvent.getTriggerTime()))
            {
                // get next event
                pNextEvent = (TimeEvent)pEvent.pNext;

                if(pMan.mCurrTime > pEvent.getTriggerTime())
                {
                    // call it
                    pEvent.process();
                    // remove from active list
                    pMan.baseRemove(pEvent);
                }

                // go to next event
                pEvent = pNextEvent;
            }
        }
        public static float GetCurrTime()
        {
            // ensure call Create() first
            TimerMan pMan = TimerMan.GetInstance();
            Debug.Assert(pMan != null);

            return pMan.mCurrTime;
        }
        public static void Destory()
        {
            // ensure call Create() first
            TimerMan pMan = TimerMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDestory();

            pMan.poNodeForCompare = null;
            TimerMan.pInstance = null;
        }
        public static void Reset()
        {
            // ensure call Create() first
            TimerMan pMan = TimerMan.GetInstance();
            Debug.Assert(pMan != null);

            TimeEvent pTimeEvent = (TimeEvent)pMan.pActive;
            while (pTimeEvent != null)
            {
                pTimeEvent.deepClear();
                pTimeEvent = (TimeEvent)pTimeEvent.pNext;
            }

            pMan.baseSetActiveHead(null);
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        protected override bool derivedCompare(DLink pNodeA, DLink pNodeB)
        {
            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);

            TimeEvent pDataA = (TimeEvent)pNodeA;
            TimeEvent pDataB = (TimeEvent)pNodeB;

            return pDataA.getName() == pDataB.getName();
        }

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new TimeEvent();
            Debug.Assert(pNode != null);
            return pNode;
        }

        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);
            TimeEvent pTimeEvent = (TimeEvent)pLink;
            pTimeEvent.deepClear();
        }
        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static TimerMan GetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }
        private void sortTimeEventList(TimeEvent pTimeEvent)
        {
            // ensure call Create() first
            TimerMan pMan = TimerMan.GetInstance();
            Debug.Assert(pMan != null);

            TimeEvent pActiveList = (TimeEvent)pMan.baseGetActiveList();

            TimeEvent pCurrTimeEvent = pActiveList;

            if(pCurrTimeEvent == null)
            {
                pMan.baseSetActiveHead(pTimeEvent);
                return;
            }

            if (pCurrTimeEvent.pNext == null && pCurrTimeEvent.pPrev == null)
            {
                if (pCurrTimeEvent.getTriggerTime() > pTimeEvent.getTriggerTime())
                {
                    pCurrTimeEvent.pPrev = pTimeEvent;
                    pTimeEvent.pNext = pCurrTimeEvent;
                    pTimeEvent.pPrev = null;
                    pMan.baseSetActiveHead(pTimeEvent);
                    return;
                }
                else
                {
                    pCurrTimeEvent.pNext = pTimeEvent;
                    pTimeEvent.pPrev = pCurrTimeEvent;
                    pTimeEvent.pNext = null;
                    return;
                }
            }

            while (pCurrTimeEvent != null)
            {
                if(pCurrTimeEvent.getTriggerTime() >= pTimeEvent.getTriggerTime())
                {
                    if(pCurrTimeEvent.pPrev == null)
                    {
                        pCurrTimeEvent.pPrev = pTimeEvent;
                        pTimeEvent.pNext = pCurrTimeEvent;
                        pTimeEvent.pPrev = null;
                        pMan.baseSetActiveHead(pTimeEvent);
                        return;
                    }
                    else
                    {
                        pTimeEvent.pPrev = pCurrTimeEvent.pPrev;
                        pTimeEvent.pNext = pCurrTimeEvent;
                        pCurrTimeEvent.pPrev.pNext = pTimeEvent;
                        pCurrTimeEvent.pPrev = pTimeEvent;
                        return;
                    }

                }

                if (pCurrTimeEvent.pNext == null)
                {
                    pCurrTimeEvent.pNext = pTimeEvent;
                    pTimeEvent.pPrev = pCurrTimeEvent;
                    pTimeEvent.pNext = null;
                    return;
                }

                pCurrTimeEvent = (TimeEvent)pCurrTimeEvent.pNext;
            }

        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private static TimerMan pInstance = null;
        private TimeEvent poNodeForCompare;
        protected float mCurrTime;
    }
}
