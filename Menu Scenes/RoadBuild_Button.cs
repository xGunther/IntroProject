using Godot;
using System;

public class RoadBuild_Button : Button
{
    //Leaves room to save the Builder node (Builder_Node)
    private Builder_Node Builder;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       
    }

    //When the button is pressed
    private void Triggered()
    {
        Builder = GetNode<Builder_Node>("../../Builder_Node");
        Builder.SelectedBuild = "road";
    }
}
