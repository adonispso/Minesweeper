using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Program
    {
        public static int lines; //Static Constant for the lines
        public static int columns; //Static Constant for the columns
        public static int answer; //Static Constant of user's answers
        public static int mines; //Static Constant of mines per field creation
        public static int f; //Static Constant for fields
        public static string[,] field = new string[0, 0]; //Static multidimensional array of strings

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minesweeper!");
            Console.WriteLine("Created by Antonis Psomas");
            Console.WriteLine("Press <1> to start or any other <key> for exit...");
            try
            {
                answer = int.Parse(Console.ReadLine()); //Ensure only numbers will be inputed
            }
            catch (Exception)
            {
                answer = 0; //Case not a number sets the program to exit
            }
            
            if (answer == 1) //User selected to start the game
            {
                Design.NumberOfFields(); //Set the number of fields for creation
                for (int i = 1; i <= f; i++)
                {
                    Design.InitializeField(i); //Initialize the dimensions of the field
                    Design.CreateFields(); //Takes the user's inputs for each position inside the field
                    Design.SetField(); //Replace each square if necessary with the correct number based on adjacent mines
                    Design.PrintField(i); //Prints the field
                }
                Console.ReadLine();
            }
        }
    }
}
