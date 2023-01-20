using Godot;
using System;

//This class specifically belongs to the settlements that the red player places
public class Red_Settlement : Placeable
{

    // Called when the node enters the scene tree for the first time, essentially when the object is constructed
    public override void _Ready()
    {
        this.player = "red";//setting the colour of its player
    }

}
