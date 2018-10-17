using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class RemoveUFOObserver : CollisionObserver
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public RemoveUFOObserver()
        {
            this.pUFO = null;
        }
        public RemoveUFOObserver(RemoveUFOObserver b)
        {
            this.pUFO = b.pUFO;
        }

        public override void notify()
        {
            this.pUFO = this.pSubject.pObjB;
            Debug.Assert(this.pUFO != null);

            if (pUFO.bMarkForDeath == false)
            {
                pUFO.bMarkForDeath = true;
                //   Delay
                RemoveUFOObserver pObserver = new RemoveUFOObserver(this);
                DelayedObjectMan.Attach(pObserver);
            }
        }

        public override void execute()
        {
            this.pUFO.remove();
            UFOEvent pUFOEvent = new UFOEvent();
            TimerMan.Add(TimeEvent.Name.MovementAnimation, pUFOEvent, UFOMan.getDeltaTime());
        }

        private GameObject pUFO;

        
    }
}
