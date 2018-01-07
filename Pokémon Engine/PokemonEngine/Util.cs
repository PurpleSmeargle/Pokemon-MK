using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEngine
{
    public class DirectBitmap : IDisposable
    {
        public System.Drawing.Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        protected System.Runtime.InteropServices.GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            this.Bits = new Int32[this.Width * this.Height];
            this.BitsHandle = System.Runtime.InteropServices.GCHandle.Alloc(this.Bits,
                System.Runtime.InteropServices.GCHandleType.Pinned);
            this.Bitmap = new System.Drawing.Bitmap(this.Width, this.Height, this.Width * 4,
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }

        public System.Drawing.Color GetPixel(int x, int y)
        {
            return System.Drawing.Color.FromArgb(this.Bits[x + y * this.Width]);
        }

        public void SetPixel(int x, int y, System.Drawing.Color Color)
        {
            this.Bits[x + y * this.Width] = Color.ToArgb();
        }
    }

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
