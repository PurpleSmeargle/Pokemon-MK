using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokemonEngine
{
    public partial class ConfigureGrid : Form
    {
        int OldWidth;
        int OldHeight;
        int OldR;
        int OldG;
        int OldB;
        int OldA;

        public bool Update = false;

        public ConfigureGrid()
        {
            InitializeComponent();
        }

        private void ConfigureGrid_Load(object sender, EventArgs e)
        {
            OldWidth = Config.GridWidth;
            OldHeight = Config.GridHeight;
            OldR = Config.GridColor.R;
            OldG = Config.GridColor.G;
            OldB = Config.GridColor.B;
            OldA = Config.GridColor.A;

            widthBox.Value = Config.GridWidth;
            heightBox.Value = Config.GridHeight;
            rBox.Value = Config.GridColor.R;
            gBox.Value = Config.GridColor.G;
            bBox.Value = Config.GridColor.B;
            aBox.Value = Config.GridColor.A;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config.GridColor = Color.FromArgb(OldA, OldR, OldG, OldB);
            Config.GridWidth = OldWidth;
            Config.GridHeight = OldHeight;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update = true;
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Config.GridWidth = (int) widthBox.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Config.GridHeight = (int) heightBox.Value;
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Config.GridColor = Color.FromArgb(Config.GridColor.A, (int) rBox.Value, Config.GridColor.G, Config.GridColor.B);
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            Config.GridColor = Color.FromArgb(Config.GridColor.A, Config.GridColor.R, (int) gBox.Value, Config.GridColor.B);
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            Config.GridColor = Color.FromArgb(Config.GridColor.A, Config.GridColor.R, Config.GridColor.G, (int) bBox.Value);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            Config.GridColor = Color.FromArgb((int) aBox.Value, Config.GridColor.R, Config.GridColor.G, Config.GridColor.B);
        }
    }
}
