using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldRoot : Composite
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public ShieldRoot(GameObject.Name name, GameSprite.Name spriteName, float posX, float posY)
            : base(name, spriteName)
        {
            this.x = posX;
            this.y = posY;
        }
        ~ShieldRoot()
        {

        }
        public void clearShield()
        {
            this.poHead = null;
            this.poLast = null;
            SpriteBatch pSB_shields = SpriteBatchMan.Find(SpriteBatch.Name.Shields);
            SpriteBatch pSB_shieldBoxes = SpriteBatchMan.Find(SpriteBatch.Name.ShieldBoxes);
            pSB_shields.deepClear();
            pSB_shieldBoxes.deepClear();
            this.activateGameSprite(pSB_shields);
            this.activateCollisionSprite(pSB_shieldBoxes);
        }
        public void storeShield()
        {
            ShieldFactory SF = new ShieldFactory(SpriteBatch.Name.Shields, SpriteBatch.Name.ShieldBoxes);

            GameObject pShieldGrid;
            GameObject pShieldColumn;

            float start_x = 60.0f;
            float start_y = 200.0f;
            float off_x = 0;
            float gap = 180.0f;
            float brickWidth = 10.0f;
            float brickHeight = 5.0f;

            // load by column
            for (int i = 0; i < 4; i++)
            {
                int j = 0;

                pShieldGrid = SF.Create(ShieldCategory.Type.Grid, GameObject.Name.ShieldGrid);

                // column 0
                pShieldColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);

                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.LeftTop1, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.LeftTop0, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight));

                pShieldGrid.add(pShieldColumn);

                // column 1
                pShieldColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                off_x += brickWidth;

                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight));

                pShieldGrid.add(pShieldColumn);

                // column 2
                pShieldColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                off_x += brickWidth;

                pShieldColumn.add(SF.Create(ShieldCategory.Type.LeftBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight));

                pShieldGrid.add(pShieldColumn);

                // column 3
                pShieldColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                off_x += brickWidth;

                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight));

                pShieldGrid.add(pShieldColumn);

                // column 4
                pShieldColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                off_x += brickWidth;

                pShieldColumn.add(SF.Create(ShieldCategory.Type.RightBottom, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight));

                pShieldGrid.add(pShieldColumn);

                // column 5
                pShieldColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                off_x += brickWidth;

                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 0 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 1 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight));

                pShieldGrid.add(pShieldColumn);

                // column 6
                pShieldColumn = SF.Create(ShieldCategory.Type.Column, GameObject.Name.ShieldColumn_0 + j++);
                off_x += brickWidth;

                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 0 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 1 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 2 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 3 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 4 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 5 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 6 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.Brick, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 7 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.RightTop1, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 8 * brickHeight));
                pShieldColumn.add(SF.Create(ShieldCategory.Type.RightTop0, GameObject.Name.ShieldBrick, start_x + off_x, start_y + 9 * brickHeight));

                pShieldGrid.add(pShieldColumn);

                // add grid to root
                this.add(pShieldGrid);
                off_x += gap;
            }
        }
        //---------------------------------------------------------------------------------------------------------
        // Override abstract methods
        //---------------------------------------------------------------------------------------------------------
        public override void accept(CollisionVisitor other)
        {
            other.visitShieldRoot(this);
        }
        public override void update()
        {
            base.BaseUpdateBoundingBox(this);
            base.update();
        }
        public override void visitMissileGroup(MissileGroup missileGroup)
        {
            // MissileGroup vs ShieldRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(missileGroup);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitMissile(Missile missile)
        {
            // Missile vs ShieldRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(missile, pGameObj);
        }
        public override void visitBombRoot(BombRoot bombRoot)
        {
            // BombRoot vs ShieldRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(bombRoot);
            CollisionPair.Collide(pGameObj, this);
        }
        public override void visitBomb(Bomb bomb)
        {
            // Bomb vs ShieldRoot
            GameObject pGameObj = (GameObject)Iterator.GetChild(this);
            CollisionPair.Collide(bomb, pGameObj);
        }
    }
}
