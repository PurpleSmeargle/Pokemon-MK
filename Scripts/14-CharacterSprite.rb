class CharacterSprite < Sprite
	attr_accessor :sprite
	attr_accessor :right_mov
	attr_accessor :left_mov
	attr_accessor :down_mov
	attr_accessor :up_mov
	
	def initialize(id = 0)
		super($Viewports["main"])
		self.bmp("Graphics/Characters/#{id.to_digits}")
		self.src_rect.width = self.bmp.width / 4
		self.src_rect.height = self.bmp.height / 4
		self.oy = self.bmp.height / 4
		self.y = 32
		@right_mov = nil
		@left_mov = nil
		@down_mov = nil
		@up_mov = nil
	end
	
	def update
		super
		if @right_mov
			self.x += 2
			if @right_mov % 8 == 0
				self.src_rect.x += self.bmp.width / 4
				self.src_rect.x = 0 if self.src_rect.x >= self.bmp.width
			end
			@right_mov -= 1
			@right_mov = nil if @right_mov == 0
		end
		if @left_mov
			self.x -= 2
			if @left_mov % 8 == 0
				self.src_rect.x += self.bmp.width / 4
				self.src_rect.x = 0 if self.src_rect.x >= self.bmp.width
			end
			@left_mov -= 1
			@left_mov = nil if @left_mov == 0
		end
		if @down_mov
			self.y += 2
			if @down_mov % 8 == 0
				self.src_rect.x += self.bmp.width / 4
				self.src_rect.x = 0 if self.src_rect.x >= self.bmp.width
			end
			@down_mov -= 1
			@down_mov = nil if @down_mov == 0
		end
		if @up_mov
			self.y -= 2
			if @up_mov % 8 == 0
				self.src_rect.x += self.bmp.width / 4
				self.src_rect.x = 0 if self.src_rect.x >= self.bmp.width
			end
			@up_mov -= 1
			@up_mov = nil if @up_mov == 0
		end
	end
	
	def go_right
		turn_right
		@right_mov = 16
		return true
	end
	
	def go_left
		turn_left
		@left_mov = 16
		return true
	end
	
	def go_down
		turn_down
		@down_mov = 16
		return true
	end
	
	def go_up
		turn_up
		@up_mov = 16
		return true
	end
	
	def turn_right
		self.src_rect.y = self.bmp.height / 4 * 2
	end
	
	def turn_left
		self.src_rect.y = self.bmp.height / 4
	end
	
	def turn_down
		self.src_rect.y = 0
	end
	
	def turn_up
		self.src_rect.y = self.bmp.height / 4 * 3
	end
end