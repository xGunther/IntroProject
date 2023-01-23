using Godot;
using System;

public class GridClick : Area
{
    public override void _Ready()
    {

    }

    public void NewBuilding(Vector3 Coordinates)
    {
        PackedScene GSettlement = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Green Placeables/Green_Settlement.tscn");
        Spatial NewBuilding = (Spatial)GSettlement.Instance();
        AddChild(NewBuilding);
        //Main main = (Main)GetNode("/root/Main");
        //test.Translate(main.lastCoordinates);
        NewBuilding.Translate(Coordinates);
        NewBuilding.Translate(new Vector3(0, 0.334f, 0));
    }
}

