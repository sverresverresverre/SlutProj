using Raylib_cs;

Raylib.InitWindow(700, 900, "Platformer");
Raylib.SetTargetFPS(60);

string scene = "start";

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    if (scene == "start")
    {
        Raylib.ClearBackground(Color.LightGray);

        Raylib.DrawText("To Move:", 200, 480, 60, Color.DarkGray);
        Raylib.DrawText("A", 240, 560, 80, Color.Black);
        Raylib.DrawText("D", 400, 560, 80, Color.Black);

        Raylib.DrawText("To Fly:", 240, 700, 60, Color.DarkGray);
        Raylib.DrawText("SPACE", 220, 780, 80, Color.Black);
    }

    Raylib.EndDrawing();
}
