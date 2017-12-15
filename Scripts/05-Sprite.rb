class Sprite
  # Explanation of all these parameters can be found in Bitmap#draw
  def draw(text, x, y, align, base_color = Color.new(255,255,255), shadow_color = nil, outline = false)
    self.bmp.draw(text, x, y, align, base_color, shadow_color, outline)
  end
  
  def draw_multi(text, x, y, width, lines = -1, base_color = Color.new(255,255,255), shadow_color = nil,
                 outline = false, y_line_diff = 24, allow_split_in_words = false)
    self.bmp.draw_multi(text, x, y, width, lines, base_color, shadow_color,
        outline, y_line_diff, allow_split_in_words)
  end
end