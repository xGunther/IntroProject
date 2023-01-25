using Godot;
using System;
using System.Collections.Generic;

//In this class, all things related to building are added, from creating a new placeable to saving all current placeables
public class BuilderNode : Node
{
    //list to save all made placeables
    public List<Placeable> AllBuildings= new List<Placeable>();
    public List<Road> AllWays= new List<Road>();

    //Lists for all players to quickly access their buildings
    public List<Placeable> RedBuilds= new List<Placeable>();
    public List<Placeable> BlueBuilds= new List<Placeable>();
    public List<Placeable> GreenBuilds= new List<Placeable>();
    public List<Placeable> YellowBuilds= new List<Placeable>();

    //Lists for all players with their roads
    public List<Road> RedWays= new List<Road>();
    public List<Road> BlueWays= new List<Road>();
    public List<Road> GreenWays= new List<Road>();
    public List<Road> YellowWays= new List<Road>();

    //this variable saves what will be built next. If nothing is being built, value should be null
    public string SelectedBuild;

    //spot to save the TurnManager
    Node TM;

    //saves which player is currently playing, with standard value, in case real value can't be retrieved.
    private int CurrentPlayer = 1;
    private string currentColour = "red";

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

    // Called when the node enters the scene tree for the first time
    public override void _Ready()
    {
        TM = GetNode<Node>("../TurnManager");//only need to be called once to access
    }

    //This method will create the nodes/placement instances and brings all the relevant functions together to make that happen
    public void build(Vector3 Plaats)
    {
        CurrentPlayer = (int)TM.Get("currentTurn");

        //A local variable to save the relevant player-specific list, with standard value
        List<Placeable> RelevantList= RedBuilds;

        switch (CurrentPlayer)
        {
            case 1:
                RelevantList = RedBuilds;
                break;
            case 2:
                RelevantList = BlueBuilds;
                break;
            case 3:
                RelevantList = GreenBuilds;
                break;
            case 4:
                RelevantList = YellowBuilds;
                break;
        }

        //A variable that checks whether anything was actually instanced. Used for victory point management
        bool ActuallyPlaced= false;

        //make placeable and add it to the list
        if (SelectedBuild == "city")
        {       
            foreach (Placeable Placed in RelevantList)
            {       
                if (Placed.Translation == Plaats)
                {
                    Placed.Hide();
                    AllBuildings.Remove(Placed);

                    Placeable NewBuild = CreateInstance();
                    NewBuild.Translate(Plaats);
                    
                    AddChild(NewBuild);
                    AllBuildings.Add(NewBuild);
                    RelevantList.Add(NewBuild);
                    ActuallyPlaced= true;
                }
                
            }
        }
        else if(SelectedBuild == "settlement")
        {
            if (AllowedSettlement(Plaats))
            {
                Placeable NewBuild = CreateInstance();
                NewBuild.Translate(Plaats);
                
                AddChild(NewBuild);
                AllBuildings.Add(NewBuild);
                RelevantList.Add(NewBuild);
                ActuallyPlaced= true;
            }
        }
        else if(SelectedBuild == "road")
        {

        }
            
        if ((SelectedBuild == "settlement" || SelectedBuild == "city") && ActuallyPlaced)
        {       
            switch (CurrentPlayer)
            {
                    
                case 1: RedScore++; break;
                case 2: BlueScore++; break;
                case 3: GreenScore++; break;
                case 4: YellowScore++; break;
            }
        }   
        
        SelectedBuild = null;
    }

    //Takes player and values and creates and instances the correct placeable
    private Placeable CreateInstance()
    {
        Placeable Result = null;

        switch (CurrentPlayer)
        {
            case 1://Red player's turn
                switch (SelectedBuild)
                {
                    case "road":
                        Result = (Placeable)RRoad.Instance();
                        break;
                    case "settlement":
                        Result = (Placeable)RSettlement.Instance();
                        break;
                    case "city":
                        Result = (Placeable)RCity.Instance();
                        break;
                }
                currentColour = "red";
                break;
            case 2://Blue player's turn
                switch (SelectedBuild)
                {
                    case "road":
                        Result = (Placeable)BRoad.Instance();
                        break;
                    case "settlement":
                        Result = (Placeable)BSettlement.Instance();
                        break;
                    case "city":
                        Result = (Placeable)BCity.Instance();
                        break;
                }
                currentColour = "blue";
                break;
            case 3: //Green player's turn
                switch (SelectedBuild)
                {
                    case "road":
                        Result = (Placeable)GRoad.Instance();
                        break;
                    case "settlement":
                        Result = (Placeable)GSettlement.Instance();
                        break;
                    case "city":
                        Result = (Placeable)GCity.Instance();
                        break;
                }
                currentColour = "green";
                break;
            case 4: //Yellow player's turn
                switch (SelectedBuild)
                {
                    case "road":
                        Result = (Placeable)YRoad.Instance();
                        break;
                    case "settlement":
                        Result = (Placeable)YSettlement.Instance();
                        break;
                    case "city":
                        Result = (Placeable)YCity.Instance();
                        break;
                }
                currentColour = "yellow";
                break;
        }
        return Result;
    }

    //Will execute all checks related to placing a settlement and if there is not anther settlement too close
    private bool AllowedSettlement(Vector3 Check)
    {
        Hex_GridCS Board = GetNode<Hex_GridCS>("../Hex_GridCS");
        float size = Board.TileSize;//TileSize describes the distance between two opposite sides of the hexagons
        foreach (Placeable other in AllBuildings)
        {
            if(Check.DistanceTo(other.Translation) < 0.8 * size)
            {
                return false;
            }
        }
        //no other building is too close
        return true;
    }
}
