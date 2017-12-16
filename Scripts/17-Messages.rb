MessageWindows = {
#  id => [width of the middle section
#         height of the middle section
#         x-offset of the middle section (relative to the center)
#         y-offset of the middle section (relative to the center)]
    1 => [4,4],
    2 => [4,4],
    3 => [4,4],
    4 => [4,4],
    5 => [4,4],
    6 => [4,4],
    7 => [4,4],
    8 => [4,16,0,-6],
    9 => [4,16,0,-6],
    10 => [24,18,-22,-8],
    11 => [24,16,-22,-6],
    12 => [24,16,-22,-6],
    13 => [22,14,-18,-4],
    14 => [24,16,-16,-8],
    15 => [16,4,-6],
    16 => [4,4],
    17 => [16,10,-6,-4],
}

def hex_to_rgb(hex)
  hex = hex[1..-1] if hex[0] == "#"
  r = hex[0...2].to_i(16)
  g = hex[2...4].to_i(16)
  b = hex[4...6].to_i(16)
  return Color.new(r, g, b)
end

def rgb_to_hex(r, g = nil, b = nil)
  values = [r.red, r.green, r.blue] if r.is_a?(Color)
  values =[r[0], r[1], r[2]] if r.is_a?(Array)
  values ||= [r, g, b]
  ret = ""
  values.each { |e| ret += "0123456789ABCDEF"[(e - (e % 16)) / 16] + "0123456789ABCDEF"[e % 16] }
  return ret
end

def get_text_chunks(bitmap, text, width, allow_split_in_words = false)
  bitmap = bitmap.bitmap if bitmap.is_a?(Sprite)
  # Each entry in this array is one line.
  new = []
  idx = 0
  loop do
    Input.update
    idx += 1
    break if idx >= text.size
    if bitmap.text_size(text[0..idx]).width > width
      if allow_split_in_words
        new << text[0..idx]
        text = text[(idx + 1)..-1]
      else
        idx_last_space = text[0..idx].reverse.index(' ')
        idx_last_space = text[0..idx].size - idx_last_space
        new << text[0...(idx_last_space - 1)]
        text = text[idx_last_space..-1]
      end
      idx = 0
    end
  end
  new << text # Remaining text
  return new
end

class MessageWindow
  attr_accessor :id
  attr_reader :height
  attr_accessor :xoffset
  attr_accessor :yoffset
  attr_accessor :viewport
  
  attr_accessor :letterbyletter
  attr_reader :text
  
  def height=(value)
    raise "Height (#{@height}) must be greater than 0" if @height <= 0
    @height = value
  end
  
  def initialize(id = 1, height = 96)
    @id = id
    @height = height
    @xoffset = 4
    @yoffset = 4
    @viewport = Viewport.new(0,0,Graphics.width,Graphics.height)
    @viewport.z = 999999
    @textviewport = Viewport.new(@xoffset, Graphics.height - @yoffset - @height + 10, Graphics.width - 2 * @xoffset, @height)
    @textviewport.z = 999999
    @textsprite = Sprite.new(@textviewport)
    @textsprite.bmp(-1,-1)
    @text_idx = 0
    @chunk_idx = 0
    @timer = 0
    @speed = 2
    @text = ""
    refresh
  end
  
  def text=(value)
    @text_idx = 0
    @text = value
    @chunks = get_text_chunks(@textsprite.bmp, @text, Graphics.width - 88)
  end
  
  def update
    @timer += 1
    if @text && @text_idx < @text.size && @timer % @speed == 0
      @textsprite.bmp.clear
      @textsprite.draw_multi(@text[0..@text_idx], 28, 12, Graphics.width - 88, 2, TEXT_BASE_COLOR, TEXT_SHADOW_COLOR, false, 32)
      @text_idx += 1
    end
  end
  
  def refresh
    if !MessageWindows[@id]
      raise "ID #{@id} not found in the MessageWindows constant"
    end
    @data = MessageWindows[@id]
    middle_width = @data[0] / 2
    middle_height = @data[1] / 2
    middle_x_off = (@data[2] ? @data[2] / 2 : 0) * 2
    middle_y_off = (@data[3] ? @data[3] / 2 : 0) * 2
    middle_x_off += middle_width - 2
    middle_y_off += middle_height - 2
    bitmap = Bitmap.new("Graphics/Windows/#{@id.to_digits}")
    halfw = bitmap.width / 2
    halfh = bitmap.height / 2
    @window ||= Sprite.new(@viewport)
    @window.y = Graphics.height - @height - @yoffset
    @window.bmp(Graphics.width, @height)
    
    # Top Left
    top_left_x = @xoffset
    top_left_y = 0
    top_left_rect_x = 0
    top_left_rect_y = 0
    top_left_rect_width = halfw - middle_width + middle_x_off
    top_left_rect_height = halfh - middle_height + middle_y_off
    
    # Bottom Left
    btm_left_x = @xoffset
    btm_left_y = @height - halfh + middle_height + middle_y_off
    btm_left_rect_x = 0
    btm_left_rect_y = halfh + middle_height + middle_y_off
    btm_left_rect_width = halfw - middle_width + middle_x_off
    btm_left_rect_height = halfh - middle_height - middle_y_off
    
    # Top Right
    top_right_rect_y = 0
    top_right_rect_x = halfw + middle_width + middle_x_off
    top_right_rect_width = halfw - middle_width - middle_x_off
    top_right_rect_height = halfh - middle_height + middle_y_off
    top_right_x = Graphics.width - top_right_rect_width - @xoffset
    top_right_y = 0
    
    # Bottom Right
    btm_right_rect_x = halfw + middle_width + middle_x_off
    btm_right_rect_y = halfh + middle_height + middle_y_off
    btm_right_rect_width = halfw - middle_width - middle_x_off
    btm_right_rect_height = halfh - middle_height - middle_y_off
    btm_right_x = Graphics.width - btm_right_rect_width - @xoffset
    btm_right_y = @height - halfh + middle_height + middle_y_off
    
    rem_w = top_right_x - top_left_x - top_left_rect_width
    rem_h = btm_left_y - top_left_y - top_left_rect_height
    
    # Filler Center
    for x in 0...((rem_w / (middle_width * 2).to_f).ceil)
      for y in 0...((rem_h / (middle_height * 2).to_f).ceil)
        @window.bmp.blt(top_left_x + top_left_rect_width + x * (middle_width * 2), top_left_rect_height + y * (middle_height * 2), bitmap,
            Rect.new(top_left_rect_width, top_left_rect_height, middle_width * 2, middle_height * 2))
      end
    end
    
    for i in 0...((rem_w / (middle_width * 2).to_f).ceil)
      # Filler Left
      @window.bmp.blt(top_left_x + top_left_rect_width + i * (middle_width * 2), 0, bitmap,
          Rect.new(top_left_rect_width, 0, top_right_rect_x - top_left_rect_width, top_right_rect_height))
      # Filler Right
      @window.bmp.blt(top_left_x + top_left_rect_width + i * (middle_width * 2), btm_left_y, bitmap,
          Rect.new(btm_left_rect_width, btm_left_rect_y, btm_right_rect_x - btm_left_rect_width, btm_right_rect_height))
    end
    
    for i in 0...((rem_h / (middle_height * 2).to_f).ceil)
      # Filler Top
      @window.bmp.blt(top_left_x, top_left_rect_height + i * (middle_height * 2), bitmap,
          Rect.new(0, top_left_rect_height, top_left_rect_width, btm_right_rect_y - top_left_rect_height))
      # Filler Bottom
      @window.bmp.blt(top_right_x, top_right_rect_height + i * (middle_height * 2), bitmap,
          Rect.new(top_right_rect_x, top_right_rect_height, top_right_rect_width, btm_left_rect_y - top_right_rect_height))
    end
    
    @window.bmp.blt(top_left_x, top_left_y, bitmap,
        Rect.new(top_left_rect_x, top_left_rect_y, top_left_rect_width, top_left_rect_height))
    @window.bmp.blt(btm_left_x, btm_left_y, bitmap,
        Rect.new(btm_left_rect_x, btm_left_rect_y, btm_left_rect_width, btm_left_rect_height))
    @window.bmp.blt(top_right_x, top_right_y, bitmap,
        Rect.new(top_right_rect_x, top_right_rect_y, top_right_rect_width, top_right_rect_height))
    @window.bmp.blt(btm_right_x, btm_right_y, bitmap,
        Rect.new(btm_right_rect_x, btm_right_rect_y, btm_right_rect_width, btm_right_rect_height))
  end
end