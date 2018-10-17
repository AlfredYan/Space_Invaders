using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Command
    {
        public abstract void execute(float deltaTime);
    }
}
