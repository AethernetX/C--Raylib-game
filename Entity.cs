using Raylib_cs;
using System.Numerics;

namespace game
{

    public class Entity
    {
        int width;
        int height;
        int posX, posY;

        Vector2 size;
        Vector2 pos;
        Vector2 Accel;
        int Mass = 10;

        public Entity(int width, int height, int posX, int posY)
        {
            this.width = width;
            this.height = height;
            this.posX = posX;
            this.posY = posY;

            size = new Vector2(width, height);
            pos = new Vector2(posX, posY);
        }

        public void draw()
        {
            //Raylib.DrawRectangle(posX, posY, width, height, Color.Blue);
            Raylib.DrawRectangleV(pos, size, Color.Red);
        }

        public void Update()
        {
            // F = MA
            // A = F/M

            Raylib.DrawText(Accel.Y.ToString(), 100, 100, 20, Color.White);

            if (pos.Y < Raylib.GetScreenHeight() - size.Y) 
            {
                Accel.Y += 19.6f * Raylib.GetFrameTime();
                pos.Y += Accel.Y * Raylib.GetFrameTime();
            }

        }
    }

}
