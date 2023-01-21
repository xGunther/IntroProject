using Godot;
using System;
using System.Collections.Generic;

//In this class, all things related to building are added, from creating a new placeable to saving all current placeables
public class BuilderNode : Node
{
    //list to save all made placeables
    public List<Placeable> AllBuildings = new List<Placeable>();

    //Lists for all players to quickly access their buildings
    public List<Placeable> RedBuilds= new List<Placeable>();
    public List<Placeable> BlueBuilds= new List<Placeable>();
    public List<Placeable> GreenBuilds= new List<Placeable>();
    public List<Placeable> YellowBuilds= new List<Placeable>();

    //this variable saves what will be built next. If nothing is being built, value should be null
    public string SelectedBuild;

    //spot to save the TurnManager
    Node TM;

    //saves which player is currently playing, with standard value, in case real value can't be retrieved.
    private int currentPlayer = 1;
    private string currentColour = "red";

    //The eventual place of the coordinates for new 'buildings'
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

    //Scorekeeping for the game
    public int RedScore = 0;
    public int BlueScore = 0;
    public int GreenScore = 0;
    public int YellowScore = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    //This method will create the nodes/placement instances and add them to the list
    public void build(Vector3 plaats)
    {
        TM = GetNode<Node>("../TurnManager");
        //currentPlayer = TM.currentTurn;

        Placeable NewBuild = null;

        //A local variable to save the relevant player-specific list, with standard value
        List<Placeable> RelevantList= RedBuilds;

        switch (currentPlayer)
        {
            case 1://Red player's turn
                switch (SelectedBuild)
                {
                    case "road":
                        NewBuild = (Placeable)RRoad.Instance();
                        break;
                    case "settlement":
                        NewBuild = (Placeable)RSettlement.Instance();
                        break;
                    case "city":
                        NewBuild = (Placeable)RCity.Instance();
                        break;
                }
                currentColour = "red";
                RelevantList = RedBuilds;
                break;
            case 2://Blue player's turn
                switch (SelectedBuild)
                {
                    case "road":
                        NewBuild = (Placeable)BRoad.Instance();
                        break;
                    case "settlement":
                        NewBuild = (Placeable)BSettlement.Instance();
                        break;
                    case "city":
                        NewBuild = (Placeable)BCity.Instance();
                        break;
                }
                currentColour = "blue";
                RelevantList = BlueBuilds;
                break;
            case 3: //Green player's turn
                switch (SelectedBuild)
                {
                    case "road":
                        NewBuild = (Placeable)GRoad.Instance();
                        break;
                    case "settlement":
                        NewBuild = (Placeable)GSettlement.Instance();
                        break;
                    case "city":
                        NewBuild = (Placeable)GCity.Instance();
                        break;
                }
                currentColour = "green";
                RelevantList= GreenBuilds;
                break;
            case 4: //Yellow player's turn
                switch (SelectedBuild)
                {
                    case "road":
                        NewBuild = (Placeable)YRoad.Instance();
                        break;
                    case "settlement":
                        NewBuild = (Placeable)YSettlement.Instance();
                        break;
                    case "city":
                        NewBuild = (Placeable)YCity.Instance();
                        break;
                }
                currentColour = "yellow";
                RelevantList = YellowBuilds;
                break;
        }

        //make placeable and add it to the list
        if (NewBuild != null)
        {
            if (SelectedBuild == "city")
            {
                bool mag = false;

                foreach (Placeable placed in AllBuildings)
                {
                    if (placed.getPlayer() == this.currentColour)
                    {
                        if (placed.Translation == plaats)
                        {
                            mag = true;
                        }

                    }
                }

            }
            else
            {
                AddChild(NewBuild);
                AllBuildings.Add(NewBuild);
                NewBuild.Translate(plaats);
                RelevantList.Add(NewBuild);
            }

            if (SelectedBuild == "settlement" || SelectedBuild == "city")
            {
                switch (currentPlayer)
                {
                    case 1: RedScore++; break;
                    case 2: BlueScore++; break;
                    case 3: GreenScore++; break;
                    case 4: YellowScore++; break;
                }
            }
            //add tiles to builds
        }

        SelectedBuild = null;
    }

}
