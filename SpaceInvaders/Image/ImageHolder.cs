﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ImageHolder : SLink
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public ImageHolder(Image pImage)
            : base()
        {
            this.pImage = pImage;
        }
        ~ImageHolder()
        {
            this.pImage = null;
        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void setImage(Image pImage)
        {
            this.pImage = pImage;
        }
        public Image getImage()
        {
            return this.pImage;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private Image pImage;
    }
}
