module System
  # Prepares the system for usage.
  def self.initialize
    Font.default_outline = false
    Font.default_name = FONTS[0][0]
    Font.default_size = FONTS[0][1]
  end
  
  # Order:
  # $Player
  
  def self.save
    File.delete("Save.mkd") if File.file?("Save.mkd")
    f = File.new("Save.mkd", 'wb')
    
    Marshal.dump($Player, f)
    
    f.close
  end
  
  def self.load
    File.open("Save.mkd", 'rb') do |f|
      
      $Player = Marshal.load(f)
      $Player.refresh
      
    end
  end
  
  def self.show_formatted_error(e)
    msg = "Pokémon MK v1.0"
    msg += "\n\n"
    msg += e.class.to_s
    msg += ": "
    msg += e.message
    msg += "\n\n"
    backtrace = e.backtrace
    backtrace = backtrace.first(12)
    backtrace.select! { |e| !e.include?("/entry.rb") && !e.include?("ruby:1:in") }
    backtrace.map! do |e|
      new = e.split(':in').first
      new = new.split("/").last
      new = new.split('-')[1..-1].join('-')
      new = new.split('.rb').join
      next new + ':in' + e.split(':in')[1..-1].join(':in')
    end
    msg += backtrace.join("\n")
    print msg
    Kernel.abort() # Close the game
  end
end