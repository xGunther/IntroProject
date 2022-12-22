using Godot;
using System;
using System.Runtime.ExceptionServices;

public class Hex_GridCS : GridMap
{
    //private Texture TileSheep = ResourceLoader.Load("res://All_Hexa-Tiles/Hexa_Tile_Sheep.tscn") as Texture;
    private Texture TileGold = ResourceLoader.Load("res://All_Hexa_Tiles/Hexa_Tile_Gold.tscn") as Texture;
    private Texture TileGrain = ResourceLoader.Load("res://All_Hexa_Tiles/Hexa_Tile_Grain.tscn") as Texture;
    private Texture TileWood = ResourceLoader.Load("res://All_Hexa_Tiles/Hexa_Tile_Wood.tscn") as Texture;
    private Texture TileStone = ResourceLoader.Load("res://All_Hexa_Tiles/Hexa_Tile_Stone.tscn") as Texture;

    private PackedScene TileSheep = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Sheep.tscn");

    private float TileSize = 5;
    public int GridRange = 5; // Number of lines and columns of the grid

    public static float ThirtyDegrees()
    {
        double radians = (Math.PI / 180) * 30;
        float radiansF = Convert.ToSingle(radians);
        return radiansF;
    }

    public override void _Ready()
    {
        MakeGrid(GridRange);
    }

    private void MakeGrid(int GridRange)
    {
        for (int x = 0; x < GridRange; x++)
        {
            Vector2 TileCoords = new Vector2();
            TileCoords.x = x * TileSize * Mathf.Cos(ThirtyDegrees());
            TileCoords.y = 0;
            for (int y = 0; y < GridRange; y++)
            {
                Spatial tile = (Spatial) TileSheep.Instance();
                AddChild(tile);
                if (x % 2 == 0)
                {
                    TileCoords.y = y * TileSize;
                }
                else
                {
                    TileCoords.y = (y * TileSize) + TileSize / 2;
                }
                Vector3 TileCoordsV3 = new Vector3();
                TileCoordsV3.x = TileCoords.x;
                TileCoordsV3.y = 0;
                TileCoordsV3.z = TileCoords.y;
                tile.Translate(TileCoordsV3);
            }
        }
    }
}
