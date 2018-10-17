using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SBNode_Link : DLink
    {

    }
    public class SBNode : SBNode_Link
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------------------------------------------
        public SBNode()
            : base()
        {
            this.pSpriteBase = null;
        }
        ~SBNode()
        {
            this.pSpriteBase = null;
        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void set(SpriteBase pNode, SBNodeMan pSBNodeMan)
        {
            Debug.Assert(pNode != null);
            this.pSpriteBase = pNode;

            // set back pointer, easy for deletion
            Debug.Assert(this.pSpriteBase != null);
            this.pSpriteBase.SetSBNode(this);

            Debug.Assert(pSBNodeMan != null);
            this.pBackSBNodeMan = pSBNodeMan;
        }
        public void deepClear()
        {
            this.pSpriteBase = null;
        }
        public SpriteBase getSpriteBase()
        {
            return this.pSpriteBase;
        }
        public void setSpriteBase(SpriteBase pSpriteBase)
        {
            this.pSpriteBase = pSpriteBase;
        }
        public SBNodeMan getSBNodeMan()
        {
            return this.pBackSBNodeMan;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private SpriteBase pSpriteBase;  // point to a SpriteBase
        private SBNodeMan pBackSBNodeMan; // point back to SBNodeMan
    }
}
