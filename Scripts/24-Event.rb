class Event
  attr_accessor :x
  attr_accessor :y
  attr_reader :id
  attr_accessor :name
  attr_reader :move_speed
  attr_reader :dir
  
  def initialize(id, map = $Map, name = "")
    @id = id
    @name = name
    @x = 0
    @y = 0
    @dir = :down
    @map = map
    @move_speed = 16
    _sprite = EventSprite.new(id, self)
    Graphics.maps[@map.id][:events] << _sprite
    @spriteindex = Graphics.maps[@map.id][:events].index(_sprite)
    sprite.x = @map.x
    sprite.y = 32 + @map.y
    sprite.move_speed = @move_speed
    sprite.update
    Events.on_event_created.call(self)
  end
  
  def can_move?
    return false if moving?
    return false if @frozen
    return true
  end
  
  def freeze
    @frozen = true
  end
  
  def unfreeze
    @frozen = false
  end
  
  # Returns whether or not this event is moving at all.
  def moving?
    return true if sprite.right_mov || sprite.left_mov ||
                   sprite.down_mov || sprite.up_mov
    return false
  end
  
  # Returns whether or not this event is moving right.
  def moving_right?
    return !sprite.right_mov.nil?
  end
  
  # Returns whether or not this event is moving left.
  def moving_left?
    return !sprite.left_mov.nil?
  end
  
  # Returns whether or not this event is moving down.
  def moving_down?
    return !sprite.down_mov.nil?
  end
  
  # Returns whether or not this event is moving up.
  def moving_up?
    return !sprite.up_mov.nil?
  end
  
  def move_speed=(value)
    @move_speed = value
    sprite.move_speed = value
  end
  
  # Returns this event's sprite object.
  def sprite
    return Graphics.maps[@map.id][:events][@spriteindex]
  end
  
  # Changes the direction this event is facing.
  def dir=(value)
    value = [:still,:down_left,:down,:down_right,:left,:still,
             :right,:up_left,:up,:up_right][value] if value.is_a?(Numeric)
    mod = 0
    mod = 1 if value == 4
    mod = 2 if value == 6
    mod = 3 if value == 8
    sprite.src_rect.y = sprite.bmp.height / 4 * mod
    @dir = value
    turn_right if @dir == :right
    turn_left if @dir == :left
    turn_down if @dir == :down
    turn_up if @dir == :up
  end
  
  # Updates this event's sprite and coordinates.
  def update
    sprite.update
    sprite.x = @map.x + @x * 32 unless moving?
    sprite.y = 32 + @map.y + @y * 32 unless moving?
  end
  
  # Makes this event move right.
  def go_right
    if can_move?
      @dir = :right
      if @x < @map.width - 1 && @map.passable?(@x, @y) && @map.passable?(@x + 1, @y)
        sprite.go_right
        @x += 1
        return true
      else
        turn_right
      end
    end
    Events.on_step_impassable.call(@dir, @x + 1, @y) if self == $Player
    return false
  end
  
  # Makes this event move left.
  def go_left
    if can_move?
      @dir = :left
      if @x > 0 && @map.passable?(@x, @y) && @map.passable?(@x - 1, @y)
        sprite.go_left
        @x -= 1
        return true
      else
        turn_left
      end
    end
    Events.on_step_impassable.call(@dir, @x - 1, @y) if self == $Player
    return false
  end
  
  # Makes this event move down.
  def go_down
    if can_move?
      @dir = :down
      if @y < @map.height - 1 && @map.passable?(@x, @y) && @map.passable?(@x, @y + 1)
        sprite.go_down
        @y += 1
        return true
      else
        turn_down
      end
    end
    Events.on_step_impassable.call(@dir, @x, @y + 1) if self == $Player
    return false
  end
  
  # Makes this event move up.
  def go_up
    if can_move?
      @dir = :up
      if @y > 0 && @map.passable?(@x, @y) && @map.passable?(@x, @y - 1)
        sprite.go_up
        @y -= 1
        return true
      else
        turn_up
      end
    end
    Events.on_step_impassable.call(@dir, @x, @y - 1) if self == $Player
    return false
  end
  
  # Makes this event face right.
  def turn_right
    sprite.turn_right
    @dir = :right
  end
  
  # Makes this event face left.
  def turn_left
    sprite.turn_left
    @dir = :left
  end
  
  # Makes this event face down.
  def turn_down
    sprite.turn_down
    @dir = :down
  end
  
  # Makes this event face up.
  def turn_up
    sprite.turn_up
    @dir = :up
  end
  
  # Moves this event in a random direction.
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
  
  # Turns this event in a random direction.
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
  
  def random
    # So a 3/5 chance to move, 1/5 to turn, 1/5 to do nothing. 
    # If there are obstacles in the way, they won't turn either.
    case rand(6)
    when 0, 1, 2
      move_random
    when 3, 4
      turn_random
    end
  end
end