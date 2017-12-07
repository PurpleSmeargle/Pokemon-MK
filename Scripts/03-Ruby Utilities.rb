# I will split this up and sort out what we need later.


def p(*args)
  msgbox *args
end

def puts(*args)
  p(*args)
end

def print(*args)
  p(*args)
end





class Class
  def to_sym
    return self.to_s.to_sym
  end
end

class NilClass
  def empty?
    return true
  end
end

class Numeric
  # Formats the number nicely (e.g. 1234567890 -> format() -> 1,234,567,890)
  def format(separator = ',')
    a = self.to_s.split('').reverse.breakup(3)
    return a.map { |e| e.join('') }.join(separator).reverse
  end
  
  # Makes sure the returned string is at least n characters long
  # (e.g. 4   -> to_digits -> "004")
  # (e.g. 19  -> to_digits -> "019")
  # (e.g. 123 -> to_digits -> "123")
  def to_digits(n = 3)
    str = self.to_s
    return str if str.size >= n
    ret = ""
    (n - str.size).times { ret += "0" }
    return ret + str
  end
  
  # n root of self. Defaults to 2 => square root.
  def root(n = 2)
    return (self ** (1.0 / n))
  end
  
  # Factorial
  # 4 -> fact -> (4 * 3 * 2 * 1) -> 24
  def fact
    raise ArgumentError, "Cannot execute factorial on negative numerics" if self < 0
    tot = 1
    for i in 2..self
      tot *= i
    end
    return tot
  end
  
  # Combinations
  def ncr(k)
    return (self.fact / (k.fact * (self - k).fact))
  end
  
  # k permutations of n (self)
  def npr(k)
    return (self.fact / (self - k).fact)
  end
  
  # Converts number to binary number (returns as string)
  def to_b
    return self.to_s(2)
  end
  
  def empty?
    return false
  end
  
  def numeric?
    return true
  end
end

class Float
  # Properly rounds floats (e.g. 1.123456 -> round(5) -> 1.12346)
  def round(n = 0)
    l, r = self.to_s.split('.')
    r ||= "0"
    t = r[0...n].to_i
    if r[n].to_i >= 5
      if n == 0
        l = l.to_i + 1
      else
        t += 1
      end
    end
    return "#{l}.#{t}".to_f
  end
  
  # Rounds itself before converting to integer
  alias marin_to_i to_i
  def to_i(*args)
    return round.marin_to_i
  end
end

# Included in TrueClass and FalseClass to be able to call _.is_a?(Boolean)_
# true.is_a?(Boolean)
module Boolean end

class TrueClass
  include Boolean
  
  def to_i
    return 1
  end
end

# false.is_a?(Boolean)
class FalseClass
  include Boolean
  
  def to_i
    return 0
  end
end

# Calculates the total amount of elements in an Enumerable. Example:
# ["one","two","three"].fullsize #=> 11
module Enumerable
  def fullsize
    n = 0
    for e in self
      if e.is_a?(String)
        n += e.size
      elsif e.respond_to?(:fullsize)
        n += e.fullsize
      elsif e.respond_to?(:size) && !e.is_a?(Numeric)
        n += e.size
      else
        n += 1
      end
    end
    return n
  end
end

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
  
  # Adds some aliases for <include?>: <has?>, <includes?>, <contains?>
  alias has? include?
  alias includes? include?
  alias contains? include?
  
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

class Hash
  # Converts itself to an array where possible
  def to_array(delete_nil_entries = false)
    ret = []
    keys = self.keys.sort
    for key in keys
      next if self[key].nil? && delete_nil_entries
      ret[key] = self[key]
    end
    return ret
  end
  
  def compact
    new = {}
    for key in self.keys
      new[key] = self[key] unless self[key].nil?
    end
    return new
  end
  
  def compact!
    self.replace(compact)
  end
  
  # Amount of spaces per "layer" in the JSON.
  Json_Indent_Width = 4
  
  # Converts _self_ to a JSON string with an indent of Json_Indent_Width per layer.
  def to_json(indent = Json_Indent_Width, _ = nil)
    return "{}" if self.size == 0
    full = "{"
    keys = self.keys.sort do |a,b|
      if $JSON_Sort_Order
        if $JSON_Sort_Order.include?(a)
          if $JSON_Sort_Order.include?(b)
            next $JSON_Sort_Order.index(a) <=> $JSON_Sort_Order.index(b)
          else
            next -1
          end
        else
          if $JSON_Sort_Order.include?(b)
            next 1
          end
          # If neither are in the key, go alphabetical
        end
      end
      if a.numeric?
        if b.numeric?
          next a <=> b
        else
          next -1
        end
      else
        if b.numeric?
          next 1
        else
          next a <=> b
        end
      end
    end
    for key in keys
      if self[key].is_a?(Hash) || self[key].is_a?(Array)
        val = self[key].to_json(indent + Json_Indent_Width, key == self.keys[0])
      else
        val = self[key]
        val = "\"#{val}\"" if val.is_a?(String)
      end
      full += "\n#{" " * indent}\"#{key}\": #{val},"
    end
    full = full[0..-2]
    full += "\n#{" " * (indent - Json_Indent_Width)}}"
    return full
  end
end

# String class extensions
class String
  # Returns true if the string starts with the passed substring.
  def starts_with?(str)
    return false if !str.is_a?(String)
    return false if str.size > self.size
    return self[0...str.length] == str
  end
  
  # Returns true if the string ends with the passed substring.
  def ends_with?(str)
    return self.reverse.starts_with?(str.reverse)
  end
  
  # Converts to bits
  def to_b
    return self.unpack('b*')[0]
  end
  
  # Converts to bits and replaces itself
  def to_b!
    self.replace(to_b)
  end
  
  # Converts from bits
  def from_b
    return [self].pack('b*')
  end
  
  # Convert from bits and replaces itself
  def from_b!
    self.replace(from_b)
  end
  
  # Returns the first n characters
  def first(n = 1)
    return self.clone if n >= self.size
    return self[0] if n == 1
    return self[0...n]
  end
  
  # Returns the last n characters
  def last(n = 1)
    return self.clone if n >= self.size
    return self[-1] if n == 1
    return self.reverse[0...n].reverse
  end
  
  # Returns a random character from the string
  def random
    return self[rand(self.size)]
  end
  
  # Shuffles the order of the characters
  def shuffle
    return self.split("").shuffle.join("")
  end
  
  # Breaks the string up every _n_ characters
  def breakup(n)
    new = []
    for i in 0...self.size
      new[(i / n).floor] ||= ""
      new[(i / n).floor] += self[i]
    end
    return new
  end
  
  def empty?
    return (self.size == 0)
  end
  
  def numeric?
    for e in self.split("")
      return false unless [0,1,2,3,4,5,6,7,8,9].map { |n| n.to_s }.include?(e)
    end
    return true
  end
  
  # Deflates itself and returns the result
  def deflate
    return Zlib::Deflate.deflate(self)
  end
  
  # Deflates and replaces itself
  def deflate!
    self.replace(deflate)
  end
  
  # Inflates itself and returns the result
  def inflate
    return Zlib::Inflate.inflate(self)
  end
  
  # Inflates and replaces itself
  def inflate!
    self.replace(inflate)
  end
  
  # Adds some aliases for <include?>: <has?>, <includes?>, <contains?>
  alias has? include?
  alias includes? include?
  alias contains? include?
end

# File class extensions
class File
  # Copies the source file to the destination path.
  def self.copy(source, destination)
    data = ""
    t = Time.now
    File.open(source, 'rb') do |f|
      while r = f.read(4096)
        if Time.now - t > 1
          Graphics.update
          t = Time.now
        end
        data += r
      end
    end
    File.delete(destination) if File.file?(destination)
    f = File.new(destination, 'wb')
    f.write data
    f.close
  end
  
  # Renames the old file to be the new file. //exact same as File::move
  def self.rename(old, new)
    File.move(old, new)
  end
  
  # Copies the source to the destination and deletes the source.
  def self.move(source, destination)
    File.copy(source, destination)
    File.delete(source)
  end
  
  # Reads the file's data and inflates it with Zlib
  def self.inflate(file)
    data = ""
    t = Time.now
    File.open(file, 'rb') do |f|
      while r = f.read(4096)
        if Time.now - t > 1
          Graphics.update
          t = Time.now
        end
        data += r
      end
    end
    data.inflate!
    File.delete(file)
    f = File.new(file, 'wb')
    f.write data
    f.close
    return data
  end
  
  # Reads the file's data and deflates it with Zlib
  def self.deflate(file)
    data = ""
    t = Time.now
    File.open(file, 'rb') do |f|
      while r = f.read(4096)
        if Time.now - t > 1
          Graphics.update
          t = Time.now
        end
        data += r
      end
    end
    data.deflate!
    File.delete(file)
    f = File.new(file, 'wb')
    f.write data
    f.close
    return data
  end
  
  # Note: This is VERY basic compression and should NOT serve as encryption.
  # Compresses all specified files into one, big package
  def self.compress(outfile, files, delete_files = true)
    start = Time.now
    files = [files] unless files.is_a?(Array)
    for i in 0...files.size
      if !File.file?(files[i])
        raise "Could not find part of the path `#{files[i]}`"
      end
    end
    files.breakup(500) # 500 files per compressed file
    full = ""
    t = Time.now
    for i in 0...files.size
      if Time.now - t > 1
        Graphics.update
        t = Time.now
      end
      data = ""
      File.open(files[i], 'rb') do |f|
        while r = f.read(4096)
          if Time.now - t > 1
            Graphics.update
            t = Time.now
          end
          data += r
        end
      end
      File.delete(files[i]) if delete_files
      full += "#{data.size}|#{files[i]}|#{data}"
      full += "|" if i != files.size - 1
    end
    File.delete(outfile) if File.file?(outfile)
    f = File.new(outfile, 'wb')
    f.write full.deflate
    f.close
    return Time.now - start
  end
  
  # Decompresses files compressed with File.compress
  def self.decompress(filename, delete_package = true)
    start = Time.now
    data = ""
    t = Time.now
    File.open(filename, 'rb') do |f|
      while r = f.read(4096)
        if Time.now - t > 1
          Graphics.update
          t = Time.now
        end
        data += r
      end
    end
    data.inflate!
    loop do
      size, name = data.split('|')
      data = data.split(size + "|" + name + "|")[1..-1].join(size + "|" + name + "|")
      size = size.to_i
      content = data[0...size]
      data = data[(size + 1)..-1]
      File.delete(name) if File.file?(name)
      f = File.new(name, 'wb')
      f.write content
      f.close
      break if !data || data.size == 0 || data.split('|').size <= 1
    end
    File.delete(filename) if delete_package
    return Time.now - start
  end
  
  # Creates all directories that don't exist in the given path, as well as the
  # file. If given a second argument, it'll write that to the file.
  def self.create(path, data = nil)
    start = Time.now
    Dir.create(path.split('/')[0..-2].join('/'))
    f = File.new(path, 'wb')
    f.write data if data && data.size > 0
    f.close
    return Time.now - start
  end
end

# Dir class extensions
class Dir
  class << Dir
    alias marin_delete delete
  end

  # Returns all files in the targeted path
  def self.get_files(path, recursive = true)
    return Dir.get_all(path, recursive).select { |path| File.file?(path) }
  end
  
  # Returns all directories in the targeted path
  def self.get_dirs(path, recursive = true)
    return Dir.get_all(path, recursive).select { |path| File.directory?(path) }
  end
  
  # Returns all files and directories in the targeted path
  def self.get_all(path, recursive = true)
    files = []
    Dir.foreach(path) do |f|
      next if f == "." || f == ".."
      if File.directory?(path + "/" + f) && recursive
        files.concat(Dir.get_files(path + "/" + f))
      end
      files << path + "/" + f
    end
    return files
  end
  
  # Deletes a directory and all files/directories within, unless non_empty is false
  def self.delete(path, non_empty = true)
    if non_empty
    for file in Dir.get_all(path)
      if File.directory?(file)
        Dir.delete(file, non_empty)
      elsif File.file?(file)
        File.delete(file)
      end
    end
  end
    marin_delete(path)
  end
  
  # Creates all directories that don't exist in the given path.
  def self.create(path)
    split = path.split('/')
    for i in 0...split.size
      Dir.mkdir(split[0..i].join('/')) unless File.directory?(split[0..i].join('/'))
    end
  end
end


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
end


# A better alternative to the typical @sprites = {}
class BetterHash
  attr_reader :x
  attr_reader :y
  attr_reader :z
  attr_reader :visible
  attr_reader :opacity
  
  def initialize
    @hash = {}
    @x = 0
    @y = 0
    @z = 0
    @visible = true
    @opacity = 255
  end
  
  # Returns the object in the specified key
  def [](key)
    key = key.to_sym if key.respond_to?(:to_sym)
    return @hash[key]
  end
  
  # Sets an object in specified key to the specified value
  def []=(key, value)
  key = key.to_sym if key.respond_to?(:to_sym)
    add(key, value)
  end
  
  def <<(value)
    i = 0
    while true
      if @hash[i]
        i += 1
        next
      end
      break
    end
    @hash[i] = value
  end
  
  # Returns the raw hash
  def raw
    return @hash
  end
  
  # Returns the keys in the hash
  def keys
    return @hash.keys
  end
  
  def length; return self.size; end
  def count; return self.size; end
  
  # Returns the amount of keys in the hash
  def size
    return @hash.keys.size
  end
  
  # Clones the hash
  def clone
    return @hash.clone
  end
  
  # Adds an object to the specified key
  def add(key, value)
    clear_disposed
    key = key.to_sym if key.respond_to?(:to_sym)
    @hash[key] if @hash[key] && @hash[key].respond_to?(:dispose)
    @hash[key] = value
    clear_disposed
  end
  
  # Deletes an object in the specified key
  def delete(key)
    key = key.to_sym if key.respond_to?(:to_sym)
    @hash[key] = nil
    clear_disposed
  end
  
  # Iterates over all sprites
  def each
    clear_disposed
    @hash.each { |s| yield s[1] if block_given? }
  end
  
  # Updates all sprites
  def update
    clear_disposed
    for key in @hash.keys
      @hash[key].update if @hash[key].respond_to?(:update)
    end
  end
  
  # Disposes all sprites
  def dispose
    clear_disposed
    for key in @hash.keys
      @hash[key].dispose if @hash[key].respond_to?(:dispose)
    end
    clear_disposed
  end
  
  # Compatibility
  def disposed?
    return false
  end
  
  # Changes x on all sprites
  def x=(value)
    clear_disposed
    for key in @hash.keys
      @hash[key].x += value - @x
    end
    @x = value
  end
  
  # Changes y on all sprites
  def y=(value)
    clear_disposed
    for key in @hash.keys
      @hash[key].y += value - @y
    end
    @y = value
  end
  
  # Changes z on all sprites
  def z=(value)
    clear_disposed
    for key in @hash.keys
      @hash[key].z += value - @z
    end
    @z = value
  end
  
  # Changes visibility on all sprites
  def visible=(value)
    clear_disposed
    for key in @hash.keys
      @hash[key].visible = value
    end
  end
  
  # Changes opacity on all sprites
  def opacity=(value)
    clear_disposed
    for key in @hash.keys
      @hash[key].opacity += value - @opacity
    end
    @opacity = [0,value,255].sort[1]
  end
  
  # Fades out all sprites
  def hide(frames = 16)
    clear_disposed
    frames.times do
      Graphics.update
      Input.update
      for key in @hash.keys
        @hash[key].opacity -= 255 / frames.to_f
      end
    end
    @opacity = 0
  end
  
  # Fades in all sprites
  def show(frames = 16)
    clear_disposed
    frames.times do
      Graphics.update
      Input.update
      for key in @hash.keys
        @hash[key].opacity += 255 / frames.to_f
      end
    end
    @opacity = 255
  end
  
  # Deletes all disposed sprites from the hash
  def clear_disposed
    for key in @hash.keys
      if (@hash[key].disposed? rescue false)
        @hash[key] = nil
        @hash.delete(key)
      end
    end
  end
end


# Stand-alone methods

# Fades in a black overlay
def showBlk(update = true)
  return if $blkVp || $blk
  $blkVp = Viewport.new(0,0,Graphics.width,Graphics.height)
  $blkVp.z = 9999999
  $blk = Sprite.new($blkVp)
  $blk.bmp(-1,-1)
  $blk.bitmap.fill_rect(0,0,Graphics.width,Graphics.height,Color.new(0,0,0))
  $blk.opacity = 0
  for i in 0...17
    if update
      Graphics.update
      Input.update
    end
    yield i if block_given?
    $blk.opacity += 256 / 16.0
  end
end

# Fades out and disposes a black overlay
def hideBlk(update = true)
  return if !$blk || !$blkVp
  for i in 0...17
    if update
      Graphics.update
      Input.update
    end
    yield i if block_given?
    $blk.opacity -= 256 / 16.0
  end
  $blk.dispose
  $blk = nil
  $blkVp.dispose
  $blkVp = nil
end



# Allows for usage of Ranges and dual arguments. Usage:
# -> rand(10)     #=> Random number between 0 and 10, exclusive
# -> rand(0..10)  #=> Random number between 0 and 10, inclusive
# -> rand(0...10) #=> Random number between 0 and 10, exclusive
# -> rand(0, 10)  #=> Random number between 0 and 10, exclusive
alias marin_rand rand
def rand(n, upper = nil)
  if n.is_a?(Range) || upper
    lower = (upper ? n : n.begin)
    upper = (upper || n.end)
    mod = 0
    mod = 1 if n.is_a?(Range) && !n.exclude_end?
    return marin_rand(upper - lower + mod) + lower
  end
  return marin_rand(n)
end

# Input module extensions
module Input
  # Returns true if any of the buttons below are pressed
  def self.any?
    keys = [Input::C,Input::B,Input::LEFT,Input::RIGHT,Input::UP,Input::DOWN,
            # 0-9, a-z
            0x30,0x31,0x32,0x33,0x34,0x35,0x36,0x37,0x38,0x39,0x41,0x42,0x43,0x44,
            0x45,0x46,0x47,0x48,0x49,0x4A,0x4B,0x4C,0x4D,0x4E,0x50,0x51,0x52,0x53,
            0x54,0x55,0x56,0x57,0x58,0x59,0x5A]
    for key in keys
      return true if Input.triggerex?(key)
    end
    return false
  end
end