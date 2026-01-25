using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program

{

    static void Main()

    {

        Console.WindowHeight = 16;

        Console.WindowWidth = 32;

        int screenWidth = Console.WindowWidth;

        int screenHeight = Console.WindowHeight;

        Random randomNumber = new Random();

        Pixel head = new Pixel();

        head.XPos = screenWidth / 2;

        head.YPos = screenHeight / 2;

        head.ScreenColor = ConsoleColor.Red;

        string movement = "RIGHT";

        List<int> bodyPositions = new List<int>();

        int score = 0;

        bodyPositions.Add(head.XPos);

        bodyPositions.Add(head.YPos);

        string obstacle = "*";

        int obstacleXPos = randomNumber.Next(1, screenWidth);

        int obstacleYPos = randomNumber.Next(1, screenHeight);

        while (true)
        {
            Console.Clear();

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
            

            //Draw Obstacle

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(obstacleXPos, obstacleYPos);

            Console.Write(obstacle);



            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(head.XPos, head.YPos);

            Console.Write("■");



            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < screenWidth; i++)

            {

                Console.SetCursorPosition(i, 0);

                Console.Write("■");

            }

            for (int i = 0; i < screenWidth; i++)

            {

                Console.SetCursorPosition(i, screenHeight - 1);

                Console.Write("■");

            }

            for (int i = 0; i < screenHeight; i++)

            {

                Console.SetCursorPosition(0, i);

                Console.Write("■");

            }

            for (int i = 0; i < screenHeight; i++)

            {

                Console.SetCursorPosition(screenWidth - 1, i);

                Console.Write("■");

            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Score: " + score);

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("H");

            for (int i = 0; i < bodyPositions.Count; i++)

            {

                Console.SetCursorPosition(bodyPositions[i], bodyPositions[i + 1]);

                Console.Write("■");

            }

            //Draw Snake

            Console.SetCursorPosition(head.XPos, head.YPos);

            Console.Write("■");

            Console.SetCursorPosition(head.XPos, head.YPos);

            Console.Write("■");

            Console.SetCursorPosition(head.XPos, head.YPos);

            Console.Write("■");

            Console.SetCursorPosition(head.XPos, head.YPos);

            Console.Write("■");



            ConsoleKeyInfo info = Console.ReadKey();

            //Game Logic

            switch (info.Key)

            {

                case ConsoleKey.UpArrow:

                    movement = "UP";

                    break;

                case ConsoleKey.DownArrow:

                    movement = "DOWN";

                    break;

                case ConsoleKey.LeftArrow:

                    movement = "LEFT";

                    break;

                case ConsoleKey.RightArrow:

                    movement = "RIGHT";

                    break;

            }

            if (movement == "UP")

                head.YPos --;

            if (movement == "DOWN")

                head.YPos++;

            if (movement == "LEFT")

                head.XPos--;

            if (movement == "RIGHT")

                head.XPos++;

            //Hindernis treffen

            if (head.XPos == obstacleXPos && head.YPos == obstacleYPos)

            {

                score++;

                obstacleXPos = randomNumber.Next(1, screenWidth);

                obstacleYPos = randomNumber.Next(1, screenHeight);

            }

            bodyPositions.Insert(0, head.XPos);

            bodyPositions.Insert(1, head.YPos);

            bodyPositions.RemoveAt(bodyPositions.Count - 1);

            bodyPositions.RemoveAt(bodyPositions.Count - 1);

            //Kollision mit Wände oder mit sich selbst

            if (head.XPos == 0 || head.XPos == screenWidth - 1 || head.YPos == 0 || head.YPos == screenHeight - 1)

            {

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);

                Console.WriteLine("Game Over");

                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);

                Console.WriteLine("Dein Score ist: " + score);

                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

                Environment.Exit(0);

            }

            for (int i = 0; i < bodyPositions.Count(); i += 2)

            {

                if (head.XPos == bodyPositions[i] && head.YPos == bodyPositions[i + 1])

                {

                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);

                    Console.WriteLine("Game Over");

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);

                    Console.WriteLine("Dein Score ist: " + score);

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

                    Environment.Exit(0);

                }

            }

            Thread.Sleep(40);

        }

    }

}




