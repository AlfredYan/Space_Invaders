using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Image_MLink : Manager
    {
        public Image_Link pActive;
        public Image_Link pReserved;
    }
    public class ImageMan : Image_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private ImageMan(int reverseNum = 3, int growNum = 1)
            : base()
        {
            // At this point, ImageMan is created, now initialize the reserve list
            this.baseInitialize(reverseNum, growNum);

            this.poNodeForCompare = new Image();
        }
        ~ImageMan()
        {
            this.poNodeForCompare = null;
            ImageMan.pInstance = null;
        }
        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reverseNum = 3, int growNum = 1)
        {
            // ensure reverseNum and growNum are reasonable
            Debug.Assert(reverseNum >= 0);
            Debug.Assert(growNum > 0);

            Debug.Assert(ImageMan.pInstance == null);

            // ensure the pInstance is null
            if(ImageMan.pInstance == null)
            {
                ImageMan.pInstance = new ImageMan();

                // Add a NULL Texture into the Manager, allows find 
                ImageMan.Add(Image.Name.NullObject, Texture.Name.NullObject, 0, 0, 128, 128);

                // add default image to active list
                ImageMan.Add(Image.Name.Default, Texture.Name.Default, 0, 0, 128, 128);
            }
        }
        public static Image Add(Image.Name imageName, Texture.Name textureName, float x, float y, float width, float height)
        {
            // ensure call Create() first
            ImageMan pMan = ImageMan.GetInstance();
            Debug.Assert(pMan != null);

            // add Image to active list
            Image pImage = (Image)pMan.baseAdd();
            Debug.Assert(pImage != null);

            // find the texture by texture name
            Texture pTexture = TextureMan.Find(textureName);
            Debug.Assert(pTexture != null);

            // set new Image
            pImage.set(imageName, pTexture, x, y, width, height);

            return pImage;
        }
        public static Image Find(Image.Name name)
        {
            // ensure call Create() first
            ImageMan pMan = ImageMan.GetInstance();
            Debug.Assert(pMan != null);

            // find the image by specific image name
            pMan.poNodeForCompare.setName(name);
            Image pImage = (Image)pMan.baseFind(pMan.poNodeForCompare);

            return pImage;
        }
        public static void Remove(Image pImage)
        {
            // ensure call Create() first
            ImageMan pMan = ImageMan.GetInstance();
            Debug.Assert(pMan != null);

            // ensure pImage is not null
            Debug.Assert(pImage != null);
            pMan.baseRemove(pImage);
        }
        public static void Destory()
        {
            // ensure call Create() first
            ImageMan pMan = ImageMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDestory();

            pMan.poNodeForCompare = null;
            ImageMan.pInstance = null;
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static ImageMan GetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        protected override bool derivedCompare(DLink pNodeA, DLink pNodeB)
        {
            // ensure pNodeA & pNodeB are not null
            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);

            // cast DLink to concrete type Image
            Image pDataA = (Image)pNodeA;
            Image pDataB = (Image)pNodeB;

            return (pDataA.getName() == pDataB.getName());

        }

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new Image();
            Debug.Assert(pNode != null);

            return pNode;
        }

        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);

            Image pImage = (Image)pLink;
            pImage.deepClear();
;        }

        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private Image poNodeForCompare;
        private static ImageMan pInstance = null;
    }
}
