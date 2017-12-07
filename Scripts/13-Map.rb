class Map
  attr_reader :id
  attr_reader :width
  attr_reader :height
  attr_reader :x
  attr_reader :y
  attr_accessor :active
  attr_reader :layers
  
  def initialize(id, current_map = false)
    @id = id
    @width = 0
    @height = 0
    @x = 0
    @y = 0
    @active = current_map
    
    @data = File.open("Maps/#{id.to_digits}.dat") do |f|
      next Marshal.load(f)
    end
    
    @width = @data[:general][:width]
    @height = @data[:general][:height]
    @tileset = @data[:general][:tileset]
    
    bmp = Bitmap.new("Graphics/Tilesets/#{@tileset}")
    
    layers = BetterHash.new
    for i in 0...@data[:layers].size
      layer = @data[:layers][i]
      for j in 0...layer.size
        id = layer[j]
        id = layer[j][0] if id.is_a?(Array)
        next if id == 0
        priority = 0
        priority = layer[j][2] if layer[j].is_a?(Array) && layer[j][2] && layer[j][2] >= 0
        unless layers[priority]
          layers[priority] = Sprite.new($Viewports["main"])
          layers[priority].bmp(32 * @width, 32 * @height)
          layers[priority].z = priority
        end
        layers[priority].bmp.blt(32 * (j % @width), 32 * ((j / @height).floor), bmp, Rect.new(32 * (id % 8), 32 * ((id / 8).floor), 32, 32))
      end
    end
    Graphics.maps[@id] = BetterHash.new
    Graphics.maps[@id][:layers] = layers
    Graphics.maps[@id][:events] = []
  end
  
  def tile_data(x, y, layer = nil)
    return @data[:layers][layer][x + @width * y] if layer
    ret = []
    i = 0
    while true
      data = @data[:layers][i]
      break unless data
      ret << data[x + @width * y]
      i += 1
    end
    return ret
  end
  
  def passable?(x, y, dir = @dir)
    return true if Input.press?(Input::CTRL)
    data = tile_data(x, y)
    for layer in data
      return false if layer.is_a?(Array) && layer[1] == 0
    end
    return true
  end
  
  def x=(value)
    @x = value
    Graphics.maps[id][:layers].x = @x
  end
  
  def y=(value)
    @y = value
    Graphics.maps[id][:layers].y = @y
  end
  
  def update
    Graphics.maps[id].update
  end
end