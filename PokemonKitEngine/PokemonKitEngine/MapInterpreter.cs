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
        public static Dictionary<string, dynamic> ParseMap(int id)
        {
            
            Dictionary<string, dynamic> data = new Dictionary<string, dynamic>();
            data["layers"] = new List<dynamic>();
            data["general"] = new Dictionary<string, dynamic>();

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
            List<List<dynamic>> Layers = new List<List<dynamic>>();
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
                            int Data = Convert.ToInt32(_tile[k].ToString());
                            Tile.Add(Data);
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

            return data;
        }
    }

    public class Map
    {
        public List<List<dynamic>> Layers { get; set; }
        public General General { get; set; }

        public Map(List<List<dynamic>> Layers, General General)
        {
            this.Layers = Layers;
            this.General = General;
        }
    }

    public class General
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Tileset { get; set; }
    }
}
