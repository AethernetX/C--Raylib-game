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

    }
}
