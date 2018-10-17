using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AnimationExplosion : Command
    {
        public AnimationExplosion(GameObject gameObject, float keepTime)
        {
            this.pGameObject = gameObject;
            this.remainTime = keepTime;

            this.poFirstImage = null;
            this.pCurrImage = null;
        }
        ~AnimationExplosion()
        {
            this.pGameObject = null;
            this.poFirstImage = null;
            this.pCurrImage = null;
        }
        public void attach(Image.Name name)
        {
            // get the image
            Image pImage = ImageMan.Find(name);
            Debug.Assert(pImage != null);

            // create a new ImageHolder to hold the image
            ImageHolder pImageHolder = new ImageHolder(pImage);
            Debug.Assert(pImageHolder != null);

            // add to front
            SLink.AddToFront(ref this.poFirstImage, pImageHolder);

            // set the first one to this image
            this.pCurrImage = pImageHolder;
        }
        public override void execute(float deltaTime)
        {
            this.remainTime -= deltaTime;

            if(this.remainTime > 0)
            {
                // get next image
                ImageHolder pImageHolder = (ImageHolder)this.pCurrImage.pNext;

                // if at the end of the list, set first image back
                if (pImageHolder == null)
                {
                    pImageHolder = (ImageHolder)this.poFirstImage;
                }

                this.pCurrImage = pImageHolder;

                // change image
                this.pGameObject.getProxySprite().getGameSprite().swapImage(pImageHolder.getImage());

                // Add itself back to TimerMan
                TimerMan.Add(TimeEvent.Name.ExplosionEvent, this, deltaTime);
            }
            else
            {
                Ship pShip = (Ship)this.pGameObject;
                pShip.reduceLife();
                if(pShip.getLife() < 0)
                {
                    pShip.remove();
                    Scene pScene = SceneMan.GetScene();
                    pScene.unLoadContent();
                    pScene.setState(SceneMan.State.GameOverScene);
                    pScene.loadContent();
                }
                else
                {
                    pShip.setState(ShipMan.State.Ready);
                    pShip.setPositionState(ShipMan.State.Normal);
                    pShip.bMarkForDeath = false;
                    pShip.getProxySprite().setGameSprite(GameSpriteMan.Find(GameSprite.Name.Ship));
                }
                
            }
            
        }

        private GameObject pGameObject;
        private SLink pCurrImage;
        private SLink poFirstImage;
        private float remainTime;
    }
}
