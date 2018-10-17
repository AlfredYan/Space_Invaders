using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class CollisionPair_Link : DLink
    {

    }
    public class CollisionPair : CollisionPair_Link
    {
        //----------------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------------
        public enum Name
        {
            Alien_Missile,
            Missile_Wall,
            Alien_Wall,
            Ship_Bump,
            Missile_Shield,
            Bomb_Shield,
            Bomb_Wall,
            Bomb_Missile,
            Bomb_Ship,
            UFO_Wall,
            UFO_Missile,

            NullObject,
            Uninitialized
        }
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        public CollisionPair()
            : base()
        {
            this.pTreeA = null;
            this.pTreeB = null;
            this.name = CollisionPair.Name.Uninitialized;

            this.poSubject = new CollisionSubject();
            Debug.Assert(this.poSubject != null);
        }
        ~CollisionPair()
        {

        }
        //----------------------------------------------------------------------
        // Static methods
        //----------------------------------------------------------------------
        public static void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
            // treeA vs treeB
            GameObject pNodeA = pSafeTreeA;
            GameObject pNodeB = pSafeTreeB;

            while(pNodeA != null)
            {
                // restart compare
                pNodeB = pSafeTreeB;

                while(pNodeB != null)
                {
                    //Debug.WriteLine("ColPair:    test:  {0}, {1}", pNodeA.getName(), pNodeB.getName());

                    // get rectangles
                    CollisionRect rectA = pNodeA.poCollisionObject.poCollisionRect;
                    CollisionRect rectB = pNodeB.poCollisionObject.poCollisionRect;

                    if(CollisionRect.Intersect(rectA, rectB))
                    {
                        // when rectA and rectB are intersected
                        pNodeA.accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)Iterator.GetSibling(pNodeB);
                }

                pNodeA = (GameObject)Iterator.GetSibling(pNodeA);
            }
        }
        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        public void set(CollisionPair.Name colPairName, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            Debug.Assert(pTreeRootA != null);
            Debug.Assert(pTreeRootB != null);

            this.pTreeA = pTreeRootA;
            this.pTreeB = pTreeRootB;
            this.name = colPairName;
        }
        public void attach(CollisionObserver observer)
        {
            this.poSubject.attach(observer);
        }
        public void notifyListeners()
        {
            this.poSubject.notify();
        }
        public void setCollision(GameObject pObjA, GameObject pObjB)
        {
            Debug.Assert(pObjA != null);
            Debug.Assert(pObjB != null);

            // GameObject pAlien = AlienCategory.GetAlien(objA, objB);
            this.poSubject.pObjA = pObjA;
            this.poSubject.pObjB = pObjB;
        }
        public void deepClean()
        {
            this.pTreeA = null;
            this.pTreeB = null;
            this.name = CollisionPair.Name.Uninitialized;
        }
        public CollisionPair.Name getName()
        {
            return this.name;
        }
        public void process()
        {
            Collide(this.pTreeA, this.pTreeB);
        }
        public void setName(CollisionPair.Name name)
        {
            this.name = name;
        }
        //----------------------------------------------------------------------
        // Data
        //----------------------------------------------------------------------
        private CollisionPair.Name name;
        public GameObject pTreeA;
        public GameObject pTreeB;
        public CollisionSubject poSubject;
    }
}
