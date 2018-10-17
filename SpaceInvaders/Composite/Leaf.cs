using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Leaf : GameObject
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public Leaf(GameObject.Name gameName, GameSprite.Name spriteName)
            : base(gameName, spriteName)
        {
            this.holder = Container.Leaf;
        }
        //----------------------------------------------------------------------
        // Override abstract methods
        //----------------------------------------------------------------------
        public override void add(Component component)
        {
            Debug.Assert(false);
        }
        public override void remove(Component component)
        {
            Debug.Assert(false);
        }
        public override void print()
        {
            Debug.WriteLine(" GameObject Name: {0} ({1})", this.getName(), this.GetHashCode());
        }
        public override void move(float deltaX, float deltaY)
        {
            Debug.Assert(false);
        }
        public override Component getFirstChild()
        {
            Debug.Assert(false);
            return null;
        }
        public override void dumpNode()
        {
            Debug.WriteLine(" GameObject Name: {0} ({1})", this.getName(), this.GetHashCode());
        }
    }
}
