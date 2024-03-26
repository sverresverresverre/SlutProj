using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(700, 900, "Platformer");
Raylib.SetTargetFPS(60);

string scene = "start";

Texture2D playerImage = Raylib.LoadTexture("Player.png");
Rectangle playerRect = new Rectangle(0, 0, 50, 50);

void Player()
{
    if (Raylib.IsKeyDown(KeyboardKey.Space))
    {
        playerRect.Y -= 4;

        Raylib.DrawTexture(playerImage, (int)playerRect.X, (int)playerRect.Y, Color.White);
    }
    else
    {
        playerRect.Y += 6;

        Raylib.DrawTexture(playerImage, (int)playerRect.X, (int)playerRect.Y, Color.White);
    }
}

void Borders()
{
    if (playerRect.Y > 850)
    {
        playerRect.Y = 850;
        playerRect.Y += 0;
    }
}

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    if (scene == "start")
    {
        Raylib.ClearBackground(Color.LightGray);

        Raylib.DrawText("To Start:", 205, 200, 60, Color.DarkGray);
        Raylib.DrawText("ENTER", 215, 280, 80, Color.Black);

        Raylib.DrawText("To Move:", 200, 480, 60, Color.DarkGray);
        Raylib.DrawText("A", 240, 560, 80, Color.Black);
        Raylib.DrawText("D", 400, 560, 80, Color.Black);

        Raylib.DrawText("To Fly:", 240, 700, 60, Color.DarkGray);
        Raylib.DrawText("SPACE", 220, 780, 80, Color.Black);

        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            scene = "level1";

            playerRect.X = 325;
            playerRect.Y = 850;
        }
    }

    if (scene == "level1")
    {
        Raylib.ClearBackground(Color.LightGray);

        Raylib.DrawText("LEVEL 1-5", 30, 30, 40, Color.DarkGray);



        Raylib.DrawRectangleRec(playerRect, Color.Blank);

        Player();

        Borders();
    }

    Raylib.EndDrawing();
}
