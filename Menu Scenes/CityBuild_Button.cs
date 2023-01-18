using Godot;
using System;

public class CityBuild_Button : Button
{
    //finds Builder node
    private Node Builder;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Connect("pressed", this, "Triggered");
    }

    private void Triggered()
    {
        Builder = GetNode<Node>("../../Builder_Node");
        GD.Print(Builder);
        GD.Print("Building City");

    }
}
