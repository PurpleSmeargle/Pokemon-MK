class Sprite
  # Explanation of all these parameters can be found in Bitmap#draw
  def draw(text, x, y, align, base_color = Color.new(255,255,255), shadow_color = nil, outline = false)
	self.bmp.draw(text, x, y, align, base_color, shadow_color, outline)
  end
end