using Godot;
using System;
using System.Collections.Generic;

//In this class, all things related to building are added, from creating a new placeable to saving all current placeables
public class Builder : Node
{
    public List<Placeable> AllBuildings= new List<Placeable>(); 

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    //This method will create the nodes/placement instances and add them to the list
    public void build()
    {
        if (MoveCheck())
        {
            //make placeable and add it to the list
        }
        else
        {
            //show a popup that this move is invalid?
        }
    }

    //This method will check whether the move is legal or not and return whether it is.
    private bool MoveCheck()
    {
        return true;
    }

}
