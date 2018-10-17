using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class TextureMan_MLink : Manager
    {
        public Texture_Link pActive;
        public Texture_Link pReserved;
    }
    public class TextureMan : TextureMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private TextureMan(int reverseNum = 3, int growNum = 1)
            :base()
        {
            // At this point, TextureMan is created, now initialize the reserve list
            this.baseInitialize(reverseNum, growNum);

            this.poNodeForCompare = new Texture();
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reverseNum = 3, int growNum = 1)
        {
            Debug.Assert(reverseNum >= 0);
            Debug.Assert(growNum > 0);

            // ensure the instance of TextureMan has not been created
            Debug.Assert(TextureMan.pInstance == null);

            // initialize the TextureMan
            if(TextureMan.pInstance == null)
            {
                pInstance = new TextureMan(reverseNum, growNum);

                // add NullObject texture to manager, allows find
                TextureMan.Add(Texture.Name.NullObject, "Hotpink.tga");

                // add default texture to active list
                TextureMan.Add(Texture.Name.Default, "Hotpink.tga");
            }

        }
        public static Texture Add(Texture.Name name, string pTextureFile)
        {
            //ensure call Create() first
            TextureMan pMan = TextureMan.GetInstance();
            Debug.Assert(pMan != null);

            //add Texture to active list
            Texture pTexture = (Texture)pMan.baseAdd();
            Debug.Assert(pTexture != null);

            // set new texture
            Debug.Assert(pTextureFile != null);
            pTexture.set(name, pTextureFile);

            return pTexture;
        }
        public static Texture Find(Texture.Name name)
        {
            //ensure call Create() first
            TextureMan pMan = TextureMan.GetInstance();
            Debug.Assert(pMan != null);

            // find the texture by specific texture name
            pMan.poNodeForCompare.setName(name);
            Texture pTexture = (Texture)pMan.baseFind(pMan.poNodeForCompare);

            return pTexture;
        }
        public static void Remove(Texture pTexture)
        {
            //ensure call Create() first
            TextureMan pMan = TextureMan.GetInstance();
            Debug.Assert(pMan != null);

            // ensure pTexture is not null
            Debug.Assert(pTexture != null);
            pMan.baseRemove(pTexture);
        }
        public static void Destory()
        {
            //ensure call Create() first
            TextureMan pMan = TextureMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDestory();

            pMan.poNodeForCompare = null;
            TextureMan.pInstance = null;
        }

        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static TextureMan GetInstance()
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

            // cast DLink to concrete type Texture
            Texture pDataA = (Texture)pNodeA;
            Texture pDataB = (Texture)pNodeB;

            return (pDataA.getName() == pDataB.getName());
        }

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new Texture();
            Debug.Assert(pNode != null);

            return pNode;
        }

        protected override void derivedReset(DLink pLink)
        {
            // ensure pLink is not null
            Debug.Assert(pLink != null);
            Texture pTexture = (Texture)pLink;
            pTexture.deepClear();
        }

        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------

        // use in Find()
        private Texture poNodeForCompare;
        private static TextureMan pInstance = null;
    }
}
