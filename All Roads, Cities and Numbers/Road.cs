using Godot;
using System;


//This class will be the blueprint for all other road classes, that belong to different players
//Therefore, there will be no instances of class
public abstract class Road : Placeable
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {    }

    //A function that should count the amount of roads connected, for the feat "Longest Traderoute"
    public int CountRoute()
    { return 1; }
    
}
