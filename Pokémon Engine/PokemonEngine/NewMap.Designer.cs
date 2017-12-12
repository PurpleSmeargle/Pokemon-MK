namespace PokemonEngine
{
    partial class NewMap
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tilesetBox = new System.Windows.Forms.ComboBox();
            this.heightBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.widthBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.create = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(50, 6);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(153, 20);
            this.nameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tileset:";
            // 
            // tilesetBox
            // 
            this.tilesetBox.FormattingEnabled = true;
            this.tilesetBox.Location = new System.Drawing.Point(50, 32);
            this.tilesetBox.Name = "tilesetBox";
            this.tilesetBox.Size = new System.Drawing.Size(153, 21);
            this.tilesetBox.TabIndex = 3;
            // 
            // heightBox
            // 
            this.heightBox.Location = new System.Drawing.Point(153, 59);
            this.heightBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.heightBox.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(41, 20);
            this.heightBox.TabIndex = 9;
            this.heightBox.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Height:";
            // 
            // widthBox
            // 
            this.widthBox.Location = new System.Drawing.Point(54, 60);
            this.widthBox.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.widthBox.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.widthBox.Name = "widthBox";
            this.widthBox.Size = new System.Drawing.Size(41, 20);
            this.widthBox.TabIndex = 7;
            this.widthBox.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Width:";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(9, 94);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 10;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // create
            // 
            this.create.Location = new System.Drawing.Point(126, 94);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(75, 23);
            this.create.TabIndex = 11;
            this.create.Text = "Create";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.create_Click);
            // 
            // NewMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 124);
            this.Controls.Add(this.create);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.widthBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tilesetBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Name = "NewMap";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Map";
            this.Load += new System.EventHandler(this.NewMap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.heightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tilesetBox;
        private System.Windows.Forms.NumericUpDown heightBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown widthBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button create;
    }
}