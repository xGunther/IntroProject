using Godot;
using System;

public class TileCorner : Area
{
    public override void _Ready()
    {
        
    }

    public void CornerInputEvent(Viewport viewport, InputEvent @event, Vector3 position, Vector3 normal, int shape_idx)
    {
        CollisionShape CornerShape = (CollisionShape)GetNode("TileCornerShape");
        if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.ButtonIndex == (int)ButtonList.Left && eventMouseButton.Pressed)
            GD.Print($"{Name} clicked: {CornerShape.GlobalTranslation}");
    }
}
