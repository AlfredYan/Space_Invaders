using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    abstract public class BoxSpriteMan_MLink : Manager
    {
        // make UML clearly
        public BoxSprite_Base pActive;
        public BoxSprite_Base pReserved;
    }
    public class BoxSpriteMan : BoxSpriteMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private BoxSpriteMan(int reserveNum = 3, int reserveGrow = 1)
            : base()
        {
            // At this point, BoxSpriteMan is created, now initialize the reserve list
            this.baseInitialize(reserveNum, reserveGrow);
            this.poNodeForCompare = new BoxSprite();
        }
        ~BoxSpriteMan()
        {
            this.poNodeForCompare = null;
            BoxSpriteMan.pInstance = null;
        }
        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int reserveGrow = 1)
        {
            // make sure parameters are ressonable 
            Debug.Assert(reserveNum > 0);
            Debug.Assert(reserveGrow > 0);

            // ensure the instance of BoxSpriteMan has not been created
            Debug.Assert(BoxSpriteMan.pInstance == null);

            if(BoxSpriteMan.pInstance == null)
            {
                pInstance = new BoxSpriteMan(reserveNum, reserveGrow);
            }
        }
        public static BoxSprite Add(BoxSprite.Name name, float x, float y, float width, float height, Azul.Color pColor = null)
        {
            //ensure call Create() first
            BoxSpriteMan pMan = BoxSpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            BoxSprite pBoxSprite = (BoxSprite)pMan.baseAdd();
            Debug.Assert(pBoxSprite != null);

            pBoxSprite.set(name, x, y, width, height, pColor);

            return pBoxSprite;
        }
        public static BoxSprite Find(BoxSprite.Name name)
        {
            //ensure call Create() first
            BoxSpriteMan pMan = BoxSpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.poNodeForCompare.setName(name);
            BoxSprite pData = (BoxSprite)pMan.baseFind(pMan.poNodeForCompare);
            return pData;
        }
        public static void Remove(BoxSprite pBoxSprite)
        {
            //ensure call Create() first
            BoxSpriteMan pMan = BoxSpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pBoxSprite != null);
            pMan.baseRemove(pBoxSprite);
        }
        public static void Destory()
        {
            //ensure call Create() first
            BoxSpriteMan pMan = BoxSpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDestory();

            pMan.poNodeForCompare = null;
            BoxSpriteMan.pInstance = null;
        }
        public static void Reset()
        {
            //ensure call Create() first
            BoxSpriteMan pMan = BoxSpriteMan.GetInstance();
            Debug.Assert(pMan != null);

            BoxSprite pBoxSprite = (BoxSprite)pMan.pActive;
            while (pBoxSprite != null)
            {
                pBoxSprite.deepClear();
                pBoxSprite = (BoxSprite)pBoxSprite.pNext;
            }

            pMan.baseSetActiveHead(null);
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        protected override bool derivedCompare(DLink pNodeA, DLink pNodeB)
        {
            // ensure pNodeA & pNodeB are not null
            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);

            // cast DLink to concrete type BoxSprite
            BoxSprite pDataA = (BoxSprite)pNodeA;
            BoxSprite pDataB = (BoxSprite)pNodeB;

            return (pDataA.getName() == pDataB.getName());
        }

        protected override DLink derivedCreateNode()
        {
            DLink pNode = new BoxSprite();
            Debug.Assert(pNode != null);

            return pNode;
        }
        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);
            BoxSprite pBoxSprite = (BoxSprite)pLink;
            pBoxSprite.deepClear();
        }
        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static BoxSpriteMan GetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }

        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private static BoxSpriteMan pInstance = null;
        private BoxSprite poNodeForCompare;
    }
}
