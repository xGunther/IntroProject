using Godot;
using System;

//This class specifically belongs to the roads that the green player places
public class Green_Road : Road
{
    // Called when the node enters the scene tree for the first time, essentially when the object is constructed
    public override void _Ready()
    {
        this.Player = "green";//setting the colour of its player
    }

}
