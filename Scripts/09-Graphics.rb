module Graphics
  # Stores each map's layers and events.
  def self.maps
    @maps ||= []
    return @maps
  end
end