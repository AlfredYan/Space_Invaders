using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Composite : GameObject
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public Composite(GameObject.Name gameName, GameSprite.Name spriteName)
            : base(gameName, spriteName)
        {
            this.poHead = null;
            this.poLast = null;
            this.holder = Container.Composite;
        }
        //----------------------------------------------------------------------
        // Override abstract methods
        //----------------------------------------------------------------------
        public override void add(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            //DLink.AddToFront(ref this.poHead, pComponent);

            DLink.AddToLast(ref this.poHead, ref this.poLast, pComponent);

            pComponent.pParent = this;
        }

        public override void remove(Component pComponent)
        {
            Debug.Assert(pComponent != null);
            DLink.RemoveNode(ref this.poHead, ref this.poLast, pComponent);
        }

        public override void move(float deltaX, float deltaY)
        {
            DLink pNode = this.poHead;

            while(pNode != null)
            {
                Component pComponent = (Component)pNode;
                pComponent.move(deltaX, deltaY);

                pNode = pNode.pNext;
            }
        }

        public override void print()
        {
            DLink pNode = this.poHead;

            while (pNode != null)
            {
                Component pComponent = (Component)pNode;
                pComponent.print();

                pNode = pNode.pNext;
            }
        }
        public override Component getFirstChild()
        {
            DLink pNode = this.poHead;
            //Debug.Assert(pNode != null);

            return (Component)pNode;
        }
        public override void dumpNode()
        {
            //Debug.WriteLine(" GameObject Name: {0} ({1})  <---- Composite", this.getName(), this.GetHashCode());
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        public DLink poHead;
        public DLink poLast;
    }
}
