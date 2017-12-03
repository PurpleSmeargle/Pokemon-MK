using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEngine
{
    public class Util
    {
        /// <summary>
        /// Ensures your number to have at least _digits_ digits
        /// </summary>
        public static string Digits(int integer, int digits = 3)
        {
            if (integer.ToString().Length >= digits) return integer.ToString();
            string ret = "";
            for (int i = 0; i < digits - integer.ToString().Length; i++)
            {
                ret += "0";
            }
            return ret + integer.ToString();
        }
    }
}
