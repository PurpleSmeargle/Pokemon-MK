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
            this.components = new System.ComponentModel.Container();
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mapsTab = new System.Windows.Forms.TabPage();
            this.mainMapPanel = new System.Windows.Forms.Panel();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.mapBoxPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.rightPanelSplitter = new System.Windows.Forms.SplitContainer();
            this.tilePanel = new System.Windows.Forms.Panel();
            this.allMapsPanel = new System.Windows.Forms.Panel();
            this.tilesetPanel = new System.Windows.Forms.Panel();
            this.tilesetBoxPanel = new System.Windows.Forms.Panel();
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutThisMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsTab = new System.Windows.Forms.TabPage();
            this.scriptEditorPanel = new System.Windows.Forms.Panel();
            this.scriptsPanel = new System.Windows.Forms.Panel();
            this.scriptBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scriptNameBox = new System.Windows.Forms.TextBox();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapWhite = new System.Windows.Forms.PictureBox();
            this.mapBlack = new System.Windows.Forms.PictureBox();
            this.tilesetBox = new System.Windows.Forms.PictureBox();
            this.tilesetWhite = new System.Windows.Forms.PictureBox();
            this.tilesetBlack = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuBar.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.mapsTab.SuspendLayout();
            this.mainMapPanel.SuspendLayout();
            this.mapPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightPanelSplitter)).BeginInit();
            this.rightPanelSplitter.Panel1.SuspendLayout();
            this.rightPanelSplitter.Panel2.SuspendLayout();
            this.rightPanelSplitter.SuspendLayout();
            this.tilesetPanel.SuspendLayout();
            this.tilesetBoxPanel.SuspendLayout();
            this.toolbarPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.scriptsTab.SuspendLayout();
            this.scriptsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBlack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBlack)).BeginInit();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.Transparent;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(1173, 24);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuStrip1";
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
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.aboutToolStripMenuItem.Text = "Engine";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.mapsTab);
            this.mainTabControl.Controls.Add(this.scriptsTab);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mainTabControl.Location = new System.Drawing.Point(0, 72);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.ShowToolTips = true;
            this.mainTabControl.Size = new System.Drawing.Size(1173, 759);
            this.mainTabControl.TabIndex = 2;
            // 
            // mapsTab
            // 
            this.mapsTab.BackColor = System.Drawing.SystemColors.Control;
            this.mapsTab.Controls.Add(this.mainMapPanel);
            this.mapsTab.Controls.Add(this.toolbarPanel);
            this.mapsTab.Location = new System.Drawing.Point(4, 22);
            this.mapsTab.Name = "mapsTab";
            this.mapsTab.Padding = new System.Windows.Forms.Padding(3);
            this.mapsTab.Size = new System.Drawing.Size(1165, 733);
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
            this.mainMapPanel.Location = new System.Drawing.Point(3, 33);
            this.mainMapPanel.Name = "mainMapPanel";
            this.mainMapPanel.Size = new System.Drawing.Size(1159, 697);
            this.mainMapPanel.TabIndex = 5;
            // 
            // mapPanel
            // 
            this.mapPanel.Controls.Add(this.mapBoxPanel);
            this.mapPanel.Controls.Add(this.mapWhite);
            this.mapPanel.Controls.Add(this.mapBlack);
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(260, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(719, 697);
            this.mapPanel.TabIndex = 2;
            // 
            // mapBoxPanel
            // 
            this.mapBoxPanel.Location = new System.Drawing.Point(6, 2);
            this.mapBoxPanel.Name = "mapBoxPanel";
            this.mapBoxPanel.Size = new System.Drawing.Size(695, 741);
            this.mapBoxPanel.TabIndex = 2;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.rightPanelSplitter);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(979, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(180, 697);
            this.rightPanel.TabIndex = 1;
            // 
            // rightPanelSplitter
            // 
            this.rightPanelSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanelSplitter.Location = new System.Drawing.Point(0, 0);
            this.rightPanelSplitter.Name = "rightPanelSplitter";
            this.rightPanelSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rightPanelSplitter.Panel1
            // 
            this.rightPanelSplitter.Panel1.Controls.Add(this.tilePanel);
            // 
            // rightPanelSplitter.Panel2
            // 
            this.rightPanelSplitter.Panel2.Controls.Add(this.allMapsPanel);
            this.rightPanelSplitter.Size = new System.Drawing.Size(180, 697);
            this.rightPanelSplitter.SplitterDistance = 342;
            this.rightPanelSplitter.TabIndex = 0;
            // 
            // tilePanel
            // 
            this.tilePanel.BackColor = System.Drawing.SystemColors.Control;
            this.tilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilePanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tilePanel.Location = new System.Drawing.Point(0, 0);
            this.tilePanel.Name = "tilePanel";
            this.tilePanel.Size = new System.Drawing.Size(180, 342);
            this.tilePanel.TabIndex = 0;
            // 
            // allMapsPanel
            // 
            this.allMapsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.allMapsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allMapsPanel.Location = new System.Drawing.Point(0, 0);
            this.allMapsPanel.Name = "allMapsPanel";
            this.allMapsPanel.Size = new System.Drawing.Size(180, 351);
            this.allMapsPanel.TabIndex = 0;
            // 
            // tilesetPanel
            // 
            this.tilesetPanel.Controls.Add(this.tilesetBoxPanel);
            this.tilesetPanel.Controls.Add(this.tilesetWhite);
            this.tilesetPanel.Controls.Add(this.tilesetBlack);
            this.tilesetPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tilesetPanel.Location = new System.Drawing.Point(0, 0);
            this.tilesetPanel.Name = "tilesetPanel";
            this.tilesetPanel.Size = new System.Drawing.Size(260, 697);
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
            // toolbarPanel
            // 
            this.toolbarPanel.Controls.Add(this.menuStrip1);
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarPanel.Location = new System.Drawing.Point(3, 3);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(1159, 30);
            this.toolbarPanel.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutThisMapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutThisMapToolStripMenuItem
            // 
            this.aboutThisMapToolStripMenuItem.Name = "aboutThisMapToolStripMenuItem";
            this.aboutThisMapToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.aboutThisMapToolStripMenuItem.Text = "About this map";
            this.aboutThisMapToolStripMenuItem.Click += new System.EventHandler(this.aboutThisMapToolStripMenuItem_Click);
            // 
            // scriptsTab
            // 
            this.scriptsTab.BackColor = System.Drawing.SystemColors.Control;
            this.scriptsTab.Controls.Add(this.scriptEditorPanel);
            this.scriptsTab.Controls.Add(this.scriptsPanel);
            this.scriptsTab.Location = new System.Drawing.Point(4, 22);
            this.scriptsTab.Name = "scriptsTab";
            this.scriptsTab.Padding = new System.Windows.Forms.Padding(3);
            this.scriptsTab.Size = new System.Drawing.Size(1165, 760);
            this.scriptsTab.TabIndex = 1;
            this.scriptsTab.Text = "Scripts";
            this.scriptsTab.ToolTipText = "Contains all tools and funtionality for scripting.";
            // 
            // scriptEditorPanel
            // 
            this.scriptEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scriptEditorPanel.Location = new System.Drawing.Point(176, 3);
            this.scriptEditorPanel.Name = "scriptEditorPanel";
            this.scriptEditorPanel.Size = new System.Drawing.Size(986, 754);
            this.scriptEditorPanel.TabIndex = 1;
            // 
            // scriptsPanel
            // 
            this.scriptsPanel.Controls.Add(this.scriptNameBox);
            this.scriptsPanel.Controls.Add(this.label1);
            this.scriptsPanel.Controls.Add(this.scriptBox);
            this.scriptsPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.scriptsPanel.Location = new System.Drawing.Point(3, 3);
            this.scriptsPanel.Name = "scriptsPanel";
            this.scriptsPanel.Size = new System.Drawing.Size(173, 754);
            this.scriptsPanel.TabIndex = 0;
            // 
            // scriptBox
            // 
            this.scriptBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.scriptBox.FormattingEnabled = true;
            this.scriptBox.Location = new System.Drawing.Point(0, 0);
            this.scriptBox.Name = "scriptBox";
            this.scriptBox.Size = new System.Drawing.Size(173, 719);
            this.scriptBox.TabIndex = 0;
            this.scriptBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.scriptBox_MouseClick);
            this.scriptBox.SelectedIndexChanged += new System.EventHandler(this.scriptBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 726);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // scriptNameBox
            // 
            this.scriptNameBox.Location = new System.Drawing.Point(13, 743);
            this.scriptNameBox.Name = "scriptNameBox";
            this.scriptNameBox.Size = new System.Drawing.Size(146, 20);
            this.scriptNameBox.TabIndex = 2;
            this.scriptNameBox.TextChanged += new System.EventHandler(this.scriptNameBox_TextChanged);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.playToolStripMenuItem.Text = "Play";
            // 
            // mapWhite
            // 
            this.mapWhite.Location = new System.Drawing.Point(5, 1);
            this.mapWhite.Name = "mapWhite";
            this.mapWhite.Size = new System.Drawing.Size(697, 743);
            this.mapWhite.TabIndex = 1;
            this.mapWhite.TabStop = false;
            // 
            // mapBlack
            // 
            this.mapBlack.BackColor = System.Drawing.Color.DimGray;
            this.mapBlack.Location = new System.Drawing.Point(4, 0);
            this.mapBlack.Name = "mapBlack";
            this.mapBlack.Size = new System.Drawing.Size(699, 745);
            this.mapBlack.TabIndex = 0;
            this.mapBlack.TabStop = false;
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
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 831);
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
            this.rightPanel.ResumeLayout(false);
            this.rightPanelSplitter.Panel1.ResumeLayout(false);
            this.rightPanelSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightPanelSplitter)).EndInit();
            this.rightPanelSplitter.ResumeLayout(false);
            this.tilesetPanel.ResumeLayout(false);
            this.tilesetBoxPanel.ResumeLayout(false);
            this.toolbarPanel.ResumeLayout(false);
            this.toolbarPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.scriptsTab.ResumeLayout(false);
            this.scriptsPanel.ResumeLayout(false);
            this.scriptsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBlack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBlack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage mapsTab;
        private System.Windows.Forms.TabPage scriptsTab;
        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.Panel mainMapPanel;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel tilesetPanel;
        private System.Windows.Forms.PictureBox tilesetBox;
        private System.Windows.Forms.SplitContainer rightPanelSplitter;
        private System.Windows.Forms.Panel tilePanel;
        private System.Windows.Forms.Panel allMapsPanel;
        private System.Windows.Forms.PictureBox tilesetWhite;
        private System.Windows.Forms.PictureBox tilesetBlack;
        private System.Windows.Forms.Panel tilesetBoxPanel;
        private System.Windows.Forms.PictureBox mapWhite;
        private System.Windows.Forms.PictureBox mapBlack;
        private System.Windows.Forms.Panel mapBoxPanel;
        private System.Windows.Forms.Panel scriptEditorPanel;
        private System.Windows.Forms.Panel scriptsPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutThisMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ListBox scriptBox;
        private System.Windows.Forms.TextBox scriptNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.ImageList imageList1;
    }
}

