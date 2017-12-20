using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonEngine
{
    public class MapTreeNode : TreeNode
    {
        public int ID = 0;

        public MapTreeNode(int ID, string Text)
        {
            this.ID = ID;
            this.Text = Text;
        }
    }
}
