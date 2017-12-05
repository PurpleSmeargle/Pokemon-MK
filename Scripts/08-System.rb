module System
	# Prepares the system for usage.
	def self.initialize
		Graphics.resize_screen(SCREENWIDTH,SCREENHEIGHT)
		Font.default_outline = false
		Font.default_name = FONTS[0][0]
		Font.default_size = FONTS[0][1]
	end
	
	# Order:
	# $Player
	
	def self.save
		File.delete("Save.dat") if File.file?("Save.dat")
		f = File.new("Save.dat", 'wb')
		
		Marshal.dump($Player, f)
		
		f.close
	end
	
	def self.load
		File.open("Save.dat", 'rb') do |f|
			
			$Player = Marshal.load(f)
			$Player.refresh
			
		end
	end
end