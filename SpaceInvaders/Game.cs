using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {
        // fields

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Kaicheng Yan");
            this.SetWidthHeight(896, 1024);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //---------------------------------------------------------------------------------------------------------
            // Manager initialization
            //---------------------------------------------------------------------------------------------------------
            ManagerFactory managerFactory = new ManagerFactory();
            managerFactory.create(Manager.Name.SceneMan);
            managerFactory.create(Manager.Name.TextureMan);
            managerFactory.create(Manager.Name.ImageMan);
            managerFactory.create(Manager.Name.GameSpriteMan);
            managerFactory.create(Manager.Name.BoxSpriteMan);
            managerFactory.create(Manager.Name.SpriteBatchMan);
            managerFactory.create(Manager.Name.TimerMan);
            managerFactory.create(Manager.Name.ProxySpriteMan, 10, 1);
            managerFactory.create(Manager.Name.GameObjectMan);
            managerFactory.create(Manager.Name.CollisionPairMan);
            managerFactory.create(Manager.Name.SoundMan);
            managerFactory.create(Manager.Name.GlyphMan);
            managerFactory.create(Manager.Name.FontMan);
            managerFactory.create(Manager.Name.UFOMan);
            managerFactory.create(Manager.Name.BombMan);
            managerFactory.create(Manager.Name.AlienMan);
            managerFactory.create(Manager.Name.ShipMan);

            //---------------------------------------------------------------------------------------------------------
            // Load the Textures
            //---------------------------------------------------------------------------------------------------------
            TextureFactory textureFactory = new TextureFactory();
            textureFactory.create(Texture.Name.SpaceInvaders, "SpaceInvaders.tga");
            textureFactory.create(Texture.Name.Shields, "Birds_N_Shield.tga");
            textureFactory.create(Texture.Name.Consolas36pt, "Consolas36pt.tga");

            FontMan.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas36pt);

            //---------------------------------------------------------------------------------------------------------
            // Create Images
            //---------------------------------------------------------------------------------------------------------
            ImageFactory imageFactory = new ImageFactory();

            imageFactory.create(Image.Name.Octopus);
            imageFactory.create(Image.Name.OctopusMovement);
            imageFactory.create(Image.Name.Crab);
            imageFactory.create(Image.Name.CrabMovement);
            imageFactory.create(Image.Name.Squid);
            imageFactory.create(Image.Name.SquidMovement);
            imageFactory.create(Image.Name.Missile);
            imageFactory.create(Image.Name.Ship);
            imageFactory.create(Image.Name.Brick);
            imageFactory.create(Image.Name.BrickLeft_Top0);
            imageFactory.create(Image.Name.BrickLeft_Top1);
            imageFactory.create(Image.Name.BrickLeft_Bottom);
            imageFactory.create(Image.Name.BrickRight_Top0);
            imageFactory.create(Image.Name.BrickRight_Top1);
            imageFactory.create(Image.Name.BrickRight_Bottom);
            imageFactory.create(Image.Name.BombStraight);
            imageFactory.create(Image.Name.BombZigZag);
            imageFactory.create(Image.Name.BombCross);
            imageFactory.create(Image.Name.Ship_Explosion1);
            imageFactory.create(Image.Name.Ship_Explosion2);
            imageFactory.create(Image.Name.Missile_Explosion);
            imageFactory.create(Image.Name.Alien_Explosion);
            imageFactory.create(Image.Name.UFO_Explosion);
            imageFactory.create(Image.Name.Bomb_Explosion);
            imageFactory.create(Image.Name.UFO);

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------
            SpriteFactory spriteFactory = new SpriteFactory();

            spriteFactory.create(GameSprite.Name.Squid, 40, 40, new Azul.Color(1, 1, 1));
            spriteFactory.create(GameSprite.Name.Crab, 40, 40, new Azul.Color(1, 1, 1));
            spriteFactory.create(GameSprite.Name.Octopus, 40, 40, new Azul.Color(1, 1, 1));
            spriteFactory.create(GameSprite.Name.Missile, 5, 25, new Azul.Color(1, 1, 1));
            spriteFactory.create(GameSprite.Name.Ship, 50, 25, new Azul.Color(1, 0, 1));

            spriteFactory.create(GameSprite.Name.Brick, 10, 10, new Azul.Color(0, 1, 0));
            spriteFactory.create(GameSprite.Name.Brick_LeftTop0, 10, 10, new Azul.Color(0, 1, 0));
            spriteFactory.create(GameSprite.Name.Brick_LeftTop1, 10, 10, new Azul.Color(0, 1, 0));
            spriteFactory.create(GameSprite.Name.Brick_LeftBottom, 10, 10, new Azul.Color(0, 1, 0));
            spriteFactory.create(GameSprite.Name.Brick_RightTop0, 10, 10, new Azul.Color(0, 1, 0));
            spriteFactory.create(GameSprite.Name.Brick_RightTop1, 10, 10, new Azul.Color(0, 1, 0));
            spriteFactory.create(GameSprite.Name.Brick_RightBottom, 10, 10, new Azul.Color(0, 1, 0));

            spriteFactory.create(GameSprite.Name.BombZigZag, 8, 32, new Azul.Color(1, 1, 0));
            spriteFactory.create(GameSprite.Name.BombStraight, 8, 32, new Azul.Color(1, 1, 0));
            spriteFactory.create(GameSprite.Name.BombDagger, 8, 32, new Azul.Color(1, 1, 0));


            spriteFactory.create(GameSprite.Name.Ship_Explosion1, 50, 25, new Azul.Color(1, 0, 1));
            spriteFactory.create(GameSprite.Name.Ship_Explosion2, 50, 25, new Azul.Color(1, 0, 1));
            spriteFactory.create(GameSprite.Name.Missile_Explosion, 10, 10, new Azul.Color(0, 1, 0));
            spriteFactory.create(GameSprite.Name.Alien_Explosion, 40, 40, new Azul.Color(1, 1, 1));
            spriteFactory.create(GameSprite.Name.UFO_Explosion, 50, 30, new Azul.Color(1, 0, 1));
            spriteFactory.create(GameSprite.Name.Bomb_Explosion, 8, 32, new Azul.Color(1, 0, 1));

            spriteFactory.create(GameSprite.Name.UFO, 50, 30, new Azul.Color(1, 0, 1));

            SceneMan.GetScene().loadContent();
        }

        //-----------------------------------------------------------------------------
        // Game::Update() 
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            SceneMan.GetScene().update(this.GetTime());
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            SceneMan.GetScene().draw();

        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            GameObjectMan.Destory();
            ProxySpriteMan.Destory();
            TimerMan.Destory();
            SpriteBatchMan.Destory();
            GameSpriteMan.Destory();
            BoxSpriteMan.Destory();
            ImageMan.Destory();
            TextureMan.Destory();
        }

    }
}

