using Godot;
using System;

//This class has the purpose of connecting the click on a collision node with the BuilderNode functions
public class TileClick : Area
{
    public override void _Ready()
    {

    }

    // Is called whenever a tile is clicked on the side or corner
    public void TileInputEvent(Viewport Viewport, InputEvent @Event, Vector3 Position, Vector3 Normal, int ShapeIdx)
    {
        // Filters for only left clicks that have just been pressed
        if (@Event is InputEventMouseButton EventMouseButton && EventMouseButton.ButtonIndex == (int)ButtonList.Left && EventMouseButton.Pressed)
        {
            CollisionShape Shape;
            Vector3 RotationOfNode;
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
            RotationOfNode = ConvertRotation(Shape.Rotation);

            // Tells Main that the tile has been clicked at the coordinates given
            BuilderNode Builder = GetNode<BuilderNode>("/root/Main/BuilderNode");
            Builder.PlaceBuilding(LastCoordinates, Corner, RotationOfNode);
        }
    }

    //A method to change the rotational vector, to avoid some problems
    public Vector3 ConvertRotation(Vector3 Rotation)
    {
        if (0.52 < Rotation[1] && Rotation[1] < 0.53)
        {
            Rotation[1] += (float)(0.5 * Math.PI);
        }

        return Rotation;
    }

}