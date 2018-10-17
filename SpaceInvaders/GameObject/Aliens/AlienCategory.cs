using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class AlienCategory : Leaf
    {
        //---------------------------------------------------------------------------------------------------------
        // Enum
        //---------------------------------------------------------------------------------------------------------
        public enum Type
        {
            Octopus,
            Crab,
            Squid,
            Group,
            Column
        }

        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public AlienCategory(GameObject.Name gameObjName, GameSprite.Name spriteName)
            : base(gameObjName, spriteName)
        {
            this.canDropBomb = true;
            setState(AlienMan.State.Ready);
        }
        //---------------------------------------------------------
        // Methods
        //---------------------------------------------------------
        public void dropBomb()
        {
            this.state.dropBomb(this);
        }
        public void setState(AlienMan.State state)
        {
            this.state = AlienMan.GetState(state);
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        public bool canDropBomb;
        private AlienState state;
    }
}
