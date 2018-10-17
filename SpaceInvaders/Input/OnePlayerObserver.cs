using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class OnePlayerObserver : InputObserver
    {
        public override void notify()
        {
            Scene pScene = SceneMan.GetScene();
            pScene.unLoadContent();
            pScene.setState(SceneMan.State.GameScene);
            pScene.loadContent();
        }
    }
}
