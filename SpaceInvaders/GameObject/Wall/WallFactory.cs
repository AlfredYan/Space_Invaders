using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class WallFactory
    {
        //-------------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------------
        public WallFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pBoxSpriteBatch = SpriteBatchMan.Find(boxSpriteBatchName);
            Debug.Assert(this.pBoxSpriteBatch != null);
        }
        ~WallFactory()
        {
            this.pSpriteBatch = null;
            this.pBoxSpriteBatch = null;
        }
        //-------------------------------------------------------------------------------
        // Method
        //-------------------------------------------------------------------------------
        public GameObject create(GameObject.Name objectName, WallCategory.Type wallType, float posX = 0.0f, float posY = 0.0f, float width = 0.0f, float height = 0.0f)
        {
            GameObject pGameObject = null;

            switch (wallType)
            {
                case WallCategory.Type.WallGroup:
                    pGameObject = new WallGroup(GameObject.Name.WallGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
                    break;

                case WallCategory.Type.Left:
                    pGameObject =  new WallLeft(GameObject.Name.WallLeft, GameSprite.Name.NullObject, posX, posY, width, height);
                    break;

                case WallCategory.Type.Right:
                    pGameObject = new WallRight(GameObject.Name.WallRight, GameSprite.Name.NullObject, posX, posY, width, height);
                    break;

                case WallCategory.Type.Top:
                    pGameObject = new WallTop(GameObject.Name.WallTop, GameSprite.Name.NullObject, posX, posY, width, height);
                    break;

                case WallCategory.Type.Bottom:
                    pGameObject = new WallBottom(GameObject.Name.WallBottom, GameSprite.Name.NullObject, posX, posY, width, height);
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            Debug.Assert(pGameObject != null);

            pGameObject.activateGameSprite(this.pSpriteBatch);
            pGameObject.activateCollisionSprite(this.pBoxSpriteBatch);

            return pGameObject;
        }
        //-------------------------------------------------------------------------------
        // Data
        //-------------------------------------------------------------------------------
        private SpriteBatch pSpriteBatch;
        private SpriteBatch pBoxSpriteBatch;
    }
}
