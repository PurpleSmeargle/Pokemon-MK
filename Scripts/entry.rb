$LOAD_PATH << "."
Dir.glob("Scripts/*.rb") { |f| require f }