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