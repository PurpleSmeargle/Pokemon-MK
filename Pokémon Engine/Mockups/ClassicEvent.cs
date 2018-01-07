using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mockups
{
    public partial class ClassicEvent : Form
    {
        public ClassicEvent()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Condition c = new Condition();
            c.ShowDialog();
        }

        private void ClassicEvent_Load(object sender, EventArgs e)
        {
            eventCommands.DrawMode = DrawMode.OwnerDrawVariable;
            eventCommands.MeasureItem += EventCommands_MeasureItem;
            eventCommands.DrawItem += EventCommands_DrawItem;

            /*eventCommands.Items.Add("@>Text: I heard you were going to the Pokémon Centre.");
            eventCommands.Items.Add("@>if (Has Pokemon (Bulbasaur) in PC) OR (Has Pokemon (Bulbasaur) in Party)");
            eventCommands.Items.Add("@>  Text: You have a Bulbasaur.");
            eventCommands.Items.Add("@>else");
            eventCommands.Items.Add("@>  Text: You don't have a Bulbasaur.");
            eventCommands.Items.Add("@>end");
            eventCommands.Items.Add("@>Text: So be it, then.");*/
        }

        private void EventCommands_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Color c = e.Index == 1 || e.Index == 3 || e.Index == 5 ? Color.Blue : e.ForeColor;
            e.Graphics.DrawString(eventCommands.Items[e.Index].ToString(), e.Font, new SolidBrush(c), e.Bounds);
        }

        private void EventCommands_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            
        }
    }
}
