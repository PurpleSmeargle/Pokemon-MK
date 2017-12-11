using System;
using System.Collections.Generic;

namespace PokemonEngine
{
    public class Config
    {
        // MKXP Config
        // Editable
        public static int RGSSVersion { get; set; } = 3;
        public static bool PrintFPS { get; set; } = false;
        public static bool StartFullscreen { get; set; } = false;
        public static bool FixedAspectRatio { get; set; } = true;
        public static bool SmoothScaling { get; set; } = true;
        public static int ScreenWidth { get; set; } = 512;
        public static int ScreenHeight { get; set; } = 384;
        public static int FixedFramerate { get; set; } = 0;
        public static bool F12SoftReset { get; set; } = true;
        public static string IconPath { get; set; } = null;
        // Not editable via the engine; have to be stored
        public static bool _DebugMode { get; set; } = false;
        public static bool _WinResizable { get; set; } = false;
        public static bool _VSync { get; set; } = false;
        public static bool _FrameSkip { get; set; } = true;
        public static bool _SyncToRefreshRate { get; set; } = false;
        public static bool _SolidFonts { get; set; } = false;
        public static bool _SubImageFix { get; set; } = false;
        public static bool _EnableBlitting { get; set; } = true;
        public static string _MaxTextureSize { get; set; } = "0";
        public static string _GameFolder { get; set; } = null;
        public static bool _AnyAltToggleFS { get; set; } = false;
        public static bool _AllowSymLinks { get; set; } = false;
        public static string _DataPathOrg { get; set; } = null;
        public static string _DataPathApp { get; set; } = null;
        public static string _CustomScript { get; set; } = null;
        public static string _PreloadScript { get; set; } = null;
        public static bool _PathCache { get; set; } = true;
        public static List<string> _RTP { get; set; } = new List<string>();
        public static bool _UseScriptNames { get; set; } = false;
        public static string _RubyLoadPath { get; set; } = null;
        public static string _SoundFont { get; set; } = null;
        public static bool _Chorus { get; set; } = false;
        public static bool _Reverb { get; set; } = false;
        public static int _SourceCount { get; set; } = 6;
        public static string _ExecName { get; set; } = null;
        public static string _TitleLanguage { get; set; } = null;

        // Engine config
        public static int LastMainTab { get; set; } = 0;
        public static int LastScriptIndex { get; set; } = 0;
        public static bool DebugMode { get; set; } = true;
        public static bool ShowGrid { get; set; } = false;
        public static int GridWidth { get; set; } = 1;
        public static int GridHeight { get; set; } = 1;
        public static System.Drawing.Color GridColor { get; set; } = System.Drawing.Color.FromArgb(96, 0, 0, 0);
    }
}
