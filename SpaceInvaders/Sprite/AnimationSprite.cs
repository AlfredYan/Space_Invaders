using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class AnimationSprite : Command
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public AnimationSprite(GameSprite.Name name)
        {
            this.pGameSprite = GameSpriteMan.Find(name);
            Debug.Assert(this.pGameSprite != null);

            this.poFirstImage = null;
            this.pCurrImage = null;
            this.poFirstSound = null;
            this.pCurrSound = null;
        }
        ~AnimationSprite()
        {
            this.pGameSprite = null;
            this.poFirstImage = null;
            this.pCurrImage = null;
            this.poFirstSound = null;
            this.pCurrSound = null;
        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
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
        public void attach(String pSound)
        {
            // create a new ImageHolder to hold the image
            SoundHolder pSoundHolder = new SoundHolder(pSound);
            Debug.Assert(pSoundHolder != null);

            // add to front
            SLink.AddToFront(ref this.poFirstSound, pSoundHolder);

            // set the first one to this image
            this.pCurrSound = pSoundHolder;
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        public override void execute(float deltaTime)
        {
            // get next image
            ImageHolder pImageHolder = (ImageHolder)this.pCurrImage.pNext;
            SoundHolder pSoundHolder = (SoundHolder)this.pCurrSound.pNext;

            // if at the end of the list, set first image back
            if (pImageHolder == null)
            {
                pImageHolder = (ImageHolder)this.poFirstImage;
            }

            if (pSoundHolder == null)
            {
                pSoundHolder = (SoundHolder)this.poFirstSound;
            }

            this.pCurrImage = pImageHolder;
            this.pCurrSound = pSoundHolder;

            // change image
            this.pGameSprite.swapImage(pImageHolder.getImage());
            SoundMan.Play(pSoundHolder.getSound());

            // Add itself back to TimerMan
            if(this.pGameSprite.getName() == GameSprite.Name.Squid)
            {
                TimerMan.Add(TimeEvent.Name.SquidAnimation, this, deltaTime);
            }
            else if (this.pGameSprite.getName() == GameSprite.Name.Crab)
            {
                TimerMan.Add(TimeEvent.Name.CrabAnimation, this, deltaTime);
            }
            else if (this.pGameSprite.getName() == GameSprite.Name.Octopus)
            {
                TimerMan.Add(TimeEvent.Name.OctopusAnimation, this, deltaTime);
            }

        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private GameSprite pGameSprite;
        private SLink pCurrImage;
        private SLink poFirstImage;
        private SLink pCurrSound;
        private SLink poFirstSound;
    }
}
