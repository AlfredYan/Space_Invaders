using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class NullGameObject : Leaf
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public NullGameObject()
            : base(GameObject.Name.Null_Object, GameSprite.Name.NullObject)
        {

        }
        ~NullGameObject()
        {

        }

        public override void accept(CollisionVisitor other)
        {
            other.visitNullGameObject(this);
        }

        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        public override void update()
        {
            // do nothing - its a null object
        }
    }
}
