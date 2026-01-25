using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.CursorVisible = false;

        int screenWidth = Math.Max(20, Math.Min(Console.BufferWidth, 80));
        int screenHeight = Math.Max(10, Math.Min(Console.BufferHeight, 30));
        int playHeight = screenHeight - 1;

        Random rng = new Random();

        Pixel head = new Pixel
        {
            XPos = screenWidth / 2,
            YPos = playHeight / 2,
            ScreenColor = ConsoleColor.Green,
            Character = "■"
        };

        string movement = "RIGHT";
        int score = 0;
        int snakeLength = 3;
        List<int> bodyPositions = new List<int> { head.XPos, head.YPos };

        int obstacleXPos = rng.Next(1, screenWidth - 1);
        int obstacleYPos = rng.Next(1, playHeight - 1);
        const string obstacleCharacter = "*";
        
        int frameCount = 0;

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow when movement != "DOWN":
                        movement = "UP";
                        break;
                    case ConsoleKey.DownArrow when movement != "UP":
                        movement = "DOWN";
                        break;
                    case ConsoleKey.LeftArrow when movement != "RIGHT":
                        movement = "LEFT";
                        break;
                    case ConsoleKey.RightArrow when movement != "LEFT":
                        movement = "RIGHT";
                        break;
                }
            }

            bool willMove = true;
            if ((movement == "UP" || movement == "DOWN") && frameCount % 2 != 0)
            {
                willMove = false;
            }
            frameCount++;

            if (willMove)
            {
                switch (movement)
                {
                    case "UP": head.YPos--; break;
                    case "DOWN": head.YPos++; break;
                    case "LEFT": head.XPos--; break;
                    case "RIGHT": head.XPos++; break;
                }

                if (head.XPos == obstacleXPos && head.YPos == obstacleYPos)
                {
                    score++;
                    snakeLength++;
                    obstacleXPos = rng.Next(1, screenWidth - 1);
                    obstacleYPos = rng.Next(1, playHeight - 1);
                }

                bodyPositions.Insert(0, head.YPos);
                bodyPositions.Insert(0, head.XPos);
                while (bodyPositions.Count > snakeLength * 2)
                {
                    bodyPositions.RemoveAt(bodyPositions.Count - 1);
                }

                bool hitWall = head.XPos <= 0 || head.XPos >= screenWidth - 1 || head.YPos <= 0 || head.YPos >= playHeight - 1;
                if (hitWall) GameOver(score, screenWidth, playHeight);

                for (int i = 2; i < bodyPositions.Count; i += 2)
                {
                    if (head.XPos == bodyPositions[i] && head.YPos == bodyPositions[i + 1])
                    {
                        GameOver(score, screenWidth, playHeight);
                    }
                }
            }

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            for (int x = 0; x < screenWidth; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("■");
                Console.SetCursorPosition(x, playHeight - 1);
                Console.Write("■");
            }
            for (int y = 0; y < playHeight; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("■");
                Console.SetCursorPosition(screenWidth - 1, y);
                Console.Write("■");
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(obstacleXPos, obstacleYPos);
            Console.Write(obstacleCharacter);

            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < bodyPositions.Count; i += 2)
            {
                Console.SetCursorPosition(bodyPositions[i], bodyPositions[i + 1]);
                Console.Write("■");
            }

            Thread.Sleep(40);
        }
    }

    static void GameOver(int score, int screenWidth, int playHeight)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(screenWidth / 5, playHeight / 2);
        Console.WriteLine("Game Over!");
        Console.SetCursorPosition(screenWidth / 5, playHeight / 2 + 1);
        Console.WriteLine($"Your score: {score}");
        Environment.Exit(0);
    }
}




