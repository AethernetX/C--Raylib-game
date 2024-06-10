using Raylib_cs;
using System.Numerics;

namespace game
{

    public class Entity
    {
        public Vector2 size;
        public Vector2 pos;
        public Vector2 Vel;
        public Vector2 Accel;
        public int Mass = 10;

        public Entity(int width, int height, int posX, int posY)
        {
            size = new Vector2(width, height);
            pos = new Vector2(posX, posY);
        }

        public virtual void draw()
        {
            //Raylib.DrawRectangle(posX, posY, width, height, Color.Blue);
            Raylib.DrawRectangleV(pos, size, Color.Red);
        }

        public virtual extern void Update();
    }

}
