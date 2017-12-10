# Must be called before anything else
System.initialize

Species.compile

#p Species.new(2).name
#p Species.new(:IVYSAUR).name



# Commented out so you can play the map
#pbLoadScene

$Viewports = {}
# Maps, events
$Viewports["main"] = Viewport.new(0,0,Graphics.width,Graphics.height)

$Map = Map.new(1)
$Player = Player.new


loop do
  begin
    Graphics.update
    Input.update
    $Player.update
    $Map.update
  rescue
    e = $!
    System.show_formatted_error(e)
  end
end