using Godot;
using System;

public class Die_Grid : Spatial
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hide();
	}
	
	public override void _Input(InputEvent inputEventArgs)
	{
		
	}
	

// temporary way to throw dice again
	public override void _Process(float delta)
	{

		// For now, pressing R will throw the dice. Will have to implement an actual system later on 
		 if (Input.IsKeyPressed((int)KeyList.R))
		{
			GetTree().ReloadCurrentScene();
		}     
	}
}
