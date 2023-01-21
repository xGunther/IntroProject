using Godot;
using System;

public class TileClick : Area
{
    public String lastClick = "";
    public Vector3 lastCoordinates = new Vector3(0, 0, 0);
    public override void _Ready()
    {

    }

    public void TileInputEvent(Viewport viewport, InputEvent @event, Vector3 position, Vector3 normal, int shape_idx)
    {
        if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.ButtonIndex == (int)ButtonList.Left && eventMouseButton.Pressed)
        {
            CollisionShape shape;
            lastClick = Name;

            if (lastClick.Contains("Side"))
                shape = (CollisionShape)GetNode("TileSideShape");
            else // Corner
                shape = (CollisionShape)GetNode("TileCornerShape");
            lastCoordinates = shape.GlobalTranslation;

            GD.Print($"{lastClick} clicked: {lastCoordinates}");
        }
    }
}