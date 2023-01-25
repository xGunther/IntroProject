using Godot;
using System;

//This class will be the blueprint for all other road classes, that belong to different players
public class Blue_Road : Road
{
    // Called when the node enters the scene tree for the first time, essentially when the object is constructed
    public override void _Ready()
    {
        this.player = "blue";//setting the colour of its player
    }

}
