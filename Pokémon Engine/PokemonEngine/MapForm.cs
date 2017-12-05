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
        public bool ShouldUpdate = false;

        Map CurrentMap;
        string OldName;
        string OldTileset;
        int OldWidth;
        int OldHeight;

        BindingSource tilesetBinder = new BindingSource();

        public MapForm(Map CurrentMap)
        {
            InitializeComponent();
            this.CurrentMap = CurrentMap;
            this.OldName = CurrentMap.General.Name;
            this.OldTileset = CurrentMap.General.Tileset;
            this.OldWidth = CurrentMap.General.Width;
            this.OldHeight = CurrentMap.General.Height;
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

            nameBox.Text = CurrentMap.General.Name;
            tilesetBox.Text = CurrentMap.General.Tileset;
            widthBox.Value = CurrentMap.General.Width;
            heightBox.Value = CurrentMap.General.Height;
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            CurrentMap.General.Name = nameBox.Text;
        }

        private void tilesetBox_TextChanged(object sender, EventArgs e)
        {
            CurrentMap.General.Tileset = tilesetBox.Text;
        }

        private void widthBox_ValueChanged(object sender, EventArgs e)
        {
            CurrentMap.General.Width = (int) widthBox.Value;
        }

        private void heightBox_ValueChanged(object sender, EventArgs e)
        {
            CurrentMap.General.Height = (int) heightBox.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentMap.General.Name = OldName;
            CurrentMap.General.Tileset = OldTileset;
            CurrentMap.General.Width = OldWidth;
            CurrentMap.General.Height = OldHeight;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShouldUpdate = CurrentMap.Update(OldWidth, OldHeight);
            Close();
        }
    }
}
