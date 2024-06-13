using Raylib_cs;
using System.Numerics;

namespace game
{
    public static class Physics
    {
        public static Vector2 gravity = new(0, 196);

        //public static void gravity(Entity e, float gravity)
        //{
        //    e.Accel.Y += gravity * Raylib.GetFrameTime();
        //    e.Vel.Y += e.Accel.Y * Raylib.GetFrameTime();
        //    e.pos.Y += e.Vel.Y;
        //}



        public static void Force(Entity e, Vector2 dir)
        {
            //dir /= (float)e.Mass;
            Accelerate(e, dir / e.Mass);
            
        }

        public static void VerletUpdatePos(Entity e, float dt)
        {
            //Xn+1 = Xn + (Xn - Xn-1) + a * dt^2

            // get the implied velocity
            e.Vel = e.transform.Pos - e.transform.prevPos;

            // save the old position
            e.transform.prevPos = e.transform.Pos;

            //set acceleration?
            // --

            e.transform.Pos += e.Vel + e.Accel * dt * dt;



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

            friction = -friction;

            friction *= coeff * normal;

            Force(e, friction);

        }



    }
}
