SCREENWIDTH = 512
SCREENHEIGHT = 384
Graphics.resize_screen(SCREENWIDTH, SCREENHEIGHT)

$LOAD_PATH << "."
Dir.glob("Scripts/*.rb") { |f| require f }