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
    8 => [24,18,-22,-8],
    9 => [4,4],
    10 => [4,4],
    11 => [4,4],
}

class MessageWindow
  attr_accessor :id
  attr_reader :height
  attr_accessor :xoffset
  attr_accessor :yoffset
  attr_accessor :viewport
  
  def height=(value)
    raise "Height (#{@height}) must be greater than 0" if @height <= 0
    @height = value
  end
  
  def initialize(id, viewport = nil, height = 96)
    @viewport = viewport
    @id = id
    @height = height
    @xoffset = 4
    @yoffset = 4
    unless @viewport
      @viewport = Viewport.new(0,0,Graphics.width,Graphics.height)
      @viewport.z = 999999
    end
    refresh
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
    
    @window.bmp.blt(top_left_x, top_left_y, bitmap, Rect.new(top_left_rect_x, top_left_rect_y, top_left_rect_width, top_left_rect_height))
    @window.bmp.blt(btm_left_x, btm_left_y, bitmap, Rect.new(btm_left_rect_x, btm_left_rect_y, btm_left_rect_width, btm_left_rect_height))
    @window.bmp.blt(top_right_x, top_right_y, bitmap, Rect.new(top_right_rect_x, top_right_rect_y, top_right_rect_width, top_right_rect_height))
    @window.bmp.blt(btm_right_x, btm_right_y, bitmap, Rect.new(btm_right_rect_x, btm_right_rect_y, btm_right_rect_width, btm_right_rect_height))
  end
end