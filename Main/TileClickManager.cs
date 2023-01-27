using Godot;
using System;

public class TileClickManager : Node
{

    [Signal] public delegate void NewBuilding(Vector3 Coordinates, bool Corner);
    public override void _Ready()
    {

    }

    // Emits signal for Builder_Node to use
    public void ClickedAt(Vector3 Coordinates, bool Corner)
    {
        EmitSignal("NewBuilding", Coordinates, Corner);

    }
}

