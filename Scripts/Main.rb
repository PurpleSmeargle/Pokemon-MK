# Must be called before anything else
System.initialize

Species.compile

p Species.new(2).name
p Species.new(:IVYSAUR).name

# Commented out so you can play the map
#pbLoadScene

$Viewports = {}
# Maps, events
$Viewports["main"] = Viewport.new(0,0,Graphics.width,Graphics.height)

$Map = Map.new(1)
$Player = Player.new

loop do
	Graphics.update
	Input.update
	$Player.update
	$Map.update
	if !$Player.moving?
		if Input.trigger?(Input::C)
			p 'Saving...'
			System.save
		end
		if Input.trigger?(Input::B)
			p 'Loading...'
			System.load
		end
	end
end