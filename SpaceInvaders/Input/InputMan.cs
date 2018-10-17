using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class InputMan
    {
        //-------------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------------
        private InputMan()
        {
            this.pSubjectArrowLeft = new InputSubject();
            this.pSubjectArrowRight = new InputSubject();
            this.pSubjectSpace = new InputSubject();
            this.pSubjectT = new InputSubject();
            this.pSubjectKey1 = new InputSubject();
            this.pSubjectKey2 = new InputSubject();
            this.pSubjectKeyEnter = new InputSubject();

            this.prevSpaceKey = false;
            this.prevTKey = false;
        }
        ~InputMan()
        {
            this.pSubjectArrowLeft = null;
            this.pSubjectArrowRight = null;
            this.pSubjectSpace = null;
            this.pSubjectT = null;
            this.pSubjectKey1 = null;
            this.pSubjectKey2 = null;
            this.pSubjectKeyEnter = null;
        }
        //-------------------------------------------------------------------------------
        // Static methods
        //-------------------------------------------------------------------------------
        public static InputSubject GetArrowRightSubject()
        {
            InputMan pMan = InputMan.GetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectArrowRight;
        }
        public static InputSubject GetArrowLeftSubject()
        {
            InputMan pMan = InputMan.GetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectArrowLeft;
        }
        public static InputSubject GetSpaceSubject()
        {
            InputMan pMan = InputMan.GetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectSpace;
        }
        public static InputSubject GetTSubject()
        {
            InputMan pMan = InputMan.GetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectT;
        }
        public static InputSubject GetKey1Subject()
        {
            InputMan pMan = InputMan.GetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectKey1;
        }
        public static InputSubject GetKey2Subject()
        {
            InputMan pMan = InputMan.GetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectKey2;
        }
        public static InputSubject GetKeyEnterSubject()
        {
            InputMan pMan = InputMan.GetInstance();
            Debug.Assert(pMan != null);

            return pMan.pSubjectKeyEnter;
        }
        public static void Update()
        {
            InputMan pMan = InputMan.GetInstance();
            Debug.Assert(pMan != null);

            // left key
            if(Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                pMan.pSubjectArrowLeft.notify();
            }

            // right key
            if(Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                pMan.pSubjectArrowRight.notify();
            }

            // T key
            bool currTKey = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_T);
            if (currTKey == true && pMan.prevTKey == false)
            {
                pMan.pSubjectT.notify();
            }

            pMan.prevTKey = currTKey;

            // space key
            bool currSpaceKey = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);
            if(currSpaceKey == true && pMan.prevSpaceKey == false)
            {
                pMan.pSubjectSpace.notify();
            }

            pMan.prevSpaceKey = currSpaceKey;

            // 1 key
            bool curr1Key = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1);
            if (curr1Key == true && pMan.prev1Key == false)
            {
                pMan.pSubjectKey1.notify();
            }

            pMan.prev1Key = curr1Key;

            // 2 key
            bool curr2Key = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2);
            if (curr2Key == true && pMan.prev2Key == false)
            {
                pMan.pSubjectKey2.notify();
            }

            pMan.prev2Key = curr2Key;

            // enter key
            bool currEnterKey = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_B);
            if (currEnterKey == true && pMan.prevEnterKey == false)
            {
                pMan.pSubjectKeyEnter.notify();
            }

            pMan.prevEnterKey = currEnterKey;

        }
        public static void Reset()
        {
            InputMan pMan = InputMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.pSubjectArrowLeft = new InputSubject();
            pMan.pSubjectArrowRight = new InputSubject();
            pMan.pSubjectSpace = new InputSubject();
            pMan.pSubjectT = new InputSubject();
            pMan.pSubjectKey1 = new InputSubject();
            pMan.pSubjectKey2 = new InputSubject();
            pMan.pSubjectKeyEnter = new InputSubject();
        }
        //-------------------------------------------------------------------------------
        // Private methods
        //-------------------------------------------------------------------------------
        private static InputMan GetInstance()
        {
            if(pInstance == null)
            {
                pInstance = new InputMan();
            }
            Debug.Assert(pInstance != null);

            return pInstance;
        }
        //-------------------------------------------------------------------------------
        // Data
        //-------------------------------------------------------------------------------
        private static InputMan pInstance = null;

        private InputSubject pSubjectArrowRight;
        private InputSubject pSubjectArrowLeft;
        private InputSubject pSubjectSpace;
        private InputSubject pSubjectT;
        private InputSubject pSubjectKey1;
        private InputSubject pSubjectKey2;
        private InputSubject pSubjectKeyEnter;

        private bool prevSpaceKey;
        private bool prevTKey;
        private bool prev1Key;
        private bool prev2Key;
        private bool prevEnterKey;
    }
}
