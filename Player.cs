using Raylib_cs;
using System.Numerics;

namespace game
{
    class Player : Entity
    {
        float move = 100f;
        Vector2 dir = new();

        public Player(int posX, int posY) : base(32, 100, posX, posY) { 
            this.Mass = 10;
        }

        public override void Draw()
        {
            base.Draw();
        }

        public override void Update()
        {

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
                dir.Y = -move * 10;
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
                base.Accel.Y = 0;
                base.transform.Pos.Y = Raylib.GetScreenHeight() - base.transform.Scale.Y + 0.0001f;

                Raylib.DrawText("friction!!", 100, 160, 20, Color.Red);
                Physics.Friction(this, 0.5f, Physics.gravity);

            }

            if (base.transform.Pos.X > Raylib.GetScreenWidth() - base.transform.Scale.X)
            {
                base.Vel.X = 0;
                base.Accel.X = 0;
                base.transform.Pos.X = Raylib.GetScreenWidth() - base.transform.Scale.X;

            }

            if (base.transform.Pos.Y < 0)
            {
                base.Vel.Y = 0;
                base.Accel.Y = 0;
                base.transform.Pos.Y = 0;
            }

            if (base.transform.Pos.X < 0)
            {
                base.Vel.X = 0;
                base.Accel.X = 0;
                base.transform.Pos.X = 0;
            }

            Physics.Accelerate(this, Physics.gravity);
            Physics.Force(this, dir);
            Physics.VerletUpdatePos(this, Raylib.GetFrameTime());

            Accel = Vector2.Zero;
            dir = Vector2.Zero;

        }
    }
}
