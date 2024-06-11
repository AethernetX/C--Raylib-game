using Raylib_cs;
using System.Numerics;

namespace game
{
    class Player : Entity
    {
        float move = 1000f;
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
                dir.Y = -move;
            }

            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                dir.Y = move;
            }

            //dir.Y = 19.6f;

            Raylib.DrawText("velocity: " + base.Vel.X.ToString() + " , " + base.Vel.X.ToString(), 100, 100, 20, Color.White);
            Raylib.DrawText("Acceleration: " + base.Accel.X.ToString() + " , " + base.Accel.X.ToString(), 100, 130, 20, Color.White);
            Raylib.DrawText("force: " + dir.X.ToString() + " , " + dir.X.ToString(), 100, 160, 20, Color.White);


            if (transform.Pos.Y > Raylib.GetScreenHeight() - transform.Scale.Y)
            {
                base.Vel.Y = 0;
                base.Accel.Y = 0;
                base.transform.Pos.Y = Raylib.GetScreenHeight() - base.transform.Scale.Y;
            }

            if (transform.Pos.X > Raylib.GetScreenWidth() - transform.Scale.X)
            {
                base.Vel.X = 0;
                base.Accel.X = 0;
                base.transform.Pos.X = Raylib.GetScreenWidth() - base.transform.Scale.X;
            }

            if (transform.Pos.Y < 0)
            {
                base.Vel.Y = 0;
                base.Accel.Y = 0;
                base.transform.Pos.Y = 0;
            }

            if (transform.Pos.X < 0)
            {
                base.Vel.X = 0;
                base.Accel.X = 0;
                base.transform.Pos.X = 0;
            }

            Physics.Force(this, Vector2.UnitY * 980f);
            Physics.Force(this, dir);
            Physics.VelVerlet(this);

            dir = Vector2.Zero;

        }
    }
}
