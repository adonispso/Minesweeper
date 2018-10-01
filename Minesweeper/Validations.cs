using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Validations
    {
        /// <summary>
        /// Return true for negative numbers false for positive numbers
        /// </summary>
        /// <param name="number">Represents the number that will be tested</param>
        /// <returns>Boolean</returns>
        public static bool IsNegative(int number)
        {
            if (number < 1)
            {
                Console.WriteLine("Incorrect Input");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Return true if user insert a mine or false if user not insert a mine
        /// </summary>
        /// <param name="inpt">Represents the user's input</param>
        /// <returns>Boolean</returns>
        public static bool IsMine(string inpt)
        {
            if (inpt == "*")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Return true if user insert a number or false if user not insert a number
        /// </summary>
        /// <param name="inpt">Represents the user's input</param>
        /// <returns>Boolean</returns>
        public static bool IsNumber(string inpt)
        {
            if (inpt == ".")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Return true if user has any mines left or false if user insert all the mines
        /// </summary>
        /// <param name="mi">Indicates the amount of user's mines</param>
        /// <returns>Boolean</returns>
        public static bool HasMines(int mi)
        {
            if (mi > 0)
            {
                return true;
            }
            else
            {
                Console.WriteLine("All mines inserted!");
                return false;
            }
        }
    }
}
