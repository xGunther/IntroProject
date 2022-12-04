extends Spatial


const Tile_Size : float = 1.0 
const Hexa_Tile = preload("res://Hexa_Tile.tscn")

export (int, 2, 20) var grid_Size := 10

#var grid_size_easy: int = 15
#var grid_size_medium: int = 25
#var grid_size_hard: int = 35

func _ready() -> void:
	make_grid()

func make_grid():
	for x in range (grid_Size):
		var tile_Coordinates := Vector2.ZERO
		tile_Coordinates.x = x * Tile_Size * cos (deg2rad(30))
		tile_Coordinates.y = 0 if x % 2 == 0 else Tile_Size / 2
		for y in range (grid_Size):
			var tile = Hexa_Tile.instance()
			add_child(tile)
			tile.translate(Vector3(tile_Coordinates.x, 0, tile_Coordinates.y))
			tile_Coordinates.y += Tile_Size 
