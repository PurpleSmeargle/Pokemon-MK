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
using FastColoredTextBoxNS;
using System.Text.RegularExpressions;

namespace PokemonEngine
{
    public partial class MainForm : Form
    {
        PictureBox Cursor;
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

            Cursor = new PictureBox();
            Cursor.Location = new Point(0, 0);
            Cursor.Image = Properties.Resources.cursor;
            Cursor.SizeMode = PictureBoxSizeMode.AutoSize;
            tilesetBoxPanel.Controls.Add(Cursor);
            Cursor.BackColor = Color.Transparent;
            tilesetBox.Controls.Add(Cursor);

            #region Script Editor
            FastColoredTextBox txt = new FastColoredTextBox();
            txt.Name = "scriptEditor";
            txt.Dock = DockStyle.Fill;
            txt.TextChanged += scriptEditor_TextChanged;
            txt.AutoIndentNeeded += scriptEditor_AutoIndentNeeded;
            txt.TabLength = 2;
            txt.KeyDown += Txt_KeyDown;
            DocumentMap DocumentMap = new DocumentMap();
            DocumentMap.Target = txt;
            scriptEditorPanel.Controls.Add(txt);
            #endregion
        }

        #region Script Editor

        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.V)
                {
                    scriptEditor_TextChanged(sender, new TextChangedEventArgs(((FastColoredTextBox) sender).VisibleRange));
                    MessageBox.Show(((FastColoredTextBox) sender).Text);
                    Console.WriteLine("Ctrl + V");
                }
                else if (e.KeyCode == Keys.T)
                {
                    Console.WriteLine("Ctrl + T");
                    FastColoredTextBox box = sender as FastColoredTextBox;
                    int iChar = box.Selection.Start.iChar;
                    int iLine = box.Selection.Start.iLine;
                    if (iLine == 0) return;
                    List<string> Lines = box.Lines.ToList();
                    string tmp = box.GetLineText(iLine);
                    Lines[iLine] = Lines[iLine - 1];
                    Lines[iLine - 1] = tmp;
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < Lines.Count; i++)
                    {
                        if (i == Lines.Count - 1) sb.Append(Lines[i]);
                        else sb.AppendLine(Lines[i]);
                    }
                    box.Text = sb.ToString();
                    box.Selection.Start = new Place(iChar, iLine - 1);
                }
            }
        }

        private void scriptEditor_AutoIndentNeeded(object sender, AutoIndentEventArgs e)
        {
            string LineText = e.LineText.Trim().Split('#')[0];
            List<string> Indents = new List<string>() { "class ", "module ", "def ", "rescue", "do ", "for ", "while ", "when ", "until", "if" };
            foreach (string Entry in Indents)
            {
                if (LineText.Contains(Entry))
                {
                    e.ShiftNextLines = e.TabLength;
                    return;
                }
            }
            if (LineText.Contains("begin") && !LineText.Contains("=begin"))
            {
                e.ShiftNextLines = e.TabLength;
                return;
            }
        }

        Style Comment = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        Style Keyword = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        Style Method = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        Style Operator = new TextStyle(Brushes.CornflowerBlue, null, FontStyle.Regular);
        Style Integer = new TextStyle(Brushes.IndianRed, null, FontStyle.Regular);
        Style String = new TextStyle(Brushes.DeepPink, null, FontStyle.Regular);

        private void scriptEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            FastColoredTextBox box = (FastColoredTextBox)sender;
            // Only the changed text
            Range range = e.ChangedRange;

            range.ClearStyle(Keyword);
            range.ClearStyle(Comment);
            range.ClearStyle(Method);
            range.ClearStyle(Operator);
            range.ClearStyle(Integer);
            range.ClearStyle(String);

            range.SetStyle(Comment, @"#[^{].*$", RegexOptions.Multiline);
            range.SetStyle(Keyword, @"\b(alias|and|begin|break|case|class|def|do|else|elsif|end|ensure|false|for|if|in|module|" +
                                                @"next|nil|not|or|redo|rescue|retry|return|self|super|then|true|undef|unless|until|when|while|yield)\b", RegexOptions.Multiline);
            range.SetStyle(Method, @"\b(BEGIN|END|_ENCODING_|_LINE_|_FILE_|defined?|_END_)\b", RegexOptions.Multiline);

            range.SetStyle(Operator, @"(=|\*|&|-|\+|%|/|!|\||~|<|>|\?|:|;|\{\}|\[\])", RegexOptions.Multiline);

            range.SetStyle(Integer, @"\b\d+\b", RegexOptions.Multiline);

            range = ((FastColoredTextBox)sender).VisibleRange;

            range.SetStyle(Comment, "=begin.*?=end", RegexOptions.Singleline);

            range.SetStyle(String, "\".*?\"", RegexOptions.Singleline);
            range.SetStyle(String, "'.*?'", RegexOptions.Singleline);

            box.AddStyle(Method);
            box.AddStyle(Keyword);
            box.AddStyle(Operator);
            box.AddStyle(Integer);
            box.AddStyle(String);
            box.AddStyle(Comment);
        }
        #endregion

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

            foreach (Control c in mapBoxPanel.Controls)
            {
                if (c.Name.StartsWith("mapLayer"))
                {
                    c.Dispose();
                    Controls.RemoveByKey(c.Name);
                }
            }

            CurrentMap = Map;

            FileStream fs = new FileStream($@"Graphics\Tilesets\{CurrentMap.General.Tileset}.png", FileMode.Open);
            Bitmap Tileset = new Bitmap(fs);
            fs.Close();

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

        private void tilesetBox_MouseDown(object sender, MouseEventArgs e)
        {
            Cursor.Location = new Point(32 * (int) Math.Floor((double) e.X / 32), 32 * (int) Math.Floor((double) e.Y / 32));
        }

        public int GetTileID()
        {
            return (Cursor.Location.X / 32) + 8 * (Cursor.Location.Y / 32);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Ruby.CreateEngine().Execute(scriptEditorPanel.Controls["scriptEditor"].Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void aboutThisMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapForm mf = new MapForm(CurrentMap);
            mf.ShowDialog();
            // If width/height changed and it needs to be redrawn
            if (mf.ShouldUpdate)
            {
                LoadMap();
            }
        }
    }
}