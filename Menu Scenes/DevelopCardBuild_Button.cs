using Godot;
using System;

public class DevelopCardBuild_Button : Button
{
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //Connect("pressed", this, "Triggered");
        var button = new Button();
        button.Pressed += ButtonPressed;
        AddChild(button);
    }

    private void ButtonPressed()
    {
        

    }
}
