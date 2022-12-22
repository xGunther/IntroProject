using Godot;
using System;
using System.Drawing.Text;
using System.Runtime.ExceptionServices;

public class Hex_GridCS : GridMap
{
    // Loading the .tscn files into the project
    private PackedScene TileSheep = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Sheep.tscn");
    private PackedScene TileGold = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Gold.tscn");
    private PackedScene TileGrain = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Grain.tscn");
    private PackedScene TileWood = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Wood.tscn");
    private PackedScene TileStone = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Stone.tscn");

    private float TileSize = 5; // Size of the tiles of the board
    public int GridRange = 5; // Number of lines and columns of the grid

    public static float ThirtyDegrees() // Making a floating number to give to the Vector3 structure
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
        Vector2 TileCoords;
        Vector3 TileCoordsV3;

        void TileChooser(int x, int p, int y)
        {
            if (x % 2 == 0)
            {
                Spatial SheepTile = (Spatial) TileSheep.Instance();
                AddChild(SheepTile);
                SheepTile.Translate(TileCoordsV3);
            }
            else
            {
                Spatial GoldTile = (Spatial) TileGold.Instance();
                AddChild(GoldTile);
                GoldTile.Translate(TileCoordsV3);
            }
        }

        for (int x = 0; x < GridRange; x++)
        {
            TileCoords = new Vector2();
            TileCoords.x = x * TileSize * Mathf.Cos(ThirtyDegrees());
            TileCoords.y = 0;
            
            for (int y = 0; y < GridRange; y++)
            {
                if (x % 2 == 0)
                {
                    TileCoords.y = y * TileSize;
                }
                else
                {
                    TileCoords.y = (y * TileSize) + TileSize / 2;
                }

                TileCoordsV3 = new Vector3();
                TileCoordsV3.x = TileCoords.x;
                TileCoordsV3.y = 0;
                TileCoordsV3.z = TileCoords.y;
                TileChooser(x, 0, y);
            }
        }
    }
}