using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Design
    {
        /// <summary>
        /// Gets the user's disered number for fields to be created
        /// </summary>
        public static void NumberOfFields()
        {
            Console.Write(Environment.NewLine + Environment.NewLine);
            int temp;
            do
            {
                Console.WriteLine("Please enter the positive number of desired fields...");
                temp = int.Parse(Console.ReadLine());
            } while (Validations.IsNegative(temp));
            Program.f = temp;
        }

        /// <summary>
        /// Initialize the dimensions of the current field
        /// </summary>
        /// <param name="number">Indicated the current field</param>
        public static void InitializeField(int number)
        {
            Console.Write(Environment.NewLine + Environment.NewLine);
            int temp;
            do
            {
                Console.WriteLine("Please enter the positive number of desired lines of the field number:"+ number +"...");
                //Ensure only positive numbers will be inputed
                try
                {
                    temp = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    temp = -1;
                }
            } while (Validations.IsNegative(temp));
            Program.lines = temp;
            Console.Write(Environment.NewLine + Environment.NewLine);
            do
            {
                Console.WriteLine("Please enter the positive number of desired columns of the field number:" + number + "...");
                //Ensure only positive numbers will be inputed
                try
                {
                    temp = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    temp = -1;
                }
            } while (Validations.IsNegative(temp));
            Program.columns = temp;
            SetMines();
        }

        /// <summary>
        /// Algorith for auto creation the number of mines that will be available for user input
        /// </summary>
        public static void SetMines()
        {
            int field = Program.lines * Program.columns;
            Program.mines = (int)((field/100.0) * 20);
        }

        /// <summary>
        /// Takes the user's inputs for each position inside the field
        /// </summary>
        public static void CreateFields()
        {
            Console.Write(Environment.NewLine + Environment.NewLine);
            string input;
            bool correct_input = false;
            int minesCount = Program.mines;
            if (minesCount == 0)
            {
                minesCount = 2;
            }

            Program.field = new string[Program.lines, Program.columns];
            Console.WriteLine("Field Set as "+ Program.lines + "x" + Program.columns);
            for (int i = 0; i < Program.lines; i++)
            {
                for (int y = 0; y < Program.columns; y++)
                {
                    Console.WriteLine("Current Position: " + "["+ i + "," + y + "]");
                    Console.WriteLine("Available Mines: " + minesCount);
                    do
                    {
                        Console.WriteLine("Please insert '*' for mine or '.' for number...");
                        input = Console.ReadLine();
                        if (!Validations.IsMine(input))
                        {
                            if (Validations.IsNumber(input))
                            {
                                correct_input = true;
                            }
                        }
                        else
                        {
                            if (Validations.HasMines(minesCount))
                            {
                                minesCount = minesCount - 1;
                                correct_input = true;
                            }
                            else
                            {
                                correct_input = false;
                            }
                        }
                    } while (!correct_input);
                    Program.field[i, y] = input;
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }
            }
        }

        /// <summary>
        /// Replace each square if necessary with the correct number based on adjacent mines
        /// </summary>
        public static void SetField()
        {
            for (int x = 0; x < Program.field.GetLength(0); x++)
            {
                for (int y = 0; y < Program.field.GetLength(1); y++)
                {
                    int minesFound = 0;
                    //If not already a mine check for neighbors mines
                    if (Program.field[x, y] != "*")
                    {
                        try
                        {
                            //Checking Upper neighbor
                            if (Program.field[x - 1, y] == "*")
                            {
                                minesFound = minesFound + 1;
                            }
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            //Checking Left neighbor
                            if (Program.field[x, y - 1] == "*")
                            {
                                minesFound = minesFound + 1;
                            }
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            //Checking Right neighbor
                            if (Program.field[x, y + 1] == "*")
                            {
                                minesFound = minesFound + 1;
                            }
                        }
                        catch (Exception)
                        {

                        }
                        try
                        {
                            //Checking Lower neighbor
                            if (Program.field[x + 1, y] == "*")
                            {
                                minesFound = minesFound + 1;
                            }
                        }
                        catch (Exception)
                        {

                        }
                        Program.field[x, y] = minesFound.ToString();
                    }
                }
            }
        }

        /// <summary>
        /// Prints the results of the created field
        /// </summary>
        /// <param name="number"></param>
        public static void PrintField(int number)
        {
            Console.Write(Environment.NewLine + Environment.NewLine);
            Console.WriteLine("Field #"+number);
            for (int i = 0; i < Program.field.GetLength(0); i++)
            {
                for (int j = 0; j < Program.field.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0} ", Program.field[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.Write(Environment.NewLine + Environment.NewLine);
        }
    }
}
