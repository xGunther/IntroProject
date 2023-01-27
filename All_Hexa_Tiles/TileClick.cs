using Godot;
using System;

public class TileClick : Area
{
    public override void _Ready()
    {

    }

    // Is called whenever a tile is clicked on the side or corner
    public void TileInputEvent(Viewport viewport, InputEvent @event, Vector3 position, Vector3 normal, int shape_idx)
    {
        // Filters for only left clicks that have just been pressed
        if (@event is InputEventMouseButton eventMouseButton && eventMouseButton.ButtonIndex == (int)ButtonList.Left && eventMouseButton.Pressed)
        {
            CollisionShape Shape;
            bool Corner;

            // Checks the name so that the coordinates can be received from the child node
            if (Name.Contains("Side"))
            {
                Shape = (CollisionShape)GetNode("TileSideShape");
                Corner = false;
            }

            else // Corner
            {
                Shape = (CollisionShape)GetNode("TileCornerShape");
                Corner = true;
            }
            Vector3 LastCoordinates = Shape.GlobalTranslation;

            // Tells Main that the tile has been clicked at the coordinates given
            TileClickManager Grid = GetNode<TileClickManager>("/root/TileClickManager");
            Grid.ClickedAt(LastCoordinates, Corner); 
        }
    }

}