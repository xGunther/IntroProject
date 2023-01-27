using Godot;
using System;

public class GridClick : Node
{

    [Signal] public delegate void NewBuilding(Vector3 Coordinates);
    public override void _Ready()
    {

    }

    // example of what you can do. In your version this GridClick.cs should not exist, instead it should just be in your BuilderNode, probably
    public void ClickedAt(Vector3 Coordinates)
    {
        /*PackedScene GSettlement = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Green Placeables/Green_Settlement.tscn");
        Spatial NewBuilding = (Spatial)GSettlement.Instance();
        AddChild(NewBuilding);
        NewBuilding.Translate(Coordinates);
        NewBuilding.Translate(new Vector3(0, 0.334f, 0));*/

        //Builder_Node Builder = GetTree().Root.GetNode("Main").GetNode<Builder_Node>("Builder_Node");
        //Builder.Build(Coordinates);

        EmitSignal("NewBuilding", Coordinates);

    }
}

