using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameScene : SceneState
    {
        public override void handle(Scene pScene)
        {
            throw new NotImplementedException();
        }
        public override void loadContent(Scene pScene)
        {
            ManagerFactory managerFactory = new ManagerFactory();

            //---------------------------------------------------------------------------------------------------------
            // Create SpriteBatch
            //---------------------------------------------------------------------------------------------------------
            SpriteBatch pSB_Box = SpriteBatchMan.Add(SpriteBatch.Name.Boxes);
            SpriteBatch pSB_ShieldBoxes = SpriteBatchMan.Add(SpriteBatch.Name.ShieldBoxes);
            SpriteBatchMan.Add(SpriteBatch.Name.Aliens);
            SpriteBatchMan.Add(SpriteBatch.Name.Walls);
            SpriteBatchMan.Add(SpriteBatch.Name.Bumps);
            SpriteBatch pSB_Ship = SpriteBatchMan.Add(SpriteBatch.Name.Ships);
            SpriteBatch pSB_Missile = SpriteBatchMan.Add(SpriteBatch.Name.Missiles);
            SpriteBatch pSB_Shield = SpriteBatchMan.Add(SpriteBatch.Name.Shields);
            SpriteBatch pSB_Bomb = SpriteBatchMan.Add(SpriteBatch.Name.Bombs);
            SpriteBatchMan.Add(SpriteBatch.Name.PlainTexts);
            SpriteBatch pSB_Life = SpriteBatchMan.Add(SpriteBatch.Name.Lifes);
            SpriteBatch pSB_Explosion = SpriteBatchMan.Add(SpriteBatch.Name.Explosions);
            SpriteBatch pSB_UFO = SpriteBatchMan.Add(SpriteBatch.Name.UFO);

            //---------------------------------------------------------------------------------------------------------
            // Set Input
            //---------------------------------------------------------------------------------------------------------
            InputSubject pInputSubject;
            pInputSubject = InputMan.GetArrowLeftSubject();
            pInputSubject.attach(new MoveLeftObserver());

            pInputSubject = InputMan.GetArrowRightSubject();
            pInputSubject.attach(new MoveRightObserver());

            pInputSubject = InputMan.GetSpaceSubject();
            pInputSubject.attach(new ShootObserver());

            pInputSubject = InputMan.GetTSubject();
            pInputSubject.attach(new ToggleBoxObserver());

            //---------------------------------------------------------------------------------------------------------
            // Create Ship
            //---------------------------------------------------------------------------------------------------------
            // create ship life group
            ShipLifeGroup pShipLifeGroup = new ShipLifeGroup(GameObject.Name.ShipLifeGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pShipLifeGroup.activateGameSprite(pSB_Life);
            pShipLifeGroup.activateCollisionSprite(pSB_Box);
            GameObjectMan.Attach(pShipLifeGroup);

            ShipGroup pShipGroup = new ShipGroup(GameObject.Name.ShipGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pShipGroup.activateGameSprite(pSB_Ship);
            pShipGroup.activateCollisionSprite(pSB_Box);

            GameObjectMan.Attach(pShipGroup);

            ShipMan.CreateShipLifes();
            

            //---------------------------------------------------------------------------------------------------------
            // Create UFO
            //---------------------------------------------------------------------------------------------------------
            UFORoot pUFORoot = new UFORoot(GameObject.Name.UFORoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            UFORoot pUFOGroup = new UFORoot(GameObject.Name.UFORoot, GameSprite.Name.NullObject, 0.0f, 0.0f);

            pUFORoot.activateGameSprite(pSB_UFO);
            pUFORoot.activateCollisionSprite(pSB_Box);

            pUFOGroup.add(pUFORoot);
            GameObjectMan.Attach(pUFOGroup);

            //managerFactory.create(Manager.Name.UFOMan);


            //---------------------------------------------------------------------------------------------------------
            // Create Missile
            //---------------------------------------------------------------------------------------------------------
            MissileGroup pMissileGroup = new MissileGroup(GameObject.Name.MissileGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pMissileGroup.activateGameSprite(pSB_Missile);
            pMissileGroup.activateCollisionSprite(pSB_Box);

            GameObjectMan.Attach(pMissileGroup);

            //---------------------------------------------------------------------------------------------------------
            // Create Bombs
            //---------------------------------------------------------------------------------------------------------
            BombRoot pBombRoot = new BombRoot(GameObject.Name.BombGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pBombRoot.activateGameSprite(pSB_Bomb);
            pBombRoot.activateCollisionSprite(pSB_Box);

            GameObjectMan.Attach(pBombRoot);
            //managerFactory.create(Manager.Name.BombMan);

            //---------------------------------------------------------------------------------------------------------
            // Create walls
            //---------------------------------------------------------------------------------------------------------
            WallFactory wallFactory = new WallFactory(SpriteBatch.Name.Walls, SpriteBatch.Name.Boxes);

            GameObject pWallGroup = wallFactory.create(GameObject.Name.WallGroup, WallCategory.Type.WallGroup);

            pWallGroup.add(wallFactory.create(GameObject.Name.WallLeft, WallCategory.Type.Left, 5, 511, 10, 912));
            pWallGroup.add(wallFactory.create(GameObject.Name.WallRight, WallCategory.Type.Right, 891, 511, 10, 912));
            pWallGroup.add(wallFactory.create(GameObject.Name.WallTop, WallCategory.Type.Top, 448, 993, 896, 50));
            pWallGroup.add(wallFactory.create(GameObject.Name.WallBottom, WallCategory.Type.Bottom, 448, 30, 896, 50));

            GameObjectMan.Attach(pWallGroup);

            //---------------------------------------------------------------------------------------------------------
            // Create bumps
            //---------------------------------------------------------------------------------------------------------
            BumpFactory bumpFactory = new BumpFactory(SpriteBatch.Name.Bumps, SpriteBatch.Name.Boxes);

            GameObject pBumpGroup = bumpFactory.create(GameObject.Name.BumpGroup, BumpCategory.Type.BumpGroup);

            pBumpGroup.add(bumpFactory.create(GameObject.Name.BumpLeft, BumpCategory.Type.Left, 10, 90, 25, 60));
            pBumpGroup.add(bumpFactory.create(GameObject.Name.BumpRight, BumpCategory.Type.Right, 886, 90, 25, 60));

            GameObjectMan.Attach(pBumpGroup);

            //---------------------------------------------------------------------------------------------------------
            // Create Aliens
            //---------------------------------------------------------------------------------------------------------
            //managerFactory.create(Manager.Name.AlienMan);

            AlienFactory alienFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.Boxes);

            // create alien groups
            AlienGroup pAlienGroup = (AlienGroup)alienFactory.create(GameObject.Name.AlienGroup, AlienCategory.Type.Group);
            pAlienGroup.nextLevel();

            AlienGroup pAlienRoot = new AlienGroup(GameObject.Name.AlienGroup, GameSprite.Name.NullObject, 0.0f, 0.0f); ;
            pAlienRoot.add(pAlienGroup);
            GameObjectMan.Attach(pAlienRoot);

            //---------------------------------------------------------------------------------------------------------
            // create Shield 
            //---------------------------------------------------------------------------------------------------------
            ShieldFactory SF = new ShieldFactory(SpriteBatch.Name.Shields, SpriteBatch.Name.ShieldBoxes);

            ShieldRoot pShieldGroup = (ShieldRoot)SF.Create(ShieldCategory.Type.Root, GameObject.Name.ShieldRoot, 0.0f, 0.0f);
            pShieldGroup.storeShield();

            ShieldRoot pShieldRoot = new ShieldRoot(GameObject.Name.ShieldRoot, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pShieldRoot.add(pShieldGroup);
            GameObjectMan.Attach(pShieldRoot);
            

            //---------------------------------------------------------------------------------------------------------
            // Create explosion group
            //---------------------------------------------------------------------------------------------------------
            ExplosionGroup pExplosionGroup = new ExplosionGroup(GameObject.Name.ExplosionGroup, GameSprite.Name.NullObject, 0.0f, 0.0f);
            pExplosionGroup.activateGameSprite(pSB_Explosion);
            pExplosionGroup.activateCollisionSprite(pSB_Box);

            GameObjectMan.Attach(pExplosionGroup);

            //---------------------------------------------------------------------------------------------------------
            // Attach sprites to Sprite Batch
            //---------------------------------------------------------------------------------------------------------
            //pSB_Boxes.attach(BoxSprite.Name.Box1);

            // Create animation sprites
            AnimationSprite pAnimOctopus = new AnimationSprite(GameSprite.Name.Octopus);
            pAnimOctopus.attach(Image.Name.OctopusMovement);
            pAnimOctopus.attach(Image.Name.Octopus);
            pAnimOctopus.attach("fastinvader1.wav");
            pAnimOctopus.attach("fastinvader2.wav");
            pAnimOctopus.attach("fastinvader3.wav");
            pAnimOctopus.attach("fastinvader4.wav");
            TimerMan.Add(TimeEvent.Name.OctopusAnimation, pAnimOctopus, 0.75f);

            AnimationSprite pAnimCrab = new AnimationSprite(GameSprite.Name.Crab);
            pAnimCrab.attach(Image.Name.CrabMovement);
            pAnimCrab.attach(Image.Name.Crab);
            pAnimCrab.attach("fastinvader1.wav");
            pAnimCrab.attach("fastinvader2.wav");
            pAnimCrab.attach("fastinvader3.wav");
            pAnimCrab.attach("fastinvader4.wav");
            TimerMan.Add(TimeEvent.Name.CrabAnimation, pAnimCrab, 0.75f);

            AnimationSprite pAminSquid = new AnimationSprite(GameSprite.Name.Squid);
            pAminSquid.attach(Image.Name.SquidMovement);
            pAminSquid.attach(Image.Name.Squid);
            pAminSquid.attach("fastinvader1.wav");
            pAminSquid.attach("fastinvader2.wav");
            pAminSquid.attach("fastinvader3.wav");
            pAminSquid.attach("fastinvader4.wav");
            TimerMan.Add(TimeEvent.Name.SquidAnimation, pAminSquid, 0.75f);

            // Create Movement sprite
            MovementSprite pMovementSprite = new MovementSprite(pAlienGroup);
            TimerMan.Add(TimeEvent.Name.MovementAnimation, pMovementSprite, 0.5f);

            // Create drop bomb sprite
            DropBomb pDropBomb = new DropBomb(pAlienGroup);
            TimerMan.Add(TimeEvent.Name.DropBombAnination, pDropBomb, 1.5f);

            // Create UFOEvent sprite
            UFOEvent pUFOEvent = new UFOEvent();
            TimerMan.Add(TimeEvent.Name.MovementAnimation, pUFOEvent, UFOMan.getDeltaTime());

            //---------------------------------------------------------------------------------------------------------
            // Collision Pair 
            //---------------------------------------------------------------------------------------------------------
            CollisionPair pColPair = CollisionPairMan.Add(CollisionPair.Name.Alien_Missile, pMissileGroup, pAlienGroup);
            Debug.Assert(pColPair != null);
            pColPair.attach(new RemoveAlienObserver());
            pColPair.attach(new PlaySoundObserver("invaderkilled.wav"));
            pColPair.attach(new AlienNumObserver(pAlienGroup, pShieldGroup));
            pColPair.attach(new RemoveMissileObserver());
            pColPair.attach(new ShipReadyObserver());

            pColPair = CollisionPairMan.Add(CollisionPair.Name.Missile_Wall, pMissileGroup, pWallGroup);
            Debug.Assert(pColPair != null);
            pColPair.attach(new RemoveMissileObserver());
            pColPair.attach(new ShipReadyObserver());

            pColPair = CollisionPairMan.Add(CollisionPair.Name.Alien_Wall, pAlienGroup, pWallGroup);
            Debug.Assert(pColPair != null);
            pColPair.attach(new AlienGroupObserver());

            pColPair = CollisionPairMan.Add(CollisionPair.Name.Ship_Bump, pBumpGroup, pShipGroup);
            Debug.Assert(pColPair != null);
            pColPair.attach(new ShipPositionObserver());

            pColPair = CollisionPairMan.Add(CollisionPair.Name.Missile_Shield, pMissileGroup, pShieldRoot);
            Debug.Assert(pColPair != null);
            pColPair.attach(new RemoveShieldObserver(GameObject.Name.Missile));
            pColPair.attach(new PlaySoundObserver("invaderkilled.wav"));
            pColPair.attach(new RemoveMissileObserver());
            pColPair.attach(new ShipReadyObserver());

            pColPair = CollisionPairMan.Add(CollisionPair.Name.Bomb_Shield, pBombRoot, pShieldRoot);
            Debug.Assert(pColPair != null);
            pColPair.attach(new RemoveShieldObserver(GameObject.Name.Bomb));
            pColPair.attach(new PlaySoundObserver("invaderkilled.wav"));
            pColPair.attach(new RemoveBombObserver());
            pColPair.attach(new AlienReadyObserver());

            pColPair = CollisionPairMan.Add(CollisionPair.Name.Bomb_Wall, pBombRoot, pWallGroup);
            Debug.Assert(pColPair != null);
            pColPair.attach(new RemoveBombObserver());
            pColPair.attach(new AlienReadyObserver());

            pColPair = CollisionPairMan.Add(CollisionPair.Name.Bomb_Missile, pBombRoot, pMissileGroup);
            Debug.Assert(pColPair != null);
            pColPair.attach(new BombExplosionObsever());
            pColPair.attach(new AlienReadyObserver());
            pColPair.attach(new RemoveMissileObserver());
            pColPair.attach(new ShipReadyObserver());

            pColPair = CollisionPairMan.Add(CollisionPair.Name.Bomb_Ship, pShipGroup, pBombRoot);
            Debug.Assert(pColPair != null);
            pColPair.attach(new RemoveBombObserver());
            pColPair.attach(new AlienReadyObserver());
            pColPair.attach(new RemoveShipObserver());
            pColPair.attach(new PlaySoundObserver("explosion.wav"));

            pColPair = CollisionPairMan.Add(CollisionPair.Name.UFO_Wall, pWallGroup, pUFORoot);
            Debug.Assert(pColPair != null);
            pColPair.attach(new RemoveUFOObserver());

            pColPair = CollisionPairMan.Add(CollisionPair.Name.UFO_Missile, pMissileGroup, pUFORoot);
            Debug.Assert(pColPair != null);
            pColPair.attach(new RemoveMissileObserver());
            pColPair.attach(new ShipReadyObserver());
            pColPair.attach(new UFOExplosionObserver());
            pColPair.attach(new PlaySoundObserver("explosion.wav"));

            //---------------------------------------------------------------------------------------------------------
            // Font
            //---------------------------------------------------------------------------------------------------------
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.PlainTexts, "SCORE<1>", Glyph.Name.Consolas36pt, 20, 1000);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.PlainTexts, "HI-SCORE", Glyph.Name.Consolas36pt, 370, 1000);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.PlainTexts, "SCORE<2>", Glyph.Name.Consolas36pt, 700, 1000);
            FontMan.Add(Font.Name.ScoreOne, SpriteBatch.Name.PlainTexts, pScene.getScoreOne().ToString("D4"), Glyph.Name.Consolas36pt, 50, 960);
            FontMan.Add(Font.Name.HighestScore, SpriteBatch.Name.PlainTexts, pScene.getHighestScore().ToString("D4"), Glyph.Name.Consolas36pt, 400, 960);
            FontMan.Add(Font.Name.ScoreTwo, SpriteBatch.Name.PlainTexts, pScene.getScoreTwo().ToString("D4"), Glyph.Name.Consolas36pt, 730, 960);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.PlainTexts, "CREDIT", Glyph.Name.Consolas36pt, 700, 25);
            FontMan.Add(Font.Name.Texts, SpriteBatch.Name.PlainTexts, "00", Glyph.Name.Consolas36pt, 830, 25);
        }
        public override void update(Scene pScene, float currTime)
        {
            // Add your update below this line: ----------------------------
            SoundMan.Update();

            InputMan.Update();

            TimerMan.Update(currTime);
            GameObjectMan.Update();

            // check collision
            CollisionPairMan.Process();

            // Delete any objects here...
            DelayedObjectMan.Process();
        }
        public override void draw(Scene pScene)
        {
            // draw all objects
            SpriteBatchMan.Draw();
        }
        public override void unLoadContent(Scene pScene)
        {
            GameObjectMan.Reset();
            TimerMan.Reset();
            InputMan.Reset();
            CollisionPairMan.Reset();
            SpriteBatchMan.Reset();
            BoxSpriteMan.Reset();
            ProxySpriteMan.Reset();
            UFOMan.Reset();
            ShipMan.Reset();
        }
    }
}
