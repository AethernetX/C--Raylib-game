using Raylib_cs;
using System.Numerics;

namespace game
{
    public static class Physics
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
            Accelerate(e, dir);
            
        }

        public static void VerletUpdatePos(Entity e, float dt)
        {
            //pos += vel * dt + 0.5 * acc * dt * dt;
            //vel += acc * dt;

            e.Vel = e.transform.Pos - e.prevPosition;

            //set current pos as prev
            e.prevPosition = e.transform.Pos;

            e.transform.Pos += e.Vel + e.Accel * dt * dt;

            //reset acceleration
            e.Accel = Vector2.Zero;

            Raylib.DrawText("velocity: " + e.Vel.ToString(), 100, 100, 20, Color.White);


        }

        public static void Accelerate(Entity e, Vector2 acc)
        {
            e.Accel += acc;
        }

        public static void Friction(Entity e, float coeff, Vector2 gravity)
        {
            // friction (N) = friction coeff * normal force (unit vector)

            //get unit vector
            //get the normal force
            //get the opposite direction

            Vector2 friction = e.Vel;
            Vector2.Normalize(friction);

            //this will be multiplied by the angle of the surface
            float normal = gravity.Y;

            friction *= -1.0f;

            friction *= coeff * normal;

            Force(e, friction);

        }



    }
}
