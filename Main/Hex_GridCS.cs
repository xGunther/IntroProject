using Godot;
using System;
using System.Runtime.ExceptionServices;

public class Hex_GridCS : GridMap
{
    private Texture TileSheep = ResourceLoader.Load("res://All_Hexa-Tiles/Hexa_Tile_Sheep.tscn") as Texture;
    private Texture TileGold = ResourceLoader.Load("res://All_Hexa_Tiles/Hexa_Tile_Gold.tscn") as Texture;
    private Texture TileGrain = ResourceLoader.Load("res://All_Hexa_Tiles/Hexa_Tile_Grain.tscn") as Texture;
    private Texture TileWood = ResourceLoader.Load("res://All_Hexa_Tiles/Hexa_Tile_Wood.tscn") as Texture;
    private Texture TileStone = ResourceLoader.Load("res://All_Hexa_Tiles/Hexa_Tile_Stone.tscn") as Texture;
    
    private int TileSize = 5;
    private int GridRange = 5; // Number of lines and columns of the grid
    

    public override void _Ready()
    {
        MakeGrid(GridRange);
    }

    private void MakeGrid(int GridRange)
    {
        for (int y = 0; y < GridRange; y++)
        {
            Vector2 TileCoords = new Vector2();
            for (int x = 0; x < GridRange; x++)
            {
                var tile = TileSheep.Instance();

            }
        }
    }
}
