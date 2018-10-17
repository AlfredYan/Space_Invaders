using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienColumn : Composite
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public AlienColumn(GameObject.Name gameObjName, GameSprite.Name spriteName, float posX, float posY)
            : base(gameObjName, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(0.0f, 1.0f, 0.0f);
        }

        //----------------------------------------------------------------------
        // Override abstract methods
        //----------------------------------------------------------------------
        public override void update()
        {
            base.BaseUpdateBoundingBox(this);

            // update after all set
            base.update();
        }
        public override void accept(CollisionVisitor other)
        {
            other.visitAlienColumn(this);
        }
        public override void visitMissileGroup(MissileGroup missileGroup)
        {
            // alien column vs missile group
            //Debug.WriteLine("         collide:  {0} <-> {1}", missileGroup.getName(), this.getName());

            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(missileGroup, pGameObj);

        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
    }
}
