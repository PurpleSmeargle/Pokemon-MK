def p(*args)
  msgbox *args
end

def puts(*args)
  p *args
end

def print(*args)
  p *args
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

# Included in TrueClass and FalseClass to be able to call is_a?(Boolean)
module Boolean end

class TrueClass
  include Boolean
  
  def to_i
    return 1
  end
end

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