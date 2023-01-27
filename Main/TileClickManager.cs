using Godot;
using System;

public class TileClickManager : Node
{

    [Signal] public delegate void NewBuilding(Vector3 Coordinates, bool Corner, Vector3 Rotation);
    public override void _Ready()
    {

    }

    public Vector3 ConvertRotation(Vector3 Rotation)
    {
        if (0.52 < Rotation[1] && Rotation[1] < 0.53)
        {
            Rotation[1] += (float)(0.5 * Math.PI);
        }
        
        return Rotation;
    }
    // Emits signal for BuilderNode to use
    public void ClickedAt(Vector3 Coordinates, bool Corner, Vector3 Rotation)
    {
        EmitSignal("NewBuilding", Coordinates, Corner, ConvertRotation(Rotation));

    }
}

