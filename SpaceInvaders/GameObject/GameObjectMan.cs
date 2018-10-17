using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameObjectMan_MLink : Manager
    {
        public GameObjectNode_Link pActive;
        public GameObjectNode_Link pReserved;
    }
    public class GameObjectMan : GameObjectMan_MLink
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private GameObjectMan(int reserveNum = 3, int growNum = 1)
            : base()
        {
            this.baseInitialize(reserveNum, growNum);

            // initialize derived data
            this.poNodeForCompare = new GameObjectNode();
            this.poNullGameObject = new NullGameObject();

            this.poNodeForCompare.setGameObject(this.poNullGameObject);
        }
        ~GameObjectMan()
        {
            this.poNodeForCompare = null;
            this.poNullGameObject = null;
            GameObjectMan.pInstance = null;
        }
        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------
        public static void Create(int reserveNum = 3, int growNum = 1)
        {
            // ensure reserveNum and growNum are reasonable
            Debug.Assert(reserveNum >= 0);
            Debug.Assert(growNum > 0);

            Debug.Assert(pInstance == null);
            if(pInstance == null)
            {
                pInstance = new GameObjectMan(reserveNum, growNum);
            }
        }
        public static GameObjectNode Attach(GameObject pGameObject)
        {
            //ensure call Create() first
            GameObjectMan pMan = GameObjectMan.GetInstance();
            Debug.Assert(pMan != null);

            GameObjectNode pNode = (GameObjectNode)pMan.baseAdd();
            Debug.Assert(pNode != null);

            pNode.set(pGameObject);
            return pNode;
        }
        public static GameObject Find(GameObject.Name name)
        {
            //ensure call Create() first
            GameObjectMan pMan = GameObjectMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.poNodeForCompare.getGameObject().setName(name);

            GameObjectNode pNode = (GameObjectNode)pMan.baseFind(pMan.poNodeForCompare);
            Debug.Assert(pNode != null);

            return pNode.getGameObject();
        }
        public static void Remove(GameObjectNode pNode)
        {
            //ensure call Create() first
            GameObjectMan pMan = GameObjectMan.GetInstance();
            Debug.Assert(pMan != null);

            Debug.Assert(pMan != null);
            pMan.baseRemove(pNode);
        }
        public static void Remove(GameObject pNode)
        {
            Debug.Assert(pNode != null);

            //ensure call Create() first
            GameObjectMan pMan = GameObjectMan.GetInstance();
            Debug.Assert(pMan != null);

            // 1. find tree root
            GameObject pTmp = pNode;
            GameObject pRoot = null;
            while(pTmp != null)
            {
                pRoot = pTmp;
                pTmp = (GameObject)Iterator.GetParent(pTmp);
            }

            // 2. pRoot is the tree we looking for, walk the active list looking for pTree
            GameObjectNode pTree = (GameObjectNode)pMan.baseGetActiveList();

            while(pTree != null)
            {
                if(pTree.getGameObject() == pRoot)
                {
                    break;
                }

                // go to next tree
                pTree = (GameObjectNode)pTree.pNext;
            }

            // 3. pTree is the tree that holds pNode, remove pNode from pTree
            Debug.Assert(pTree != null);
            Debug.Assert(pTree.getGameObject() != null);

            // always have a group
            Debug.Assert(pTree.getGameObject() != pNode);

            GameObject pParent = (GameObject)Iterator.GetParent(pNode);
            Debug.Assert(pParent != null);

            // remove the node
            pParent.remove(pNode);
        }
        public static void Update()
        {
            //ensure call Create() first
            GameObjectMan pMan = GameObjectMan.GetInstance();
            Debug.Assert(pMan != null);

            GameObjectNode pGameObjectNode = (GameObjectNode)pMan.baseGetActiveList();

            while (pGameObjectNode != null)
            {
                ReverseIterator pRev = new ReverseIterator(pGameObjectNode.getGameObject());

                Component pNode = pRev.first();
                while (!pRev.isDone())
                {
                    GameObject pGameObj = (GameObject)pNode;
                    pGameObj.update();

                    pNode = pRev.next();
                }

                pGameObjectNode = (GameObjectNode)pGameObjectNode.pNext;
            }
        }
        public static void Reset()
        {
            //ensure call Create() first
            GameObjectMan pMan = GameObjectMan.GetInstance();
            Debug.Assert(pMan != null);

            GameObjectNode pGameObjectNode = (GameObjectNode)pMan.baseGetActiveList();

            while (pGameObjectNode != null)
            {
                Component pGameObject = (Component)pGameObjectNode.getGameObject();
                while (pGameObject.holder == Component.Container.Composite)
                {
                    Composite pComposite = (Composite)pGameObject;

                    pGameObject = (Component)pComposite.poHead;
                    pComposite.poHead = null;
                    pComposite.poLast = null;
                    if (pGameObject == null || pGameObject.holder == Component.Container.Leaf) break;
                }

                pGameObjectNode = (GameObjectNode)pGameObjectNode.pNext;
            }

        }
        public static void Destory()
        {
            //ensure call Create() first
            GameObjectMan pMan = GameObjectMan.GetInstance();
            Debug.Assert(pMan != null);

            pMan.baseDestory();

            pMan.poNodeForCompare = null;
            pMan.poNullGameObject = null;
            GameObjectMan.pInstance = null;
        }
        //----------------------------------------------------------------------
        // Override Abstract methods
        //----------------------------------------------------------------------
        protected override bool derivedCompare(DLink pNodeA, DLink pNodeB)
        {
            Debug.Assert(pNodeA != null);
            Debug.Assert(pNodeB != null);

            GameObjectNode pDataA = (GameObjectNode)pNodeA;
            GameObjectNode pDataB = (GameObjectNode)pNodeB;

            return pDataA.getGameObject().getName() == pDataB.getGameObject().getName();
        }
        protected override DLink derivedCreateNode()
        {
            DLink pNode = new GameObjectNode();
            Debug.Assert(pNode != null);

            return pNode;
        }
        protected override void derivedReset(DLink pLink)
        {
            Debug.Assert(pLink != null);
            GameObjectNode pNode = (GameObjectNode)pLink;
            pNode.deepClear();
        }
        //----------------------------------------------------------------------
        // Private methods
        //----------------------------------------------------------------------
        private static GameObjectMan GetInstance()
        {
            Debug.Assert(pInstance != null);
            return pInstance;
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private static GameObjectMan pInstance = null;
        private GameObjectNode poNodeForCompare;
        private NullGameObject poNullGameObject;
    }
}
