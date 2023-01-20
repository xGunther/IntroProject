using Godot;
using System;

public class die : RigidBody
{
    public Transform startLocation;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        // saves the start location so that any following die throws can be respawned from the same location
        startLocation = GlobalTransform;

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

            GlobalTransform = startLocation;

            // x is up (neg) and down (pos) the board, z is left (pos) to right (neg) on the board. 

            // Different xForces makes it more likely for the dice to hit each other, can remove if needed.
            double xForce;
            if (Name == "die")
            {
                xForce = GD.RandRange(3, 7);
            }
            else
            {
                xForce = GD.RandRange(-7, 0);
            }
            double yForce = GD.RandRange(8, 10);
            double zForce = GD.RandRange(-26, -28);
            Vector3 vecForce = new Vector3((float)xForce, (float)yForce, (float)zForce);

            double xAngle = GD.RandRange(5, 10);
            double yAngle = GD.RandRange(5, 10);
            double zAngle = GD.RandRange(5, 10);
            Vector3 vecAngle = new Vector3((float)xAngle, (float)yAngle, (float)zAngle);

            // Adds a random force and angular velocity
            AddCentralForce(vecForce);
            SetAngularVelocity(vecAngle);
        }
        else // dice not being thrown
        {
            // Respawns the die at the start location
            GlobalTransform = startLocation;
            // Disables gravity so that the dice don't fall to the ground before thrown
            GravityScale = 0;
        }

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
	{
		  
	}

}
																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																					   


