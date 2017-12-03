using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronRuby;
using Microsoft.Scripting.Hosting;
using static PokemonKitEngine.Util;
using System.IO;

namespace PokemonKitEngine
{
    public class MapInterpreter
    {
        /// <summary>
        /// Loads a map data file based on ID and parses it to C# object.
        /// </summary>
        public static Map Parse(int id)
        {
            Dictionary<string, dynamic> Data = new Dictionary<string, dynamic>();
            Data["layers"] = new List<List<dynamic>>();
            Data["general"] = new General();

            ScriptEngine engine = Ruby.CreateEngine();
            dynamic ret = engine.Execute($@"
f = File.open(""Maps/{Digits(id)}.dat"", ""rb"")
Data = Marshal.load(f)
f.close

New = {{}}

New[""layers""] = Data[:layers]

for key in Data[:general].keys
  New[""general""] ||= {{}}
  New[""general""][key.to_s] = Data[:general][key]
end

return New

");

            // Parses the Layer data to C# objects (in Lists instead of Arrays)
            dynamic[] _layers = ret["layers"].ToArray();
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
                Data["layers"].Add(Layer);
            }

            Data["general"].Width = Convert.ToInt32(ret["general"]["width"].ToString());
            Data["general"].Height = Convert.ToInt32(ret["general"]["height"].ToString());
            Data["general"].Tileset = ret["general"]["tileset"].ToString();
            Data["general"].Name = ret["general"]["name"].ToString();

            return new Map(id, Data["layers"], Data["general"]);
        }
    }

    public class Map
    {
        /// <summary>
        /// Isn't stored in the map data file itself, but uses the filename to determine its ID.
        /// </summary>
        public int ID { get; set; }
        public List<List<dynamic>> Layers { get; set; }
        public General General { get; set; }

        public Map(int ID, List<List<dynamic>> Layers, General General)
        {
            this.ID = ID;
            this.Layers = Layers;
            this.General = General;
        }
    }

    public class General
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Tileset { get; set; }
        public string Name { get; set; }
    }
}
