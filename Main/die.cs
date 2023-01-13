using Godot;
using System;

public class die : RigidBody
{
    public Transform startLocation;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        startLocation = GlobalTransform;

    }
	

	private void Die_GridChangedVis()
	{
        // randomizes RandRange function
        GD.Randomize();
        
        // saves the start location so that any following die throws can be respawned from the same location
        GlobalTransform = startLocation;

        // x is up (neg) and down (pos) the board, z is left (pos) to right (neg) on the board. 

        // Makes it more likely for the dice to hit each other, can remove if needed.
        double xForce;
        if (Name == "die")
        {
            xForce = GD.RandRange(3, 7);
        }
        else
        {
            xForce = GD.RandRange(-7, 0);
        }
        double yForce = GD.RandRange(8,10);
        double zForce = GD.RandRange(-17,-18);

        Vector3 vecForce = new Vector3((float)xForce, (float)yForce, (float)zForce);

        double xAngle = GD.RandRange(5, 10);
        double yAngle = GD.RandRange(5, 10);
        double zAngle = GD.RandRange(5, 10);

        Vector3 vecAngle = new Vector3((float)xAngle, (float)yAngle, (float)zAngle);

        // Adds a random force and angular velocity
        AddCentralForce(vecForce);
        SetAngularVelocity(vecAngle);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
	{
		  
	}

}
																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																					   


