using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienFactory
    {
        //-------------------------------------------------------------------------------
        // Constructor
        //-------------------------------------------------------------------------------
        public AlienFactory(SpriteBatch.Name spriteBatchName, SpriteBatch.Name boxSpriteBatchName)
        {
            this.pSpriteBatch = SpriteBatchMan.Find(spriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pBoxSpriteBatch = SpriteBatchMan.Find(boxSpriteBatchName);
            Debug.Assert(this.pSpriteBatch != null);
        }
        ~AlienFactory()
        {
            this.pSpriteBatch = null;
        }
        //-------------------------------------------------------------------------------
        // Methods
        //-------------------------------------------------------------------------------
        public GameObject create(GameObject.Name objectName, AlienCategory.Type alienType, float posX = 0.0f, float posY = 0.0f)
        {
            GameObject pGameObject = null;

            switch(alienType)
            {
                case AlienCategory.Type.Octopus:
                    pGameObject = new Octopus(objectName, GameSprite.Name.Octopus, posX, posY);
                    break;

                case AlienCategory.Type.Crab:
                    pGameObject = new Crab(objectName, GameSprite.Name.Crab, posX, posY);
                    break;

                case AlienCategory.Type.Squid:
                    pGameObject = new Squid(objectName, GameSprite.Name.Squid, posX, posY);
                    break;

                case AlienCategory.Type.Column:
                    pGameObject = new AlienColumn(objectName, GameSprite.Name.NullObject, 0.0f, 0.0f);
                    break;

                case AlienCategory.Type.Group:
                    pGameObject = new AlienGroup(objectName, GameSprite.Name.NullObject, 0.0f, 0.0f);
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            // add pGameObject to GameObjectMan and pGrid
            Debug.Assert(pGameObject != null);

            // attached to SpritBatch
            pGameObject.activateGameSprite(this.pSpriteBatch);
            pGameObject.activateCollisionSprite(this.pBoxSpriteBatch);

            return pGameObject;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private SpriteBatch pSpriteBatch;
        private SpriteBatch pBoxSpriteBatch;
    }
}
