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
        Map CurrentMap;

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

            CurrentMap = MapInterpreter.Parse(1);
            LoadMap();

            UpdatePanels();
        }

        /// <summary>
        /// Resizes all panels and boxes according to the screensize.
        /// </summary>
        public void UpdatePanels()
        {
            // Make it work with all screensizes
        }

        /// <summary>
        /// Makes the map the active map by drawing it to the main screen and displaying the proper tileset.
        /// </summary>
        public void LoadMap(Map Map = null)
        {
            if (Map == null) Map = CurrentMap;

            foreach (Control c in Controls)
            {
                if (c.Name.StartsWith("mapLayer"))
                {
                    c.Dispose();
                    Controls.RemoveByKey(c.Name);
                }
            }

            CurrentMap = Map;

            Bitmap Tileset = new Bitmap(new FileStream($@"Graphics\Tilesets\{CurrentMap.General.Tileset}.png", FileMode.Open));

            tilesetBox.Image = Tileset;
            tilesetBox.SizeMode = PictureBoxSizeMode.AutoSize;
            tilesetPanel.Width = Tileset.Width + 20;
            tilesetBlack.Width = Tileset.Width + 20;
            tilesetWhite.Width = Tileset.Width + 18;
            tilesetBoxPanel.Width = Tileset.Width + 17;

            int Width = CurrentMap.General.Width;
            int Height = CurrentMap.General.Height;

            for (int i = 0; i < CurrentMap.Layers.Count; i++)
            {
                PictureBox layer = new PictureBox();
                layer.Name = $"mapLayer{i}";
                layer.Location = new Point(0, 0);
                layer.Size = mapBoxPanel.Size;
                layer.BackColor = Color.Transparent;
                Image LayerBitmap = new Bitmap(Width * 32, Height * 32);
                Graphics g = Graphics.FromImage(LayerBitmap);
                for (int k = 0; k < CurrentMap.Layers[i].Count; k++)
                {
                    object Tile = CurrentMap.Layers[i][k];
                    int TileID = 0;
                    if (Tile is int)
                    {
                        TileID = (int) Tile;
                    }
                    else
                    {
                        TileID = (int) ((List<dynamic>) Tile)[0];
                    }
                    if (TileID == 0) continue;
                    Bitmap TileBitmap = new Bitmap(32, 32);
                    int RealTilesetX = (TileID % 8) * 32;
                    int RealTilesetY = (int) Math.Floor((double) TileID / 8) * 32;
                    for (int x = RealTilesetX; x < RealTilesetX + 32; x++)
                    {
                        for (int y = RealTilesetY; y < RealTilesetY + 32; y++)
                        {
                            TileBitmap.SetPixel(x - RealTilesetX, y - RealTilesetY, Tileset.GetPixel(x, y));
                        }
                    }

                    int RealX = (k % Width) * 32;
                    int RealY = (int) Math.Floor((double) k / Width) * 32;
                    g.DrawImage(TileBitmap, RealX, RealY);
                }
                layer.BackgroundImage = LayerBitmap;
                layer.BackgroundImageLayout = ImageLayout.None;
                mapBoxPanel.Controls.Add(layer);
            }
            for (int i = CurrentMap.Layers.Count - 1; i > 0; i--)
            {
                mapBoxPanel.Controls[$"mapLayer{i - 1}"].Controls.Add(mapBoxPanel.Controls[$"mapLayer{i}"]);
            }
        }
    }
}