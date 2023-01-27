using Godot;
using System;
using System.Collections.Generic;
using static TileClickManager;

//In this class, all things related to building are added, from creating a new placeable to saving all current placeables
public class Builder_Node : Node
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
    private DiceValueManager DVM;

    //spot to save the HexatileBoard
    private Hex_GridCS Board;

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

    private TileClickManager Signal;

    // Called when the node enters the scene tree for the first time
    public override void _Ready()
    {
        //only need to be called once to access
        DVM = GetNode<DiceValueManager>("../DiceValueManager");
        Board = GetNode<Hex_GridCS>("../Hex_GridCS");

        Signal = GetNode<TileClickManager>("/root/TileClickManager");
        Signal.Connect("NewBuilding", this, "Build");
    }

    //This method will create the nodes/placement instances and brings all the relevant functions together to make that happen
    public void Build(Vector3 Plaats, bool IsCorner, Vector3 Rotation)
    {
        CurrentPlayer = (int)DVM.Get("CurrentTurn");

        //Local variables to save the relevant player-specific list, whether for roads or buildings, with standard value
        List<Placeable> RelevantList = RedBuilds;
        List<Road> RoadList = RedWays;

        switch (CurrentPlayer)
        {
            case 1:
                RoadList = RedWays;
                RelevantList = RedBuilds;
                break;
            case 2:
                RoadList = BlueWays;
                RelevantList = BlueBuilds;
                break;
            case 3:
                RoadList = GreenWays;
                RelevantList = GreenBuilds;
                break;
            case 4:
                RoadList = YellowWays;
                RelevantList = YellowBuilds;
                break;
        }
        
        //A variable that checks whether anything was actually instanced. Used for victory point management
        bool ActuallyPlaced= false;

        //make placeable and add it to the list
        if (SelectedBuild == "city" && IsCorner)
        {       
            foreach (Placeable Placed in RelevantList)
            {       
                if (Placed.Translation == Plaats)
                {
                    Placed.Hide();
                    AllBuildings.Remove(Placed);

                    Placeable NewBuild = CreateBuidingInstance();
                    NewBuild.Translate(Plaats);
                    
                    AddChild(NewBuild);
                    AllBuildings.Add(NewBuild);
                    RelevantList.Add(NewBuild);
                    ActuallyPlaced= true;
                }
                
            }
        }
        else if(SelectedBuild == "settlement" && IsCorner)
        {
            if (AllowedSettlement(Plaats))
            {
                Placeable NewBuild = CreateBuidingInstance();
                NewBuild.Translate(Plaats);
                
                AddChild(NewBuild);
                AllBuildings.Add(NewBuild);
                RelevantList.Add(NewBuild);
                ActuallyPlaced= true;
                NewBuild.Translate(new Vector3(0, 0.334f, 0));
            }
        }
        else if(SelectedBuild == "road" && !IsCorner)
        {
            if (AllowedRoad(Plaats, RoadList, RelevantList))
            {
                Road NewBuild = CreateRoadInstance();
                NewBuild.Translate(Plaats);

                AddChild(NewBuild);
                AllWays.Add(NewBuild);
                RelevantList.Add(NewBuild);
                NewBuild.Translate(new Vector3(0, 0.1667f, 0));
                NewBuild.Rotation = Rotation;
                GD.Print($"{NewBuild.Rotation} {Rotation}");

            }
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

    //Takes player and values and creates and instances the correct placeable/building
    private Placeable CreateBuidingInstance()
    {
        Placeable Result = null;

        switch (CurrentPlayer)
        {
            case 1://Red player's turn
                switch (SelectedBuild)
                {
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

    //Takes player and values and creates an instance of a road
    private Road CreateRoadInstance()
    {
        Road Result = null;

        switch (CurrentPlayer)
        {
            case 1://Red player's turn
                Result = (Road)RRoad.Instance();
                currentColour = "red";
                break;
            case 2://Blue player's turn
                Result = (Road)BRoad.Instance();
                currentColour = "blue";
                break;
            case 3: //Green player's turn
                Result = (Road)GRoad.Instance();
                currentColour = "green";
                break;
            case 4: //Yellow player's turn
                Result = (Road)YRoad.Instance();
                currentColour = "yellow";
                break;
        }
        return Result;
    }

    //Will execute all checks related to placing a settlement and if there is not anther settlement too close
    private bool AllowedSettlement(Vector3 Check)
    {
        float size = Board.TileSize;//TileSize describes the distance between two opposite sides of the hexagons

        foreach (Placeable Other in AllBuildings)
        {
            if(Check.DistanceTo(Other.Translation) < 0.8 * size)
            {
                return false;
            }
        }
        //no other building is too close
        return true;
    }

    //Will execute all checks related to placing a road and if there isn't a road on the same spot
    private bool AllowedRoad(Vector3 Check, List<Road> OwnedRoads, List<Placeable> OwnedBuildings)
    {
        float size = Board.TileSize;//TileSize describes the distance between two opposite sides of the hexagons

        int TurnCount = (int)DVM.Get("TurnCount");

        foreach(Road Another in AllWays)
        {
            if(Check.DistanceTo(Another.Translation) < 0.25 * size)//the roads are on the same edge of a tile, practically in the same spot
            {
                return false;
            }
        }
        //No road in the same spot
        foreach(Road OwnedRoad in OwnedRoads)
        {
            if(Check.DistanceTo(OwnedRoad.Translation) < 0.7 * size && TurnCount>2)//there is a road that is only one tile edge away, or 'directly connects'
            {
                return true;
            }
        }

        foreach(Placeable OwnedBuilding in OwnedBuildings)
        {
            if (Check.DistanceTo(OwnedBuilding.Translation) < 0.7 * size)//there is a building that is only one tile edge away, or 'directly connects'
            {
                return true;
            }
        }
        //there are no roads of this player that 'directly connect'; they're all too far away
        return false;
    }
}
