using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    
    public class ExplosionEvent : Command
    {
        public ExplosionEvent(GameObject pGameObject)
        {
            this.pGameObject = pGameObject;
        }
        public override void execute(float deltaTime)
        {
            GameObject pParent = (GameObject)Iterator.GetParent(this.pGameObject);
            this.pGameObject.remove();

            while (checkParent(pParent))
            {
                GameObject pGrandParent = (GameObject)Iterator.GetParent(pParent);
                //if (pParent.getName() == GameObject.Name.AlienGroup) break;
                if(pGrandParent == null) break;

                pParent.remove();
                pParent = pGrandParent;
            }
        }
        private bool checkParent(GameObject pParent)
        {
            GameObject pChild = (GameObject)Iterator.GetChild(pParent);

            if (pChild == null)
            {
                return true;
            }

            return false;
        }

        private GameObject pGameObject;
    }
}
