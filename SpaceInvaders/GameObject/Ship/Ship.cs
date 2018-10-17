using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class Ship : ShipCategory
    {
        //---------------------------------------------------------
        // Constructor
        //---------------------------------------------------------
        public Ship(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName, ShipCategory.Type.Ship)
        {
            this.x = posX;
            this.y = posY;

            this.shipSpeed = 5.0f;
            this.state = null;
            this.posistionState = null;
            this.pLifeGroup = null;

            this.lifeRemain = 2;

        }
        //---------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitShip(this);
        }
        public override void update()
        {
            base.update();
        }
        //---------------------------------------------------------
        // Methods
        //---------------------------------------------------------
        public void moveRight()
        {
            this.posistionState.moveRight(this);
        }
        public void moveLeft()
        {
            this.posistionState.moveLeft(this);
        }
        public void shootMissile()
        {
            this.state.shootMissile(this);
        }
        public void setState(ShipMan.State state)
        {
            this.state = ShipMan.GetState(state);
        }
        public void setPositionState(ShipMan.State state)
        {
            this.posistionState = ShipMan.GetState(state);
        }
        public void reduceLife()
        {
            this.lifeRemain--;
            Ship pShipLife = (Ship)(pLifeGroup.poLast);
            if (pShipLife != null)
            {
                pShipLife.remove();
            }
        }
        public int getLife()
        {
            return this.lifeRemain;
        }
        public void createLifes()
        {
            this.pLifeGroup = (ShipLifeGroup)GameObjectMan.Find(GameObject.Name.ShipLifeGroup);
            SpriteBatch pSB_Lifes = SpriteBatchMan.Find(SpriteBatch.Name.Lifes);
            SpriteBatch pSB_Boxes = SpriteBatchMan.Find(SpriteBatch.Name.Boxes);

            Ship pShip;
            float startX = 40.0f;
            float startY = 30.0f;
            float gap = 60.0f;

            for (int i=0; i<this.lifeRemain; i++)
            {
                pShip = new Ship(GameObject.Name.Ship, GameSprite.Name.Ship, startX, startY);
                pShip.activateGameSprite(pSB_Lifes);
                pShip.activateCollisionSprite(pSB_Boxes);
                this.pLifeGroup.add(pShip);
                startX += gap;
            }

        }
        //---------------------------------------------------------
        // Data
        //---------------------------------------------------------
        public float shipSpeed;
        private ShipState state;
        private ShipState posistionState;
        private int lifeRemain;
        private ShipLifeGroup pLifeGroup;

    }
}
