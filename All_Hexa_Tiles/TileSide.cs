using Godot;
using System;

public class TileSide : Area
{
    // currently TileSide.cs and TileCorner.cs are two different files in case that is necessary, but it's possible to use only one file
    public override void _Ready()
    {

    }

    public void SideInputEvent(Viewport viewport, InputEvent @event, Vector3 position, Vector3 normal, int shape_idx)
    {
        CollisionShape SideShape = (CollisionShape)GetNode("TileSideShape");
        if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.ButtonIndex == (int)ButtonList.Left && eventMouseButton.Pressed)
            GD.Print($"{Name} clicked: {SideShape.GlobalTranslation}");
    }
}
