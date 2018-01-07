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
    public partial class SettingsForm : Form
    {
        int OldRGSSVersion;
        bool OldPrintFPS;
        bool OldStartFullscreen;
        bool OldFixedAspectRatio;
        bool OldSmoothScaling;
        bool OldF12SoftReset;
        int OldFixedFrameRate;
        int OldScreenWidth;
        int OldScreenHeight;
        string OldIconPath;
        string OldWindowTitle;

        bool SaveChanges = false;

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            OldRGSSVersion = Config.RGSSVersion;
            OldPrintFPS = Config.PrintFPS;
            OldStartFullscreen = Config.StartFullscreen;
            OldFixedAspectRatio = Config.FixedAspectRatio;
            OldSmoothScaling = Config.SmoothScaling;
            OldF12SoftReset = Config.F12SoftReset;
            OldFixedFrameRate = Config.FixedFramerate;
            OldScreenWidth = Config.ScreenWidth;
            OldScreenHeight = Config.ScreenHeight;
            OldIconPath = Config.IconPath;
            OldWindowTitle = Config.WindowTitle;

            rgssVersion.SelectedIndex = Config.RGSSVersion;
            printFPS.Checked = Config.PrintFPS;
            startFullscreen.Checked = Config.StartFullscreen;
            fixedAspectRatio.Checked = Config.FixedAspectRatio;
            smoothScaling.Checked = Config.SmoothScaling;
            f12SoftReset.Checked = Config.F12SoftReset;
            fixedFramerate.Value = Config.FixedFramerate;
            screenWidth.Value = Config.ScreenWidth;
            screenHeight.Value = Config.ScreenHeight;
            windowTitle.Text = Config.WindowTitle;
        }

        // Cancel
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Apply
        private void button2_Click(object sender, EventArgs e)
        {
            ActiveControl = (Control) sender;
            SaveChanges = true;
            Close();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EventArgs ev = new EventArgs();
            rgssVersion_SelectedIndexChanged(sender, ev);
            printFPS_CheckedChanged(sender, ev);
            startFullscreen_CheckedChanged(sender, ev);
            fixedAspectRatio_CheckedChanged(sender, ev);
            smoothScaling_CheckedChanged(sender, ev);
            f12SoftReset_CheckedChanged(sender, ev);
            maxFramerate_ValueChanged(sender, ev);
            screenWidth_ValueChanged(sender, ev);
            screenHeight_ValueChanged(sender, ev);
            windowTitle_TextChanged(sender, ev);

            if (!SaveChanges)
            {
                Config.RGSSVersion = OldRGSSVersion;
                Config.PrintFPS = OldPrintFPS;
                Config.StartFullscreen = OldStartFullscreen;
                Config.FixedAspectRatio = OldFixedAspectRatio;
                Config.SmoothScaling = OldSmoothScaling;
                Config.F12SoftReset = OldF12SoftReset;
                Config.FixedFramerate = OldFixedFrameRate;
                Config.ScreenWidth = OldScreenWidth;
                Config.ScreenHeight = OldScreenHeight;
                Config.IconPath = OldIconPath;
                Config.WindowTitle = OldWindowTitle;
            }
        }

        private void rgssVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Config.RGSSVersion = rgssVersion.SelectedIndex;
        }

        private void printFPS_CheckedChanged(object sender, EventArgs e)
        {
            Config.PrintFPS = printFPS.Checked;
        }

        private void startFullscreen_CheckedChanged(object sender, EventArgs e)
        {
            Config.StartFullscreen = startFullscreen.Checked;
        }

        private void fixedAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            Config.FixedAspectRatio = fixedAspectRatio.Checked;
        }

        private void smoothScaling_CheckedChanged(object sender, EventArgs e)
        {
            Config.SmoothScaling = smoothScaling.Checked;
        }

        private void f12SoftReset_CheckedChanged(object sender, EventArgs e)
        {
            Config.F12SoftReset = f12SoftReset.Checked;
        }

        private void maxFramerate_ValueChanged(object sender, EventArgs e)
        {
            Config.FixedFramerate = (int) fixedFramerate.Value;
        }

        private void screenWidth_ValueChanged(object sender, EventArgs e)
        {
            Config.ScreenWidth = (int) screenWidth.Value;
        }

        private void screenHeight_ValueChanged(object sender, EventArgs e)
        {
            Config.ScreenHeight = (int) screenHeight.Value;
        }

        private void windowTitle_TextChanged(object sender, EventArgs e)
        {
            Config.WindowTitle = windowTitle.Text;
        }

        private void engineStoreMapsInMemory_MouseHover(object sender, EventArgs e)
        {
            storeMapsInMemory.SetToolTip(engineStoreMapsInMemory, "Enabling this setting will keep a Map's Bitmaps stored in Memory when switching between maps.\r\nThis will make loading maps much faster, but it will be quite costly for your memory.");
        }

        private void engineStoreMapsInMemory_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
