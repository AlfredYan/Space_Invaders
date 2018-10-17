using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class FontMan : Manager
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private FontMan(int reserveNum = 3, int reserveGrow = 1)
            : base()
        {
            this.baseInitialize(reserveNum, reserveGrow);
            this.pRefNode = (Font)this.derivedCreateNode();
        }
        ~FontMan()
        {
            this.pRefNode = null;
            FontMan.pInstance = null;
        }
        //----------------------------------------------------------------------
        // Static methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure values are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // initialize the singleton here
            Debug.Assert(pInstance == null);

            // Do the initialization
            if (pInstance == null)
            {
                pInstance = new FontMan(reserveNum, reserveGrow);
            }
        }
        public static Font Add(Font.Name name, SpriteBatch.Name SB_Name, String pMessage, Glyph.Name glyphName, float xStart, float yStart)
        {
            FontMan pMan = FontMan.GetInstance();

            Font pNode = (Font)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.set(name, pMessage, glyphName, xStart, yStart);

            // Add to sprite batch
            SpriteBatch pSB = SpriteBatchMan.Find(SB_Name);
            Debug.Assert(pSB != null);
            Debug.Assert(pNode.pFontSprite != null);
            pSB.attach(pNode.pFontSprite);

            return pNode;
        }
        public static void AddXml(Glyph.Name glyphName, String assetName, Texture.Name textName)
        {
            GlyphMan.AddXml(glyphName, assetName, textName);
        }

        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            FontMan pMan = FontMan.GetInstance();
            pMan.baseRemove(pNode);
        }
        public static Font Find(Font.Name name)
        {
            FontMan pMan = FontMan.GetInstance();

            // Compare functions only compares two Nodes
            pMan.pRefNode.name = name;

            Font pData = (Font)pMan.baseFind(pMan.pRefNode);
            return pData;
        }
        public static void Destroy()
        {
            // Get the instance
            FontMan pMan = FontMan.GetInstance();
            pMan.baseDestory();
        }
        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static FontMan GetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }
        //----------------------------------------------------------------------
        // Override abstract methods
        //----------------------------------------------------------------------
        protected override DLink derivedCreateNode()
        {
            DLink pNode = new Font();
            Debug.Assert(pNode != null);
            return pNode;
        }
        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Font pNode = (Font)pLink;
            pNode.deepClear();
        }
        protected override bool derivedCompare(DLink pNodeA, DLink pNodeB)
        {
            // This is used in baseFind() 
            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);

            Font pDataA = (Font)pNodeA;
            Font pDataB = (Font)pNodeB;

            Boolean status = false;

            if (pDataA.name == pDataB.name)
            {
                status = true;
            }

            return status;
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private static FontMan pInstance = null;
        private Font pRefNode;
    }
}
