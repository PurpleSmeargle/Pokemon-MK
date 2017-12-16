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