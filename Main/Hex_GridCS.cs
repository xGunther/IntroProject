using Godot;
using System;
using System.Runtime.ExceptionServices;

public class Hex_GridCS : GridMap
{
    private int Tile_Size = 5;
    var 
    var texture = ResourceLoader.Load("res://All_Hexa-Tiles/Hexa_Tile_Sheep.tscn") as Texture;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        make_grid(grid_Range);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
