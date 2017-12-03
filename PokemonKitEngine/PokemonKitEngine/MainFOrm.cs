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
using static PokemonKitEngine.Util;

namespace PokemonKitEngine
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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

            Map Map001 = MapInterpreter.ParseMap(1);

            MessageBox.Show(Map001.General.Name);
        }
    }
}