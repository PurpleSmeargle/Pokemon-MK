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

        public static bool Empty(object obj)
        {
            if (obj == null) return true;
            if (obj is string && (((string) obj).Length == 0 || (string) obj == "")) return true;
            return false;
        }

        public static string ColorToString(System.Drawing.Color Color)
        {
            return $"{Color.A},{Color.R},{Color.G},{Color.B}";
        }

        public static System.Drawing.Color StringToColor(string Color)
        {
            List<string> Nums = Color.Split(',').ToList();
            return System.Drawing.Color.FromArgb(Convert.ToInt32(Nums[0]), Convert.ToInt32(Nums[1]),
                Convert.ToInt32(Nums[2]), Convert.ToInt32(Nums[3]));
        }
    }
}
