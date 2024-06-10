using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace game
{
    class Player : Entity
    {
        Vector2 dir = new Vector2();

        public Player(int posX, int posY) : base(32, 100, posX, posY) { 
            this.Mass = 5;
        }

        public override void draw()
        {
            base.draw();
        }

        public override void Update()
        {
            // F = MA
            // A = F/M

            if (Raylib.IsKeyDown(KeyboardKey.D))
            {
                dir.X = 10;
            }
            
            if (Raylib.IsKeyDown(KeyboardKey.A))
            {
                dir.X = -10;
            }

            if (Raylib.IsKeyDown(KeyboardKey.W))
            {
                dir.Y = -10;
            }

            if (Raylib.IsKeyDown(KeyboardKey.S))
            {
                dir.Y = 10;
            }

            //dir.Y = 19.6f;

            Raylib.DrawText("velocity: " + base.Vel.X.ToString() + " , " + base.Vel.X.ToString(), 100, 100, 20, Color.White);
            Raylib.DrawText("Acceleration: " + base.Accel.X.ToString() + " , " + base.Accel.X.ToString(), 100, 130, 20, Color.White);
            Raylib.DrawText("force: " + dir.X.ToString() + " , " + dir.X.ToString(), 100, 160, 20, Color.White);


            if (pos.Y > Raylib.GetScreenHeight() - size.Y)
            {
                base.Vel.Y = 0;
                base.Accel.Y = 0;
                base.pos.Y = Raylib.GetScreenHeight() - base.size.Y;
            }

            if (pos.X > Raylib.GetScreenWidth() - size.X)
            {
                base.Vel.X = 0;
                base.Accel.X = 0;
                base.pos.X = Raylib.GetScreenWidth() - base.size.X;
            }

            if (pos.Y < 0)
            {
                base.Vel.Y = 0;
                base.Accel.Y = 0;
                base.pos.Y = 0;
            }

            if (pos.X < 0)
            {
                base.Vel.X = 0;
                base.Accel.X = 0;
                base.pos.X = 0;
            }

            Physics.force(this, dir);

            //Physics.gravity(this, 19.6f);

            dir = Vector2.Zero;

        }
    }
}
