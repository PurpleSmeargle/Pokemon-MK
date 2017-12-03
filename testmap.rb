data = {
  layers: [
  		# Layer 1
		[1,      1,      1,      1,      1,      1,      1,      1,      1,     1,
		 1,      1,      1,      1,      1,      1,      1,      1,      1,     1,
    	 1,      1,      1,      1,      1,      1,      1,      1,      1,     1,
    	 1,      1,      1,      1,      1,      1,      1,      1,      1,     1,
    	 1,      1,      1,      1,      1,      1,      1,      1,      1,     1,
		 1,      6,      6,      1,      1,      1,      1,      1,      1,     1,
		 6,      6,      6,      6,      1,      1,      1,      1,      1,     1,
	 	 6,      6,      6,      6,      1,      1,      1,      1,      1,     1,
	 	 6,      6,      6,      6,      6,      1,      1,      1,      1,     1,
 		 1,      1,      6,      6,      6,      1,      1,      1,      1,     1],
 
		# Layer 2
		[0,      0,      0,      0,      0,      0,        0,        0,        0,        0,
		 0,      0,      0,      0,      0,      0,        0,        0,        0,        0,
		 0,      0,      0,      0,      0,      0,        0,        0,        0,        0,
		 0,      0,      0,      0,      0,      [420,1,1],[421,1,1],[420,1,1],[421,1,1],0,
		 0,      0,      0,      0,      0,      [428,0],  [429,0],  [428,0],  [429,0],  0,
		 0,      0,      0,      0,      0,      [436,0],  [437,0],  [436,0],  [437,0],  0,
		 0,      0,      0,      0,      0,      0,        0,        0,        0,        0,
		 0,      0,      0,      0,      0,      0,        0,        0,        0,        0,
		 0,      0,      0,      0,      0,      0,        0,        0,        0,        0,
		 0,      0,      0,      0,      0,      0,        0,        0,        0,        0],
	],

	general: {
		width: 10,
		height: 10,
		tileset: "outside",
		name: "Route 1"
	}
}

File.delete("Maps/001.dat") if File.file?("Maps/001.dat")
f = File.new("Maps/001.dat", 'wb')
Marshal.dump(data, f)
f.close