extends Spatial


const Tile_Size : float = 5.0 
const Hexa_Tile_Sheep = preload("res://Hexa_Tile_Sheep.tscn")
const Hexa_Tile_Gold = preload("res://Hexa_Tile_Gold.tscn")
const Hexa_Tile_Grain = preload("res://Hexa_Tile_Grain.tscn")
const Hexa_Tile_Wood = preload("res://Hexa_Tile_Wood.tscn")
const Hexa_Tile_Stone = preload("res://Hexa_Tile_Stone.tscn")


var grid_Range: int = 5
var x: int = 1
var tile_Coordinates := Vector2.ZERO


func _ready() -> void:
	make_grid(grid_Range)


func make_grid(grid_Range):


	for x in range (1):
		var tile_Coordinates := Vector2.ZERO
		tile_Coordinates.x = x * Tile_Size * cos (deg2rad(30))
		tile_Coordinates.y = 0 if x % 2 == 0 else Tile_Size / 2
		for y in range (3):
			var tile = Hexa_Tile_Sheep.instance()
			add_child(tile)
			tile.translate(Vector3(tile_Coordinates.x, 0, tile_Coordinates.y))
			tile_Coordinates.y += Tile_Size 
	for x in range (2, 3):
		var tile_Coordinates := Vector2.ZERO
		tile_Coordinates.x = (x / 2) * Tile_Size * cos (deg2rad(30))
		tile_Coordinates.y = -2.5 if x % 2 == 0 else Tile_Size / 2
		for y in range (4):
			var tile = Hexa_Tile_Wood.instance()
			add_child(tile)
			tile.translate(Vector3(tile_Coordinates.x, 0, tile_Coordinates.y))
			tile_Coordinates.y += Tile_Size 
	for x in range (2, 3):
		var tile_Coordinates := Vector2.ZERO
		tile_Coordinates.x = x * Tile_Size * cos (deg2rad(30))
		tile_Coordinates.y = -5 if x % 2 == 0 else Tile_Size / 2
		for y in range (5):
			var tile = Hexa_Tile_Stone.instance()
			add_child(tile)
			tile.translate(Vector3(tile_Coordinates.x, 0, tile_Coordinates.y))
			tile_Coordinates.y += Tile_Size 
	for x in range (3, 4):
		var tile_Coordinates := Vector2.ZERO
		tile_Coordinates.x = x  * Tile_Size * cos (deg2rad(30))
		tile_Coordinates.y = -2.5 if x % 3 == 0 else Tile_Size / 2
		for y in range (4):
			var tile = Hexa_Tile_Gold.instance()
			add_child(tile)
			tile.translate(Vector3(tile_Coordinates.x, 0, tile_Coordinates.y))
			tile_Coordinates.y += Tile_Size 
	for x in range (4, 5):
		var tile_Coordinates := Vector2.ZERO
		tile_Coordinates.x = x * Tile_Size * cos (deg2rad(30))
		tile_Coordinates.y = 0 if x % 2 == 0 else Tile_Size / 2
		for y in range (3):
			var tile = Hexa_Tile_Grain.instance()
			add_child(tile)
			tile.translate(Vector3(tile_Coordinates.x, 0, tile_Coordinates.y))
			tile_Coordinates.y += Tile_Size 


#		for x in range(0,5):
#			if (x % 2 == 0): 
#				tile_Coordinates.x = (x / 2) * Tile_Size * cos (deg2rad(30)) 
#				tile_Coordinates.y = -2.5 if x % 3 == 0 else Tile_Size / 2
#			if (x == 3): 
#				tile_Coordinates.x = (x / 2) * Tile_Size * cos (deg2rad(30)) 
#				tile_Coordinates.y = -5 if x % 2 == 0 else Tile_Size / 2
#			else: 
#				tile_Coordinates.x = x * Tile_Size * cos (deg2rad(30)) 
#				tile_Coordinates.y = 0 if x % 2 == 0 else Tile_Size / 2
#			for y in range(0,5):
#				var tile = Hexa_Tile_Wood.instance()
#				add_child(tile)
#				tile.translate(Vector3(tile_Coordinates.x, 0, tile_Coordinates.y))
#				tile_Coordinates.y += Tile_Size 
			
