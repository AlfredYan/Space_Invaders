using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SceneState
    {
        // state()
        public abstract void handle(Scene pScene);

        // strategy()
        public virtual void loadContent(Scene pScene)
        {

        }
        public virtual void update(Scene pScene, float currTime)
        {

        }
        public virtual void draw(Scene pScene)
        {

        }
        public virtual void unLoadContent(Scene pScene)
        {

        }
    }
}
