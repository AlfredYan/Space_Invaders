using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class BackToSelectObserver : InputObserver
    {
        public override void notify()
        {
            Scene pScene = SceneMan.GetScene();
            pScene.unLoadContent();
            pScene.setState(SceneMan.State.SelectScene);
            pScene.loadContent();
        }
    }
}
