using Godot;
using System;

public class CancelBuild_Button : Button
{
    //Leaves room to save the Builder node (BuilderNode)
    private BuilderNode Builder;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    //When the button is pressed
    private void Triggered()
    {
        Builder = GetNode<BuilderNode>("../../BuilderNode");
        Builder.SelectedBuild = null;

    }
}
