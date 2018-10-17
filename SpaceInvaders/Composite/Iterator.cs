using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Iterator
    {
        //----------------------------------------------------------------------
        // Abstract methods
        //----------------------------------------------------------------------
        public abstract Component next();
        public abstract Component first();
        public abstract bool isDone();
        //----------------------------------------------------------------------
        // Static methods
        //----------------------------------------------------------------------
        public static Component GetSibling(Component pNode)
        {
            Debug.Assert(pNode != null);

            return (Component)pNode.pNext;
        }
        public static Component GetChild(Component pNode)
        {
            Debug.Assert(pNode != null);

            Component pChild;

            if(pNode.holder == Component.Container.Composite)
            {
                pChild = pNode.getFirstChild();
            }
            else
            {
                pChild = null;
            }

            return pChild;
        }
        public static Component GetParent(Component pNode)
        {
            Debug.Assert(pNode != null);

            return pNode.pParent;
        }
    }
}
