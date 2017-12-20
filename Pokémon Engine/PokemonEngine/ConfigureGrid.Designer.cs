namespace PokemonEngine
{
    partial class ConfigureGrid
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
            this.label1 = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.NumericUpDown();
            this.heightBox = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.gBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.bBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.aBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "W: ";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(71, 7);
            this.widthBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(41, 20);
            this.widthBox.TabIndex = 1;
            this.widthBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthBox.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(141, 7);
            this.heightBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(41, 20);
            this.heightBox.TabIndex = 3;
            this.heightBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightBox.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "H: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Color:";
            // 
            // rBox
            // 
            this.rBox.Location = new System.Drawing.Point(72, 32);
            this.rBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.rBox.Name = "rBox";
            this.rBox.Size = new System.Drawing.Size(41, 20);
            this.rBox.TabIndex = 6;
            this.rBox.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "R:";
            // 
            // gBox
            // 
            this.gBox.Location = new System.Drawing.Point(141, 32);
            this.gBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.gBox.Name = "gBox";
            this.gBox.Size = new System.Drawing.Size(41, 20);
            this.gBox.TabIndex = 8;
            this.gBox.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(120, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "G:";
            // 
            // bBox
            // 
            this.bBox.Location = new System.Drawing.Point(72, 58);
            this.bBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.bBox.Name = "bBox";
            this.bBox.Size = new System.Drawing.Size(41, 20);
            this.bBox.TabIndex = 10;
            this.bBox.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "B:";
            // 
            // aBox
            // 
            this.aBox.Location = new System.Drawing.Point(141, 58);
            this.aBox.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.aBox.Name = "aBox";
            this.aBox.Size = new System.Drawing.Size(41, 20);
            this.aBox.TabIndex = 12;
            this.aBox.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(120, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "A:";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(12, 84);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(107, 84);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(75, 23);
            this.apply.TabIndex = 14;
            this.apply.Text = "Apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.button2_Click);
            // 
            // ConfigureGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 113);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.aBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.bBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.label1);
            this.Name = "ConfigureGrid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grid";
            this.Load += new System.EventHandler(this.ConfigureGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown widthBox;
        private System.Windows.Forms.NumericUpDown heightBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown rBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown gBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown bBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown aBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button apply;
    }
}