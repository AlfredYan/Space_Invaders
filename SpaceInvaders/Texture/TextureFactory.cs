using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TextureFactory
    {
        //-------------------------------------------------------------------------------
        // Methods
        //-------------------------------------------------------------------------------
        public void create(Texture.Name name, String textureFile)
        {
            switch (name)
            {
                case Texture.Name.SpaceInvaders:
                    TextureMan.Add(Texture.Name.SpaceInvaders, textureFile);
                    break;

                case Texture.Name.Shields:
                    TextureMan.Add(Texture.Name.Shields, textureFile);
                    break;

                case Texture.Name.Consolas36pt:
                    TextureMan.Add(Texture.Name.Consolas36pt, textureFile);
                    break;

                default:
                    Debug.Assert(false);
                    break;
            }
        }
    }
}
