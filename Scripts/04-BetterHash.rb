# A better alternative to the typical @sprites = {}
class BetterHash
  attr_reader :x
  attr_reader :y
  attr_reader :z
  attr_reader :visible
  attr_reader :opacity
  
  def initialize
    @hash = {}
    @x = 0
    @y = 0
    @z = 0
    @visible = true
    @opacity = 255
  end
  
  # Returns the object in the specified key
  def [](key)
    key = key.to_sym if key.respond_to?(:to_sym)
    return @hash[key]
  end
  
  # Sets an object in specified key to the specified value
  def []=(key, value)
  key = key.to_sym if key.respond_to?(:to_sym)
    add(key, value)
  end
  
  def <<(value)
    i = 0
    while true
      if @hash[i]
        i += 1
        next
      end
      break
    end
    @hash[i] = value
  end
  
  # Returns the raw hash
  def raw
    return @hash
  end
  
  # Returns the keys in the hash
  def keys
    return @hash.keys
  end
  
  def length; return self.size; end
  def count; return self.size; end
  
  # Returns the amount of keys in the hash
  def size
    return @hash.keys.size
  end
  
  # Clones the hash
  def clone
    return @hash.clone
  end
  
  # Adds an object to the specified key
  def add(key, value)
    clear_disposed
    key = key.to_sym if key.respond_to?(:to_sym)
    @hash[key] if @hash[key] && @hash[key].respond_to?(:dispose)
    @hash[key] = value
    clear_disposed
  end
  
  # Deletes an object in the specified key
  def delete(key)
    key = key.to_sym if key.respond_to?(:to_sym)
    @hash[key] = nil
    clear_disposed
  end
  
  # Iterates over all sprites
  def each
    clear_disposed
    @hash.each { |s| yield s[1] if block_given? }
  end
  
  # Updates all sprites
  def update
    clear_disposed
    for key in @hash.keys
      @hash[key].update if @hash[key].respond_to?(:update)
    end
  end
  
  # Disposes all sprites
  def dispose
    clear_disposed
    for key in @hash.keys
      @hash[key].dispose if @hash[key].respond_to?(:dispose)
    end
    clear_disposed
  end
  
  # Compatibility
  def disposed?
    return false
  end
  
  # Changes x on all sprites
  def x=(value)
    clear_disposed
    for key in @hash.keys
      @hash[key].x += value - @x
    end
    @x = value
  end
  
  # Changes y on all sprites
  def y=(value)
    clear_disposed
    for key in @hash.keys
      @hash[key].y += value - @y
    end
    @y = value
  end
  
  # Changes z on all sprites
  def z=(value)
    clear_disposed
    for key in @hash.keys
      @hash[key].z += value - @z
    end
    @z = value
  end
  
  # Changes visibility on all sprites
  def visible=(value)
    clear_disposed
    for key in @hash.keys
      @hash[key].visible = value
    end
  end
  
  # Changes opacity on all sprites
  def opacity=(value)
    clear_disposed
    for key in @hash.keys
      @hash[key].opacity += value - @opacity
    end
    @opacity = [0,value,255].sort[1]
  end
  
  # Fades out all sprites
  def hide(frames = 16)
    clear_disposed
    frames.times do
      Graphics.update
      Input.update
      for key in @hash.keys
        @hash[key].opacity -= 255 / frames.to_f
      end
    end
    @opacity = 0
  end
  
  # Fades in all sprites
  def show(frames = 16)
    clear_disposed
    frames.times do
      Graphics.update
      Input.update
      for key in @hash.keys
        @hash[key].opacity += 255 / frames.to_f
      end
    end
    @opacity = 255
  end
  
  # Deletes all disposed sprites from the hash
  def clear_disposed
    for key in @hash.keys
      if (@hash[key].disposed? rescue false)
        @hash[key] = nil
        @hash.delete(key)
      end
    end
  end
end