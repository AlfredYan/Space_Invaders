using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameObjectNode_Link : DLink
    {

    }
    public class GameObjectNode : GameObjectNode_Link
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public GameObjectNode()
            : base()
        {
            this.pGameObject = null;
        }
        ~GameObjectNode()
        {
            this.pGameObject = null;
        }
        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public void set(GameObject pGameObject)
        {
            Debug.Assert(pGameObject != null);
            this.pGameObject = pGameObject;
        }
        public void deepClear()
        {
            this.pGameObject = null;
        }
        public GameObject.Name getName()
        {
            return this.pGameObject.getName();
        }
        public void setGameObject(GameObject pGameObject)
        {
            this.pGameObject = pGameObject;
        }
        public GameObject getGameObject()
        {
            return this.pGameObject;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private GameObject pGameObject;
    }
}
