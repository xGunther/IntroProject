using Godot;
using System;

public class SettlementBuild_Button : Button
{
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Connect("pressed", this, "Triggered");
    }

    private void Triggered()
    {
        Builder.SelectedBuild = "settlement";
        

    }
}
