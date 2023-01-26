using Godot;
using System;


//This class will be the blueprint for all other road classes, that belong to different players
//Therefore, there will be no instances of class
//This class exists so in later versions, road-specific functionalities can be added here
public abstract class Road : Placeable
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {    }

}
