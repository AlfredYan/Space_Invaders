using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienMan
    {
        //---------------------------------------------------------
        // Enum
        //---------------------------------------------------------
        public enum State
        {
            Ready,
            BombDroping,
            End
        }
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        private AlienMan()
        {
            // store states
            this.pStateReady = new AlienStateReady();
            this.pStateBombDroping = new AlienStateBombDroping();
        }
        //---------------------------------------------------------
        // Static methods
        //---------------------------------------------------------
        public static void Create()
        {
            // ensure the instance of AlienMan has not been created
            Debug.Assert(pInstance == null);

            if (pInstance == null)
            {
                pInstance = new AlienMan();
            }

            Debug.Assert(pInstance != null);
        }
        public static AlienState GetState(AlienMan.State state)
        {
            //ensure call Create() first
            AlienMan pMan = AlienMan.GetInstance();
            Debug.Assert(pMan != null);

            AlienState pAlienState = null;

            switch(state)
            {
                case AlienMan.State.Ready:
                    pAlienState = pMan.pStateReady;
                    break;

                case AlienMan.State.BombDroping:
                    pAlienState = pMan.pStateBombDroping;
                    break;

                default:
                    Debug.Assert(false);
                    break;

            }

            return pAlienState;
        }
        //---------------------------------------------------------
        // Private methods
        //---------------------------------------------------------
        private static AlienMan GetInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }
        //---------------------------------------------------------
        // Data
        //---------------------------------------------------------
        private static AlienMan pInstance = null;

        // states
        private AlienStateReady pStateReady;
        private AlienStateBombDroping pStateBombDroping;
    }
}
