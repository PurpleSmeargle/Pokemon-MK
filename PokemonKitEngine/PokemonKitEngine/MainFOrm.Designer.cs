namespace PokemonKitEngine
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
            this.tilesetPanel = new System.Windows.Forms.Panel();
            this.tilesetBox = new System.Windows.Forms.PictureBox();
            this.tilesetPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tilesetPanel
            // 
            this.tilesetPanel.AutoScroll = true;
            this.tilesetPanel.Controls.Add(this.tilesetBox);
            this.tilesetPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tilesetPanel.Location = new System.Drawing.Point(0, 0);
            this.tilesetPanel.Name = "tilesetPanel";
            this.tilesetPanel.Size = new System.Drawing.Size(256, 714);
            this.tilesetPanel.TabIndex = 0;
            // 
            // tilesetBox
            // 
            this.tilesetBox.Location = new System.Drawing.Point(3, 3);
            this.tilesetBox.Name = "tilesetBox";
            this.tilesetBox.Size = new System.Drawing.Size(137, 169);
            this.tilesetBox.TabIndex = 0;
            this.tilesetBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 714);
            this.Controls.Add(this.tilesetPanel);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Pokémon Kit Engine";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tilesetPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tilesetBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel tilesetPanel;
        private System.Windows.Forms.PictureBox tilesetBox;
    }
}

