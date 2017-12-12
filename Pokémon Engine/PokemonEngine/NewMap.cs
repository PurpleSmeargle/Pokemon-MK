using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonEngine
{
    public partial class NewMap : Form
    {
        public new bool Created = false;
        public Map Map;
        int ID;

        List<string> Tilesets = new List<string>();
        BindingSource tilesetBinder = new BindingSource();

        public NewMap(int ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void create_Click(object sender, EventArgs e)
        {
            Created = true;
            string Name = nameBox.Text;
            string Tileset = tilesetBox.Text;
            int Width = (int) widthBox.Value;
            int Height = (int) heightBox.Value;
            List<List<dynamic>> Layers = new List<List<dynamic>>();
            for (int n = 0; n < 7; n++)
            {
                List<dynamic> Layer = new List<dynamic>();
                for (int i = 0; i < Width + Height * Width; i++)
                {
                    Layer.Add(0);
                }
                Layers.Add(Layer);
            }
            Map = new Map(ID, Layers, Width, Height, Tileset, Name);
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewMap_Load(object sender, EventArgs e)
        {
            foreach (string file in System.IO.Directory.GetFiles(@"Graphics\Tilesets"))
            {
                string Tileset = file;
                List<string> _ = Tileset.Split('\\').Last().Split('.').ToList();
                _.RemoveAt(_.Count - 1);
                Tileset = null;
                for (int i = 0; i < _.Count; i++)
                {
                    Tileset += _[i];
                    if (i != _.Count - 1) Tileset += ".";
                }
                Tilesets.Add(Tileset);
            }
            tilesetBinder.DataSource = Tilesets;
            tilesetBox.DataSource = tilesetBinder;
            tilesetBox.DisplayMember = "Name";
        }
    }
}
