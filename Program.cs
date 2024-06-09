using Raylib_cs;
using System.Numerics;
using game;

class Program
{
    public static void Main()
    {
        Raylib.SetTargetFPS(60);

        Vector2 example = new Vector2(100f, 100f);

        Raylib.InitWindow(1280, 720, "Game");

        Player x = new Player(100, 100);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            x.draw();
            x.Update();


            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}