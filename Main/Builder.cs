using Godot;
using System;
using System.Collections.Generic;

//In this class, all things related to building are added, from creating a new placeable to saving all current placeables
public class BuilderNode : Node
{
    //list to save all made placeables
    public List<Placeable> AllBuildings= new List<Placeable>();

    //this variable saves what will be built next. If nothing is being built, value should be null
    public string SelectedBuild;

    //spot to save the TurnManager
    Node TM;

    //The eventual place of the co�rdinates for new 'buildings'
    Vector3 Buildplacement;

    //Red Builds
    private PackedScene RCity = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Red Placeables/Red_City.tscn");
    private PackedScene RSettlement = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Red Placeables/Red_Settlement.tscn");
    private PackedScene RRoad = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Red Placeables/Red_Road.tscn");

    //Blue Builds
    private PackedScene BCity = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Blue Placeables/Blue_City.tscn");
    private PackedScene BSettlement = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Blue Placeables/Blue_Settlement.tscn");
    private PackedScene BRoad = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Blue Placeables/Blue_Road.tscn");

    //Green Builds
    private PackedScene GCity = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Green Placeables/Green_City.tscn");
    private PackedScene GSettlement = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Green Placeables/Green_Settlement.tscn");
    private PackedScene GRoad = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Green Placeables/Green_Road.tscn");


    //Yellow builds
    private PackedScene YCity = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Yellow Placeables/Yellow_City.tscn");
    private PackedScene YSettlement = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Yellow Placeables/Yellow_Settlement.tscn");
    private PackedScene YRoad = (PackedScene)GD.Load("res://All Roads, Cities and Numbers/Yellow Placeables/Yellow_Road.tscn");

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    //This method will create the nodes/placement instances and add them to the list
    public void build()
    {
        if (MoveCheck())
        {
            TM = GetNode<Node>("../TurnManager");
            int currentPlayer;
            //currentPlayer = TM.currentTurn;

            Placeable NewBuild = null;


            /*switch (currentPlayer)
            {
                case 1://Red player's turn
                    switch(SelectedBuild)
                    {
                        case "road": 
                            NewBuild = (Placeable) RRoad.Instance(); 
                            break;
                        case "settlement":
                            NewBuild = (Placeable) RSettlement.Instance();
                            break;
                        case "city":
                            NewBuild = (Placeable)RCity.Instance(); 
                            break;
                    }
                    break;
                case 2://Blue player's turn
                    switch (SelectedBuild)
                    {
                        case "road":
                            NewBuild = (Placeable) BRoad.Instance();
                            break;
                        case "settlement":
                            NewBuild = (Placeable)BSettlement.Instance();
                            break;
                        case "city":
                            NewBuild = (Placeable)BCity.Instance();
                            break;
                    }
                    break;
                case 3: //Green player's turn
                    switch (SelectedBuild)
                    {
                        case "road":
                            NewBuild = (Placeable) GRoad.Instance();
                            break;
                        case "settlement": 
                            NewBuild = (Placeable)GSettlement.Instance();
                            break;
                        case "city": 
                            NewBuild = (Placeable)GCity.Instance();
                            break;
                    }
                    break;
                case 4: //Yellow player's turn
                    switch (SelectedBuild)
                    {
                        case "road":
                            NewBuild = (Placeable) YRoad.Instance();
                            break;
                        case "settlement": 
                            NewBuild = (Placeable)YSettlement.Instance();
                            break;
                        case "city":
                            NewBuild = (Placeable)YCity.Instance();
                            break;
                    }
                    break;
            }
            */
            
            //make placeable and add it to the list
            if(NewBuild != null)
            {
                AddChild(NewBuild);
                AllBuildings.Add(NewBuild);
                //NewBuild.Translate();
            }
            /*Inspiration for creating new nodes:
             * Spatial SheepTile = (Spatial) TileSheep.Instance();
                AddChild(SheepTile);
                SheepTile.Translate(TileCoordsV3);

            NewBuild has access to C# added methods and methods for normal nodes
             */
        }
        else
        {
            //show a popup that this move is invalid?
        }
        SelectedBuild = null;
    }

    //This method will check whether the move is legal or not and return whether it is.
    private bool MoveCheck()
    {
        if (SelectedBuild != null)
        {
            return true;
        }
        return false;
    }

}
