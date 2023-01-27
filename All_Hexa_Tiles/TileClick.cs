using Godot;
using System;

public class TileClick : Area
{
    public override void _Ready()
    {
        //GetTree().Root.GetNode("Main").GetNode<Builder_Node>("Builder_Node");
    }

    public void TileInputEvent(Viewport viewport, InputEvent @event, Vector3 position, Vector3 normal, int shape_idx)
    {
        if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.ButtonIndex == (int)ButtonList.Left && eventMouseButton.Pressed)
        {
            CollisionShape Shape;
            String LastClick = Name;
            String ShapeString = "";

            if (LastClick.Contains("Side"))
            {
                Shape = (CollisionShape)GetNode("TileSideShape");
                ShapeString = "Side";
            }

            else // Corner
            {
                Shape = (CollisionShape)GetNode("TileCornerShape");
                ShapeString = "Corner";
            }
            Vector3 LastCoordinates = Shape.GlobalTranslation;

            GD.Print($"{LastClick} clicked: {LastCoordinates}"); // REMOVE LATER

            GridClick Grid = GetNode<GridClick>("/root/GridClick");
            Grid.ClickedAt(LastCoordinates); // This is where you use the buildernode. Something like: BuilderNode.NewBuilding(parameters that you need here)
        }
    }

}