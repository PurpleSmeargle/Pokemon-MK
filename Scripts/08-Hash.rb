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