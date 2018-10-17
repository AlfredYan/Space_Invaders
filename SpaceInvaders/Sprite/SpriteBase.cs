using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SpriteBase : DLink
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public SpriteBase()
            : base()
        {
            this.pBackSBNode = null;
        }
        ~SpriteBase()
        {

        }
        //---------------------------------------------------------------------------------------------------------
        // Abstract methods
        //---------------------------------------------------------------------------------------------------------
        // let all sprites use the same render() and update()
        public abstract void update();
        public abstract void render();
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public SBNode GetSBNode()
        {
            Debug.Assert(this.pBackSBNode != null);
            return this.pBackSBNode;
        }
        public void SetSBNode(SBNode pSpriteBatchNode)
        {
            Debug.Assert(pSpriteBatchNode != null);
            this.pBackSBNode = pSpriteBatchNode;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        // have a back pointer to spriteBatchNode, easy for deletion
        private SBNode pBackSBNode;
    }
}
