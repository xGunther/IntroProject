using Godot;
using System;

//This class has the purpose of connecting the click on a collision node with the BuilderNode functions
public class TileClick : Area
{
    public override void _Ready()
    {

    }

    //This function intakes all the necessary parameters for input_event from CollisionObject and sends the right information to BuilderNode   
    public void TileInputEvent(Viewport Viewport, InputEvent @Event, Vector3 Position, Vector3 Normal, int ShapeIdx)
    {
        if (@Event is InputEventMouseButton eventMouseButton && eventMouseButton.ButtonIndex == (int)ButtonList.Left && eventMouseButton.Pressed)
        {
            CollisionShape Shape;
            String LastClick = Name;
            String ShapeString;//variable to state where relative to the hexatiles the collision node is placed

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

            BuilderNode Builder = (BuilderNode)GetNode("/root/Main/BuilderNode");
            Builder.PlaceBuilding(LastCoordinates, ShapeString); 
        }
    }

}