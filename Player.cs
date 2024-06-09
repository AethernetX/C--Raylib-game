using Raylib_cs;

namespace game
{
    class Player : Entity
    {

        public Player(int posX, int posY) : base(32, 100, posX, posY) { }

        public override void draw()
        {
            base.draw();
        }

        public override void Update()
        {
            // F = MA
            // A = F/M

            Raylib.DrawText(base.Vel.Y.ToString(), 100, 100, 20, Color.White);

            if (pos.Y < Raylib.GetScreenHeight() - size.Y)
            {
                Physics.gravity(this, 19.6f);
                //Accel.Y += 19.6f * Raylib.GetFrameTime();
                //Vel.Y += Accel.Y * Raylib.GetFrameTime();
                //pos.Y += Vel.Y;
            }
            else
            {
                base.Vel.Y = 0;
                base.pos.Y = Raylib.GetScreenHeight() - base.size.Y;
            }
        }
    }
}
