using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronRuby;
using Microsoft.Scripting.Hosting;
using static PokemonEngine.Util;
using System.IO;

namespace PokemonEngine
{
    public class MapInterpreter
   { 
        /// <summary>
        /// Loads a map data file based on ID and parses it to C# object.
        /// </summary>
        public static Map Parse(int id)
        {
            Dictionary<string, dynamic> Data = new Dictionary<string, dynamic>();
            List<List<dynamic>> Layers = new List<List<dynamic>>();

            ScriptEngine engine = Ruby.CreateEngine();
            dynamic ret = engine.Execute($@"
f = File.open(""Maps/{Digits(id)}.mkd"", ""rb"")
Data = Marshal.load(f)
f.close
return [Data[0],Data[1..-1]]");

            // Parses the Layer data to C# objects (in Lists instead of Arrays)
            dynamic[] _layers = ret[1].ToArray();
            for (int i = 0; i < _layers.Length; i++)
            {
                List<dynamic> Layer = new List<dynamic>();
                dynamic[] _layer = ((IronRuby.Builtins.RubyArray) _layers[i]).ToArray();
                for (int j = 0; j < _layer.Length; j++)
                {
                    if (_layer[j] is IronRuby.Builtins.RubyArray)
                    {
                        dynamic[] _tile = ((IronRuby.Builtins.RubyArray) _layer[j]).ToArray();
                        List<dynamic> Tile = new List<dynamic>();
                        for (int k = 0; k < _tile.Length; k++)
                        {
                            int TileData = Convert.ToInt32(_tile[k].ToString());
                            Tile.Add(TileData);
                        }
                        Layer.Add(Tile);
                    }
                    else
                    {
                        Layer.Add(Convert.ToInt32(_layer[j].ToString()));
                    }
                }
                Layers.Add(Layer);
            }

            int Width = Convert.ToInt32(ret[0][0].ToString());
            int Height = Convert.ToInt32(ret[0][1].ToString());
            string Tileset = ret[0][2].ToString();
            string Name = ret[0][3].ToString();

            return new Map(id, Layers, Width, Height, Tileset, Name);
        }
    }

    public class Map
    {
        /// <summary>
        /// Isn't stored in the map data file itself, but uses the filename to determine its ID.
        /// </summary>
        public int ID { get; set; }
        public List<List<dynamic>> Layers { get; set; }
        public List<System.Drawing.Bitmap> VisualLayers { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Tileset { get; set; }
        public string Name { get; set; }

        public Map(int ID, List<List<dynamic>> Layers, int Width, int Height, string Tileset, string Name)
        {
            this.ID = ID;
            this.Layers = Layers;
            this.Width = Width;
            this.Height = Height;
            this.Tileset = Tileset;
            this.Name = Name;
        }

        public bool Update(int OldWidth, int OldHeight)
        {
            int WidthDiff = Math.Abs(Width - OldWidth);
            int HeightDiff = Math.Abs(Height - OldHeight);
            List<List<dynamic>> NewLayers = new List<List<dynamic>>();
            foreach (List<dynamic> Layer in Layers)
            {
                List<dynamic> NewLayer = new List<dynamic>();
                for (int i = 0; i < Layer.Count; i++)
                {
                    if (Width > OldWidth)
                    {
                        NewLayer.Add(Layer[i]);
                        if (i % OldWidth == OldWidth - 1) { for (int n = 0; n < WidthDiff; n++) { NewLayer.Add(0); } }
                    }
                    else if (Width < OldWidth)
                    {
                        if (i % OldWidth < OldWidth - WidthDiff) { NewLayer.Add(Layer[i]); }
                    }
                    else
                    {
                        NewLayer.Add(Layer[i]);
                    }
                }
                if (Height > OldHeight) for (int n = 0; n < HeightDiff; n++) { for (int k = 0; k < Width; k++) { NewLayer.Add(0); } }
                else if (Height < OldHeight) NewLayer.RemoveRange(Width * (Height - 1), Width * (OldHeight - Height));
                NewLayers.Add(NewLayer);
            }
            // Whether or not the map should be redrawn
            bool ret = (Layers[0].Count != NewLayers[0].Count);
            Layers = NewLayers;
            return ret;
        }
    }
}
