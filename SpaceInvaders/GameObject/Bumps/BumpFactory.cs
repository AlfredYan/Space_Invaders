using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BumpFactory
    {
        //-------------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------------
        public BumpFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pBoxSpriteBatch = SpriteBatchMan.Find(boxSpriteBatchName);
            Debug.Assert(this.pBoxSpriteBatch != null);
        }
        //-------------------------------------------------------------------------------
        // Method
        //-------------------------------------------------------------------------------
        public GameObject create(GameObject.Name objectName, BumpCategory.Type bumpType, float posX = 0.0f, float posY = 0.0f, float width = 0.0f, float height = 0.0f)
        {
            GameObject pGameObject = null;

            switch (bumpType)
            {
                case BumpCategory.Type.BumpGroup:
                    pGameObject = new BumpGroup(GameObject.Name.BumpGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
                    break;

                case BumpCategory.Type.Left:
                    pGameObject = new BumpLeft(GameObject.Name.BumpLeft, GameSprite.Name.NullObject, posX, posY, width, height);
                    break;

                case BumpCategory.Type.Right:
                    pGameObject = new BumpRight(GameObject.Name.BumpRight, GameSprite.Name.NullObject, posX, posY, width, height);
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
