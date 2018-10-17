using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGroup : Composite
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public AlienGroup(Name gameObjName, GameSprite.Name spriteName, float posX, float posY) 
            : base(gameObjName, spriteName)
        {
            this.x = posX;
            this.y = posY;

            this.poCollisionObject.pCollisionSprite.setLineColor(0, 0, 1);

            this.deltaX = 10.0f;
            this.deltaY = -50.0f;
            this.speedUp = 5.0f;
            this.level = 0;
            this.goingDown = false;
            this.moveForward = true;
            this.randNum = new Random();
        }
        ~AlienGroup()
        {
            this.randNum = null;
        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------------------------------------------------------
        public override void update()
        {

            base.BaseUpdateBoundingBox(this);

            // update after all set
            base.update();
        }
        public override void accept(CollisionVisitor other)
        {
            other.visitAlienGroup(this);
        }
        public override void visitMissileGroup(MissileGroup missileGroup)
        {
            // alien group vs missile group
            //Debug.WriteLine("         collide:  {0} <-> {1}", missileGroup.getName(), this.getName());

            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(missileGroup, pGameObj);
        }
        public override void visitWallGroup(WallGroup wallGroup)
        {
            // MissileGroup vs WallGroup
            GameObject pGameObj = (GameObject)Iterator.GetChild(wallGroup);
            CollisionPair.Collide(this, pGameObj);
        }
        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void MoveGrid()
        {
            ForwardIterator pFor = new ForwardIterator(this);
            float currSpeed = this.deltaX;
            if (this.moveForward == false)
                currSpeed *= -1;

            Component pNode = pFor.first();
            if (this.goingDown)
            {
                while (!pFor.isDone())
                {
                    GameObject pGameObj = (GameObject)pNode;
                    pGameObj.x += currSpeed;
                    pGameObj.y += this.deltaY;

                    pNode = pFor.next();
                }
                this.goingDown = false;
            }
            else
            {
                while (!pFor.isDone())
                {
                    GameObject pGameObj = (GameObject)pNode;
                    pGameObj.x += currSpeed;

                    pNode = pFor.next();
                }
            }
        }
        public void dropBomb()
        {
             AlienColumn pAlienColumn = (AlienColumn)this.poHead;

            while(pAlienColumn != null)
            {
                if(this.randNum.Next(10) >= 10-this.level)
                {
                    AlienCategory pAlien = (AlienCategory)pAlienColumn.poHead;

                    if (pAlien != null)
                    {
                        // get last alien of column
                        while (pAlien.pNext != null)
                        {
                            pAlien = (AlienCategory)pAlien.pNext;
                        }

                        pAlien.dropBomb();

                    }
                }

                pAlienColumn = (AlienColumn)pAlienColumn.pNext;

            }
        }
        public void nextLevel()
        {
            this.level++;
            GameObject pGameObjCol;

            // store columns
            GameObject.Name[] columns = {GameObject.Name.AlienColumn_0, GameObject.Name.AlienColumn_1,
                                        GameObject.Name.AlienColumn_2, GameObject.Name.AlienColumn_3,
                                        GameObject.Name.AlienColumn_4, GameObject.Name.AlienColumn_5,
                                        GameObject.Name.AlienColumn_6, GameObject.Name.AlienColumn_7,
                                        GameObject.Name.AlienColumn_8, GameObject.Name.AlienColumn_9,
                                        GameObject.Name.AlienColumn_10};

            AlienFactory alienFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);

            for (int i = 0; i < 11; i++)
            {

                // create column and add to column composite
                pGameObjCol = alienFactory.create(columns[i], AlienCategory.Type.Column);

                // add children to children composite
                pGameObjCol.add(alienFactory.create(GameObject.Name.Squid, AlienCategory.Type.Squid, 80.0f + 40 * i, 850.0f));
                pGameObjCol.add(alienFactory.create(GameObject.Name.Crab, AlienCategory.Type.Crab, 80.0f + 40 * i, 800.0f));
                pGameObjCol.add(alienFactory.create(GameObject.Name.Crab, AlienCategory.Type.Crab, 80.0f + 40 * i, 750.0f));
                pGameObjCol.add(alienFactory.create(GameObject.Name.Octopus, AlienCategory.Type.Octopus, 80.0f + 40 * i, 700.0f));
                pGameObjCol.add(alienFactory.create(GameObject.Name.Octopus, AlienCategory.Type.Octopus, 80.0f + 40 * i, 650.0f));

                // add column to alien group composite
                this.add(pGameObjCol);
            }

            if(level > 1)
            {
                this.deltaX = 10 * (level - 1);
                this.deltaX += this.speedUp;
                this.goingDown = false;
                this.moveForward = true;

                TimeEvent pTimeEvent = TimerMan.Find(TimeEvent.Name.SquidAnimation);
                pTimeEvent.setDeltaTime(0.75f);

                pTimeEvent = TimerMan.Find(TimeEvent.Name.OctopusAnimation);
                pTimeEvent.setDeltaTime(0.75f);

                pTimeEvent = TimerMan.Find(TimeEvent.Name.CrabAnimation);
                pTimeEvent.setDeltaTime(0.75f);
            }
            
        }
        public void addDifficult()
        {
            TimeEvent pTimeEvent = TimerMan.Find(TimeEvent.Name.SquidAnimation);
            float currDelta = pTimeEvent.getDeltaTime();
            pTimeEvent.setDeltaTime(currDelta - 0.15f);

            pTimeEvent = TimerMan.Find(TimeEvent.Name.OctopusAnimation);
            currDelta = pTimeEvent.getDeltaTime();
            pTimeEvent.setDeltaTime(currDelta - 0.15f);

            pTimeEvent = TimerMan.Find(TimeEvent.Name.CrabAnimation);
            currDelta = pTimeEvent.getDeltaTime();
            pTimeEvent.setDeltaTime(currDelta - 0.15f);

            this.deltaX++;
        }
        public float getDeltaX()
        {
            return this.deltaX;
        }
        public void setDeltaX(float deltaX)
        {
            this.deltaX = deltaX;
        }
        public void setGoingDown(bool goingDown)
        {
            this.goingDown = goingDown;
        }
        public bool getMoveForward()
        {
            return this.moveForward;
        }
        public void setMoveForward(bool moveForward)
        {
            this.moveForward = moveForward;
        }
        //---------------------------------------------------------------------------------------------------------
        // Data
        //---------------------------------------------------------------------------------------------------------
        private float deltaX;
        private float deltaY;
        private bool goingDown;
        private Random randNum;
        private float speedUp;
        public bool moveForward;
        public int level;
    }
}
