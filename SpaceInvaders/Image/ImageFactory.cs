using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ImageFactory
    {
        //-------------------------------------------------------------------------------
        // Methods
        //-------------------------------------------------------------------------------
        public void create(Image.Name imageName)
        {
            switch (imageName)
            {
                case Image.Name.Octopus:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 14.0f, 15.0f, 250.0f, 135.0f);
                    break;
                case Image.Name.OctopusMovement:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 14.0f, 168.0f, 250.0f, 135.0f);
                    break;
                case Image.Name.Crab:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 282.0f, 15.0f, 250.0f, 135.0f);
                    break;
                case Image.Name.CrabMovement:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 282.0f, 168.0f, 250.0f, 135.0f);
                    break;
                case Image.Name.Squid:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 547.0f, 15.0f, 250.0f, 135.0f);
                    break;
                case Image.Name.SquidMovement:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 547.0f, 168.0f, 250.0f, 135.0f);
                    break;
                case Image.Name.Missile:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 376.0f, 798.0f, 16.0f, 100.0f);
                    break;
                case Image.Name.Ship:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 56.0f, 323.0f, 184.0f, 132.0f);
                    break;
                case Image.Name.Brick:
                    ImageMan.Add(imageName, Texture.Name.Shields, 20, 210, 10, 5);
                    break;
                case Image.Name.BrickLeft_Top0:
                    ImageMan.Add(imageName, Texture.Name.Shields, 15, 180, 10, 5);
                    break;
                case Image.Name.BrickLeft_Top1:
                    ImageMan.Add(imageName, Texture.Name.Shields, 15, 185, 10, 5);
                    break;
                case Image.Name.BrickLeft_Bottom:
                    ImageMan.Add(imageName, Texture.Name.Shields, 35, 215, 10, 5);
                    break;
                case Image.Name.BrickRight_Top0:
                    ImageMan.Add(imageName, Texture.Name.Shields, 75, 180, 10, 5);
                    break;
                case Image.Name.BrickRight_Top1:
                    ImageMan.Add(imageName, Texture.Name.Shields, 75, 185, 10, 5);
                    break;
                case Image.Name.BrickRight_Bottom:
                    ImageMan.Add(imageName, Texture.Name.Shields, 55, 215, 10, 5);
                    break;
                case Image.Name.BombStraight:
                    ImageMan.Add(imageName, Texture.Name.Shields, 111, 101, 5, 49);
                    break;
                case Image.Name.BombZigZag:
                    ImageMan.Add(imageName, Texture.Name.Shields, 132, 100, 20, 50);
                    break;
                case Image.Name.BombCross:
                    ImageMan.Add(imageName, Texture.Name.Shields, 219, 103, 19, 47);
                    break;
                case Image.Name.Ship_Explosion1:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 281, 323, 253, 141);
                    break;
                case Image.Name.Ship_Explosion2:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 544, 323, 253, 142);
                    break;
                case Image.Name.Missile_Explosion:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 393, 475, 139, 142);
                    break;
                case Image.Name.Alien_Explosion:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 544, 475, 253, 142);
                    break;
                case Image.Name.UFO_Explosion:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 14, 630, 364, 140);
                    break;
                case Image.Name.Bomb_Explosion:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 687, 783, 114, 142);
                    break;
                case Image.Name.UFO:
                    ImageMan.Add(imageName, Texture.Name.SpaceInvaders, 78, 499, 234, 112);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
        }
    }
}
