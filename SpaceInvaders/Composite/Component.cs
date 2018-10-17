using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Component : CollisionVisitor
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Container
        {
            Leaf,
            Composite,
            Unknown
        }

        //----------------------------------------------------------------------
        // Abstract methods
        //----------------------------------------------------------------------
        public abstract void add(Component component);
        public abstract void remove(Component component);
        public abstract void print();
        public abstract void move(float deltaX, float deltaY);
        public abstract Component getFirstChild();
        public abstract void dumpNode();

        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        public Component pParent = null;
        public Container holder = Container.Unknown;
        public Component pReverse = null;
    }
}
