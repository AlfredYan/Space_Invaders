using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class CollisionVisitor : DLink
    {
        //----------------------------------------------------------------------
        // Abstract methods
        //----------------------------------------------------------------------
        public virtual void visitAlienGroup(AlienGroup alienGroup)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by AlienGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void visitAlienColumn(AlienColumn alienColumn)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by AlienColumn not implemented");
            Debug.Assert(false);
        }
        public virtual void visitOctopus(Octopus octopus)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by Octopus not implemented");
            Debug.Assert(false);
        }
        public virtual void visitCrab(Crab crab)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by Crab not implemented");
            Debug.Assert(false);
        }
        public virtual void visitSquid(Squid squid)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by Squid not implemented");
            Debug.Assert(false);
        }
        public virtual void visitMissile(Missile missile)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by Missile not implemented");
            Debug.Assert(false);
        }
        public virtual void visitMissileGroup(MissileGroup missileGroup)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by MissileGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void visitNullGameObject(NullGameObject nullGameObject)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by NullGameObject not implemented");
            Debug.Assert(false);
        }
        public virtual void visitWallGroup(WallGroup wallGroup)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by WallGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void visitWallLeft(WallLeft wallLeft)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by WallLeft not implemented");
            Debug.Assert(false);
        }
        public virtual void visitWallRight(WallRight wallRight)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by WallRight not implemented");
            Debug.Assert(false);
        }
        public virtual void visitWallTop(WallTop wallTop)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by WallTop not implemented");
            Debug.Assert(false);
        }
        public virtual void visitWallBottom(WallBottom wallBottom)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by WallBottom not implemented");
            Debug.Assert(false);
        }
        public virtual void visitShipGroup(ShipGroup shipGroup)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by ShipGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void visitShip(Ship ship)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by Ship not implemented");
            Debug.Assert(false);
        }
        public virtual void visitBumpGroup(BumpGroup bumpGroup)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by BumpGroup not implemented");
            Debug.Assert(false);
        }
        public virtual void visitBumpRight(BumpRight bumpRight)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by BumpRight not implemented");
            Debug.Assert(false);
        }
        public virtual void visitBumpLeft(BumpLeft bumpLeft)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by BumpLeft not implemented");
            Debug.Assert(false);
        }
        public virtual void visitShieldRoot(ShieldRoot shieldRoot)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by ShieldRoot not implemented");
            Debug.Assert(false);
        }
        public virtual void visitShieldGrid(ShieldGrid shieldGrid)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by ShieldGrid not implemented");
            Debug.Assert(false);
        }
        public virtual void visitShieldColumn(ShieldColumn shieldColumn)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by ShieldColumn not implemented");
            Debug.Assert(false);
        }
        public virtual void visitShieldBrick(ShieldBrick shieldBrick)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by ShieldBrick not implemented");
            Debug.Assert(false);
        }
        public virtual void visitBombRoot(BombRoot bombRoot)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by BombRoot not implemented");
            Debug.Assert(false);
        }
        public virtual void visitBomb(Bomb bomb)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by Bomb not implemented");
            Debug.Assert(false);
        }
        public virtual void visitUFORoot(UFORoot ufoRoot)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by UFORoot not implemented");
            Debug.Assert(false);
        }
        public virtual void visitUFO(UFO ufo)
        {
            // no differed to subclass
            Debug.WriteLine("Visit by UFO not implemented");
            Debug.Assert(false);
        }
        public abstract void accept(CollisionVisitor other);
    }
}
