using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFORoot : Composite
    {
        public UFORoot(Name gameName, GameSprite.Name spriteName, float posX, float posY) 
            : base(gameName, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(0, 0, 1);
        }
        ~UFORoot()
        {

        }

        public override void accept(CollisionVisitor other)
        {
            other.visitUFORoot(this);
        }
        public override void update()
        {
            base.BaseUpdateBoundingBox(this);
            base.update();
        }
        public override void visitWallGroup(WallGroup wallGroup)
        {
            // wallGroup vs UFORoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(wallGroup, pGameObj);
        }
        public override void visitMissileGroup(MissileGroup missileGroup)
        {
            // ufo group vs missile group
            //Debug.WriteLine("         collide:  {0} <-> {1}", missileGroup.getName(), this.getName());

            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(missileGroup, pGameObj);
        }
    }
}
