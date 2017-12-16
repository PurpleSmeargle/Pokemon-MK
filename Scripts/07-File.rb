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