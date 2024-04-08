using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

Raylib.InitWindow(700, 900, "Platformer");
Raylib.SetTargetFPS(60);

string scene = "start";

Texture2D playerImage = Raylib.LoadTexture("Player.png");
Rectangle playerRect = new Rectangle(0, 0, 50, 50);

Rectangle door1Rect = new Rectangle(325, 50, 50, 50);
Rectangle door2Rect = new Rectangle(425, 325, 50, 50);
Rectangle door3Rect = new Rectangle(425, 225, 50, 50);

void Player()
{
    if (Raylib.IsKeyDown(KeyboardKey.Space))
    {
        playerRect.Y -= 4;

        Raylib.DrawTexture(playerImage, (int)playerRect.X, (int)playerRect.Y, Color.White);
    }
    else if (Raylib.IsKeyDown(KeyboardKey.A))
    {
        playerRect.X -= 4;

        Raylib.DrawTexture(playerImage, (int)playerRect.X, (int)playerRect.Y, Color.White);
    }
    else if (Raylib.IsKeyDown(KeyboardKey.D))
    {
        playerRect.X += 4;

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
    if (playerRect.Y < 0)
    {
        playerRect.Y = 0;
    }
    if (playerRect.X > 650)
    {
        playerRect.X = 650;
        playerRect.X += 0;
    }
    if (playerRect.X < 0)
    {
        playerRect.X = 0;
        playerRect.X += 0;
    }
}

List<Rectangle> walls = new();
walls.Add(new Rectangle(0, 700, 200, 100));
walls.Add(new Rectangle(500, 700, 200, 100));
walls.Add(new Rectangle(150, 350, 400, 200));
walls.Add(new Rectangle(0, 100, 200, 100));
walls.Add(new Rectangle(500, 100, 200, 100));
walls.Add(new Rectangle(0, 200, 25, 500));
walls.Add(new Rectangle(675, 200, 25, 500));

List<Rectangle> walls2 = new();
walls2.Add(new Rectangle(0, 600, 500, 100));
walls2.Add(new Rectangle(600, 100, 100, 600));
walls2.Add(new Rectangle(200, 400, 400, 100));
walls2.Add(new Rectangle(0, 100, 100, 500));
walls2.Add(new Rectangle(200, 300, 200, 100));
walls2.Add(new Rectangle(100, 100, 600, 100));

List<Rectangle> walls3 = new();
walls3.Add(new Rectangle(0, 100, 50, 700));
walls3.Add(new Rectangle(125, 225, 100, 575));
walls3.Add(new Rectangle(50, 100, 650, 50));
walls3.Add(new Rectangle(225, 750, 475, 50));
walls3.Add(new Rectangle(425, 650, 275, 100));
walls3.Add(new Rectangle(300, 100, 50, 575));
walls3.Add(new Rectangle(300, 100, 50, 575));
walls3.Add(new Rectangle(350, 100, 50, 450));
walls3.Add(new Rectangle(400, 300, 150, 250));
walls3.Add(new Rectangle(625, 100, 75, 700));
walls3.Add(new Rectangle(350, 100, 350, 100));

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

        Raylib.DrawText("LEVEL 1-3", 30, 30, 40, Color.DarkGray);

        Raylib.DrawRectangleRec(door1Rect, Color.Green);

        Raylib.DrawRectangleRec(playerRect, Color.Blank);

        Player();

        Borders();

        foreach (Rectangle wall in walls)
        {
            Raylib.DrawRectangleRec(wall, Color.Black);

            if (Raylib.CheckCollisionRecs(playerRect, wall))
            {
                scene = "start";
            }
        }


        if (Raylib.CheckCollisionRecs(playerRect, door1Rect))
        {
            for (int i = 0; i > walls.Count; i++)
            {
                walls.RemoveAt(i);
            }
            scene = "level2";
            playerRect.X = 325;
            playerRect.Y = 850;
        }
    }

    if (scene == "level2")
    {
        Raylib.ClearBackground(Color.LightGray);

        Raylib.DrawText("LEVEL 2-3", 30, 30, 40, Color.DarkGray);

        Raylib.DrawRectangleRec(door2Rect, Color.Green);

        Raylib.DrawRectangleRec(playerRect, Color.Blank);

        Player();

        Borders();

        foreach (Rectangle wall2 in walls2)
        {
            Raylib.DrawRectangleRec(wall2, Color.Black);

            if (Raylib.CheckCollisionRecs(playerRect, wall2))
            {
                scene = "start";
            }
        }

        if (Raylib.CheckCollisionRecs(playerRect, door2Rect))
        {
            for (int i = 0; i > walls2.Count; i++)
            {
                walls2.RemoveAt(i);
            }
            scene = "level3";
            playerRect.X = 325;
            playerRect.Y = 850;
        }
    }

    if (scene == "level3")
    {
        Raylib.ClearBackground(Color.LightGray);

        Raylib.DrawText("LEVEL 3-3", 30, 30, 40, Color.DarkGray);

        Raylib.DrawRectangleRec(door3Rect, Color.Green);

        Raylib.DrawRectangleRec(playerRect, Color.Blank);

        Player();

        Borders();

        foreach (Rectangle wall3 in walls3)
        {
            Raylib.DrawRectangleRec(wall3, Color.Black);

            if (Raylib.CheckCollisionRecs(playerRect, wall3))
            {
                scene = "start";
            }
        }

        if (Raylib.CheckCollisionRecs(playerRect, door3Rect))
        {
            for (int i = 0; i > walls3.Count; i++)
            {
                walls3.RemoveAt(i);
            }
            scene = "win";
        }
    }

    if (scene == "win")
    {
        Raylib.ClearBackground(Color.Gold);

        Raylib.DrawText("YOU WIN!", 130, 300, 100, Color.Black);

        Raylib.DrawText("To Start:", 205, 450, 60, Color.DarkGray);
        Raylib.DrawText("ENTER", 215, 530, 80, Color.Black);

        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            scene = "start";
        }

    }

    Raylib.EndDrawing();
}
