using Godot;
using System;

//This class specifically belongs to the settlements that the green player places
public class Green_Settlement : Placeable
{
    // Called when the node enters the scene tree for the first time, essentially when the object is constructed
    public override void _Ready()
    {
        this.player = "green";//setting the colour of its player
    }

}
