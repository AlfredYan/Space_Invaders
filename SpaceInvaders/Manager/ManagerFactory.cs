using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ManagerFactory
    {
        //-------------------------------------------------------------------------------
        // Methods
        //-------------------------------------------------------------------------------
        public void create(Manager.Name managerName, int reserveNum = 3, int growNum = 1)
        {
            switch (managerName)
            {
                case Manager.Name.TextureMan:
                    TextureMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.ImageMan:
                    ImageMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.GameSpriteMan:
                    GameSpriteMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.BoxSpriteMan:
                    BoxSpriteMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.SpriteBatchMan:
                    SpriteBatchMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.TimerMan:
                    TimerMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.ProxySpriteMan:
                    ProxySpriteMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.GameObjectMan:
                    GameObjectMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.CollisionPairMan:
                    CollisionPairMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.GlyphMan:
                    GlyphMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.FontMan:
                    FontMan.Create(reserveNum, growNum);
                    break;
                case Manager.Name.ShipMan:
                    ShipMan.Create();
                    break;
                case Manager.Name.BombMan:
                    BombMan.Create();
                    break;
                case Manager.Name.SoundMan:
                    SoundMan.Create();
                    break;
                case Manager.Name.AlienMan:
                    AlienMan.Create();
                    break;
                case Manager.Name.UFOMan:
                    UFOMan.Create();
                    break;
                case Manager.Name.SceneMan:
                    SceneMan.Create();
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }
    }
}
