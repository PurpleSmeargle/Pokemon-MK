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
using System.Drawing.Imaging;
using Microsoft.Scripting.Hosting;

namespace PokemonEngine
{
    public partial class MainForm : Form
    {
        PictureBox TilesetCursor;
        Bitmap Tileset;
        PictureBox MapBox;
        Map CurrentMap;

        Script ScriptClipboard;

        int CurrentLayer = 1;
        int CursorX = 0;
        int CursorY = 0;
        bool LeftMouse = false;
        bool RightMouse = false;
        bool MiddleMouse = false;

        List<Bitmap> Layers = new List<Bitmap>();
        Bitmap Black;
        Bitmap Grid;
        Bitmap Overlay;

        List<Map> Maps = new List<Map>();

        // Whether or not the engine is still starting up
        bool Starting = true;
        bool MadeChanges = false;
        string TilesetPath = null;

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

            TilesetCursor = new PictureBox();
            TilesetCursor.Location = new Point(0, 0);
            TilesetCursor.Image = Properties.Resources.cursor;
            TilesetCursor.Width = TilesetCursor.Image.Width;
            TilesetCursor.Height = TilesetCursor.Image.Height;
            TilesetCursor.SizeMode = PictureBoxSizeMode.AutoSize;
            tilesetBoxPanel.Controls.Add(TilesetCursor);
            TilesetCursor.BackColor = Color.Transparent;
            tilesetBox.Controls.Add(TilesetCursor);

            #region Script Editor
            FastColoredTextBox txt = new FastColoredTextBox();
            txt.Name = "scriptEditor";
            txt.TextChanged += scriptEditor_TextChanged;
            txt.AutoIndentNeeded += scriptEditor_AutoIndentNeeded;
            txt.TabLength = 2;
            txt.KeyDown += Txt_KeyDown;
            DocumentMap DocumentMap = new DocumentMap();
            DocumentMap.Target = txt;
            scriptEditorPanel.Controls.Add(txt);
            #endregion

            #region Script Files
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
            #endregion

            // Load MKXP Config
            #region Load MKXP Config
            if (File.Exists("mkxp.conf"))
            {
                StreamReader sr = new StreamReader(File.OpenRead("mkxp.conf"));
                string data = sr.ReadToEnd();
                sr.Close();
                List<string> Lines = data.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList();
                data = null;
                for (int i = 0; i < Lines.Count; i++)
                {
                    if (Lines[i].StartsWith("#")) continue;
                    data += Lines[i];
                    if (i != Lines.Count - 1) data += "\r\n";
                }
                // Compatibility with other line endings
                while (data.Contains("\r")) { data = data.Replace("\r", ""); }
                if (data.Contains("rgssVersion=")) { Config.RGSSVersion = Convert.ToInt32(data.Split(new string[] { "rgssVersion=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("debugMode=")) { Config._DebugMode = Convert.ToBoolean(data.Split(new string[] { "debugMode=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("printFPS=")) { Config.PrintFPS = Convert.ToBoolean(data.Split(new string[] { "printFPS=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("winResizable=")) { Config._WinResizable = Convert.ToBoolean(data.Split(new string[] { "winResizable=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("fullscreen=")) { Config.StartFullscreen = Convert.ToBoolean(data.Split(new string[] { "fullscreen=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("fixedAspectRatio=")) { Config.FixedAspectRatio = Convert.ToBoolean(data.Split(new string[] { "fixedAspectRatio=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("smoothScaling=")) { Config.SmoothScaling = Convert.ToBoolean(data.Split(new string[] { "smoothScaling=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("vsync=")) { Config._VSync = Convert.ToBoolean(data.Split(new string[] { "vsync=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("defScreenW=")) { Config.ScreenWidth = Convert.ToInt32(data.Split(new string[] { "defScreenW=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("defScreenH=")) { Config.ScreenHeight = Convert.ToInt32(data.Split(new string[] { "defScreenH=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("windowTitle=")) { Config.WindowTitle = data.Split(new string[] { "windowTitle=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("fixedFramerate=")) { Config.FixedFramerate = Convert.ToInt32(data.Split(new string[] { "fixedFramerate=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("frameSkip=")) { Config._FrameSkip = Convert.ToBoolean(data.Split(new string[] { "frameSkip=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("syncToRefreshrate=")) { Config._SyncToRefreshRate = Convert.ToBoolean(data.Split(new string[] { "syncToRefreshrate=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("solidFonts=")) { Config._SolidFonts = Convert.ToBoolean(data.Split(new string[] { "solidFonts=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("subImageFix=")) { Config._SubImageFix = Convert.ToBoolean(data.Split(new string[] { "subImageFix=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("enableBlitting=")) { Config._EnableBlitting = Convert.ToBoolean(data.Split(new string[] { "enableBlitting=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("maxTextureSize=")) { Config._MaxTextureSize = data.Split(new string[] { "maxTextureSize=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("gameFolder=")) { Config._GameFolder = data.Split(new string[] { "gameFolder=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("anyAltToggleFS=")) { Config._AnyAltToggleFS = Convert.ToBoolean(data.Split(new string[] { "anyAltToggleFS=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("enableReset=")) { Config.F12SoftReset = Convert.ToBoolean(data.Split(new string[] { "enableReset=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("allowSymlinks=")) { Config._AllowSymLinks = Convert.ToBoolean(data.Split(new string[] { "allowSymlinks=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("dataPathOrg=")) { Config._DataPathOrg = data.Split(new string[] { "dataPathOrg=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("dataPathApp=")) { Config._DataPathApp = data.Split(new string[] { "dataPathApp=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("iconPath=")) { Config.IconPath = data.Split(new string[] { "iconPath=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("customScript=")) { Config._CustomScript = data.Split(new string[] { "customScript=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("preloadScript=")) { Config._PreloadScript = data.Split(new string[] { "preloadScript=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("pathCache=")) { Config._PathCache = Convert.ToBoolean(data.Split(new string[] { "pathCache=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("useScriptNames=")) { Config._UseScriptNames = Convert.ToBoolean(data.Split(new string[] { "useScriptNames=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("rubyLoadpath=")) { Config._RubyLoadPath = data.Split(new string[] { "rubyLoadpath=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("midi.soundFont=")) { Config._SoundFont = data.Split(new string[] { "midi.soundFont=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("midi.chorus=")) { Config._Chorus = Convert.ToBoolean(data.Split(new string[] { "midi.chorus=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("midi.reverb=")) { Config._Reverb = Convert.ToBoolean(data.Split(new string[] { "midi.reverb=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("SE.sourceCount=")) { Config._SourceCount = Convert.ToInt32(data.Split(new string[] { "SE.sourceCount=" }, StringSplitOptions.None)[1].Split('\n')[0]); }
                if (data.Contains("execName=")) { Config._ExecName = data.Split(new string[] { "execName=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                if (data.Contains("titleLanguage=")) { Config._TitleLanguage = data.Split(new string[] { "titleLanguage=" }, StringSplitOptions.None)[1].Split('\n')[0]; }
                List<string> RTPs = data.Split(new string[] { "RTP=" }, StringSplitOptions.None).ToList();
                for (int i = 1; i < RTPs.Count; i++)
                {
                    Config._RTP.Add(RTPs[i].Split('\n')[0]);
                }
            }
            #endregion

            #region Load Maps
            foreach (string File in Directory.GetFiles("Maps"))
            {
                if (!Regex.IsMatch(File, @"Maps\\\d+.mkd")) continue;
                Map Map = MapInterpreter.Parse(Convert.ToInt32(File.Split('\\').Last().Split('.').First()));
                Maps.Add(Map);
                allMaps.Nodes.Add(Map.Name);
            }
            CurrentMap = Maps[0];
            #endregion

            Cursor = new PictureBox();
            Cursor.Name = "Cursor";
            Cursor.Width = CurrentMap.Width * 32;
            Cursor.Height = CurrentMap.Height * 32;
            Cursor.BackColor = Color.Transparent;
            Cursor.MouseDown += MapBox_MouseDown;
            Cursor.MouseMove += MapBox_MouseMove;
            Cursor.MouseUp += MapBox_MouseUp;
            Cursor.Paint += Cursor_Paint;
            mapBoxPanel.Controls.Add(Cursor);
            Cursor.Refresh();

            LoadMap(null, true, true);

            scriptBox.SelectedIndex = 0;

            
            Starting = false;

            MainForm_SizeChanged(sender, e);

            SetLayer(1);

            scriptBox_SelectedIndexChanged(sender, e);
        }

        private void Cursor_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.cursor, CursorX * 32, CursorY * 32);
        }

        PictureBox Cursor;

        #region Script Editor

        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                if (e.KeyCode == Keys.V)
                {
                    scriptEditor_TextChanged(sender, new TextChangedEventArgs(((FastColoredTextBox)sender).VisibleRange));
                }
                else if (e.KeyCode == Keys.T)
                {
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
            if (Regex.IsMatch(LineText, $@"\b(module|def|do|for|when)\b"))
            {
                e.ShiftNextLines = e.TabLength;
                return;
            }
            if (Regex.IsMatch(LineText, @"\bbegin\b") && !Regex.IsMatch(LineText, @"=begin\b") && !Regex.IsMatch(LineText, @".begin\b") &&
               !Regex.IsMatch(LineText, @"_begin\b") ||
               Regex.IsMatch(LineText, @"\bclass\b") && !Regex.IsMatch(LineText, @".class\b"))
            {
                e.ShiftNextLines = e.TabLength;
                return;
            }
            if (Regex.IsMatch(e.LineText, @"^[^a-zA-Z=\*&-\+%/!\|~<>\?:;{}\[\]\(\),\.](if|unless|while|until|rescue)"))
            {
                e.ShiftNextLines = e.TabLength;
                return;
            }
            List<string> Special = new List<string>() { "if", "unless", "while", "until" };
            foreach (string Char in Special)
            {
                if (e.LineText.Contains($"{Char} ") || e.LineText.Contains($"{Char}("))
                {
                    string Left = e.LineText.Split(new string[] { Char }, StringSplitOptions.None)[0];
                    if (Empty(Left) || Left.EndsWith("\n") || Left.EndsWith("\r") || Left.EndsWith("\r\n") || Left.EndsWith("  "))
                    {
                        e.ShiftNextLines = e.TabLength;
                        return;
                    }
                }
            }
            if (e.LineText.Contains("rescue"))
            {
                string Left = e.LineText.Split(new string[] { "rescue" }, StringSplitOptions.None)[0];
                if (Empty(Left) || Left.EndsWith("\n") || Left.EndsWith("\r") || Left.EndsWith("\r\n") || Left.EndsWith("  "))
                {
                    e.ShiftNextLines = e.TabLength;
                    return;
                }
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
            Range range = box.Range;
            range.ClearStyle(Keyword, Method, Operator, Integer, String, Comment);

            // Keywords
            range.SetStyle(Keyword, @"\b(alias|and|begin|break|case|class|def|do|else|elsif|end|ensure|false|for|if|in|module|" +
                                                @"next|nil|not|or|redo|rescue|retry|return|self|super|then|true|undef|unless|until|when|while|yield)\b", RegexOptions.Multiline);

            // Special keywords
            range.SetStyle(Method, @"\b(BEGIN|END|_ENCODING_|_LINE_|_FILE_|defined?|_END_)\b", RegexOptions.Multiline);

            // Integer and Hex
            range.SetStyle(Integer, @"\b([\d+_]|(\d+|\d+x[0123456789ABCDEF]*))+\b", RegexOptions.Multiline);

            range.SetStyle(Operator, @"(=|\*|\/|\(|\)|\[|\]|-|:|;|>|<|\.|\+|%|\?|!|{|}|\||~|&|\\|,)", RegexOptions.Multiline);

            List<Range> StringMatches = range.GetRanges("(\"\"|\"+(.*?((?<!\\\\)+\")|.*?\n|.*$)|''|'+(.*?(?<!\\\\)+'|.*?\n|.*$))",
                RegexOptions.Multiline).ToList();
            foreach (Range r in StringMatches)
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

            List<Range> MultilineComments = range.GetRanges(@"=begin.*?=end", RegexOptions.Singleline).ToList();
            foreach (Range r in MultilineComments)
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
            if (Starting) return;
            mainTabControl.Location = new Point(0, 52);
            mainTabControl.Size = new Size(Width - 2, Height - 56 + 31);
            tilesetBoxPanel.Size = new Size(tilesetBoxPanel.Width, mainTabControl.Height - tilesetBoxPanel.Location.Y - mainTabControl.Location.Y - 47);
            tilesetWhite.Size = new Size(tilesetWhite.Width, mainTabControl.Height - tilesetWhite.Location.Y - mainTabControl.Location.Y - 46);
            tilesetBlack.Size = new Size(tilesetBlack.Width, mainTabControl.Height - tilesetBlack.Location.Y - mainTabControl.Location.Y - 45);
            mapWhite.Size = new Size(Width - tilesetPanel.Width - rightPanel.Width - 26, mainTabControl.Height - mapBlack.Location.Y - mainTabControl.Location.Y - 47);
            mapBlack.Size = new Size(Width - tilesetPanel.Width - rightPanel.Width - 24, mainTabControl.Height - mapBlack.Location.Y - mainTabControl.Location.Y - 45);
            if (!Empty(CurrentMap) && !Empty(mapBoxPanel))
                mapBoxPanel.Size = new Size(Math.Min(mapBlack.Size.Width - 4, 32 * CurrentMap.Width),
                    Math.Min(mapBlack.Size.Height - 4, 32 * CurrentMap.Height));

            try
            {
                rightPanelSplitter.SplitterDistance = (Height / 3);
                tileBlack.Height = tilePanel.Height;
                tileWhite.Height = tilePanel.Height - 2;
                allMapsBlack.Height = allMapsPanel.Height - 65;
                allMapsWhite.Height = allMapsPanel.Height - 67;
                allMapsBoxPanel.Height = allMapsPanel.Height - 69;
            }
            catch (Exception) { }

            FastColoredTextBox txt = scriptEditorPanel.Controls["scriptEditor"] as FastColoredTextBox;
            txt.Size = new Size(Width - scriptEditorPanel.Location.X - 20, Height - mainTabControl.Location.Y - scriptEditorPanel.Location.Y - 68);
            scriptNameBox.Location = new Point(scriptNameBox.Location.X, Height - 148);
            scriptNameLabel.Location = new Point(scriptNameLabel.Location.X, Height - 166);
            scriptBox.Size = new Size(scriptBox.Size.Width, Height - mainTabControl.Location.Y - 140);
        }

        /// <summary>
        /// Makes the map the active map by drawing it to the main screen and displaying the proper tileset.
        /// </summary>
        public void LoadMap(Map Map = null, bool RedrawLayers = true, bool UpdateBounds = false)
        {
            if (Map == null) Map = CurrentMap;

            if (!Empty(MapBox)) MapBox.UseWaitCursor = true;

            if (RedrawLayers)
            {
                foreach (Bitmap Bmp in Layers) { Bmp.Dispose(); }
                Layers.Clear();
            }

            CurrentMap = Map;

            if (TilesetPath != CurrentMap.Tileset)
            {
                if (!Empty(Tileset)) Tileset.Dispose();

                FileStream fs = new FileStream($@"Graphics\Tilesets\{CurrentMap.Tileset}.png", FileMode.Open);
                Tileset = new Bitmap(fs);
                fs.Close();

                tilesetBox.Image = (Bitmap)Tileset.Clone();
                tilesetBox.Width = Tileset.Width;
                tilesetBox.Height = Tileset.Height;
                tilesetBox.SizeMode = PictureBoxSizeMode.AutoSize;
                tilesetPanel.Width = Tileset.Width + 20;
                tilesetBlack.Width = Tileset.Width + 20;
                tilesetWhite.Width = Tileset.Width + 18;
                tilesetBoxPanel.Width = Tileset.Width + 17;
                TilesetPath = CurrentMap.Tileset;
            }

            int Width = CurrentMap.Width;
            int Height = CurrentMap.Height;

            if (RedrawLayers || UpdateBounds)
            {
                CreateBlack();
                CreateGrid();
                CreateOverlay();
            }

            if (RedrawLayers)
            {
                for (int i = 0; i < CurrentMap.Layers.Count; i++)
                {
                    Bitmap Layer = new Bitmap(Width * 32, Height * 32);
                    Graphics gr = Graphics.FromImage(Layer);
                    for (int k = 0; k < CurrentMap.Layers[i].Count; k++)
                    {
                        object Tile = CurrentMap.Layers[i][k];
                        int TileID = 0;
                        if (Tile is int)
                        {
                            TileID = (int)Tile;
                        }
                        else
                        {

                            TileID = (int)((List<dynamic>)Tile)[0];
                        }
                        if (TileID == 0) continue;
                        int RealTilesetX = (TileID % 8) * 32;
                        int RealTilesetY = (int)Math.Floor((double)TileID / 8) * 32;
                        int RealX = (k % Width) * 32;
                        int RealY = (int)Math.Floor((double)k / Width) * 32;
                        for (int x = RealX; x < RealX + 32; x++)
                        {
                            for (int y = RealY; y < RealY + 32; y++)
                            {
                                Color Pix = Tileset.GetPixel(RealTilesetX + (x - RealX), RealTilesetY + (y - RealY));
                                Layer.SetPixel(x, y, Pix);
                            }
                        }
                    }
                    Layers.Add(Layer);
                }
                for (int i = CurrentMap.Layers.Count; i < 7; i++)
                {
                    List<dynamic> Tiles = new List<dynamic>();
                    for (int t = 0; t < Width + Height * Width; t++) Tiles.Add(0);
                    CurrentMap.Layers.Add(Tiles);
                    Layers.Add(new Bitmap(Width * 32, Height * 32));
                }
            }

            if (Empty(MapBox)) MakeMapBox();

            MapBox.Width = Width * 32;
            MapBox.Height = Height * 32;
            if (!Empty(Cursor)) MapBox.Controls.Add(Cursor);
            mapBoxPanel.Width = Width * 32;
            mapBoxPanel.Height = Height * 32;
            MapBox.Refresh();

            if (UpdateBounds)
            {
                if (!Empty(CurrentMap)) mapBoxPanel.Size = new Size(Math.Min(mapBlack.Size.Width - 4, 32 * CurrentMap.Width),
                Math.Min(mapBlack.Size.Height - 4, 32 * CurrentMap.Height));
                mapBoxPanel.Size = new Size(Math.Min(mapBlack.Size.Width - 4, 32 * CurrentMap.Width),
                    Math.Min(mapBlack.Size.Height - 4, 32 * CurrentMap.Height));
                if (mapBoxPanel.VerticalScroll.Visible) { mapBoxPanel.Width -= 17; }
                if (mapBoxPanel.HorizontalScroll.Visible) { mapBoxPanel.Height -= 17; }
            }
            MapBox.UseWaitCursor = false;
        }

        private void MapBox_SizeChanged(object sender, EventArgs e)
        {
            if (!Empty(Cursor))
            {
                Cursor.Width = MapBox.Width;
                Cursor.Height = MapBox.Height;
            }
        }

        private void MakeMapBox()
        {
            PictureBox MapBox = new PictureBox();
            MapBox.Name = "mapBox";
            MapBox.Paint += MapBox_Paint;
            MapBox.SizeMode = PictureBoxSizeMode.AutoSize;
            MapBox.SizeChanged += MapBox_SizeChanged;
            mapBoxPanel.Controls.Add(MapBox);
            this.MapBox = MapBox;
        }

        private void MapBox_MouseUp(object sender, MouseEventArgs e)
        {
            LeftMouse = false;
            RightMouse = false;
            MiddleMouse = false;
        }

        private void MapBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(Black, 0, 0); // Black background
            for (int i = 0; i < Layers.Count; i++) // Layers
            {
                g.DrawImage(Layers[i], 0, 0);
                if (Config.HideLowerLayers && i == CurrentLayer - 2) { g.DrawImage(Overlay, 0, 0); }
            }
            if (Config.ShowGrid) g.DrawImage(Grid, 0, 0); // Grid
        }

        private void MapBox_MouseDown(object sender, MouseEventArgs e)
        {
            LeftMouse = (e.Button == MouseButtons.Left);
            RightMouse = (e.Button == MouseButtons.Right);
            MiddleMouse = (e.Button == MouseButtons.Middle);
            if (LeftMouse)
            {
                if (SetTile(CurrentLayer, CursorX, CursorY,
                    (int) Math.Floor((double)TilesetCursor.Location.X / 32) +
                    (int) Math.Floor((double)TilesetCursor.Location.Y / 32) * 8))
                {
                    MapBox.Refresh();
                }
            }
            if (RightMouse)
            {
                dynamic obj = CurrentMap.Layers[CurrentLayer - 1][CursorX + CurrentMap.Width * CursorY];
                int TileID = (obj is int ? (int) obj : (int) obj[0]);
                TilesetCursor.Location = new Point(32 * (TileID % 8), 32 * (int) Math.Floor((double) TileID / 8));
            }
        }

        private void MapBox_MouseMove(object sender, MouseEventArgs e)
        {
            int OldX = CursorX;
            int OldY = CursorY;
            CursorX = Math.Max(0, Math.Min(CurrentMap.Width - 1, (int)Math.Floor((double)e.X / 32)));
            CursorY = Math.Max(0, Math.Min(CurrentMap.Height - 1, (int)Math.Floor((double)e.Y / 32)));
            if (CursorX != OldX || CursorY != OldY) Cursor.Refresh();
            if (LeftMouse)
            {
                SetTile(CurrentLayer, CursorX, CursorY,
                    (int)Math.Floor((double)TilesetCursor.Location.X / 32) +
                    (int)Math.Floor((double)TilesetCursor.Location.Y / 32) * 8);
                MapBox.Refresh();
            }
        }

        private bool SetTile(int Layer, int X, int Y, int TileID)
        {
            if (CurrentMap.Layers[Layer - 1][X + Y * CurrentMap.Width] is int &&
                CurrentMap.Layers[Layer - 1][X + Y * CurrentMap.Width] == TileID ||
                CurrentMap.Layers[Layer - 1][X + Y * CurrentMap.Width] is List<dynamic> &&
                CurrentMap.Layers[Layer - 1][X + Y * CurrentMap.Width][0] == TileID)
            {
                return false;
            }
            Graphics g = Graphics.FromImage(Layers[Layer - 1]);
            for (int x = X * 32; x < X * 32 + 32; x++)
            {
                for (int y = Y * 32; y < Y * 32 + 32; y++)
                {
                    Layers[Layer - 1].SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));
                }
            }

            if (TileID != 0)
            {
                for (int x = X * 32; x < X * 32 + 32; x++)
                {
                    for (int y = Y * 32; y < Y * 32 + 32; y++)
                    {
                        Layers[Layer - 1].SetPixel(x, y, Tileset.GetPixel((32 * (TileID % 8)) + (x - X * 32), ((int)(32 * Math.Floor((double)TileID / 8)) + (y - Y * 32))));
                    }
                }
            }
            if (CurrentMap.Layers[Layer - 1][X + Y * CurrentMap.Width] is int)
            {
                CurrentMap.Layers[Layer - 1][X + Y * CurrentMap.Width] = TileID;
            }
            else
            {
                CurrentMap.Layers[Layer - 1][X + Y * CurrentMap.Width][0] = TileID;
            }
            return true;
        }

        private void CreateOverlay()
        {
            if (!Empty(Overlay)) Overlay.Dispose();
            Overlay = new Bitmap(CurrentMap.Width * 32, CurrentMap.Height * 32);
            for (int x = 0; x < CurrentMap.Width * 32; x++)
            {
                for (int y = 0; y < CurrentMap.Height * 32; y++)
                {
                    Overlay.SetPixel(x, y, Color.FromArgb(128, 0, 0, 0));
                }
            }
        }

        private void CreateBlack()
        {
            if (!Empty(Black)) Black.Dispose();
            Black = new Bitmap(CurrentMap.Width * 32, CurrentMap.Height * 32);
            Graphics g = Graphics.FromImage(Black);
            g.FillRectangle(Brushes.Black, 0, 0, CurrentMap.Width * 32, CurrentMap.Height * 32);
            g.Dispose();
        }

        private void CreateGrid()
        {
            if (!Empty(Grid)) Grid.Dispose();
            Grid = new Bitmap(CurrentMap.Width * 32, CurrentMap.Height * 32);
            for (int x = 0; x < Grid.Width; x++)
            {
                for (int y = 0; y < Grid.Height; y++)
                {
                    if (x > 1 && x < Grid.Width - 2 && x % (Config.GridWidth * 32) == (Config.GridWidth * 32 - 1) || x % (Config.GridWidth * 32) == 0 ||
                        y > 1 && y < Grid.Height - 2 && y % (Config.GridHeight * 32) == (Config.GridHeight * 32 - 1) || y % (Config.GridHeight * 32) == 0)
                    {
                        Grid.SetPixel(x, y, Config.GridColor);
                    }
                }
            }
        }

        private void tilesetBox_MouseDown(object sender, MouseEventArgs e)
        {
            TilesetCursor.Location = new Point(32 * (int)Math.Floor((double)e.X / 32), 32 * (int)Math.Floor((double)e.Y / 32));
        }

        public int GetTileID()
        {
            return (TilesetCursor.Location.X / 32) + 8 * (TilesetCursor.Location.Y / 32);
        }

        private void scriptBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Starting) return;
            scriptNameBox.Text = Scripts[scriptBox.SelectedIndex].Name;
            scriptEditorPanel.Controls["scriptEditor"].Text = Scripts[scriptBox.SelectedIndex].Code;
            scriptEditor_TextChanged(scriptEditorPanel.Controls["scriptEditor"],
                new TextChangedEventArgs(((FastColoredTextBox)scriptEditorPanel.Controls["scriptEditor"]).Range));
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
            // Saving all scripts
            #region Scripts
            if (!Directory.Exists("Scripts")) Directory.CreateDirectory("Scripts");
            foreach (string file in Directory.GetFiles("Scripts")) { File.Delete(file); }
            StreamWriter stwr = new StreamWriter(File.OpenWrite(@"Scripts\entry.rb"));
            stwr.Write(
$@"SCREENWIDTH = {Config.ScreenWidth}
SCREENHEIGHT = {Config.ScreenHeight}
Graphics.resize_screen(SCREENWIDTH, SCREENHEIGHT)

$LOAD_PATH << "".""
Dir.glob(""Scripts/*.rb"") {{ |f| require f }}");
            stwr.Close();
            int ExtraDigits = Scripts.Count.ToString().Length;
            for (int i = 0; i < Scripts.Count; i++)
            {
                string Name = $"{Digits(i + 1, ExtraDigits)}-{Scripts[i].Name}.rb";
                StreamWriter streamwriter = new StreamWriter(File.OpenWrite(@"Scripts\" + Name));
                streamwriter.Write(Scripts[i].Code);
                streamwriter.Close();
            }
            #endregion

            // Saving MKXP's Config
            #region MKXP Config
            if (File.Exists("mkxp.conf")) { File.Delete("mkxp.conf"); }
            StreamWriter sw = new StreamWriter(File.OpenWrite("mkxp.conf"));
            if (Config.RGSSVersion != 0) sw.WriteLine($"rgssVersion={Config.RGSSVersion}");
            if (Config._DebugMode) sw.WriteLine($"debugMode=true");
            if (Config.PrintFPS) sw.WriteLine($"printFPS=true");
            if (Config._WinResizable) sw.WriteLine($"winResizable=true");
            if (Config.StartFullscreen) sw.WriteLine($"fullscreen=true");
            if (!Config.FixedAspectRatio) sw.WriteLine($"fixedAspectRatio=false");
            if (!Config.SmoothScaling) sw.WriteLine($"smoothScaling=false");
            if (Config.ScreenWidth != 0) sw.WriteLine($"defScreenW={Config.ScreenWidth}");
            if (Config.ScreenHeight != 0) sw.WriteLine($"defScreenH={Config.ScreenHeight}");
            if (!Empty(Config.WindowTitle)) sw.WriteLine($"windowTitle={Config.WindowTitle}");
            if (Config.FixedFramerate != 0) sw.WriteLine($"fixedFramerate={Config.FixedFramerate}");
            if (!Config._FrameSkip) sw.WriteLine($"frameSkip=false");
            if (Config._SyncToRefreshRate) sw.WriteLine($"syncToRefreshratetrue");
            if (Config._SolidFonts) sw.WriteLine($"solidFonts=true");
            if (Config._SubImageFix) sw.WriteLine($"subImageFix=true");
            if (!Config._EnableBlitting) sw.WriteLine($"enableBlitting=false");
            if (Config._MaxTextureSize != "0") sw.WriteLine($"maxTextureSize={Config._MaxTextureSize}");
            if (!Empty(Config._GameFolder)) sw.WriteLine($"gameFolder={Config._GameFolder}");
            if (Config._AnyAltToggleFS) sw.WriteLine($"anyAltToggleFS=true");
            if (!Config.F12SoftReset) sw.WriteLine($"enableReset=false");
            if (Config._AllowSymLinks) sw.WriteLine($"allowSymlinks=true");
            if (!Empty(Config._DataPathOrg)) sw.WriteLine($"dataPathOrg={Config._DataPathOrg}");
            if (!Empty(Config._DataPathApp)) sw.WriteLine($"dataPathApp={Config._DataPathApp}");
            if (!Empty(Config.IconPath)) sw.WriteLine($"iconPath={Config.IconPath}");
            if (!Empty(Config._CustomScript)) sw.WriteLine($"customScript={Config._CustomScript}");
            if (!Empty(Config._PreloadScript)) sw.WriteLine($"preloadScript={Config._PreloadScript}");
            if (!Config._PathCache) sw.WriteLine($"pathCache=false");
            foreach (string s in Config._RTP) sw.WriteLine($"RTP={s}");
            if (Config._UseScriptNames) sw.WriteLine($"useScriptNames=true");
            if (!Empty(Config._RubyLoadPath)) sw.WriteLine($"rubyLoadpath={Config._RubyLoadPath}");
            if (!Empty(Config._SoundFont)) sw.WriteLine($"midi.soundFont={Config._SoundFont}");
            if (Config._Chorus) sw.WriteLine($"midi.chorus=true");
            if (Config._Reverb) sw.WriteLine($"midi.reverb=true");
            if (Config._SourceCount != 6) sw.WriteLine($"SE.sourceCount={Config._SourceCount}");
            if (!Empty(Config._ExecName)) sw.WriteLine($"execName={Config._ExecName}");
            if (!Empty(Config._TitleLanguage)) sw.WriteLine($"titleLanguage={Config._TitleLanguage}");
            sw.Close();
            #endregion

            // Saving all maps
            #region maps
            ScriptEngine Engine = Ruby.CreateEngine();
            foreach (Map m in Maps)
            {
                if (File.Exists($@"Maps\{Digits(m.ID)}.txt")) File.Delete($@"Maps\{Digits(m.ID)}.txt");
                string Data = ($"[[{m.Width},{m.Height},'{m.Tileset}','{m.Name}'],");
                for (int i = 0; i < m.Layers.Count; i++)
                {
                    Data += "[";
                    for (int j = 0; j < m.Layers[i].Count; j++)
                    {
                        if (m.Layers[i][j] is int)
                        {
                            Data += m.Layers[i][j].ToString();
                        }
                        else
                        {
                            Data += "[";
                            for (int k = 0; k < m.Layers[i][j].Count; k++)
                            {
                                Data += m.Layers[i][j][k].ToString();
                                if (k != m.Layers[i][j].Count - 1) Data += ",";
                            }
                            Data += "]";
                        }
                        if (j != m.Layers[i].Count - 1) Data += ",";
                    }
                    Data += "]";
                    if (i != m.Layers.Count - 1) Data += ",";
                }
                Data += "]";
                Engine.Execute(
$@"f = File.new('Maps\\{Digits(m.ID)}.mkd', 'wb')
Marshal.dump({Data}, f)
f.close");
            }
            #endregion
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
            Process.Start("Game.exe");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            playToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SettingsForm settings = new SettingsForm();
            settings.ShowDialog();
        }

        private void mainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            MainForm_SizeChanged(sender, e);
        }

        private void SetLayer(int n)
        {
            for (int i = 1; i <= 7; i++) { ((ToolStripButton)mappingTools.Items[$"layerBtn{i}"]).Checked = (i == n); }
            layer1ToolStripMenuItem.Checked = (n == 1);
            layer2ToolStripMenuItem.Checked = (n == 2);
            layer3ToolStripMenuItem.Checked = (n == 3);
            layer4ToolStripMenuItem.Checked = (n == 4);
            layer5ToolStripMenuItem.Checked = (n == 5);
            layer6ToolStripMenuItem.Checked = (n == 6);
            layer7ToolStripMenuItem.Checked = (n == 7);
            CurrentLayer = n;
            MapBox.Refresh();
        }

        #region Layer Buttons
        private void layerBtn1_Click(object sender, EventArgs e) { SetLayer(1); }
        private void layerBtn2_Click(object sender, EventArgs e) { SetLayer(2); }
        private void layerBtn3_Click(object sender, EventArgs e) { SetLayer(3); }
        private void layerBtn4_Click(object sender, EventArgs e) { SetLayer(4); }
        private void layerBtn5_Click(object sender, EventArgs e) { SetLayer(5); }
        private void layerBtn6_Click(object sender, EventArgs e) { SetLayer(6); }
        private void layerBtn7_Click(object sender, EventArgs e) { SetLayer(7); }
        private void layer1ToolStripMenuItem_Click(object sender, EventArgs e) { SetLayer(1); }
        private void layer2ToolStripMenuItem_Click(object sender, EventArgs e) { SetLayer(2); }
        private void layer3ToolStripMenuItem_Click(object sender, EventArgs e) { SetLayer(3); }
        private void layer4ToolStripMenuItem_Click(object sender, EventArgs e) { SetLayer(4); }
        private void layer5ToolStripMenuItem_Click(object sender, EventArgs e) { SetLayer(5); }
        private void layer6ToolStripMenuItem_Click(object sender, EventArgs e) { SetLayer(6); }
        private void layer7ToolStripMenuItem_Click(object sender, EventArgs e) { SetLayer(7); }
        #endregion

        private void mapSettings_Click(object sender, EventArgs e)
        {
            MapForm mf = new MapForm(CurrentMap, MapBox);
            mf.ShowDialog();
            // If width/height changed and it needs to be redrawn
            if (mf.ShouldUpdate)
            {
                LoadMap(null, true, true);
            }
        }

        private void mapGrid_Click(object sender, EventArgs e)
        {
            Config.ShowGrid = !Config.ShowGrid;
            mapGrid.Checked = Config.ShowGrid;
            showToolStripMenuItem.Checked = Config.ShowGrid;
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config.ShowGrid = !Config.ShowGrid;
            mapGrid.Checked = Config.ShowGrid;
            showToolStripMenuItem.Checked = Config.ShowGrid;
            MapBox.Refresh();
        }

        private void hideLowerLayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config.HideLowerLayers = !Config.HideLowerLayers;
            MapBox.Refresh();
        }

        private int UniqueID()
        {
            List<int> IDs = new List<int>();
            foreach (Map m in Maps) { IDs.Add(m.ID); }
            int ID = 1;
            while (IDs.Contains(ID)) { ID += 1; }
            return ID;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = UniqueID();
            NewMap CreateNewMap = new NewMap(ID);
            CreateNewMap.ShowDialog();
            if (CreateNewMap.Created)
            {
                CurrentMap = CreateNewMap.Map;
                Maps.Add(CreateNewMap.Map);
                LoadMap(CreateNewMap.Map, true, true);
                allMaps.Nodes.Add(CreateNewMap.Map.Name);
            }
        }

        private void allMaps_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (Map M in Maps)
            {
                if (M.Name == allMaps.SelectedNode.Text)
                {
                    LoadMap(M, true, true);
                }
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "MK Data file (*.mkd)|*.mkd|RPG Maker XP map (*.rxdata)|*.rxdata";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                int ID = UniqueID();
                File.Move(ofd.FileName, $@"Maps\{Digits(ID)}.mkd");
                Map Map = MapInterpreter.Parse(ID);
                Maps.Add(Map);
                allMaps.Nodes.Add(Map.Name);
            }
        }

        private void newSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scripts.Insert(scriptBox.SelectedIndex, new Script("", ""));
            scriptBinder.ResetBindings(false);
            scriptBox_SelectedIndexChanged(sender, e);
        }

        private void copySectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScriptClipboard = new Script(Scripts[scriptBox.SelectedIndex].Name, Scripts[scriptBox.SelectedIndex].Code);
        }

        private void cutSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScriptClipboard = new Script(Scripts[scriptBox.SelectedIndex].Name, Scripts[scriptBox.SelectedIndex].Code);
            Scripts.RemoveAt(scriptBox.SelectedIndex);
            scriptBox_SelectedIndexChanged(sender, e);
        }

        private void pasteSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Empty(ScriptClipboard))
            {
                Scripts.Insert(scriptBox.SelectedIndex, new Script(ScriptClipboard.Name, ScriptClipboard.Code));
                scriptBinder.ResetBindings(false);
                scriptBox_SelectedIndexChanged(sender, e);
            }
        }

        private void deleteSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scripts.RemoveAt(scriptBox.SelectedIndex);
            scriptBinder.ResetBindings(false);
            scriptBox_SelectedIndexChanged(sender, e);
        }

        private void importSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Ruby Files (*.rb)|*.rb|All Files (*.*)|*.*";
            ofd.Title = "Choose a file to import to a new section";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string Filename = ofd.FileName;
                Filename = Filename.Split('\\').Last();
                if (Regex.IsMatch(Filename, @"^\d+-.*?\.rb", RegexOptions.None))
                {
                    List<string> Tmp = Filename.Split('-').ToList();
                    string Res = null;
                    for (int i = 1; i < Tmp.Count; i++) { Res += Tmp[i]; if (i != Tmp.Count - 1) Res += "-"; }
                    Filename = Res;
                }
                if (Filename.Contains("."))
                {
                    List<string> Tmp = Filename.Split('.').ToList();
                    string Res = null;
                    for (int i = 0; i < Tmp.Count - 1; i++) { Res += Tmp[i]; if (i != Tmp.Count - 2) Res += "."; }
                    Filename = Res;
                }
                StreamReader sr = new StreamReader(File.OpenRead(ofd.FileName));
                string Code = sr.ReadToEnd();
                sr.Close();
                Scripts.Insert(scriptBox.SelectedIndex, new Script(Filename, Code));
                scriptBinder.ResetBindings(false);
                scriptBox_SelectedIndexChanged(sender, e);
            }
        }
    }
}