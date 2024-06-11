using Raylib_cs;
using System.Numerics;

namespace game
{

    public class Entity
    {
        public Transform2D transform;

        public Vector2 Vel;
        public Vector2 Accel;
        public int Mass = 10;

        public Entity(int width, int height, int posX, int posY)
        {
            transform.Scale = new Vector2(width, height);
            transform.Pos = new Vector2(posX, posY);
        }

        public virtual void Draw()
        {
            //Raylib.DrawRectangle(posX, posY, width, height, Color.Blue);
            Raylib.DrawRectangleV(transform.Pos, transform.Scale, Color.Red);
        }

        public virtual extern void Update();
    }

}
