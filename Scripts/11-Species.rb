class Species
  # Stores the compiled species data
  Data = []
  
  # Compiles all species into hash _Data_
  def self.compile
    raw = ""
    t = Time.now
    File.open("Data/pokemon.txt", "rb") do |f|
      while r = f.read(4096)
        # To ensure it doesn't freeze while reading (due to the size)
        if Time.now - t > 2
          Graphics.update
          t = Time.now
        end
        raw << r
      end
    end
    sections = raw.split(/(?=\[\d+\])/) # Split where it equals [n] and n is a valid number (and keep the delimiter)
    for section in sections
      next if section.starts_with?("#")
      lines = section.get_lines
      species = lines[0].split('[')[1].split(']')[0].to_i
      # We can safely convert it to an integer right away, as we've already
      # made sure that it's a valid integer in our split(regex).
      Data[species] = {}
      # An array storing all properties iterated over in the loop below.
      # Used to determine if all properties that a species HAS to implement,
      # have been compiled.
      properties = []
      # [1..-1] because we're skipping the actual _[n]_ line
      for line in lines[1..-1]
        next if line.starts_with?("#")
        key = line.split('=')[0].strip
        key = key.to_sym
        value = line.split('=')[1]
        next if value.empty? # If someone types, say, "Evolutions=", this will detect that it is empty.
        value = value.strip
        case key
        # These properties are arrays and should be parsed as integer arrays
        when :BaseStats, :EffortPoints, :RegionalNumbers
          Data[species][key] = value.split(',').map(&:to_i)
        # These properties are arrays and should be parsed as string arrays
        when :Abilities, :Compatibility
          Data[species][key] = value.split(',')
        # This one, Moves, requires a special way of compiling as it's stored differently
        when :Moves
          Data[species][:Moves] = {}
          list = value.split(',').map { |e| next e.to_sym unless e.numeric?; next e.to_i }
          for i in 0...list.size
            next if i % 2 == 1
            level = list[i]
            move = list[i + 1]
            if Data[species][:Moves][level]
              Data[species][:Moves][level] = [Data[species][:Moves][level], move]
            else
              Data[species][:Moves][level] = move
            end
          end
        # The rest is treated as a string, but is converted to an integer if it is detected to be an integer.
        else
          Data[species][key] = (value.numeric? ? value.to_i : value)
        end
        Data[species][key] = Data[species][key].to_sym if key == :InternalName || key == :Type1 || key == :Type2
        Data[species][key].map!(&:to_sym) if key == :Abilities
        
        properties << key
      end
    end
  end
  
  def initialize(arg)
    if arg.is_a?(Symbol)
      for i in 0...Data.size
        next unless Data[i] # Skip empty entries
        if Data[i][:InternalName] == arg
          @id = i
          return
        end
      end
    end
    @id = arg
  end
  
  def id
    return @id
  end
  
  def name
    return Data[@id][:Name]
  end
end