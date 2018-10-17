using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionObject
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public CollisionObject(ProxySprite pProxySprite)
        {
            Debug.Assert(pProxySprite != null);

            // create collision Rect
            // use the reference sprite to set size and shape
            GameSprite pGameSprite = pProxySprite.getGameSprite();
            Debug.Assert(pGameSprite != null);

            this.poCollisionRect = new CollisionRect(pGameSprite.getScreenRect());
            Debug.Assert(this.poCollisionRect != null);

            // create collision sprite(box sprite)
            this.pCollisionSprite = BoxSpriteMan.Add(BoxSprite.Name.Box, this.poCollisionRect.x, this.poCollisionRect.y, this.poCollisionRect.width, this.poCollisionRect.height);
            Debug.Assert(this.pCollisionSprite != null);
            this.pCollisionSprite.setLineColor(1.0f, 0.0f, 0.0f);
        }

        public void updatePosition(float x, float y)
        {
            this.poCollisionRect.x = x;
            this.poCollisionRect.y = y;

            this.pCollisionSprite.x = this.poCollisionRect.x;
            this.pCollisionSprite.y = this.poCollisionRect.y;

            this.pCollisionSprite.setScreenRect(this.poCollisionRect.x, this.poCollisionRect.y, this.poCollisionRect.width, this.poCollisionRect.height);
            this.pCollisionSprite.update();
        }

        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        public BoxSprite pCollisionSprite;
        public CollisionRect poCollisionRect;
    }
}
