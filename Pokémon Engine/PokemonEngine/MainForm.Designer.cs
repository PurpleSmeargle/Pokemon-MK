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
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mapsTab = new System.Windows.Forms.TabPage();
            this.mainMapPanel = new System.Windows.Forms.Panel();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.mapBoxPanel = new System.Windows.Forms.Panel();
            this.mapWhite = new System.Windows.Forms.PictureBox();
            this.mapBlack = new System.Windows.Forms.PictureBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.rightPanelSplitter = new System.Windows.Forms.SplitContainer();
            this.tilePanel = new System.Windows.Forms.Panel();
            this.allMapsPanel = new System.Windows.Forms.Panel();
            this.tilesetPanel = new System.Windows.Forms.Panel();
            this.tilesetBoxPanel = new System.Windows.Forms.Panel();
            this.tilesetBox = new System.Windows.Forms.PictureBox();
            this.tilesetWhite = new System.Windows.Forms.PictureBox();
            this.tilesetBlack = new System.Windows.Forms.PictureBox();
            this.toolbarPanel = new System.Windows.Forms.Panel();
            this.scriptsTab = new System.Windows.Forms.TabPage();
            this.menuBar.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.mapsTab.SuspendLayout();
            this.mainMapPanel.SuspendLayout();
            this.mapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mapWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBlack)).BeginInit();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightPanelSplitter)).BeginInit();
            this.rightPanelSplitter.Panel1.SuspendLayout();
            this.rightPanelSplitter.Panel2.SuspendLayout();
            this.rightPanelSplitter.SuspendLayout();
            this.tilesetPanel.SuspendLayout();
            this.tilesetBoxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetWhite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBlack)).BeginInit();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.BackColor = System.Drawing.Color.Transparent;
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.changeNameToolStripMenuItem});
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
            // changeNameToolStripMenuItem
            // 
            this.changeNameToolStripMenuItem.Name = "changeNameToolStripMenuItem";
            this.changeNameToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.changeNameToolStripMenuItem.Text = "Settings";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.mapsTab);
            this.mainTabControl.Controls.Add(this.scriptsTab);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 24);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.ShowToolTips = true;
            this.mainTabControl.Size = new System.Drawing.Size(1173, 807);
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
            this.mapsTab.Size = new System.Drawing.Size(1165, 781);
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
            this.mainMapPanel.Size = new System.Drawing.Size(1159, 745);
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
            this.mapPanel.Size = new System.Drawing.Size(719, 745);
            this.mapPanel.TabIndex = 2;
            // 
            // mapBoxPanel
            // 
            this.mapBoxPanel.Location = new System.Drawing.Point(6, 2);
            this.mapBoxPanel.Name = "mapBoxPanel";
            this.mapBoxPanel.Size = new System.Drawing.Size(695, 741);
            this.mapBoxPanel.TabIndex = 2;
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
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.rightPanelSplitter);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(979, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(180, 745);
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
            this.rightPanelSplitter.Size = new System.Drawing.Size(180, 745);
            this.rightPanelSplitter.SplitterDistance = 366;
            this.rightPanelSplitter.TabIndex = 0;
            // 
            // tilePanel
            // 
            this.tilePanel.BackColor = System.Drawing.SystemColors.Control;
            this.tilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilePanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tilePanel.Location = new System.Drawing.Point(0, 0);
            this.tilePanel.Name = "tilePanel";
            this.tilePanel.Size = new System.Drawing.Size(180, 366);
            this.tilePanel.TabIndex = 0;
            // 
            // allMapsPanel
            // 
            this.allMapsPanel.BackColor = System.Drawing.SystemColors.Control;
            this.allMapsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allMapsPanel.Location = new System.Drawing.Point(0, 0);
            this.allMapsPanel.Name = "allMapsPanel";
            this.allMapsPanel.Size = new System.Drawing.Size(180, 375);
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
            this.tilesetPanel.Size = new System.Drawing.Size(260, 745);
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
            // toolbarPanel
            // 
            this.toolbarPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolbarPanel.Location = new System.Drawing.Point(3, 3);
            this.toolbarPanel.Name = "toolbarPanel";
            this.toolbarPanel.Size = new System.Drawing.Size(1159, 30);
            this.toolbarPanel.TabIndex = 4;
            // 
            // scriptsTab
            // 
            this.scriptsTab.BackColor = System.Drawing.SystemColors.Control;
            this.scriptsTab.Location = new System.Drawing.Point(4, 22);
            this.scriptsTab.Name = "scriptsTab";
            this.scriptsTab.Padding = new System.Windows.Forms.Padding(3);
            this.scriptsTab.Size = new System.Drawing.Size(1165, 781);
            this.scriptsTab.TabIndex = 1;
            this.scriptsTab.Text = "Scripts";
            this.scriptsTab.ToolTipText = "Contains all tools and funtionality for scripting.";
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
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.mapsTab.ResumeLayout(false);
            this.mainMapPanel.ResumeLayout(false);
            this.mapPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mapWhite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mapBlack)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.rightPanelSplitter.Panel1.ResumeLayout(false);
            this.rightPanelSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightPanelSplitter)).EndInit();
            this.rightPanelSplitter.ResumeLayout(false);
            this.tilesetPanel.ResumeLayout(false);
            this.tilesetBoxPanel.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem changeNameToolStripMenuItem;
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
    }
}

