def pbLoadScene
  scene = Scene_Load.new
  scene.main
  scene.dispose
  return nil
end

class Scene_Load
  def initialize
    showBlk(false)
    @viewport = Viewport.new(0,0,Graphics.width,Graphics.height)
    @viewport.z = 99999
    @sprites = BetterHash.new
    @sprites["bg"] = Sprite.new(@viewport)
    @sprites["bg"].bmp("Graphics/Scenes/Load/background")
    @sprites["panels"] = BetterHash.new
    @sprites["panels"]["txt"] = Sprite.new(@viewport)
    @sprites["panels"]["txt"].bitmap = Bitmap.new(512,384)
    @sprites["panels"]["txt"].z = 1
    y = 32
    if File.file?("Save.dat")
      @sprites["panels"]["Continue"] = Sprite.new(@viewport)
      @sprites["panels"]["Continue"].bmp("Graphics/Scenes/Load/panel_big")
      @sprites["panels"]["Continue"].src_rect.height = @sprites["panels"]["Continue"].bmp.height / 2
      @sprites["panels"]["Continue"].src_rect.y = @sprites["panels"]["Continue"].src_rect.height
      @sprites["panels"]["Continue"].ox = @sprites["panels"]["Continue"].bmp.width / 2
      @sprites["panels"]["Continue"].x = Graphics.width / 2 - 8
      @sprites["panels"]["Continue"].y = 32
      @sprites["panels"]["Continue"].opacity = 224
      @sprites["panels"]["txt"].draw("Continue", 80, 48, 0, Color.new(232,232,232), Color.new(136,136,136))
      y = 256
    end
    new_btn = proc do |display|
      @sprites["panels"][display] = Sprite.new(@viewport)
      @sprites["panels"][display].bmp("Graphics/Scenes/Load/panel_small")
      @sprites["panels"][display].src_rect.height = @sprites["panels"][display].bmp.height / 2
      @sprites["panels"][display].ox = @sprites["panels"][display].bmp.width / 2
      @sprites["panels"][display].x = Graphics.width / 2
      @sprites["panels"][display].y = y
      @sprites["panels"][display].opacity = 224
      @sprites["panels"]["txt"].bmp.draw(display, 80, y + 16, 0, Color.new(232,232,232), Color.new(136,136,136))
      y += 48
    end
    new_btn.call("New Game")
    new_btn.call("Options")
    new_btn.call("Quit Game")
    hideBlk
  end
  
  def main
    loop do
      Graphics.update
      Input.update
    end
  end
  
  def dispose
    @sprites.dispose
    @viewport.dispose
  end
end