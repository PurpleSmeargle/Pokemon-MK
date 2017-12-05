$LOAD_PATH << "."
Dir.glob("Scripts/*.rb") do |f|
  require f
end