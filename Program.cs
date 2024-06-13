using Raylib_cs;
using System.Numerics;
using game;

namespace game {
    public struct Transform2D
    {
        public Vector2 Pos;
        public Vector2 prevPos;
        public Vector2 Scale;
    }
}

class Program
{
    public static void Main()
    {

        Raylib.SetTargetFPS(60);

        Raylib.InitWindow(1280, 720, "Game");

        Entity y = new Entity(32, 100, 140, 100);
        Player x = new (100, 100);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            x.Draw();
            y.Draw();

            Physics.Accelerate(y, Physics.gravity);
            Physics.VerletUpdatePos(y, Raylib.GetFrameTime());
            y.Accel = Vector2.Zero;
            x.Update();

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}