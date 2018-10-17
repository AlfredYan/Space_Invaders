using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class ProxySprite_Base : SpriteBase
    {

    }
    public class ProxySprite : ProxySprite_Base
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Name
        {
            Proxy,
            Uninitialized
        }
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public ProxySprite()
            : base()
        {
            this.name = ProxySprite.Name.Uninitialized;

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;

            this.pGameSprite = null;
        }
        public ProxySprite(GameSprite.Name name)
        {
            this.name = ProxySprite.Name.Proxy;

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;

            this.pGameSprite = GameSpriteMan.Find(name);
            Debug.Assert(this.pGameSprite != null);
        }
        ~ProxySprite()
        {
            this.pGameSprite = null;
            this.name = ProxySprite.Name.Uninitialized;
        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void set(GameSprite.Name name)
        {
            this.name = ProxySprite.Name.Proxy;

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;

            this.pGameSprite = GameSpriteMan.Find(name);
            Debug.Assert(this.pGameSprite != null);
        }
        private void pushToReal()
        {
            // push data from proxy to real GameSprite
            Debug.Assert(this.pGameSprite != null);

            this.pGameSprite.x = this.x;
            this.pGameSprite.y = this.y;
            this.pGameSprite.sx = this.sx;
            this.pGameSprite.sy = this.sy;
        }
        public void setName(ProxySprite.Name name)
        {
            this.name = name;
        }
        public ProxySprite.Name getName()
        {
            return this.name;
        }
        public void setX(float x)
        {
            this.x = x;
        }
        public void setY(float y)
        {
            this.y = y;
        }
        public new void clear()
        {
            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.name = ProxySprite.Name.Uninitialized;
            this.pGameSprite = null;
        }
        public void deepClear()
        {
            base.clear();
            this.clear();
        }
        public GameSprite getGameSprite()
        {
            return this.pGameSprite;
        }
        public void setGameSprite(GameSprite gameSprite)
        {
            this.pGameSprite = gameSprite;
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        public override void update()
        {
            // push data from proxy to real GameSprite
            this.pushToReal();
            this.pGameSprite.update();
        }

        public override void render()
        {
            // move the values over to Real GameSprite
            this.pushToReal();

            // update and draw real sprite 
            // Seems redundant - Real Sprite might be stale
            this.pGameSprite.update();
            this.pGameSprite.render();
        }

        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private ProxySprite.Name name;
        private float x;
        private float y;
        public float sx;
        public float sy;
        private GameSprite pGameSprite;
    }
}
