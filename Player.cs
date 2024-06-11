using Raylib_cs;
using System.Numerics;

namespace game
{
    class Player : Entity
    {
        float move = 196f;
        Vector2 gravity = new(0, 98);
        Vector2 dir = new();

        public Player(int posX, int posY) : base(32, 100, posX, posY) { 
            this.Mass = 5;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {
            // F = MA
            // A = F/M

            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                dir.X = move;
            }
            
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                dir.X = -move;
            }

            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                dir.Y = -move * 2;
            }

            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                dir.Y = move;
            }

            //dir.Y = 19.6f;

            Console.WriteLine("velocity: " + base.Vel.X.ToString() + " , " + base.Vel.X.ToString());
            //Console.WriteLine("Acceleration: " + base.Accel.X.ToString() + " , " + base.Accel.X.ToString());
            //Console.WriteLine("force: " + dir.X.ToString() + " , " + dir.X.ToString());


            //Raylib.DrawText("velocity: " + base.Vel.X.ToString() + " , " + base.Vel.X.ToString(), 100, 100, 20, Color.White);
            //Raylib.DrawText("Acceleration: " + base.Accel.X.ToString() + " , " + base.Accel.X.ToString(), 100, 130, 20, Color.White);
            //Raylib.DrawText("force: " + dir.X.ToString() + " , " + dir.X.ToString(), 100, 160, 20, Color.White);


            if (base.transform.Pos.Y > Raylib.GetScreenHeight() - base.transform.Scale.Y)
            {
                base.Vel.Y = 0;
                base.transform.Pos.Y = Raylib.GetScreenHeight() - base.transform.Scale.Y + 0.0001f;

                Raylib.DrawText("friction!!", 100, 160, 20, Color.Red);
                Physics.Friction(this, 40, gravity);

            }

            if (base.transform.Pos.X > Raylib.GetScreenWidth() - base.transform.Scale.X)
            {
                base.Vel.X = 0;
                base.transform.Pos.X = Raylib.GetScreenWidth() - base.transform.Scale.X;

            }

            if (base.transform.Pos.Y < 0)
            {
                base.Vel.Y = 0;
                base.transform.Pos.Y = 0;
            }

            if (base.transform.Pos.X < 0)
            {
                base.Vel.X = 0;
                base.transform.Pos.X = 0;
            }

            Physics.Accelerate(this, gravity);

            Physics.Force(this, dir);
            Physics.VerletUpdatePos(this, Raylib.GetFrameTime());

            dir = Vector2.Zero;

        }
    }
}
