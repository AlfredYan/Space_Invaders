using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SpriteBatch_Link : DLink
    {
        // make the UML clearly
    }
    public class SpriteBatch : SpriteBatch_Link
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Name
        {
            Aliens,
            Boxes,
            Missiles,
            Walls,
            Ships,
            Bumps,
            Shields,
            Bombs,
            StartWindowTexts,
            StartWindowSprites,
            PlainTexts,
            GameOverWindowTexts,
            SelectWindowTexts,
            Lifes,
            Explosions,
            UFO,
            ShieldBoxes,
            Uninitialized
        }

        //---------------------------------------------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------------------------------------------
        public SpriteBatch()
            : base()
        {
            this.name = SpriteBatch.Name.Uninitialized;
            this.poSBNodeMan = new SBNodeMan();
            this.isDraw = true;
            Debug.Assert(this.poSBNodeMan != null);
        }
        ~SpriteBatch()
        {
            this.name = SpriteBatch.Name.Uninitialized;
            this.poSBNodeMan = null;
        }
        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public void set(SpriteBatch.Name name, int reserveNum = 3, int numGrow = 1)
        {
            this.name = name;
            this.poSBNodeMan.set(name, reserveNum, numGrow);
        }
        public void attach(SpriteBase pNode)
        {
            Debug.Assert(pNode != null);

            SBNode pSBNode = this.poSBNodeMan.attach(pNode);
            Debug.Assert(pSBNode != null);

            // initialize SpriteBatchNode
            pSBNode.set(pNode, this.poSBNodeMan);
        }
        public void destory()
        {
            Debug.Assert(this.poSBNodeMan != null);
            this.poSBNodeMan.destory();
        }
        public void deepClear()
        {
            this.poSBNodeMan.destory();
        }
        public void setName(SpriteBatch.Name name)
        {
            this.name = name;
        }
        public SpriteBatch.Name getName()
        {
            return this.name;
        }
        public SBNodeMan getSBNodeMan()
        {
            return this.poSBNodeMan;
        }
        public void remove(SpriteBase pNode)
        {
            Debug.Assert(pNode != null);

            SBNode pSBNode = (SBNode)this.poSBNodeMan.baseGetActiveList();
            Debug.Assert(pSBNode != null);

            while(pSBNode != null)
            {
                if(pSBNode.getSpriteBase() == pNode)
                {
                    // to do..
                    pSBNode.pNext.pPrev = pSBNode.pPrev;
                    pSBNode.pPrev.pNext = pSBNode.pNext;
                    break;
                }
                pSBNode = (SBNode)pSBNode.pNext;
            }
        }
        public void setIsDraw(bool isDraw)
        {
            this.isDraw = isDraw;
        }
        public bool getIsDraw()
        {
            return this.isDraw;
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private SpriteBatch.Name name;
        private SBNodeMan poSBNodeMan;
        private bool isDraw;
    }
}
