# Must be called before anything else
System.initialize

Species.compile

#b = Species.new(1)
#p b.base_exp
#p b.types
#p b.gender_rate
#p b.growth_rate
#p b.base_stats



# Commented out so you can play the map
#pbLoadScene

$Viewports = {}
# Maps, events
$Viewports["main"] = Viewport.new(0,0,Graphics.width,Graphics.height)

$Map = Map.new(3)
$Player = Player.new
$Player.x = 9
$Player.y = 4
npc = Character.new(1)
npc.x = 9
npc.y = 2

# Instructions to follow.
win = MessageWindow.new(1)
win.text = "Hello! I am here to tell you that you will die tomorrow."

loop do
  begin
    Graphics.update
    Input.update
    $Player.update
    npc.update
    npc.move_random if Graphics.frame_count % 60 == 0
    win.update
    $Map.update
  rescue
    System.show_formatted_error($!)
  end
end