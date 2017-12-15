class Bitmap
  # Changes the font to one of the predefined fonts in Settings::FONTS.
  # _num_ is the index in the FONTS array.
  def set_font(num)
    self.font = Font.new(*FONTS[num])
  end
  
  # text : The string of text to draw.
  # x : X coordinate of the bitmap to draw the text at.
  # y : Y coordinate of the bitmap to draw the text at.
  # align : How the text should be aligned. 0 = left (default), 1 = center, 2 = right.
  # base_color : The color of the main text. Defaults to white (Color.new(255,255,255)).
  # shadow_color : The color of shadow/outline text.
  # outline : If true, draws an outline instead of a shadow.
  def draw(text, x, y, align, base_color = Color.new(255,255,255), shadow_color = nil, outline = false)
    y -= self.height / 2 - 6 # Getting rid of the vertical alignment and adding an offset of 6
    y += (self.text_size(text).height % 20) / 2
    old_color = self.font.color
    text = text.to_s
    if shadow_color || outline
      shadow_color ||= base_color
      self.font.color = shadow_color
      if outline
        self.draw_text(x, y - 2, self.width, self.height, text, align)
        self.draw_text(x, y + 2, self.width, self.height, text, align)
        self.draw_text(x - 2, y, self.width, self.height, text, align)
        self.draw_text(x - 2, y - 2, self.width, self.height, text, align)
        self.draw_text(x - 2, y + 2, self.width, self.height, text, align)
        self.draw_text(x + 2, y, self.width, self.height, text, align)
        self.draw_text(x + 2, y - 2, self.width, self.height, text, align)
        self.draw_text(x + 2, y + 2, self.width, self.height, text, align)
      else
        self.draw_text(x + 2, y, self.width, self.height, text, align)
        self.draw_text(x, y + 2, self.width, self.height, text, align)
        self.draw_text(x + 2, y + 2, self.width, self.height, text, align)
      end
    end
    self.font.color = base_color
    self.draw_text(x, y, self.width, self.height, text, align)
    self.font.color = old_color
  end
  
  #def draw_multiline(text, x, y, width, lines = -1, base_color = Color.new(255,255,255), shadow_color = nil)
    # Each entry in this array is one line.
    #new = []
    #loop do
      
    #end
  #end
end