class Character
  attr_accessor :x
  attr_accessor :y
  attr_reader :id
  attr_accessor :name
  
  def initialize(id, map = $Map, name = "")
    @id = id
    @name = name
    @x = 0
    @y = 0
    @dir = :down
    @map = map
    @move_speed = 8
    _sprite = CharacterSprite.new(id)
    Graphics.maps[@map.id][:events] << _sprite
    @spriteindex = Graphics.maps[@map.id][:events].index(_sprite)
    sprite.x = @map.x
    sprite.y = 32 + @map.y
    sprite.move_speed = @move_speed
  end
  
  def moving?
    return true if sprite.right_mov || sprite.left_mov ||
                   sprite.down_mov || sprite.up_mov
    return false
  end
  
  def moving_right?
    return !sprite.right_mov.nil?
  end
  
  def moving_left?
    return !sprite.left_mov.nil?
  end
  
  def moving_down?
    return !sprite.down_mov.nil?
  end
  
  def moving_up?
    return !sprite.up_mov.nil?
  end
  
  def sprite
    return Graphics.maps[@map.id][:events][@spriteindex]
  end
  
  def dir=(value)
    value = [:still,:down_left,:down,:down_right,:left,:still,
             :right,:up_left,:up,:up_right][value] if value.is_a?(Numeric)
    mod = 0
    mod = 1 if value == 4
    mod = 2 if value == 6
    mod = 3 if value == 8
    sprite.src_rect.y = sprite.bmp.height / 4 * mod
    @dir = value
  end
  
  def update
    sprite.update
    sprite.x = @map.x + @x * 32 unless moving?
    sprite.y = 32 + @map.y + @y * 32 unless moving?
    
    #p sprite.x if moving?
  end
  
  def go_right
    if !moving?
      if @x < @map.width - 1 && @map.passable?(@x, @y) && @map.passable?(@x + 1, @y)
        sprite.go_right
        @x += 1
      else
        turn_right
      end
      @dir = :right
      return true
    end
    return false
  end
  
  def go_left
    if !moving?
      if @x > 0 && @map.passable?(@x, @y) && @map.passable?(@x - 1, @y)
        sprite.go_left
        @x -= 1
      else
        turn_left
      end
      @dir = :left
      return true
    end
    return false
  end
  
  def go_down
    if !moving?
      if @y < @map.height - 1 && @map.passable?(@x, @y) && @map.passable?(@x, @y + 1)
        sprite.go_down
        @y += 1
      else
        turn_down
      end
      @dir = :down
      return true
    end
    return false
  end
  
  def go_up
    if !moving?
      if @y > 0 && @map.passable?(@x, @y) && @map.passable?(@x, @y - 1)
        sprite.go_up
        @y -= 1
      else
        turn_up
      end
      @dir = :up
      return true
    end
    return false
  end
  
  def turn_right
    sprite.turn_right
    @dir = :right
  end
  
  def turn_left
    sprite.turn_left
    @dir = :left
  end
  
  def turn_down
    sprite.turn_down
    @dir = :down
  end
  
  def turn_up
    sprite.turn_up
    @dir = :up
  end
  
  def move_random
    case rand(4)
    when 0
      go_right
    when 1
      go_left
    when 2
      go_down
    when 3
      go_up
    end
  end
  
  def turn_random
    case rand(4)
    when 0
      turn_right
    when 1
      go_left
    when 2
      go_down
    when 3
      go_up
    end
  end
end