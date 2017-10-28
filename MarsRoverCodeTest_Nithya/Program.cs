using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace MarsRover
{
    public class Program
    {
        static string position = null;
        static string Navigation = null;
        static int startX = 0;
        static int startY = 0;
        static int endX, endY = 0;
        static int boundaryX, boundaryY;
        static string dir = "N";
        private static string Key = "Y";

        enum Directions { N, E, W, S };
        public static void Main(string[] args)
        {
            try
            {

                WriteLine("Please enter the upper right co-ordiantes seperated by a single space (eg:5 5)");
                var coord = Console.ReadLine();
                string[] boundary = coord.Split(" ".ToCharArray());
                boundaryX = Convert.ToInt32(boundary[0]);
                boundaryY = Convert.ToInt32(boundary[1]);
                do
                {
                    WriteLine("\n Enter the position of the Rover seperated by a single space (eg: 2 2 N)");
                    position = ReadLine();
                    WriteLine("\nEnter the Navigation of the Rover (eg: LMLMLMM)");
                    Navigation = ReadLine();

                    string[] currPosition = position.Split(" ".ToCharArray());
                    startX = Convert.ToInt32(currPosition[0]);
                    startY = Convert.ToInt32(currPosition[1]);
                    dir = currPosition[2];
                    char[] commands = Navigation.ToCharArray();
                    foreach (char command in commands)
                    {
                        Rove(command);
                    }

                    if (IsRoverInsideBoundary)
                    {
                        WriteLine($"\n Rover Start Position {position}");
                        WriteLine($"\n Navigation {Navigation}");
                        WriteLine($"\n Rover End Position {endX} {endY} {dir}");

                    }
                    else
                    {
                        WriteLine($"\n\n Rover navigated outside boundary limits of {coord}");
                    }

                    WriteLine("\n\n Enter Rover Input for the next rover in Sequence.\n Do you want to continue (Y/N)?");
                    Key = ReadLine();
                }
                while (Key.ToUpper() == "Y");
            }
            catch (Exception ex)
            {
                WriteLine($"{ex} Exception caught.");
            }
        }


        public static bool IsRoverInsideBoundary
        {
            get
            {
                bool IsRoverInsideBoundary = true;
                if (endX > boundaryX || endY > boundaryY)
                    IsRoverInsideBoundary = false;
                return IsRoverInsideBoundary;
            }
        }


        private static void Rove(char command)
        {
            try
            {
                if (dir.Equals(Directions.N.ToString()))
                {
                    switch (command)
                    {
                        case 'L':
                            dir = Directions.W.ToString();
                            break;
                        case 'R':
                            dir = Directions.E.ToString();
                            break;
                        case 'M':
                            startY++;
                            break;
                    }
                }
                else if (dir.Equals(Directions.E.ToString()))
                {
                    switch (command)
                    {
                        case 'L':
                            dir = Directions.N.ToString();
                            break;
                        case 'R':
                            dir = Directions.S.ToString();
                            break;
                        case 'M':
                            startX++;
                            break;
                    }

                }
                else if (dir.Equals(Directions.W.ToString()))
                {
                    switch (command)
                    {
                        case 'L':
                            dir = Directions.S.ToString();
                            break;
                        case 'R':
                            dir = Directions.N.ToString();
                            break;
                        case 'M':
                            startX--;
                            break;
                    }

                }
                else if (dir.Equals(Directions.S.ToString()))
                {
                    switch (command)
                    {
                        case 'L':
                            dir = Directions.E.ToString();
                            break;
                        case 'R':
                            dir = Directions.W.ToString();
                            break;
                        case 'M':
                            startY--;
                            break;
                    }

                }
                endX = startX;
                endY = startY;
            }

            catch (Exception e)
            {
                WriteLine($"{e} Exception caught.");
            }
        }

    }


}
