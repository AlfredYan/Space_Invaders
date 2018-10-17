using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class FallStrategy
    {
        public abstract void fall(Bomb pBomb);
        public abstract void reset(float posY);
    }
}
