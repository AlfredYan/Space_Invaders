using System;
using System.Xml;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GlyphMan : Manager
    {
        //----------------------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------------------
        private GlyphMan(int reserveNum = 3, int reserveGrow = 1)
           : base()
        {
            this.baseInitialize(reserveNum, reserveGrow);

            this.pRefNode = (Glyph)this.derivedCreateNode();
        }
        ~GlyphMan()
        {
            this.pRefNode = null;
            GlyphMan.pInstance = null;
        }
        //----------------------------------------------------------------------------------
        // Static methods
        //----------------------------------------------------------------------------------
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
                pInstance = new GlyphMan(reserveNum, reserveGrow);
            }
        }
        public static Glyph Add(Glyph.Name name, int key, Texture.Name textName, float x, float y, float width, float height)
        {
            GlyphMan pMan = GlyphMan.GetInstance();

            Glyph pNode = (Glyph)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.set(name, key, textName, x, y, width, height);
            return pNode;
        }
        public static void AddXml(Glyph.Name glyphName, String assetName, Texture.Name textName)
        {
            System.Xml.XmlTextReader reader = new XmlTextReader(assetName);

            int key = -1;
            int x = -1;
            int y = -1;
            int width = -1;
            int height = -1;

            // I'm sure there is a better way to do this... but this works for now
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.
                        if (reader.GetAttribute("key") != null)
                        {
                            key = Convert.ToInt32(reader.GetAttribute("key"));
                        }
                        else if (reader.Name == "x")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    x = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "y")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    y = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "width")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    width = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        else if (reader.Name == "height")
                        {
                            while (reader.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Text)
                                {
                                    height = Convert.ToInt32(reader.Value);
                                    break;
                                }
                            }
                        }
                        break;

                    case XmlNodeType.EndElement: //Display the end of the element 
                        if (reader.Name == "character")
                        {
                            // have all the data... so now create a glyph
                            //Debug.WriteLine("key:{0} x:{1} y:{2} w:{3} h:{4}", key, x, y, width, height);
                            GlyphMan.Add(glyphName, key, textName, x, y, width, height);
                        }
                        break;
                }
            }
        }
        public static void Remove(Glyph pNode)
        {
            Debug.Assert(pNode != null);
            GlyphMan pMan = GlyphMan.GetInstance();
            pMan.baseRemove(pNode);
        }
        public static Glyph Find(Glyph.Name name, int key)
        {
            GlyphMan pMan = GlyphMan.GetInstance();

            // Compare functions only compares two Nodes
            pMan.pRefNode.name = name;
            pMan.pRefNode.key = key;

            Glyph pData = (Glyph)pMan.baseFind(pMan.pRefNode);
            return pData;
        }
        public static void Destroy()
        {
            // Get the instance
            GlyphMan pMan = GlyphMan.GetInstance();
            pMan.baseDestory();
        }
        //----------------------------------------------------------------------------------
        // Override abstract class
        //----------------------------------------------------------------------------------
        protected override bool derivedCompare(DLink pNodeA, DLink pNodeB)
        {
            // This is used in baseFind() 
            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);

            Glyph pDataA = (Glyph)pNodeA;
            Glyph pDataB = (Glyph)pNodeB;

            Boolean status = false;

            if (pDataA.name == pDataB.name && pDataA.key == pDataB.key)
            {
                status = true;
            }

            return status;
        }
        protected override DLink derivedCreateNode()
        {
            DLink pNode = new Glyph();
            Debug.Assert(pNode != null);
            return pNode;
        }
        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);
            Glyph pNode = (Glyph)pLink;
            pNode.deepClear();
        }
        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static GlyphMan GetInstance()
        {
            // Safety - this forces users to call Create() first before using class
            Debug.Assert(pInstance != null);

            return pInstance;
        }
        //----------------------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------------------
        private static GlyphMan pInstance = null;
        private Glyph pRefNode;

    }
}
