using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonEngine
{
    public class Script
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public Script(string Name, string Code)
        {
            this.Name = Name;
            this.Code = Code;
        }
    }
}
