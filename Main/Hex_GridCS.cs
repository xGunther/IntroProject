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
    public int GridRange = 7; // Number of lines and columns of the grid

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
        /*
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
        */
        void TileChooserV2(int x, int p, int y)
        {
            int F = x + 10 * y;
            switch (F)
            {
                case 0: break; // x=0 y=0
                case 1: break; // x=1 y=0
                case 2: break; // x=2 y=0
                case 3: break; // x=3 y=0
                case 4: break; // x=4 y=0
                case 5: break; // x=5 y=0
                case 6: break; // x=6 y=0
                case 10: break; // x=0 y=1
                case 11: break; // x=1 y=1
                case 12: break; // x=2 y=1 there needs to be a caravan tile here
                case 13: TileChooserGrain(); break; // x=3 y=1
                case 14: break; // x=4 y=1 there needs to be a caravan tile here
                case 15: break; // x=5 y=1
                case 16: break; // x=6 y=1
                case 20: break; // x=0 y=2
                case 21: TileChooserStone(); break; // x=1 y=2
                case 22: TileChooserWood(); break; // x=2 y=2
                case 23: TileChooserWood(); break; // x=3 y=2
                case 24: TileChooserGrain(); break; // x=4 y=2
                case 25: TileChooserGold(); break; // x=5 y=2
                case 26: break; // x=6 y=2 there needs to be a caravan tile here
                case 30: break; // x=0 y=3
                case 31: TileChooserGrain(); break; // x=1 y=3
                case 32: TileChooserGold(); break; // x=2 y=3
                case 33: break; // x=3 y=3 there needs to be a desert tile here
                case 34: TileChooserStone(); break; // x=4 y=3
                case 35: TileChooserSheep(); break; // x=5 y=3
                case 36: break; // x=6 y=3
                case 40: break; // x=0 y=4
                case 41: TileChooserSheep(); break; // x=1 y=4
                case 42: TileChooserGrain(); break; // x=2 y=4
                case 43: TileChooserWood(); break; // x=3 y=4
                case 44: TileChooserSheep(); break; // x=4 y=4
                case 45: TileChooserWood(); break; // x=5 y=4
                case 46: break; // x=6 y=4 there needs to be a caravan tile here
                case 50: break; // x=0 y=5
                case 51: break; // x=1 y=5 there needs to be a caravan tile here
                case 52: TileChooserSheep(); break; // x=2 y=5
                case 53: TileChooserGold(); break; // x=3 y=5
                case 54: TileChooserStone(); break; // x=4 y=5
                case 55: break; // x=5 y=5 there needs to be a caravan tile here
                case 56: break; // x=6 y=5
                case 60: break; // x=0 y=6
                case 61: break; // x=1 y=6
                case 62: break; // x=2 y=6
                case 63: break; // x=3 y=6 there needs to be a caravan tile here
                case 64: break; // x=4 y=6
                case 65: break; // x=5 y=6
                case 66: break; // x=6 y=6
            }
        }

        void TileChooserSheep()
        {
            Spatial SheepTile = (Spatial)TileSheep.Instance();
            AddChild(SheepTile);
            SheepTile.Translate(TileCoordsV3);
        }

        void TileChooserGold()
        {
            Spatial GoldTile = (Spatial)TileGold.Instance();
            AddChild(GoldTile);
            GoldTile.Translate(TileCoordsV3);
        }

        void TileChooserGrain()
        {
            Spatial GrainTile = (Spatial)TileGrain.Instance();
            AddChild(GrainTile);
            GrainTile.Translate(TileCoordsV3);
        }

        void TileChooserWood()
        {
            Spatial WoodTile = (Spatial)TileWood.Instance();
            AddChild(WoodTile);
            WoodTile.Translate(TileCoordsV3);
        }

        void TileChooserStone()
        {
            Spatial StoneTile = (Spatial)TileStone.Instance();
            AddChild(StoneTile);
            StoneTile.Translate(TileCoordsV3);
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
                TileChooserV2(x, 0, y);
            }
        }
    }
}