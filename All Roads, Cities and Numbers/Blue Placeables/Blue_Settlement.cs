using Godot;
using System;

//This class specifically belongs to the settlements that the blue player places
public class Blue_Settlement : Placeable
{
    // Called when the node enters the scene tree for the first time, essentially when the object is constructed
    public override void _Ready()
    {
        this.Player = "blue";//setting the colour of its player
    }

}
