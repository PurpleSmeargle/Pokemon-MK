class Player < Character
	attr_accessor :party
	attr_reader :gender
	
	def initialize(gender = 0, name = "")
		super($Map, gender)
		@gender = gender
		@party = []
		sprite.x = Graphics.width / 2 - sprite.src_rect.width / 2
		sprite.y = Graphics.height / 2
		self.x = 0
		self.y = 0
		@right_cooldown = 0
		@left_cooldown = 0
		@down_cooldown = 0
		@up_cooldown = 0
	end
	
	# Called after being restored via Marshal.load
	def refresh
		self.x = self.x
		self.y = self.y
		turn_right if @dir == 6
		turn_left if @dir == 4
		turn_down if @dir == 2
		turn_up if @dir == 8
	end
	
	def update
		@right_cooldown -= 1 if @right_cooldown > 0
		@left_cooldown -= 1 if @left_cooldown > 0
		@down_cooldown -= 1 if @down_cooldown > 0
		@up_cooldown -= 1 if @up_cooldown > 0
		if Input.press?(Input::RIGHT) && !moving?
			if @dir != 6
				turn_right
				@right_cooldown = 4
			elsif @right_cooldown == 0
    		go_right
			end
		end
		if Input.press?(Input::LEFT) && !moving?
  		if @dir != 4
				turn_left
				@left_cooldown = 4
			elsif @left_cooldown == 0
				go_left
			end
		end
		if Input.press?(Input::DOWN) && !moving?
			if @dir != 2
				turn_down
				@down_cooldown = 4
			elsif @down_cooldown == 0
    		go_down
			end
		end
		if Input.press?(Input::UP) && !moving?
  		if @dir != 8
				turn_up
				@up_cooldown = 4
			elsif @up_cooldown == 0
				go_up
			end
		end
		
		
		if sprite.right_mov
			$Map.x -= 2
			if sprite.right_mov % 8 == 0
				sprite.src_rect.x += sprite.bmp.width / 4
				sprite.src_rect.x = 0 if sprite.src_rect.x >= sprite.bmp.width
			end
			sprite.right_mov -= 1
			sprite.right_mov = nil if sprite.right_mov == 0
		end
		if sprite.left_mov
			$Map.x += 2
			if sprite.left_mov % 8 == 0
				sprite.src_rect.x += sprite.bmp.width / 4
				sprite.src_rect.x = 0 if sprite.src_rect.x >= sprite.bmp.width
			end
			sprite.left_mov -= 1
			sprite.left_mov = nil if sprite.left_mov == 0
		end
		if sprite.down_mov
			$Map.y -= 2
			if sprite.down_mov % 8 == 0
				sprite.src_rect.x += sprite.bmp.width / 4
				sprite.src_rect.x = 0 if sprite.src_rect.x >= sprite.bmp.width
			end
			sprite.down_mov -= 1
			sprite.down_mov = nil if sprite.down_mov == 0
		end
		if sprite.up_mov
			$Map.y += 2
			if sprite.up_mov % 8 == 0
				sprite.src_rect.x += sprite.bmp.width / 4
				sprite.src_rect.x = 0 if sprite.src_rect.x >= sprite.bmp.width
			end
			sprite.up_mov -= 1
			sprite.up_mov = nil if sprite.up_mov == 0
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