using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMan
    {
        //---------------------------------------------------------
        // Enum
        //---------------------------------------------------------
        public enum State
        {
            Ready,
            MissileFlying,
            End,
            MostLeft,
            MostRight,
            Normal,
            Stay
        }
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        private ShipMan()
        {
            // store states
            this.pStateReady = new ShipStateReady();
            this.pStateMissileFlying = new ShipStateMissileFlying();
            this.pStateEnd = new ShipStateEnd();
            this.pStateNormal = new ShipStateNormal();
            this.pStateMostRight = new ShipStateMostRight();
            this.pStateMostLeft = new ShipStateMostLeft();
            this.pStateStay = new ShipStateStay();

            // set objects
            this.pShip = null;
            this.pMissile = null;
        }
        //---------------------------------------------------------
        // Static methods
        //---------------------------------------------------------
        public static void Create()
        {
            // ensure the instance of ShipMan has not been created
            Debug.Assert(pInstance == null);

            if(pInstance == null)
            {
                pInstance = new ShipMan();
            }

            Debug.Assert(pInstance != null);
            
        }
        public static Ship ActivateShip()
        {
            //ensure call Create() first
            ShipMan pShipMan = ShipMan.GetInstance();
            Debug.Assert(pShipMan != null);

            // create ship
            Ship pShip = new Ship(GameObject.Name.Ship, GameSprite.Name.Ship, 440, 90);
            pShipMan.pShip = pShip;

            // attach sprite to correct sprite batch
            SpriteBatch pSB_Ships = SpriteBatchMan.Find(SpriteBatch.Name.Ships);
            pSB_Ships.attach(pShip.getProxySprite());

            // attach ship to ship group
            GameObject pShipGroup = GameObjectMan.Find(GameObject.Name.ShipGroup);
            Debug.Assert(pShipGroup != null);

            // add to GameObject
            pShipGroup.add(pShipMan.pShip);
            pShip.activateCollisionSprite(SpriteBatchMan.Find(SpriteBatch.Name.Boxes));

            return pShipMan.pShip;
        }
        public static void CreateShipLifes()
        {
            //ensure call Create() first
            ShipMan pShipMan = ShipMan.GetInstance();
            Debug.Assert(pShipMan != null);

            
            pInstance.pShip = ActivateShip();

            pInstance.pShip.setState(ShipMan.State.Ready);
            pInstance.pShip.setPositionState(ShipMan.State.Normal);
            pInstance.pShip.createLifes();
        }
        public static Ship GetShip()
        {
            //ensure call Create() first
            ShipMan pShipMan = ShipMan.GetInstance();
            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pShip != null);

            return pShipMan.pShip;
        }
        public static ShipState GetState(ShipMan.State state)
        {
            //ensure call Create() first
            ShipMan pShipMan = ShipMan.GetInstance();
            Debug.Assert(pShipMan != null);

            ShipState pShipState = null;

            switch (state)
            {
                case ShipMan.State.Ready:
                    pShipState = pShipMan.pStateReady;
                    break;

                case ShipMan.State.MissileFlying:
                    pShipState = pShipMan.pStateMissileFlying;
                    break;

                case ShipMan.State.End:
                    pShipState = pShipMan.pStateEnd;
                    break;

                case ShipMan.State.Normal:
                    pShipState = pShipMan.pStateNormal;
                    break;

                case ShipMan.State.MostLeft:
                    pShipState = pShipMan.pStateMostLeft;
                    break;

                case ShipMan.State.MostRight:
                    pShipState = pShipMan.pStateMostRight;
                    break;

                case ShipMan.State.Stay:
                    pShipState = pShipMan.pStateStay;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pShipState;
        }
        public static Missile ActivateMissile()
        {
            //ensure call Create() first
            ShipMan pShipMan = ShipMan.GetInstance();
            Debug.Assert(pShipMan != null);

            // create Missile
            Missile pMissile = new Missile(GameObject.Name.Missile, GameSprite.Name.Missile, 400, 100);
            pShipMan.pMissile = pMissile;

            // activate collision sprite and game sprite
            pMissile.activateCollisionSprite(SpriteBatchMan.Find(SpriteBatch.Name.Boxes));
            pMissile.activateGameSprite(SpriteBatchMan.Find(SpriteBatch.Name.Missiles));

            // attach missile to missile group
            GameObject pMissileGroup = GameObjectMan.Find(GameObject.Name.MissileGroup);
            Debug.Assert(pMissileGroup != null);

            // Add to GameObject
            pMissileGroup.add(pShipMan.pMissile);

            return pShipMan.pMissile;
        }
        public static Missile GetMissile()
        {
            //ensure call Create() first
            ShipMan pShipMan = ShipMan.GetInstance();
            Debug.Assert(pShipMan != null);
            Debug.Assert(pShipMan.pMissile != null);

            return pShipMan.pMissile;
        }
        public static void Reset()
        {
            //ensure call Create() first
            ShipMan pShipMan = ShipMan.GetInstance();
            Debug.Assert(pShipMan != null);

            pShipMan.pShip = null;
            pShipMan.pMissile = null;
        }
        //---------------------------------------------------------
        // Private methods
        //---------------------------------------------------------
        private static ShipMan GetInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }
        //---------------------------------------------------------
        // Data
        //---------------------------------------------------------
        private static ShipMan pInstance = null;

        // objects
        private Ship pShip;
        private Missile pMissile;

        // states
        private ShipStateReady pStateReady;
        private ShipStateMissileFlying pStateMissileFlying;
        private ShipStateEnd pStateEnd;
        private ShipStateNormal pStateNormal;
        private ShipStateMostLeft pStateMostLeft;
        private ShipStateMostRight pStateMostRight;
        private ShipStateStay pStateStay;
    }
}
