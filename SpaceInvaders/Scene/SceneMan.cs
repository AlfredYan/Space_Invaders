using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneMan
    {
        //---------------------------------------------------------
        // Enum
        //---------------------------------------------------------
        public enum State
        {
            SelectScene,
            GameScene,
            GameOverScene
        }
        private SceneMan()
        {
            this.pStateSelectScene = new SelectScene();
            this.pStateGameScene = new GameScene();
            this.pStateGameOverScene = new GameOverScene();
        }
        public static void Create()
        {
            Debug.Assert(pInstance == null);

            if (pInstance == null)
            {
                pInstance = new SceneMan();
            }

            Debug.Assert(pInstance != null);

            pInstance.pScene = ActivateScene();
            pInstance.pScene.setState(SceneMan.State.SelectScene);
        }
        public static Scene ActivateScene()
        {
            //ensure call Create() first
            SceneMan pSceneMan = SceneMan.GetInstance();
            Debug.Assert(pSceneMan != null);

            pSceneMan.pScene = new Scene();

            return pSceneMan.pScene;
        }
        public static Scene GetScene()
        {
            //ensure call Create() first
            SceneMan pSceneMan = SceneMan.GetInstance();
            Debug.Assert(pSceneMan != null);

            return pSceneMan.pScene;
        }
        public static SceneState GetState(SceneMan.State state)
        {
            //ensure call Create() first
            SceneMan pSceneMan = SceneMan.GetInstance();
            Debug.Assert(pSceneMan != null);

            SceneState pSceneState = null;

            switch (state)
            {
                case SceneMan.State.SelectScene:
                    pSceneState = pSceneMan.pStateSelectScene;
                    break;

                case SceneMan.State.GameScene:
                    pSceneState = pSceneMan.pStateGameScene;
                    break;

                case SceneMan.State.GameOverScene:
                    pSceneState = pSceneMan.pStateGameOverScene;
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }

            return pSceneState;
        }

        private static SceneMan GetInstance()
        {
            Debug.Assert(pInstance != null);

            return pInstance;
        }

        private Scene pScene;
        private static SceneMan pInstance = null;
        private SelectScene pStateSelectScene;
        private GameScene pStateGameScene;
        private GameOverScene pStateGameOverScene;
    }
}
