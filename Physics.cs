using Raylib_cs;
using System.Numerics;

namespace game
{
    public class Physics
    {
        //public static void gravity(Entity e, float gravity)
        //{
        //    e.Accel.Y += gravity * Raylib.GetFrameTime();
        //    e.Vel.Y += e.Accel.Y * Raylib.GetFrameTime();
        //    e.pos.Y += e.Vel.Y;
        //}

        public static void Force(Entity e, Vector2 dir)
        {
            //dir /= (float)e.Mass;
            e.Accel += dir * Raylib.GetFrameTime();
        }

        public static void VelVerlet(Entity e)
        {
            //pos += vel * dt + 0.5 * acc * dt * dt;
            //vel += acc * dt;
            float dt = Raylib.GetFrameTime();
            e.transform.Pos += e.Vel * dt + 0.5f * e.Accel * dt * dt;
            e.Vel += e.Accel * dt;
        }



    }
}
