using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SpriteFactory
    {
        //-------------------------------------------------------------------------------
        // Methods
        //-------------------------------------------------------------------------------
        public void create(GameSprite.Name name, float width, float height, Azul.Color pColor)
        {
            switch (name)
            {
                case GameSprite.Name.Squid:
                    GameSpriteMan.Add(GameSprite.Name.Squid, Image.Name.Squid, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Crab:
                    GameSpriteMan.Add(GameSprite.Name.Crab, Image.Name.Crab, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Octopus:
                    GameSpriteMan.Add(GameSprite.Name.Octopus, Image.Name.Octopus, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Missile:
                    GameSpriteMan.Add(GameSprite.Name.Missile, Image.Name.Missile, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Ship:
                    GameSpriteMan.Add(GameSprite.Name.Ship, Image.Name.Ship, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Brick:
                    GameSpriteMan.Add(GameSprite.Name.Brick, Image.Name.Brick, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Brick_LeftTop0:
                    GameSpriteMan.Add(GameSprite.Name.Brick_LeftTop0, Image.Name.BrickLeft_Top0, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Brick_LeftTop1:
                    GameSpriteMan.Add(GameSprite.Name.Brick_LeftTop1, Image.Name.BrickLeft_Top1, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Brick_LeftBottom:
                    GameSpriteMan.Add(GameSprite.Name.Brick_LeftBottom, Image.Name.BrickLeft_Bottom, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Brick_RightTop0:
                    GameSpriteMan.Add(GameSprite.Name.Brick_RightTop0, Image.Name.BrickRight_Top0, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Brick_RightTop1:
                    GameSpriteMan.Add(GameSprite.Name.Brick_RightTop1, Image.Name.BrickRight_Top1, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Brick_RightBottom:
                    GameSpriteMan.Add(GameSprite.Name.Brick_RightBottom, Image.Name.BrickRight_Bottom, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.BombZigZag:
                    GameSpriteMan.Add(GameSprite.Name.BombZigZag, Image.Name.BombZigZag, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.BombStraight:
                    GameSpriteMan.Add(GameSprite.Name.BombStraight, Image.Name.BombStraight, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.BombDagger:
                    GameSpriteMan.Add(GameSprite.Name.BombDagger, Image.Name.BombCross, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Ship_Explosion1:
                    GameSpriteMan.Add(GameSprite.Name.Ship_Explosion1, Image.Name.Ship_Explosion1, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Ship_Explosion2:
                    GameSpriteMan.Add(GameSprite.Name.Ship_Explosion2, Image.Name.Ship_Explosion2, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Missile_Explosion:
                    GameSpriteMan.Add(GameSprite.Name.Missile_Explosion, Image.Name.Missile_Explosion, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Alien_Explosion:
                    GameSpriteMan.Add(GameSprite.Name.Alien_Explosion, Image.Name.Alien_Explosion, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.UFO_Explosion:
                    GameSpriteMan.Add(GameSprite.Name.UFO_Explosion, Image.Name.UFO_Explosion, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.Bomb_Explosion:
                    GameSpriteMan.Add(GameSprite.Name.Bomb_Explosion, Image.Name.Bomb_Explosion, 0, 0, width, height, pColor);
                    break;
                case GameSprite.Name.UFO:
                    GameSpriteMan.Add(GameSprite.Name.UFO, Image.Name.UFO, 0, 0, width, height, pColor);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }
    }
}
