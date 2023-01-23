using Godot;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Runtime.ExceptionServices;

public class Hex_GridCS : GridMap
{
    // Loading the tile files into the project
    public PackedScene TileSheep = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Sheep.tscn");
    public PackedScene TileGold = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Gold.tscn");
    public PackedScene TileGrain = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Grain.tscn");
    public PackedScene TileWood = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Wood.tscn");
    public PackedScene TileStone = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Stone.tscn");
    public PackedScene TileSand = (PackedScene)GD.Load("res://All_Hexa_Tiles/Sand_Tile2.tscn");

    // Loading the number files into the project
    public PackedScene Number2 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_2.tscn");
    public PackedScene Number3 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_3.tscn");
    public PackedScene Number4 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_4.tscn");
    public PackedScene Number5 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_5.tscn");
    public PackedScene Number6 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_6.tscn");
    public PackedScene Number8 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_8.tscn");
    public PackedScene Number9 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_9.tscn");
    public PackedScene Number10 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_10.tscn");
    public PackedScene Number11 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_11.tscn");
    public PackedScene Number12 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_12.tscn");

    public float TileSize = 5; // Size of the tiles of the board
    public int GridRange = 7; // Number of lines and columns of the grid
    List<Spatial> Tiles = new List<Spatial>();

    // Function that makes a floating number to give to the Vector3 structure
    public static float ThirtyDegrees() 
    {
        double radians = (Math.PI / 180) * 30;
        float radiansF = Convert.ToSingle(radians);
        return radiansF;
    }

    // Function that puts the tiles in a list for the build feature to use
    public void PutInTileList(Spatial listTile)
    {
        Tiles.Add(listTile);
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
                case 3: TileChooserGrain(); NumberChooser9(); break; // x=3 y=0
                case 4: break; // x=4 y=0
                case 5: break; // x=5 y=0
                case 6: break; // x=6 y=0
                case 10: break; // x=0 y=1
                case 11: TileChooserStone(); NumberChooser5(); break; // x=1 y=1
                case 12: TileChooserWood(); NumberChooser8(); break; // x=2 y=1
                case 13: TileChooserWood(); NumberChooser11(); break; // x=3 y=1
                case 14: TileChooserGrain(); NumberChooser12(); break; // x=4 y=1
                case 15: TileChooserGold(); NumberChooser10(); break; // x=5 y=1
                case 16: break; // x=6 y=1
                case 20: break; // x=0 y=2
                case 21: TileChooserGrain(); NumberChooser6(); break; // x=1 y=2
                case 22: TileChooserGold(); NumberChooser3(); break; // x=2 y=2
                case 23: TileChooserSand(); break; // x=3 y=2
                case 24: TileChooserStone(); NumberChooser6(); break; // x=4 y=2
                case 25: TileChooserSheep(); NumberChooser2(); break; // x=5 y=2
                case 26: break; // x=6 y=2
                case 30: break; // x=0 y=3
                case 31: TileChooserSheep(); NumberChooser11(); break; // x=1 y=3
                case 32: TileChooserGrain(); NumberChooser4(); break; // x=2 y=3
                case 33: TileChooserWood(); NumberChooser3(); break; // x=3 y=3
                case 34: TileChooserSheep(); NumberChooser4(); break; // x=4 y=3
                case 35: TileChooserWood(); NumberChooser9(); break; // x=5 y=3
                case 36: break; // x=6 y=3
                case 40: break; // x=0 y=4
                case 41: break; // x=1 y=4
                case 42: TileChooserSheep(); NumberChooser5(); break; // x=2 y=4
                case 43: TileChooserGold(); NumberChooser8(); break; // x=3 y=4
                case 44: TileChooserStone(); NumberChooser10(); break; // x=4 y=4
                case 45: break; // x=5 y=4
                case 46: break; // x=6 y=4
            }
        }

        // Functions for adding the specific tile to the coordinate in the switch (above)
        void TileChooserSheep()
        {
            Spatial sheepTile = (Spatial)TileSheep.Instance();
            AddChild(sheepTile);
            sheepTile.Translate(tileCoordsV3);
            PutInTileList(sheepTile);
        }
        void TileChooserGold()
        {
            Spatial goldTile = (Spatial)TileGold.Instance();
            AddChild(goldTile);
            goldTile.Translate(tileCoordsV3);
            PutInTileList(goldTile);
        }
        void TileChooserGrain()
        {
            Spatial grainTile = (Spatial)TileGrain.Instance();
            AddChild(grainTile);
            grainTile.Translate(tileCoordsV3);
            PutInTileList(grainTile);
        }
        void TileChooserWood()
        {
            Spatial woodTile = (Spatial)TileWood.Instance();
            AddChild(woodTile);
            woodTile.Translate(tileCoordsV3);
            PutInTileList(woodTile);
        }
        void TileChooserStone()
        {
            Spatial stoneTile = (Spatial)TileStone.Instance();
            AddChild(stoneTile);
            stoneTile.Translate(tileCoordsV3);
            PutInTileList(stoneTile);
        }
        void TileChooserSand()
        {
            Spatial sandTile = (Spatial)TileSand.Instance();
            AddChild(sandTile);
            sandTile.Translate(tileCoordsV3);
            PutInTileList(sandTile);
        }

        // Functions for adding the specific number to the coordinate in the switch (above)
        void NumberChooser2()
        {
            Spatial nr2 = (Spatial)Number2.Instance();
            AddChild(nr2);
            nr2.Translate(tileCoordsV3);
        }
        void NumberChooser3()
        {
            Spatial nr3 = (Spatial)Number3.Instance();
            AddChild(nr3);
            nr3.Translate(tileCoordsV3);
        }
        void NumberChooser4()
        {
            Spatial nr4 = (Spatial)Number4.Instance();
            AddChild(nr4);
            nr4.Translate(tileCoordsV3);
        }
        void NumberChooser5()
        {
            Spatial nr5 = (Spatial)Number5.Instance();
            AddChild(nr5);
            nr5.Translate(tileCoordsV3);
        }
        void NumberChooser6()
        {
            Spatial nr6 = (Spatial)Number6.Instance();
            AddChild(nr6);
            nr6.Translate(tileCoordsV3);
        }
        void NumberChooser8()
        {
            Spatial nr8 = (Spatial)Number8.Instance();
            AddChild(nr8);
            nr8.Translate(tileCoordsV3);
        }
        void NumberChooser9()
        {
            Spatial nr9 = (Spatial)Number9.Instance();
            AddChild(nr9);
            nr9.Translate(tileCoordsV3);
        }
        void NumberChooser10()
        {
            Spatial nr10 = (Spatial)Number10.Instance();
            AddChild(nr10);
            nr10.Translate(tileCoordsV3);
        }
        void NumberChooser11()
        {
            Spatial nr11 = (Spatial)Number11.Instance();
            AddChild(nr11);
            nr11.Translate(tileCoordsV3);
        }   
        void NumberChooser12()
        {
            Spatial nr12 = (Spatial)Number12.Instance();
            AddChild(nr12);
            nr12.Translate(tileCoordsV3);
        }
    }
    public override void _Ready()
    {
        MakeGrid(GridRange);
    }
}