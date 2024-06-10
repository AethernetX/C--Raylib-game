using Raylib_cs;
using System.Numerics;

namespace game
{
    public class Physics
    {
        public static void gravity(Entity e, float gravity)
        {
            e.Accel.Y += gravity * Raylib.GetFrameTime();
            e.Vel.Y += e.Accel.Y * Raylib.GetFrameTime();
            e.pos.Y += e.Vel.Y;
        }

        public static void force(Entity e, Vector2 dir)
        {
            dir /= (float)e.Mass;
            e.Accel += dir * Raylib.GetFrameTime();
            e.Vel += e.Accel * Raylib.GetFrameTime();
            e.pos += e.Vel;
        }



    }
}
