class EventHandler
  # Initializes a new Event
  def initialize
    @procs = []
  end
  
  # Adds a new proc to this Event
  def +(value)
    @procs << value
    return self
  end
  
  # Calls all procs of this Event
  def call(*args)
    @procs.each { |e| e.call(*args) }
  end
end

module Events
  # Called whenever the Player successfully takes a step
  @@on_step_taken = EventHandler.new
  def self.on_step_taken=(v); @@on_step_taken = v end
  def self.on_step_taken; return @@on_step_taken end
  
  # Called whenever the Player tries to move one direction but fails
  @@on_step_impassable = EventHandler.new
  def self.on_step_impassable=(v); @@on_step_impassable = v end
  def self.on_step_impassable; return @@on_step_impassable end
  
  # Called whenever a new Map object is created
  @@on_map_created = EventHandler.new
  def self.on_map_created=(v); @@on_map_created = v end
  def self.on_map_created; return @@on_map_created end
  
  # Called whenever a new Event object is created
  @@on_event_created = EventHandler.new
  def self.on_event_created=(v); @@on_event_created = v end
  def self.on_event_created; return @@on_event_created end
  
  # Called whenver the Player has saved the game
  @@on_save = EventHandler.new
  def self.on_save=(v); @@on_save = v end
  def self.on_save; return @@on_save end
  
  # Called whenever the Player has loaded a save file
  @@on_load = EventHandler.new
  def self.on_load=(v); @@on_load = v end
  def self.on_load; return @@on_load end
  
  # Called whenever an Exception is thrown and caught by the main loop
  @@on_error = EventHandler.new
  def self.on_error=(v); @@on_error = v end
  def self.on_error; return @@on_error end
end

Events.on_step_taken += proc do |dir|
  # dir: The direction the Player went
end

Events.on_step_impassable += proc do |dir,x,y|
  # dir: The direction the Player tried to go in
  # x: The X position the Player attempted to go to
  # Y: The Y position the Player attempted to go to
end

Events.on_map_created += proc do |map|
  # map: The Map object that has just been created
end

Events.on_event_created += proc do |event|
  # event: The Event object that has just been created
end

Events.on_save += proc do
  
end

Events.on_load += proc do
  
end

Events.on_error += proc do |e|
  # e: The Exception object thrown
end