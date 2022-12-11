using Godot;
using System;


//This class will be the blueprint for all other city classes, that belong to different players
//Therefore, there will be no instances of class
public abstract class City : Spatial
{
    private string player;//this describes what player this city belongs to

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    /*// Called every frame. 'delta' is the elapsed time since the previous frame.
      public override void _Process(float delta)
      {

      }*/
}
