using Godot;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Runtime.ExceptionServices;
using static Godot.RichTextLabel;

public class Hex_GridCS : GridMap
{
    // Loading the tile files into the project
    public PackedScene TileSheep = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Sheep.tscn");
    public PackedScene TileGold = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Gold.tscn");
    public PackedScene TileGrain = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Grain.tscn");
    public PackedScene TileWood = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Wood.tscn");
    public PackedScene TileStone = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Stone.tscn");
    public PackedScene TileSand = (PackedScene)GD.Load("res://All_Hexa_Tiles/Sand_Tile2.tscn");

    public PackedScene[] Numbers = new PackedScene[13];

    public float TileSize = 5; // Size of the tiles of the board
    public int GridRange = 7; // Number of lines and columns of the grid
    public List<Spatial> Tiles = new List<Spatial>();
    public Dictionary<int, List<Tile>> TilesDictionary = new Dictionary<int, List<Tile>>();
    private int LastNumber;


    private void AddNumbers()
    {
        for (int i = 2; i < 13; i++)
        {
            if (i != 7) // The number 7 is not used in this board, hence it is not needed
            {
                Numbers[i] = ((PackedScene)GD.Load($"res://All Roads, Cities and Numbers/Number_{i}.tscn"));
            }
        }
    }

    // Function that makes a floating number to give to the Vector3 structure
    public static float ThirtyDegrees() 
    {
        double Radians = (Math.PI / 180) * 30;
        float RadiansF = Convert.ToSingle(Radians);
        return RadiansF;
    }

    // Function that puts the tiles in a list for the build feature to use
    public void PutInTileList(Spatial listTile)
    {
        Tiles.Add(listTile);
        TilesDictionary[LastNumber].Add(new Tile(listTile, LastNumber));

    }

    public void FillTilesDictionary()
    {
        for (int n = 2; n < 13; n++)
        {
            TilesDictionary[n] = new List<Tile>() ;
        }
    }

    // Function responsible for creating the grid
    public void MakeGrid(int GridRange)
    {
        Vector2 tileCoords = new Vector2();
        Vector3 tileCoordsV3 = new Vector3();

        // Loop that calculates the coordinates of the tiles
        for (int x = 0; x < GridRange; x++)
        {
            tileCoords.x = x * TileSize * Mathf.Cos(ThirtyDegrees());
            tileCoords.y = 0;

            for (int y = 0; y < (GridRange - 2); y++) // "GridRange - 2" because the grid is higher than it is wide
            {
                if (x % 2 == 0)
                {
                    tileCoords.y = y * TileSize;
                }
                else
                {
                    tileCoords.y = (y * TileSize) + TileSize / 2;
                }

                tileCoordsV3.x = tileCoords.x;
                tileCoordsV3.y = 0;
                tileCoordsV3.z = tileCoords.y;
                TileChooser(x, 0, y); // The calculated coordinates are given to TileChooser
            }
        }

        // Function that places the tiles in Catan's beginner layout
        void TileChooser(int x, int p, int y) 
        {
            int F = x + 10 * y;
            switch (F)
            {
                case 0: break; // x=0 y=0
                case 1: break; // x=1 y=0
                case 2: break; // x=2 y=0
                case 3: NumberChooser(9); SpecificTileChooser(TileGrain); break; // x=3 y=0
                case 4: break; // x=4 y=0
                case 5: break; // x=5 y=0
                case 6: break; // x=6 y=0
                case 10: break; // x=0 y=1
                case 11: NumberChooser(5); SpecificTileChooser(TileStone); break; // x=1 y=1
                case 12: NumberChooser(8); SpecificTileChooser(TileWood); break; // x=2 y=1
                case 13: NumberChooser(11); SpecificTileChooser(TileWood); break; // x=3 y=1
                case 14: NumberChooser(12); SpecificTileChooser(TileGrain); break; // x=4 y=1
                case 15: NumberChooser(10); SpecificTileChooser(TileGold); break; // x=5 y=1
                case 16: break; // x=6 y=1
                case 20: break; // x=0 y=2
                case 21: NumberChooser(6); SpecificTileChooser(TileGrain); break; // x=1 y=2
                case 22: NumberChooser(3); SpecificTileChooser(TileGold); break; // x=2 y=2
                case 23: NumberChooser(7); SpecificTileChooser(TileSand); break; // x=3 y=2
                case 24: NumberChooser(6); SpecificTileChooser(TileStone); break; // x=4 y=2
                case 25: NumberChooser(2); SpecificTileChooser(TileSheep); break; // x=5 y=2
                case 26: break; // x=6 y=2
                case 30: break; // x=0 y=3
                case 31: NumberChooser(11); SpecificTileChooser(TileSheep); break; // x=1 y=3
                case 32: NumberChooser(4); SpecificTileChooser(TileGrain); break; // x=2 y=3
                case 33: NumberChooser(3); SpecificTileChooser(TileWood); break; // x=3 y=3
                case 34: NumberChooser(4); SpecificTileChooser(TileSheep); break; // x=4 y=3
                case 35: NumberChooser(9); SpecificTileChooser(TileWood); break; // x=5 y=3
                case 36: break; // x=6 y=3
                case 40: break; // x=0 y=4
                case 41: break; // x=1 y=4
                case 42: NumberChooser(5); SpecificTileChooser(TileSheep); break; // x=2 y=4
                case 43: NumberChooser(8); SpecificTileChooser(TileGold); break; // x=3 y=4
                case 44: NumberChooser(10); SpecificTileChooser(TileStone); break; // x=4 y=4
                case 45: break; // x=5 y=4
                case 46: break; // x=6 y=4
            }
            DiceValueManager DiceManager = GetNode<DiceValueManager>("../DiceValueManager");
            DiceManager.UpdateVars();
        }

        // Functions for adding the specific tile to the coordinate in the switch (above)

        void SpecificTileChooser(PackedScene Tile)
        {
            Spatial SpatialTile = (Spatial)Tile.Instance();
            AddChild(SpatialTile);
            SpatialTile.Translate(tileCoordsV3);

            PutInTileList(SpatialTile);
        }


        // Functions for adding the specific number to the coordinate in the switch (above)
        void NumberChooser(int Number)
        {
            if (Number != 7)
            {
                Spatial SpatialNumber = (Spatial)Numbers[Number].Instance();
                AddChild(SpatialNumber);
                SpatialNumber.Translate(tileCoordsV3);
            }

            LastNumber = Number;
        }
    }
    public override void _Ready()
    {
        AddNumbers();
        FillTilesDictionary();
        MakeGrid(GridRange);
    }
}