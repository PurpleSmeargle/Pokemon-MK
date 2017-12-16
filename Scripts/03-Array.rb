class Array  
  # Returns a random element of the array
  def random
    return self[rand(self.size)]
  end
  
  # Shuffles the order of the array
  def shuffle
    indexes = []
    new = []
    while new.size != self.size
      i = rand(self.size)
      if !indexes.include?(i)
        indexes << i
        new << self[i]
      end
    end
    return new
  end
  
  # Shuffles the order of the array and replaces itself
  def shuffle!
    self.replace(shuffle)
  end
  
  # Breaks the array up every n elements
  def breakup(n)
    ret = []
    for i in 0...self.size
      ret[(i / n).floor] ||= []
      ret[(i / n).floor] << self[i]
    end
    return ret
  end
  
  # Breaks the array up every n elements and replaces itself
  def breakup!(n)
    self.replace(breakup(n))
  end
  
  # Swaps two elements' indexes
  def swap(index1, index2)
    new = self.clone
    tmp = new[index2].clone
    new[index2] = new[index1]
    new[index1] = tmp
    return new
  end
  
  # Swaps two elements' indexes and replaces itself
  def swap!(index1, index2)
    self.replace(swap(index1, index2))
  end
  
  # Returns whether or not the first element is equal to the passed argument
  def starts_with?(e)
    return self.first == e
  end
  
  # Returns whether or not the last element is equal to the passed argument
  def ends_with?(e)
   return self.last == e
  end
  
  # Does the same as <<, but concatenates if argument passed is an array
  def +(var)
    if var.is_a?(Array)
      self.concat(var)
    else
      self << var
    end
    return self
  end
  
  # Deletes every instance of _var_ in the array
  def -(var)
    if var.is_a?(Array)
      var.each { |e| self.delete(e) if self.include?(e) }
    else
      self.delete(var) if self.include?(var)
    end
    return self
  end
  
  # Converts itself to a hash where possible
  def to_hash(delete_nil_entries = false)
    ret = {}
    for i in 0...self.size
      next if self[i].nil? && delete_nil_entries
      ret[i] = self[i]
    end
    return ret
  end
  
  # If you have 8 elements, if true, grabs the 5th element, the 4rd if false.
  # If you have 7 elements, grabs the 4th.
  def mid(round_up = true)
    i = (self.size - 1) / 2.0
    i = i.ceil if round_up
    return self[i].floor
  end
  
  # Returns the average of all elements in the array. Will throw errors on non-numerics.
  # Skips <nil> entries.
  def average
    total = 0
    self.each { |n| total += n unless n.nil? }
    return total / self.compact.size.to_f
  end
  
  # Evaluates the block you pass it for every number between 0 and "slots".
  # Example usage:
  # Array.make_table { |i| i ** 2 }
  #   =>  [1, 4, 9, 16, 25, 36, 49, 64, 81, 100]
  # Array.make_table(10..16) { |i| i.to_s(2) }
  #   => ["1010", "1011", "1100", "1101", "1110", "1111", "10000"]
  # (you can also pass it an array of values to iterate over)
  def self.make_table(range = 1..10, &proc)
    return range.map { |n| next proc.call(n) }
  end
  
  # If true:
  # [0, 1, 3, 4, 5]  --  etc
  # If false:
  # [0,1,2,3,4,5]  --  etc
  Json_Extra_Space_After_Entry = false
  
  # Converts _self_ to a JSON string with an indent of Json_Indent_Width per layer.
  def to_json(indent = Hash::Json_Indent_Width, inline = false)
    return "[]" unless self.size > 0
    full = "["
    for i in 0...self.size
      nl = false
      if self[i].is_a?(Hash) || self[i].is_a?(Array)
        val = self[i].to_json(indent + Hash::Json_Indent_Width, i == 0)
        nl = !(inline && i == 0)
      else
        val = self[i]
        val = "\"#{val}\"" if val.is_a?(String)
        nl = (self.fullsize > 24 || self.map { |e| e.class.to_sym }.include?(:Hash))
      end
      full += "\n" + " " * indent if nl
      full += val.to_s + ","
      full += " " if Json_Extra_Space_After_Entry
    end
    i = 2 + Json_Extra_Space_After_Entry.to_i
    full = full[0..(-i)]
    full += "\n#{" " * (indent - Hash::Json_Indent_Width)}" if self.fullsize > 24 ||
                                 self.map { |e| e.class.to_sym }.include?(:Hash)
    full += "]"
    return full
  end
end