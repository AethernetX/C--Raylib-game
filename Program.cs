using Raylib_cs;
using System.Numerics;
using game;

namespace game {
    public struct Transform2D
    {
        public Vector2 Pos;
        public Vector2 Scale;
    }
}

class Program
{

    public static void Main()
    {

        //Raylib.SetTargetFPS(60);

        Raylib.InitWindow(1280, 720, "Game");

        Player x = new (100, 100);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            x.Draw();
            x.Update();


            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}