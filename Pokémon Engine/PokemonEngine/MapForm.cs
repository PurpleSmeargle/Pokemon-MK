using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonEngine
{
    public partial class MapForm : Form
    {
        public bool UpdateMap = false;
        public bool UpdateName = false;
        PictureBox MapBox;

        Map CurrentMap;
        string OldName;
        string OldTileset;
        int OldWidth;
        int OldHeight;

        bool Starting = true;

        BindingSource tilesetBinder = new BindingSource();

        public MapForm(Map CurrentMap, PictureBox MapBox)
        {
            InitializeComponent();
            this.CurrentMap = CurrentMap;
            this.OldName = CurrentMap.Name;
            this.OldTileset = CurrentMap.Tileset;
            this.OldWidth = CurrentMap.Width;
            this.OldHeight = CurrentMap.Height;
            this.MapBox = MapBox;
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            List<string> Tilesets = new List<string>();
            foreach (string file in Directory.GetFiles(@"Graphics\Tilesets"))
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

            nameBox.Text = CurrentMap.Name;
            tilesetBox.Text = CurrentMap.Tileset;
            widthBox.Value = CurrentMap.Width;
            heightBox.Value = CurrentMap.Height;

            Starting = false;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            CurrentMap.Name = nameBox.Text;
        }

        private void tilesetBox_TextChanged(object sender, EventArgs e)
        {
            if (Starting) return;
            CurrentMap.Tileset = tilesetBox.Text;
        }

        private void widthBox_ValueChanged(object sender, EventArgs e)
        {
            CurrentMap.Width = (int) widthBox.Value;
        }

        private void heightBox_ValueChanged(object sender, EventArgs e)
        {
            CurrentMap.Height = (int) heightBox.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentMap.Name = OldName;
            CurrentMap.Tileset = OldTileset;
            CurrentMap.Width = OldWidth;
            CurrentMap.Height = OldHeight;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveControl = button2;
            MapBox.UseWaitCursor = true;
            UpdateMap = CurrentMap.Update(OldWidth, OldHeight);
            UpdateName = (OldName != CurrentMap.Name);
            MapBox.UseWaitCursor = false;
            Close();
        }
    }
}
