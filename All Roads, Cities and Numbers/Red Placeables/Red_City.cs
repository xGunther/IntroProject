using Godot;
using System;

//This class specifically belongs to the cities that the red player places
public class Red_City : Placeable
{
    // Called when the node enters the scene tree for the first time, essentially when the object is constructed
    public override void _Ready()
    {
        string player = "red";
    }
}
