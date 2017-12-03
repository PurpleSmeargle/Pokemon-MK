using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronRuby;
using System.IO;
using static PokemonEngine.Util;

namespace PokemonEngine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Setting the working directory to the root folder instead of this application's
            List<string> Path = Application.StartupPath.Split('\\').ToList();
            Path.RemoveAt(Path.Count - 1);
            Path.RemoveAt(Path.Count - 1);
            Path.RemoveAt(Path.Count - 1);
            Path.RemoveAt(Path.Count - 1);
            string ret = "";
            foreach (string obj in Path)
            {
                ret += obj + "\\";
            }
            ret = ret.Remove(ret.Length - 1);
            Directory.SetCurrentDirectory(ret);


            Map CurrentMap = MapInterpreter.Parse(1);

            tilesetBox.Image = Image.FromFile($@"Graphics\Tilesets\{CurrentMap.General.Tileset}.png");
            tilesetBox.SizeMode = PictureBoxSizeMode.AutoSize;
            tilesetPanel.Width = tilesetBox.Image.Width + 20;
            tilesetBlack.Width = tilesetBox.Image.Width + 20;
            tilesetWhite.Width = tilesetBox.Image.Width + 18;
            tilesetBoxPanel.Width = tilesetBox.Image.Width + 17;

            mapBox.Image = (Image) tilesetBox.Image.Clone();

            UpdatePanels();
        }

        /// <summary>
        /// Resizes all panels and boxes according to the screensize.
        /// </summary>
        public void UpdatePanels()
        {
            // Make it work with all screensizes
        }
    }
}