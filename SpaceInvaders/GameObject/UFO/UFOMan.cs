using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFOMan
    {
        private UFOMan()
        {
            this.pUFO = null;
        }
        public static void Create()
        {
            // ensure the instance of ShipMan has not been created
            Debug.Assert(pInstance == null);

            if (pInstance == null)
            {
                pInstance = new UFOMan();
            }

            Debug.Assert(pInstance != null);
        }

        public static UFO ActiveUFO()
        {
            UFOMan pUFOMan = UFOMan.GetInstance();
            Debug.Assert(pUFOMan != null);

            UFO pUFO = new UFO(GameObject.Name.UFO, GameSprite.Name.UFO, 10.0f, 925.0f);
            pUFOMan.pUFO = pUFO;
            pUFOMan.pUFO.activateGameSprite(SpriteBatchMan.Find(SpriteBatch.Name.UFO));
            pUFOMan.pUFO.activateCollisionSprite(SpriteBatchMan.Find(SpriteBatch.Name.Boxes));
            GameObject pUFORoot = GameObjectMan.Find(GameObject.Name.UFORoot);
            pUFORoot.add(pUFOMan.pUFO);

            return pUFOMan.pUFO;
        }

        public static void Reset()
        {
            UFOMan pUFOMan = UFOMan.GetInstance();
            Debug.Assert(pUFOMan != null);

            pUFOMan.pUFO = null;
        }

        public static UFO getUFO()
        {
            UFOMan pUFOMan = UFOMan.GetInstance();
            Debug.Assert(pUFOMan != null);
            return pUFOMan.pUFO;
        }
        public static int getDeltaTime()
        {
            return UFOMan.randomDeltaTime.Next(10);
        }
        public static int getShootTime()
        {
            return UFOMan.randomDeltaTime.Next(5);
        }

        private static UFOMan GetInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        private static UFOMan pInstance = null;
        private static Random randomDeltaTime = new Random();

        // objects
        private UFO pUFO;
    }
}
