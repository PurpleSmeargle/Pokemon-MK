namespace PokemonEngine
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mapsTab = new System.Windows.Forms.TabPage();
            this.mainMapPanel = new System.Windows.Forms.Panel();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.mappingTools = new System.Windows.Forms.ToolStrip();
            this.mapGrid = new System.Windows.Forms.ToolStripButton();
            this.layerBtn1 = new System.Windows.Forms.ToolStripButton();
            this.layerBtn2 = new System.Windows.Forms.ToolStripButton();
            this.layerBtn3 = new System.Windows.Forms.ToolStripButton();
            this.layerBtn4 = new System.Windows.Forms.ToolStripButton();
            this.layerBtn5 = new System.Windows.Forms.ToolStripButton();
            this.layerBtn6 = new System.Windows.Forms.ToolStripButton();
            this.layerBtn7 = new System.Windows.Forms.ToolStripButton();
            this.mapSettings = new System.Windows.Forms.ToolStripButton();
            this.mapBoxPanel = new System.Windows.Forms.Panel();
            this.mapWhite = new System.Windows.Forms.PictureBox();
            this.mapBlack = new System.Windows.Forms.PictureBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tilePanel = new System.Windows.Forms.Panel();
            this.tileWhite = new System.Windows.Forms.PictureBox();
            this.tileBlack = new System.Windows.Forms.PictureBox();
            this.allMapsPanel = new System.Windows.Forms.Panel();
            this.allMapsWhite = new System.Windows.Forms.PictureBox();
            this.allMapsBlack = new System.Windows.Forms.PictureBox();
            this.tilesetPanel = new System.Windows.Forms.Panel();
            this.tilesetBoxPanel = new System.Windows.Forms.Panel();
            this.tilesetBox = new System.Windows.Forms.PictureBox();
            this.tilesetWhite = new System.Windows.Forms.PictureBox();
            this.tilesetBlack = new System.Windows.Forms.PictureBox();
            this.scriptsTab = new System.Windows.Forms.TabPage();
            this.scriptEditorPanel = new System.Windows.Forms.Panel();
            this.scriptsPanel = new System.Windows.Forms.Panel();
            this.scriptNameBox = new System.Windows.Forms.TextBox();
            this.scriptNameLabel = new System.Windows.Forms.Label();
            this.scriptBox = new System.Windows.Forms.ListBox();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.menuBar.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.mapsTab.SuspendLayout();
            this.mainMapPanel.SuspendLayout();
            this.mapPanel.SuspendLayout();
            this.mappingTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBlack)).BeginInit();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tileWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileBlack)).BeginInit();
            this.allMapsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allMapsWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allMapsBlack)).BeginInit();
            this.tilesetPanel.SuspendLayout();
            this.tilesetBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBlack)).BeginInit();
            this.scriptsTab.SuspendLayout();
            this.scriptsPanel.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.Transparent;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.settingsToolStripMenuItem1});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1173, 24);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compressToolStripMenuItem,
            this.playToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // compressToolStripMenuItem
            // 
            this.compressToolStripMenuItem.Name = "compressToolStripMenuItem";
            this.compressToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.compressToolStripMenuItem.Text = "Compress";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.playToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.playToolStripMenuItem.Text = "Play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.mapsTab);
            this.mainTabControl.Controls.Add(this.scriptsTab);
            this.mainTabControl.Location = new System.Drawing.Point(0, 52);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.ShowToolTips = true;
            this.mainTabControl.Size = new System.Drawing.Size(1173, 779);
            this.mainTabControl.TabIndex = 2;
            this.mainTabControl.SelectedIndexChanged += new System.EventHandler(this.mainTabControl_SelectedIndexChanged);
            // 
            // mapsTab
            // 
            this.mapsTab.BackColor = System.Drawing.SystemColors.Control;
            this.mapsTab.Controls.Add(this.mainMapPanel);
            this.mapsTab.Location = new System.Drawing.Point(4, 22);
            this.mapsTab.Name = "mapsTab";
            this.mapsTab.Padding = new System.Windows.Forms.Padding(3);
            this.mapsTab.Size = new System.Drawing.Size(1165, 753);
            this.mapsTab.TabIndex = 0;
            this.mapsTab.Text = "Maps";
            this.mapsTab.ToolTipText = "Contains all tools and functionality for mapping.";
            // 
            // mainMapPanel
            // 
            this.mainMapPanel.Controls.Add(this.mapPanel);
            this.mainMapPanel.Controls.Add(this.rightPanel);
            this.mainMapPanel.Controls.Add(this.tilesetPanel);
            this.mainMapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMapPanel.Location = new System.Drawing.Point(3, 3);
            this.mainMapPanel.Name = "mainMapPanel";
            this.mainMapPanel.Size = new System.Drawing.Size(1159, 747);
            this.mainMapPanel.TabIndex = 5;
            // 
            // mapPanel
            // 
            this.mapPanel.Controls.Add(this.mappingTools);
            this.mapPanel.Controls.Add(this.mapBoxPanel);
            this.mapPanel.Controls.Add(this.mapWhite);
            this.mapPanel.Controls.Add(this.mapBlack);
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(260, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(719, 747);
            this.mapPanel.TabIndex = 2;
            // 
            // mappingTools
            // 
            this.mappingTools.BackColor = System.Drawing.Color.Transparent;
            this.mappingTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mapGrid,
            this.layerBtn1,
            this.layerBtn2,
            this.layerBtn3,
            this.layerBtn4,
            this.layerBtn5,
            this.layerBtn6,
            this.layerBtn7,
            this.mapSettings});
            this.mappingTools.Location = new System.Drawing.Point(0, 0);
            this.mappingTools.Name = "mappingTools";
            this.mappingTools.Size = new System.Drawing.Size(719, 25);
            this.mappingTools.TabIndex = 3;
            this.mappingTools.Text = "toolStrip1";
            // 
            // mapGrid
            // 
            this.mapGrid.CheckOnClick = true;
            this.mapGrid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapGrid.Image = global::PokemonEngine.Properties.Resources.grid;
            this.mapGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapGrid.Name = "mapGrid";
            this.mapGrid.Size = new System.Drawing.Size(23, 22);
            this.mapGrid.Text = "toolStripButton3";
            this.mapGrid.Click += new System.EventHandler(this.mapGrid_Click);
            // 
            // layerBtn1
            // 
            this.layerBtn1.CheckOnClick = true;
            this.layerBtn1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerBtn1.Image = global::PokemonEngine.Properties.Resources.layer1;
            this.layerBtn1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerBtn1.Name = "layerBtn1";
            this.layerBtn1.Size = new System.Drawing.Size(23, 22);
            this.layerBtn1.Text = "toolStripButton4";
            this.layerBtn1.Click += new System.EventHandler(this.layerBtn1_Click);
            // 
            // layerBtn2
            // 
            this.layerBtn2.CheckOnClick = true;
            this.layerBtn2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerBtn2.Image = global::PokemonEngine.Properties.Resources.layer2;
            this.layerBtn2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerBtn2.Name = "layerBtn2";
            this.layerBtn2.Size = new System.Drawing.Size(23, 22);
            this.layerBtn2.Text = "toolStripButton5";
            this.layerBtn2.Click += new System.EventHandler(this.layerBtn2_Click);
            // 
            // layerBtn3
            // 
            this.layerBtn3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerBtn3.Image = global::PokemonEngine.Properties.Resources.layer3;
            this.layerBtn3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerBtn3.Name = "layerBtn3";
            this.layerBtn3.Size = new System.Drawing.Size(23, 22);
            this.layerBtn3.Text = "toolStripButton6";
            this.layerBtn3.Click += new System.EventHandler(this.layerBtn3_Click);
            // 
            // layerBtn4
            // 
            this.layerBtn4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerBtn4.Image = global::PokemonEngine.Properties.Resources.layer4;
            this.layerBtn4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerBtn4.Name = "layerBtn4";
            this.layerBtn4.Size = new System.Drawing.Size(23, 22);
            this.layerBtn4.Text = "toolStripButton7";
            this.layerBtn4.Click += new System.EventHandler(this.layerBtn4_Click);
            // 
            // layerBtn5
            // 
            this.layerBtn5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerBtn5.Image = global::PokemonEngine.Properties.Resources.layer5;
            this.layerBtn5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerBtn5.Name = "layerBtn5";
            this.layerBtn5.Size = new System.Drawing.Size(23, 22);
            this.layerBtn5.Text = "toolStripButton8";
            this.layerBtn5.Click += new System.EventHandler(this.layerBtn5_Click);
            // 
            // layerBtn6
            // 
            this.layerBtn6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerBtn6.Image = global::PokemonEngine.Properties.Resources.layer6;
            this.layerBtn6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerBtn6.Name = "layerBtn6";
            this.layerBtn6.Size = new System.Drawing.Size(23, 22);
            this.layerBtn6.Text = "toolStripButton9";
            this.layerBtn6.Click += new System.EventHandler(this.layerBtn6_Click);
            // 
            // layerBtn7
            // 
            this.layerBtn7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.layerBtn7.Image = global::PokemonEngine.Properties.Resources.layer7;
            this.layerBtn7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.layerBtn7.Name = "layerBtn7";
            this.layerBtn7.Size = new System.Drawing.Size(23, 22);
            this.layerBtn7.Text = "toolStripButton10";
            this.layerBtn7.Click += new System.EventHandler(this.layerBtn7_Click);
            // 
            // mapSettings
            // 
            this.mapSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mapSettings.Image = global::PokemonEngine.Properties.Resources.settings;
            this.mapSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mapSettings.Name = "mapSettings";
            this.mapSettings.Size = new System.Drawing.Size(23, 22);
            this.mapSettings.Text = "toolStripButton11";
            // 
            // mapBoxPanel
            // 
            this.mapBoxPanel.Location = new System.Drawing.Point(6, 34);
            this.mapBoxPanel.Name = "mapBoxPanel";
            this.mapBoxPanel.Size = new System.Drawing.Size(506, 453);
            this.mapBoxPanel.TabIndex = 2;
            // 
            // mapWhite
            // 
            this.mapWhite.Location = new System.Drawing.Point(5, 33);
            this.mapWhite.Name = "mapWhite";
            this.mapWhite.Size = new System.Drawing.Size(697, 711);
            this.mapWhite.TabIndex = 1;
            this.mapWhite.TabStop = false;
            // 
            // mapBlack
            // 
            this.mapBlack.BackColor = System.Drawing.Color.DimGray;
            this.mapBlack.Location = new System.Drawing.Point(4, 32);
            this.mapBlack.Name = "mapBlack";
            this.mapBlack.Size = new System.Drawing.Size(699, 713);
            this.mapBlack.TabIndex = 0;
            this.mapBlack.TabStop = false;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.splitContainer1);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(979, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(180, 747);
            this.rightPanel.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tilePanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.allMapsPanel);
            this.splitContainer1.Size = new System.Drawing.Size(180, 747);
            this.splitContainer1.SplitterDistance = 329;
            this.splitContainer1.TabIndex = 0;
            // 
            // tilePanel
            // 
            this.tilePanel.Controls.Add(this.tileWhite);
            this.tilePanel.Controls.Add(this.tileBlack);
            this.tilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilePanel.Location = new System.Drawing.Point(0, 0);
            this.tilePanel.Name = "tilePanel";
            this.tilePanel.Size = new System.Drawing.Size(180, 329);
            this.tilePanel.TabIndex = 0;
            // 
            // tileWhite
            // 
            this.tileWhite.BackColor = System.Drawing.SystemColors.Control;
            this.tileWhite.Location = new System.Drawing.Point(1, 1);
            this.tileWhite.Name = "tileWhite";
            this.tileWhite.Size = new System.Drawing.Size(165, 314);
            this.tileWhite.TabIndex = 1;
            this.tileWhite.TabStop = false;
            // 
            // tileBlack
            // 
            this.tileBlack.BackColor = System.Drawing.Color.DimGray;
            this.tileBlack.Location = new System.Drawing.Point(0, 0);
            this.tileBlack.Name = "tileBlack";
            this.tileBlack.Size = new System.Drawing.Size(167, 316);
            this.tileBlack.TabIndex = 0;
            this.tileBlack.TabStop = false;
            // 
            // allMapsPanel
            // 
            this.allMapsPanel.Controls.Add(this.allMapsWhite);
            this.allMapsPanel.Controls.Add(this.allMapsBlack);
            this.allMapsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allMapsPanel.Location = new System.Drawing.Point(0, 0);
            this.allMapsPanel.Name = "allMapsPanel";
            this.allMapsPanel.Size = new System.Drawing.Size(180, 414);
            this.allMapsPanel.TabIndex = 0;
            // 
            // allMapsWhite
            // 
            this.allMapsWhite.BackColor = System.Drawing.SystemColors.Control;
            this.allMapsWhite.Location = new System.Drawing.Point(1, 1);
            this.allMapsWhite.Name = "allMapsWhite";
            this.allMapsWhite.Size = new System.Drawing.Size(165, 395);
            this.allMapsWhite.TabIndex = 1;
            this.allMapsWhite.TabStop = false;
            // 
            // allMapsBlack
            // 
            this.allMapsBlack.BackColor = System.Drawing.Color.DimGray;
            this.allMapsBlack.Location = new System.Drawing.Point(0, 0);
            this.allMapsBlack.Name = "allMapsBlack";
            this.allMapsBlack.Size = new System.Drawing.Size(167, 397);
            this.allMapsBlack.TabIndex = 0;
            this.allMapsBlack.TabStop = false;
            // 
            // tilesetPanel
            // 
            this.tilesetPanel.Controls.Add(this.tilesetBoxPanel);
            this.tilesetPanel.Controls.Add(this.tilesetWhite);
            this.tilesetPanel.Controls.Add(this.tilesetBlack);
            this.tilesetPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tilesetPanel.Location = new System.Drawing.Point(0, 0);
            this.tilesetPanel.Name = "tilesetPanel";
            this.tilesetPanel.Size = new System.Drawing.Size(260, 747);
            this.tilesetPanel.TabIndex = 0;
            // 
            // tilesetBoxPanel
            // 
            this.tilesetBoxPanel.AutoScroll = true;
            this.tilesetBoxPanel.Controls.Add(this.tilesetBox);
            this.tilesetBoxPanel.Location = new System.Drawing.Point(2, 2);
            this.tilesetBoxPanel.Name = "tilesetBoxPanel";
            this.tilesetBoxPanel.Size = new System.Drawing.Size(256, 741);
            this.tilesetBoxPanel.TabIndex = 2;
            // 
            // tilesetBox
            // 
            this.tilesetBox.BackColor = System.Drawing.SystemColors.Control;
            this.tilesetBox.Location = new System.Drawing.Point(0, 0);
            this.tilesetBox.Name = "tilesetBox";
            this.tilesetBox.Size = new System.Drawing.Size(256, 741);
            this.tilesetBox.TabIndex = 0;
            this.tilesetBox.TabStop = false;
            this.tilesetBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tilesetBox_MouseDown);
            // 
            // tilesetWhite
            // 
            this.tilesetWhite.BackColor = System.Drawing.SystemColors.Control;
            this.tilesetWhite.Location = new System.Drawing.Point(1, 1);
            this.tilesetWhite.Name = "tilesetWhite";
            this.tilesetWhite.Size = new System.Drawing.Size(258, 743);
            this.tilesetWhite.TabIndex = 1;
            this.tilesetWhite.TabStop = false;
            // 
            // tilesetBlack
            // 
            this.tilesetBlack.BackColor = System.Drawing.Color.DimGray;
            this.tilesetBlack.Location = new System.Drawing.Point(0, 0);
            this.tilesetBlack.Name = "tilesetBlack";
            this.tilesetBlack.Size = new System.Drawing.Size(260, 745);
            this.tilesetBlack.TabIndex = 0;
            this.tilesetBlack.TabStop = false;
            // 
            // scriptsTab
            // 
            this.scriptsTab.BackColor = System.Drawing.SystemColors.Control;
            this.scriptsTab.Controls.Add(this.scriptEditorPanel);
            this.scriptsTab.Controls.Add(this.scriptsPanel);
            this.scriptsTab.Location = new System.Drawing.Point(4, 22);
            this.scriptsTab.Name = "scriptsTab";
            this.scriptsTab.Padding = new System.Windows.Forms.Padding(3);
            this.scriptsTab.Size = new System.Drawing.Size(1165, 753);
            this.scriptsTab.TabIndex = 1;
            this.scriptsTab.Text = "Scripts";
            this.scriptsTab.ToolTipText = "Contains all tools and funtionality for scripting.";
            // 
            // scriptEditorPanel
            // 
            this.scriptEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptEditorPanel.Location = new System.Drawing.Point(176, 3);
            this.scriptEditorPanel.Name = "scriptEditorPanel";
            this.scriptEditorPanel.Size = new System.Drawing.Size(986, 747);
            this.scriptEditorPanel.TabIndex = 1;
            // 
            // scriptsPanel
            // 
            this.scriptsPanel.Controls.Add(this.scriptNameBox);
            this.scriptsPanel.Controls.Add(this.scriptNameLabel);
            this.scriptsPanel.Controls.Add(this.scriptBox);
            this.scriptsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.scriptsPanel.Location = new System.Drawing.Point(3, 3);
            this.scriptsPanel.Name = "scriptsPanel";
            this.scriptsPanel.Size = new System.Drawing.Size(173, 747);
            this.scriptsPanel.TabIndex = 0;
            // 
            // scriptNameBox
            // 
            this.scriptNameBox.Location = new System.Drawing.Point(13, 720);
            this.scriptNameBox.Name = "scriptNameBox";
            this.scriptNameBox.Size = new System.Drawing.Size(146, 20);
            this.scriptNameBox.TabIndex = 2;
            this.scriptNameBox.TextChanged += new System.EventHandler(this.scriptNameBox_TextChanged);
            // 
            // scriptNameLabel
            // 
            this.scriptNameLabel.AutoSize = true;
            this.scriptNameLabel.Location = new System.Drawing.Point(66, 703);
            this.scriptNameLabel.Name = "scriptNameLabel";
            this.scriptNameLabel.Size = new System.Drawing.Size(38, 13);
            this.scriptNameLabel.TabIndex = 1;
            this.scriptNameLabel.Text = "Name:";
            // 
            // scriptBox
            // 
            this.scriptBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.scriptBox.FormattingEnabled = true;
            this.scriptBox.Location = new System.Drawing.Point(0, 0);
            this.scriptBox.Name = "scriptBox";
            this.scriptBox.Size = new System.Drawing.Size(173, 693);
            this.scriptBox.TabIndex = 0;
            this.scriptBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.scriptBox_MouseClick);
            this.scriptBox.SelectedIndexChanged += new System.EventHandler(this.scriptBox_SelectedIndexChanged);
            // 
            // toolbar
            // 
            this.toolbar.BackColor = System.Drawing.Color.Transparent;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolbar.Location = new System.Drawing.Point(0, 24);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(1173, 25);
            this.toolbar.TabIndex = 3;
            this.toolbar.Text = "Toolbar";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Save";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Play";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 831);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuBar);
            this.MainMenuStrip = this.menuBar;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Pokémon Engine";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.mapsTab.ResumeLayout(false);
            this.mainMapPanel.ResumeLayout(false);
            this.mapPanel.ResumeLayout(false);
            this.mapPanel.PerformLayout();
            this.mappingTools.ResumeLayout(false);
            this.mappingTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBlack)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tilePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tileWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileBlack)).EndInit();
            this.allMapsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allMapsWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allMapsBlack)).EndInit();
            this.tilesetPanel.ResumeLayout(false);
            this.tilesetBoxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBlack)).EndInit();
            this.scriptsTab.ResumeLayout(false);
            this.scriptsPanel.ResumeLayout(false);
            this.scriptsPanel.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage mapsTab;
        private System.Windows.Forms.TabPage scriptsTab;
        private System.Windows.Forms.Panel mainMapPanel;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel tilesetPanel;
        private System.Windows.Forms.PictureBox tilesetBox;
        private System.Windows.Forms.PictureBox tilesetWhite;
        private System.Windows.Forms.PictureBox tilesetBlack;
        private System.Windows.Forms.Panel tilesetBoxPanel;
        private System.Windows.Forms.PictureBox mapWhite;
        private System.Windows.Forms.PictureBox mapBlack;
        private System.Windows.Forms.Panel mapBoxPanel;
        private System.Windows.Forms.Panel scriptEditorPanel;
        private System.Windows.Forms.Panel scriptsPanel;
        private System.Windows.Forms.ListBox scriptBox;
        private System.Windows.Forms.TextBox scriptNameBox;
        private System.Windows.Forms.Label scriptNameLabel;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel tilePanel;
        private System.Windows.Forms.PictureBox tileWhite;
        private System.Windows.Forms.PictureBox tileBlack;
        private System.Windows.Forms.Panel allMapsPanel;
        private System.Windows.Forms.PictureBox allMapsBlack;
        private System.Windows.Forms.PictureBox allMapsWhite;
        private System.Windows.Forms.ToolStrip mappingTools;
        private System.Windows.Forms.ToolStripButton mapGrid;
        private System.Windows.Forms.ToolStripButton layerBtn1;
        private System.Windows.Forms.ToolStripButton layerBtn2;
        private System.Windows.Forms.ToolStripButton layerBtn3;
        private System.Windows.Forms.ToolStripButton layerBtn4;
        private System.Windows.Forms.ToolStripButton layerBtn5;
        private System.Windows.Forms.ToolStripButton layerBtn6;
        private System.Windows.Forms.ToolStripButton layerBtn7;
        private System.Windows.Forms.ToolStripButton mapSettings;
    }
}

