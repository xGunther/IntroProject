using Godot;
using System;
using System.Drawing.Text;
using System.Runtime.ExceptionServices;

public class Hex_GridCS : GridMap
{
    // Loading the tile files into the project
    private PackedScene TileSheep = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Sheep.tscn");
    private PackedScene TileGold = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Gold.tscn");
    private PackedScene TileGrain = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Grain.tscn");
    private PackedScene TileWood = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Wood.tscn");
    private PackedScene TileStone = (PackedScene)GD.Load("res://All_Hexa_Tiles/Hexa_Tile_Stone.tscn");
    private PackedScene TileSand = (PackedScene)GD.Load("res://All_Hexa_Tiles/Sand_Tile2.tscn");

    // Loading the number files into the project
    private PackedScene Number2 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_2.tscn");
    private PackedScene Number3 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_3.tscn");
    private PackedScene Number4 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_4.tscn");
    private PackedScene Number5 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_5.tscn");
    private PackedScene Number6 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_6.tscn");
    private PackedScene Number8 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_8.tscn");
    private PackedScene Number9 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_9.tscn");
    private PackedScene Number10 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_10.tscn");
    private PackedScene Number11 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_11.tscn");
    private PackedScene Number12 = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Number_12.tscn");

    public float TileSize = 5; // Size of the tiles of the board
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

        void TileChooser(int x, int p, int y) // Function that places the tiles in Catan's beginner layout
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
        void TileChooserSand()
        {
            Spatial SandTile = (Spatial)TileSand.Instance();
            AddChild(SandTile);
            SandTile.Translate(TileCoordsV3);
        }

        // Functions for adding the specific number to the coordinate in the switch (above)
        void NumberChooser2()
        {
            Spatial Nr2 = (Spatial)Number2.Instance();
            AddChild(Nr2);
            Nr2.Translate(TileCoordsV3);
        }
        void NumberChooser3()
        {
            Spatial Nr3 = (Spatial)Number3.Instance();
            AddChild(Nr3);
            Nr3.Translate(TileCoordsV3);
        }
        void NumberChooser4()
        {
            Spatial Nr4 = (Spatial)Number4.Instance();
            AddChild(Nr4);
            Nr4.Translate(TileCoordsV3);
        }
        void NumberChooser5()
        {
            Spatial Nr5 = (Spatial)Number5.Instance();
            AddChild(Nr5);
            Nr5.Translate(TileCoordsV3);
        }
        void NumberChooser6()
        {
            Spatial Nr6 = (Spatial)Number6.Instance();
            AddChild(Nr6);
            Nr6.Translate(TileCoordsV3);
        }
        void NumberChooser8()
        {
            Spatial Nr8 = (Spatial)Number8.Instance();
            AddChild(Nr8);
            Nr8.Translate(TileCoordsV3);
        }
        void NumberChooser9()
        {
            Spatial Nr9 = (Spatial)Number9.Instance();
            AddChild(Nr9);
            Nr9.Translate(TileCoordsV3);
        }
        void NumberChooser10()
        {
            Spatial Nr10 = (Spatial)Number10.Instance();
            AddChild(Nr10);
            Nr10.Translate(TileCoordsV3);
        }
        void NumberChooser11()
        {
            Spatial Nr11 = (Spatial)Number11.Instance();
            AddChild(Nr11);
            Nr11.Translate(TileCoordsV3);
        }
        void NumberChooser12()
        {
            Spatial Nr12 = (Spatial)Number12.Instance();
            AddChild(Nr12);
            Nr12.Translate(TileCoordsV3);
        }

        // Function for calculating the coordinates of the tiles
        for (int x = 0; x < GridRange; x++) // Function for calculating the coordinates of the tiles
        {
            TileCoords = new Vector2();
            TileCoords.x = x * TileSize * Mathf.Cos(ThirtyDegrees());
            TileCoords.y = 0;
            
            for (int y = 0; y < (GridRange - 2); y++) // "GridRange - 2" because the grid is higher than it is wide
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
                TileChooser(x, 0, y); // The calculated coordinates are given to the Tile Chooser
            }
        }
    }
}