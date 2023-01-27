using Godot;
using System;

public class Die : RigidBody
{
    public Transform StartLocation;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        // saves the start location so that any following die throws can be respawned from the same location
        StartLocation = GlobalTransform;

        Bounce = 0.25f;
    }
	

	private void Die_GridChangedVis()
	{
        Spatial Grid = GetNode<Spatial>("..");

        // randomizes RandRange function
        GD.Randomize();

        // Grid is visible: dice are being thrown
        if (Grid.Visible)
        {
            // reset gravity
            GravityScale = 1;

            GlobalTransform = StartLocation;

            // x is up (neg) and down (pos) the board, z is left (pos) to right (neg) on the board. 

            // Different ForceXs makes it more likely for the dice to hit each other, can remove if needed.
            double ForceX;
            if (Name == "Die")
            {
                ForceX = GD.RandRange(3, 7);
            }
            else
            {
                ForceX = GD.RandRange(-7, 0);
            }
            double ForceY = GD.RandRange(8, 10);
            double ForceZ = GD.RandRange(-26, -28);
            Vector3 ForceVec = new Vector3((float)ForceX, (float)ForceY, (float)ForceZ);

            double AngleX = GD.RandRange(5, 10);
            double AngleY = GD.RandRange(5, 10);
            double AngleZ = GD.RandRange(5, 10);
            Vector3 AngleVec = new Vector3((float)AngleX, (float)AngleY, (float)AngleZ);

            // Adds a random force and angular velocity
            AddCentralForce(ForceVec);
            SetAngularVelocity(AngleVec);
        }
        else // dice not being thrown
        {
            // Respawns the die at the start location
            GlobalTransform = StartLocation;
            // Disables gravity so that the dice don't fall to the ground before thrown
            GravityScale = 0;
        }

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
	{
		  
	}

}
																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																					   


