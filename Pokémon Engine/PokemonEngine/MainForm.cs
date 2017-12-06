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
using System.Diagnostics;

namespace PokemonEngine
{
    public partial class MainForm : Form
    {
        new PictureBox Cursor;
        Map CurrentMap;

        // Whether or not the engine is still starting up
        bool Starting = true;
        bool MadeChanges = false;

        BindingSource scriptBinder = new BindingSource();
        List<Script> Scripts = new List<Script>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            #region Setting Current Working Directory
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
            #endregion

            CurrentMap = MapInterpreter.Parse(1);

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

            List<string> ScriptFiles = new List<string>();
            foreach (string file in Directory.GetFiles("Scripts"))
            {
                if (Regex.IsMatch(file, @"\d+-") && file.EndsWith(".rb"))
                {
                    ScriptFiles.Add(file.Split('\\').Last());
                    Scripts.Add(new Script(null, null));
                }
            }
            for (int i = 0; i < ScriptFiles.Count; i++)
            {
                List<string> tmp1 = ScriptFiles[i].Split('.').ToList();
                string Extensionless = "";
                for (int j = 0; j < tmp1.Count - 1; j++)
                {
                    Extensionless += tmp1[j];
                    if (j != tmp1.Count - 2) Extensionless += ".";
                }
                List<string> tmp2 = Extensionless.Split('-').ToList();
                int Index = Convert.ToInt32(tmp2[0]) - 1;
                string Name = "";
                for (int j = 1; j < tmp2.Count; j++)
                {
                    Name += tmp2[j];
                    if (j != tmp2.Count - 1) Name += "-";
                }
                StreamReader sr = new StreamReader(File.OpenRead(@"Scripts\" + ScriptFiles[i]));
                string Code = sr.ReadToEnd();
                sr.Close();
                Scripts[Index] = new Script(Name, Code);
            }
            scriptBinder.DataSource = Scripts;
            scriptBox.DataSource = scriptBinder;
            scriptBox.DisplayMember = "Name";

            LoadMap();

            MainForm_SizeChanged(sender, e);

            scriptBox.SelectedIndex = 0;

            Starting = false;

            scriptBox_SelectedIndexChanged(sender, e);
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
            if (Regex.IsMatch(LineText, $@"\b(class|module|def|rescue|do|for|while|when|until|if)\b"))
            {
                e.ShiftNextLines = e.TabLength;
                return;
            }
            if (Regex.IsMatch(LineText, @"\bbegin\b") && !Regex.IsMatch(LineText, @"=begin\b") && !Regex.IsMatch(LineText, @".begin\b") && 
               !Regex.IsMatch(LineText, @"_begin\b"))
            {
                e.ShiftNextLines = e.TabLength;
                return;
            }
        }

        Style Comment = new TextStyle(Brushes.Green, null, FontStyle.Italic);
        Style Keyword = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        Style Method = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        Style Operator = new TextStyle(Brushes.CornflowerBlue, null, FontStyle.Regular);
        Style Integer = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        Style String = new TextStyle(Brushes.Purple, null, FontStyle.Regular);

        private void scriptEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            FastColoredTextBox box = (FastColoredTextBox) sender;
            // Only the changed text
            Range range = e.ChangedRange;

            range.ClearStyle(Keyword, Comment, Method, Operator, Integer, String);

            range.SetStyle(Keyword, @"\b(alias|and|begin|break|case|class|def|do|else|elsif|end|ensure|false|for|if|in|module|" +
                                                @"next|nil|not|or|redo|rescue|retry|return|self|super|then|true|undef|unless|until|when|while|yield)\b", RegexOptions.Multiline);
            range.SetStyle(Method, @"\b(BEGIN|END|_ENCODING_|_LINE_|_FILE_|defined?|_END_)\b", RegexOptions.Multiline);

            range.SetStyle(Operator, @"(=|\*|&|-|\+|%|/|!|\||~|<|>|\b\?|:|;|{|}|\[|\]|\(|\)|,|\.)", RegexOptions.Multiline);

            range.SetStyle(Integer, @"\b(\d+|\d+x[0123456789ABCDEF]*)\b|", RegexOptions.Multiline);

            range = ((FastColoredTextBox) sender).Range;

            range.SetStyle(Comment, "=begin.*?=end", RegexOptions.Singleline);

            string RangeText = range.Text;
            string[] Lines = RangeText.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            List<Range> DoubleStringMatches = range.GetRanges("\".*?\"", RegexOptions.Singleline).ToList();
            foreach (Range r in DoubleStringMatches)
            {
                r.ClearStyle(Method, Keyword, Operator, Integer, Comment);
                r.SetStyle(String);
            }
            List<Range> SingleStringMatches = range.GetRanges("'.*?'", RegexOptions.Singleline).ToList();
            foreach (Range r in SingleStringMatches)
            {
                r.ClearStyle(Method, Keyword, Operator, Integer, Comment);
                r.SetStyle(String);
            }

            List<Range> CommentMatches = range.GetRanges(@"#[^{].*$", RegexOptions.Multiline).ToList();
            foreach (Range r in CommentMatches)
            {
                r.ClearStyle(Keyword, Method, Operator, Integer, String);
                r.SetStyle(Comment);
            }

            box.AddStyle(Method);
            box.AddStyle(Keyword);
            box.AddStyle(Operator);
            box.AddStyle(Integer);
            box.AddStyle(String);
            box.AddStyle(Comment);

            if (Scripts[scriptBox.SelectedIndex].Code != box.Text) MadeChanges = true;
            Scripts[scriptBox.SelectedIndex].Code = box.Text;
        }
        #endregion
        /// <summary>
        /// Resizes all panels and boxes to match the screensize.
        /// </summary>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            mainTabControl.Location = new Point(0, 52);
            mainTabControl.Size = new Size(Width - 2, Height - 56);
            tilesetBoxPanel.Size = new Size(tilesetBoxPanel.Width, mainTabControl.Height - tilesetBoxPanel.Location.Y - mainTabControl.Location.Y - 47);
            tilesetWhite.Size = new Size(tilesetWhite.Width, mainTabControl.Height - tilesetWhite.Location.Y - mainTabControl.Location.Y - 46);
            tilesetBlack.Size = new Size(tilesetBlack.Width, mainTabControl.Height - tilesetBlack.Location.Y - mainTabControl.Location.Y - 45);
            mapBoxPanel.Size = new Size(32 * CurrentMap.General.Width, 32 * CurrentMap.General.Height);
            mapWhite.Size = new Size(Width - tilesetPanel.Width - rightPanel.Width - 26, mainTabControl.Height - mapBlack.Location.Y - mainTabControl.Location.Y - 47);
            mapBlack.Size = new Size(Width - tilesetPanel.Width - rightPanel.Width - 24, mainTabControl.Height - mapBlack.Location.Y - mainTabControl.Location.Y - 45);
            rightPanelSplitter.SplitterDistance = mainTabControl.Height / 3;
            tileBlack.Size = new Size(tilePanel.Width - 13, tilePanel.Height);
            tileWhite.Size = new Size(tilePanel.Width - 15, tilePanel.Height - 2);
            allMapsBlack.Size = new Size(allMapsPanel.Width - 13, allMapsPanel.Height - 35);
            allMapsWhite.Size = new Size(allMapsPanel.Width - 15, allMapsPanel.Height - 37);
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

        private void scriptBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Starting) return;
            scriptNameBox.Text = Scripts[scriptBox.SelectedIndex].Name;
            scriptEditorPanel.Controls["scriptEditor"].Text = Scripts[scriptBox.SelectedIndex].Code;
            scriptEditor_TextChanged(scriptEditorPanel.Controls["scriptEditor"],
                new TextChangedEventArgs(((FastColoredTextBox) scriptEditorPanel.Controls["scriptEditor"]).Range));
            Config.LastScriptIndex = scriptBox.SelectedIndex;
        }

        private void scriptNameBox_TextChanged(object sender, EventArgs e)
        {
            string Name = scriptNameBox.Text;
            List<string> Invalid = new List<string>() { "\\", "/", ":", "*", "?", "\"", "<", ">", "|" };
            foreach (string s in Invalid)
            {
                while (Name.Contains(s))
                {
                    Name = Name.Replace(s, "");
                }
            }
            if (Scripts[scriptBox.SelectedIndex].Name != Name) MadeChanges = true;
            Scripts[scriptBox.SelectedIndex].Name = Name;
            scriptNameBox.Text = Name;
            scriptBinder.ResetBindings(false);
        }

        private void scriptBox_MouseClick(object sender, MouseEventArgs e)
        {
            // Implement right-click stuff
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("Scripts")) Directory.CreateDirectory("Scripts");
            foreach (string file in Directory.GetFiles("Scripts")) { File.Delete(file); }
            StreamWriter stwr = new StreamWriter(File.OpenWrite(@"Scripts\entry.rb"));
            stwr.Write(
@"$LOAD_PATH << "".""
Dir.glob(""Scripts/*.rb"") { |f| require f }");
            stwr.Close();
            int ExtraDigits = Scripts.Count.ToString().Length;
            for (int i = 0; i < Scripts.Count; i++)
            {
                string Name = $"{Digits(i + 1, ExtraDigits)}-{Scripts[i].Name}.rb";
                StreamWriter sw = new StreamWriter(File.OpenWrite(@"Scripts\" + Name));
                sw.Write(Scripts[i].Code);
                sw.Close();
            }
            MadeChanges = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MadeChanges)
            {
                DialogResult result = MessageBox.Show("Save changes before closing?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, new EventArgs());
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
            System.Threading.Thread.Sleep(100);
            Process.Start("mkxp.exe");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            playToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }
    }
}