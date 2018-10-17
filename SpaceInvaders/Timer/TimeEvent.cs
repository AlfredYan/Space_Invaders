using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class TimeEvent_Link : DLink
    {

    }
    public class TimeEvent : TimeEvent_Link
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Name
        {
            CrabAnimation,
            OctopusAnimation,
            SquidAnimation,
            UFOBombAnination,
            MovementAnimation,
            DropBombAnination,
            ExplosionEvent,
            Uninitialized
        }
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public TimeEvent()
            : base()
        {
            this.name = TimeEvent.Name.Uninitialized;
            this.pCommand = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }
        ~TimeEvent()
        {
            this.name = TimeEvent.Name.Uninitialized;
            this.pCommand = null;
        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void set(TimeEvent.Name name, Command pCommand, float deltaTimeToTrigger)
        {
            Debug.Assert(pCommand != null);
            this.name = name;
            this.pCommand = pCommand;
            this.deltaTime = deltaTimeToTrigger;

            // set trigger time
            this.triggerTime = TimerMan.GetCurrTime() + deltaTimeToTrigger;
        }
        public void process()
        {
            // ensure pCommand is not null
            Debug.Assert(this.pCommand != null);
            this.pCommand.execute(this.deltaTime);
        }
        public new void clear()
        {
            this.name = TimeEvent.Name.Uninitialized;
            this.pCommand = null;
            this.triggerTime = 0.0f;
            this.deltaTime = 0.0f;
        }
        public void deepClear()
        {
            base.clear();
            this.clear();
        }
        public void setName(TimeEvent.Name name)
        {
            this.name = name;
        }
        public TimeEvent.Name getName()
        {
            return this.name;
        }
        public void setCommand(Command pCommand)
        {
            this.pCommand = pCommand;
        }
        public Command getCommand()
        {
            return this.pCommand;
        } 
        public void setTriggerTime(float triggerTime)
        {
            this.triggerTime = triggerTime;
        } 
        public float getTriggerTime()
        {
            return this.triggerTime;
        } 
        public void setDeltaTime(float deltaTime)
        {
            this.deltaTime = deltaTime;
        } 
        public float getDeltaTime()
        {
            return this.deltaTime;
        } 
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private TimeEvent.Name name;
        private Command pCommand;
        private float triggerTime;
        private float deltaTime;
    }
}
