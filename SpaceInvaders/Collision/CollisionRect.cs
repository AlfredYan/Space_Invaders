using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CollisionRect : Azul.Rect
    {
        //---------------------------------------------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------------------------------------------
        public CollisionRect()
            : base()
        {

        }
        public CollisionRect(Azul.Rect pRect)
            : base(pRect)
        {

        }
        public CollisionRect(CollisionRect pRect)
            : base(pRect)
        {

        }
        public CollisionRect(float x, float y, float width, float height)
            : base(x, y, width, height)
        {

        }
        //----------------------------------------------------------------------
        // Static methods
        //----------------------------------------------------------------------
        public static bool Intersect(CollisionRect colRectA, CollisionRect colRectB)
        {
            bool status = false;

            float A_minx = colRectA.x - colRectA.width / 2;
            float A_maxx = colRectA.x + colRectA.width / 2;
            float A_miny = colRectA.y - colRectA.height / 2;
            float A_maxy = colRectA.y + colRectA.height / 2;

            float B_minx = colRectB.x - colRectB.width / 2;
            float B_maxx = colRectB.x + colRectB.width / 2;
            float B_miny = colRectB.y - colRectB.height / 2;
            float B_maxy = colRectB.y + colRectB.height / 2;

            // Trivial reject
            if ((B_maxx < A_minx) || (B_minx > A_maxx) || (B_maxy < A_miny) || (B_miny > A_maxy))
            {
                status = false;
            }
            else
            {
                status = true;
            }


            return status;
        }
        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------
        // add boxes together
        public void union(CollisionRect colRect)
        {
            float minX = ((this.x - this.width / 2) < (colRect.x - colRect.width / 2)) ? (this.x - this.width / 2) : (colRect.x - colRect.width / 2);
            float maxX = ((this.x + this.width / 2) > (colRect.x + colRect.width / 2)) ? (this.x + this.width / 2) : (colRect.x + colRect.width / 2);
            float minY = ((this.y - this.height / 2) < (colRect.y - colRect.height / 2)) ? (this.y - this.height / 2) : (colRect.y - colRect.height / 2);
            float maxY = ((this.y + this.height / 2) > (colRect.y + colRect.height / 2)) ? (this.y + this.height / 2) : (colRect.y + colRect.height / 2);

            this.width = (maxX - minX);
            this.height = (maxY - minY);
            this.x = minX + this.width / 2;
            this.y = minY + this.height / 2;

        }
    }
}
