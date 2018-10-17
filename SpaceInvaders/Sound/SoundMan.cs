using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SoundMan
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        private SoundMan()
        {
            this.pSndEngine = new IrrKlang.ISoundEngine();
        }
        ~SoundMan()
        {
            this.pSndEngine = null;
        }
        //---------------------------------------------------------
        // Static methods
        //---------------------------------------------------------
        public static void Create()
        {
            Debug.Assert(pInstance == null);

            if(pInstance == null)
            {
                pInstance = new SoundMan();
            }

            Debug.Assert(pInstance != null);
        }
        public static void Play(String soundPath)
        {
            //ensure call Create() first
            SoundMan pMan = SoundMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.pSndEngine.Play2D(soundPath);
        }
        public static void Update()
        {
            //ensure call Create() first
            SoundMan pMan = SoundMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.pSndEngine.Update();
        }
        //---------------------------------------------------------
        // Private methods
        //---------------------------------------------------------
        private static SoundMan GetInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }
        //---------------------------------------------------------
        // Data
        //---------------------------------------------------------
        private static SoundMan pInstance = null;
        private IrrKlang.ISoundEngine pSndEngine;

    }
}
