using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameObject : Component
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Name
        {
            Octopus,
            Crab,
            Squid,
            AlienColumn_0,
            AlienColumn_1,
            AlienColumn_2,
            AlienColumn_3,
            AlienColumn_4,
            AlienColumn_5,
            AlienColumn_6,
            AlienColumn_7,
            AlienColumn_8,
            AlienColumn_9,
            AlienColumn_10,
            AlienGroup,

            Missile,
            MissileGroup,

            WallGroup,
            WallRight,
            WallLeft,
            WallTop,
            WallBottom,

            BumpGroup,
            BumpRight,
            BumpLeft,

            Ship,
            ShipGroup,

            ShieldRoot,
            ShieldGrid,
            ShieldColumn_0,
            ShieldColumn_1,
            ShieldColumn_2,
            ShieldColumn_3,
            ShieldColumn_4,
            ShieldColumn_5,
            ShieldColumn_6,
            ShieldBrick,

            BombGroup,
            Bomb,

            ShipLifeGroup,
            ExplosionGroup,

            UFO,
            UFORoot,

            Null_Object,
            Uninitialized
        }
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        protected GameObject(GameObject.Name gameName, GameSprite.Name spriteName)
        {
            this.name = gameName;
            this.x = 0.0f;
            this.y = 0.0f;
            this.bMarkForDeath = false;
            this.pProxySprite = ProxySpriteMan.Add(spriteName);

            this.poCollisionObject = new CollisionObject(this.pProxySprite);
            Debug.Assert(this.poCollisionObject != null);
        }
        ~GameObject()
        {
            this.name = GameObject.Name.Uninitialized;
            this.pProxySprite = null;
        }
        //----------------------------------------------------------------------
        // Abstract methods
        //----------------------------------------------------------------------
        public virtual void remove()
        {
            //Debug.WriteLine("REMOVE: {0}", this);

            // remove from SpriteBatch
            Debug.Assert(this.getProxySprite() != null);
            SBNode pSBNode = this.getProxySprite().GetSBNode();

            // remove it from the manager
            Debug.Assert(pSBNode != null);
            SpriteBatchMan.Remove(pSBNode);

            // remove collision sprite from spriteBatch
            Debug.Assert(this.poCollisionObject != null);
            Debug.Assert(this.poCollisionObject.pCollisionSprite != null);
            pSBNode = this.poCollisionObject.pCollisionSprite.GetSBNode();

            Debug.Assert(pSBNode != null);
            SpriteBatchMan.Remove(pSBNode);

            // remove from GameObjectMan
            GameObjectMan.Remove(this);

        }
        public virtual void update()
        {
            // update proxy sprite
            Debug.Assert(this.pProxySprite != null);
            this.pProxySprite.setX(this.x);
            this.pProxySprite.setY(this.y);

            // update collision sprite(box sprite)
            Debug.Assert(this.poCollisionObject != null);
            this.poCollisionObject.updatePosition(this.x, this.y);
            Debug.Assert(this.poCollisionObject.pCollisionSprite != null);
            this.poCollisionObject.pCollisionSprite.update();
        }
        public override void move(float deltaX, float deltaY)
        {
            this.x += deltaX;
            this.y += deltaY;
        }
        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public void activateCollisionSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            Debug.Assert(this.poCollisionObject != null);
            pSpriteBatch.attach(this.poCollisionObject.pCollisionSprite);
        }
        public void activateGameSprite(SpriteBatch pSpriteBatch)
        {
            Debug.Assert(pSpriteBatch != null);
            pSpriteBatch.attach(this.pProxySprite);
        }
        protected void BaseUpdateBoundingBox(Component pStart)
        {
            GameObject pNode = (GameObject)pStart;

            // point to ColTotal
            CollisionRect ColTotal = this.poCollisionObject.poCollisionRect;

            // Get the first child
            pNode = (GameObject)Iterator.GetChild(pNode);
            
            if(pNode != null)
            {
                // Initialized the union to the first block
                ColTotal.Set(pNode.poCollisionObject.poCollisionRect);

                // loop through sliblings
                while (pNode != null)
                {
                    ColTotal.union(pNode.poCollisionObject.poCollisionRect);

                    // go to next sibling
                    pNode = (GameObject)Iterator.GetSibling(pNode);
                }

                //this.poColObj.poColRect.Set(201, 201, 201, 201);
                this.x = this.poCollisionObject.poCollisionRect.x;
                this.y = this.poCollisionObject.poCollisionRect.y;

                //  Debug.WriteLine("x:{0} y:{1} w:{2} h:{3}", ColTotal.x, ColTotal.y, ColTotal.width, ColTotal.height);
            }

        }
        public GameObject.Name getName()
        {
            return this.name;
        }
        public void setName(GameObject.Name name)
        {
            this.name = name;
        }
        public ProxySprite getProxySprite()
        {
            return pProxySprite;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private GameObject.Name name;
        public float x;
        public float y;
        public bool bMarkForDeath;
        private ProxySprite pProxySprite;
        public CollisionObject poCollisionObject;
    }
}
