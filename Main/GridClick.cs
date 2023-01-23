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
        GD.Print("click");
        Spatial test = (Spatial)GSettlement.Instance();
        AddChild(test);
        //Main main = (Main)GetNode("/root/Main");
        //test.Translate(main.lastCoordinates);
        test.Translate(Coordinates);
        test.Translate(new Vector3(0, 0.334f, 0));
    }
}

