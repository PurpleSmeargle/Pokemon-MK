class Player < Event
  attr_accessor :party
  attr_reader :gender
  
  def initialize(gender = 0, name = "")
    super(gender, $Map)
    @gender = gender
    @party = []
    @move_speed = WALK_SPEED
    sprite.x = Graphics.width / 2 - sprite.src_rect.width / 2
    sprite.y = Graphics.height / 2
    sprite.z = 1
    self.x = 0
    self.y = 0
    @map.initial_x = Graphics.width / 2 - sprite.src_rect.width / 2
    @map.initial_y = Graphics.height / 2 - 32
    @right_cooldown = 0
    @left_cooldown = 0
    @down_cooldown = 0
    @up_cooldown = 0
    @frozen = false
    sprite.move_speed = @move_speed
  end
  
  # Called after being restored via Marshal.load
  def refresh
    self.x = self.x
    self.y = self.y
    turn_right if @dir == :right
    turn_left if @dir == :left
    turn_down if @dir == :down
    turn_up if @dir == :up
  end
  
  def update
    @right_cooldown -= 1 if @right_cooldown > 0
    @left_cooldown -= 1 if @left_cooldown > 0
    @down_cooldown -= 1 if @down_cooldown > 0
    @up_cooldown -= 1 if @up_cooldown > 0
    if can_move?
      if Input.press?(Input::RIGHT)
        if @dir != :right
          turn_right
          @right_cooldown = 4
        elsif @right_cooldown == 0
          go_right
        end
      end
      if Input.press?(Input::LEFT)
        if @dir != :left
          turn_left
          @left_cooldown = 4
        elsif @left_cooldown == 0
          go_left
        end
      end
      if Input.press?(Input::DOWN)
        if @dir != :down
          turn_down
          @down_cooldown = 4
        elsif @down_cooldown == 0
          go_down
        end
      end
      if Input.press?(Input::UP)
        if @dir != :up
          turn_up
          @up_cooldown = 4
        elsif @up_cooldown == 0
          go_up
        end
      end
    end
    
    if sprite.right_mov
      $Map.x -= (32.0 / @move_speed)
      if sprite.right_mov % (@move_speed / 2) == 0
        sprite.src_rect.x += sprite.bmp.width / 4
        sprite.src_rect.x = 0 if sprite.src_rect.x >= sprite.bmp.width
      end
      sprite.right_mov -= 1
      if sprite.right_mov == 0
        sprite.right_mov = nil
        Events.on_step_taken.call(:right)
      end
    end
    if sprite.left_mov
      $Map.x += (32.0 / @move_speed)
      if sprite.left_mov % (@move_speed / 2) == 0
        sprite.src_rect.x += sprite.bmp.width / 4
        sprite.src_rect.x = 0 if sprite.src_rect.x >= sprite.bmp.width
      end
      sprite.left_mov -= 1
      if sprite.left_mov == 0
        sprite.left_mov = nil
        Events.on_step_taken.call(:left)
      end
    end
    if sprite.down_mov
      $Map.y -= (32.0 / @move_speed)
      if sprite.down_mov % (@move_speed / 2) == 0
        sprite.src_rect.x += sprite.bmp.width / 4
        sprite.src_rect.x = 0 if sprite.src_rect.x >= sprite.bmp.width
      end
      sprite.down_mov -= 1
      if sprite.down_mov == 0
        sprite.down_mov = nil
        Events.on_step_taken.call(:down)
      end
    end
    if sprite.up_mov
      $Map.y += (32.0 / @move_speed)
      if sprite.up_mov % (@move_speed / 2) == 0
        sprite.src_rect.x += sprite.bmp.width / 4
        sprite.src_rect.x = 0 if sprite.src_rect.x >= sprite.bmp.width
      end
      sprite.up_mov -= 1
      if sprite.up_mov == 0
        sprite.up_mov = nil
        Events.on_step_taken.call(:up)
      end
    end
  end
  
  def x=(value)
    @x = value
    $Map.x = Graphics.width / 2 - sprite.src_rect.width / 2 - 32 * @x
  end
  
  def y=(value)
    @y = value
    $Map.y = Graphics.height / 2 - 32 - 32 * @y
  end
end