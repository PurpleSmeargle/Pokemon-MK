# Sprite class extensions
class Sprite
  # Shorthand for initializing a bitmap by path, bitmap, or width/height:
  # -> bmp("Graphics/Pictures/bag")
  # -> bmp(32, 32)
  # -> bmp(some_other_bitmap)
  def bmp(arg1 = nil, arg2 = nil)
    if arg1
      if arg2
        arg1 = Graphics.width if arg1 == -1
        arg2 = Graphics.height if arg2 == -1
        self.bitmap = Bitmap.new(arg1, arg2)
      elsif arg1.is_a?(Bitmap)
        self.bitmap = arg1.clone
      else
        self.bitmap = Bitmap.new(arg1)
      end
    else
      return self.bitmap
    end
  end
  
  # Alternative to bmp(path):
  # -> bmp = "Graphics/Pictures/bag"
  def bmp=(arg1)
    bmp(arg1)
  end
  
  # Usage:
  # -> [x]             # Sets sprite.x to x
  # -> [x,y]           # Sets sprite.x to x and sprite.y to y
  # -> [x,y,z]         # Sets sprite.x to x and sprite.y to y and sprite.z to z
  # -> [nil,y]         # Sets sprite.y to y
  # -> [nil,nil,z]     # Sets sprite.z to z
  # -> [x,nil,z]       # Sets sprite.x to x and sprite.z to z
  # Etc.
  def xyz=(args)
    self.x = args[0] || self.x
    self.y = args[1] || self.y
    self.z = args[2] || self.z
  end
  
  # Returns the x, y, and z coordinates in the xyz=(args) format, [x,y,z]
  def xyz
    return [self.x,self.y,self.z]
  end
  
  # Centers the sprite by setting the origin points to half the width and height
  def center_origins
    return if !self.bitmap
    self.ox = self.bitmap.width / 2
    self.oy = self.bitmap.height / 2
  end
  
  # Returns the sprite's full width, taking zoom_x into account
  def fullwidth
    return self.bitmap.width.to_f * self.zoom_x
  end
  
  # Returns the sprite's full height, taking zoom_y into account
  def fullheight
    return self.bitmap.height.to_f * self.zoom_y
  end
  
  # Explanation of all these parameters can be found in Bitmap#draw
  def draw(text, x, y, align, base_color = Color.new(255,255,255), shadow_color = nil, outline = false)
    self.bmp.draw(text, x, y, align, base_color, shadow_color, outline)
  end
  
  # Explanation of all these parameters can be found in Bitmap#draw_multi
  def draw_multi(text, x, y, width, lines = -1, base_color = Color.new(255,255,255), shadow_color = nil,
                 outline = false, y_line_diff = 24, allow_split_in_words = false)
    self.bmp.draw_multi(text, x, y, width, lines, base_color, shadow_color,
        outline, y_line_diff, allow_split_in_words)
  end
end