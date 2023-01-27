using Godot;
using System.Collections.Generic;
using System;
using System.Data;

public class DiceValueManager : Node
{   public static bool ButtonPressedOrNot = false;
    public static int CurrentTurn = 1;
    public static int TurnCount = 1;
    public static int PlayerCount = 4;
    public static Hex_GridCS Board;
    public static BuilderNode Builder;
    public static Node InventoryManager;
    public static List<Label> ResourceLabels = new List<Label>();
    public static Button DiceButton;
    public static Label RedScoreLabel;
    public static Label BlueScoreLabel;
    public static Label GreenScoreLabel;
    public static Label YellowScoreLabel;
    public static Panel EndTurnWarningPanel;
    public static Timer WarningTimer;
    public static Panel VictoryScreen;
    public static Label WinningName;
    public static Label PlayerName1;
    public static Label PlayerName2;
    public static Label PlayerName3;
    public static Label PlayerName4;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    { //gets all the nodes needed from GDscript or other scripts
        InventoryManager = GetNode("../InventoryManager");
        Board = GetNode<Hex_GridCS>("../Hex_GridCS");
        Builder = GetNode<BuilderNode>("../BuilderNode");
        DiceButton = GetNode<Button>("../Throw_Dice_Button");
        RedScoreLabel = GetNode<Label>("../UI_Rect_Players_4/Player_Name1/PlayerScore1");
        BlueScoreLabel = GetNode<Label>("../UI_Rect_Players_4/Player_Name2/PlayerScore2");
        GreenScoreLabel = GetNode<Label>("../UI_Rect_Players_4/Player_Name3/PlayerScore3");
        YellowScoreLabel = GetNode<Label>("../UI_Rect_Players_4/Player_Name4/PlayerScore4");
        EndTurnWarningPanel = GetNode<Panel>("../WarningLabel");
        WarningTimer = GetNode<Timer>("../WarningLabel/WarningTimer");
        VictoryScreen = GetNode<Panel>("../VictoryRect");
        WinningName = GetNode<Label>("../VictoryRect/WinningName");
        PlayerName1 = GetNode<Label>("../UI_Rect_Players_4/Player_Name1");
        PlayerName2 = GetNode<Label>("../UI_Rect_Players_4/Player_Name2");
        PlayerName3 = GetNode<Label>("../UI_Rect_Players_4/Player_Name3");
        PlayerName4 = GetNode<Label>("../UI_Rect_Players_4/Player_Name4");
    }

//Updates the scores according to the amount of cities or settlements for each player player
    public static void UpdateScoreLabels()
    {
        RedScoreLabel.Text = ": " + BuilderNode.RedScore.ToString();
        BlueScoreLabel.Text = ": " + BuilderNode.BlueScore.ToString();
        GreenScoreLabel.Text = ": " + BuilderNode.GreenScore.ToString();
        YellowScoreLabel.Text = ": " + BuilderNode.YellowScore.ToString();
    }
    //Checks if a player has reached the amount of points to win
    public static void CheckVictoryScreen()
    {
        if(BuilderNode.RedScore >= 10)
        {
            WinningName.Text = PlayerName1.Text + " has won!!!";
            VictoryScreen.Visible = true;
            EndTurnWarningPanel.Visible = false;
        }
        else if(BuilderNode.BlueScore >= 10)
        {
            WinningName.Text = PlayerName2.Text + " has won!!!";
            VictoryScreen.Visible = true;
            EndTurnWarningPanel.Visible = false;
        }
        else if(BuilderNode.GreenScore >= 10)
        {
            WinningName.Text = PlayerName3.Text + " has won!!!";
            VictoryScreen.Visible = true;
            EndTurnWarningPanel.Visible = false;
        }
        else if(BuilderNode.YellowScore >= 10)
        {
            WinningName.Text = PlayerName4.Text + " has won!!!";
            VictoryScreen.Visible = true;
            EndTurnWarningPanel.Visible = false;
        }

    }
    //Shows a warning message if you have not yet clicked the dice and want to end a turn
    public static void ShowWarningMessage()
    {
        EndTurnWarningPanel.Visible = true;
        WarningTimer.Start(4.0f);
        WarningTimerTimeOut();
    }
    //If the warning timeout is 0 the panel is removed
    public static void WarningTimerTimeOut()
    {   
        if(WarningTimer.TimeLeft == 0)
        {
            EndTurnWarningPanel.Visible = false;
        }
    }

//This function checks every possible Die sum and checks the corresponding tiles with that particular number on the board for settlements or cities
    public static void DieValue()
    {
        int DieNumber = Throw_Dice_Button.DieSideSum;

        // Goes over each Tile that has the given Die number
        foreach(Tile Tile in Board.TilesDictionary[DieNumber])
        {
            Vector3 Location = Tile.TileNode.GlobalTranslation;
            // Goes over each Building that is on the corners of the tile
            GetPlayerResources(Tile.ResourceType, Location);
        }
    }

    private static void GetPlayerResources(String ResourceType, Vector3 Location)
    {
        foreach (Placeable Placeable in GetPlaceables(Location))
        {
            if (Placeable.GetPlayer() == "red")
            { AddResources(ResourceType, 1, 1); }
            else if (Placeable.GetPlayer() == "blue")
            { AddResources(ResourceType, 2, 1); }
            else if (Placeable.GetPlayer() == "green")
            { AddResources(ResourceType, 3, 1); }
            else if (Placeable.GetPlayer() == "yellow")
            { AddResources(ResourceType, 4, 1); }

        }
    }

    public static void EarlyResources()
    {
        foreach (KeyValuePair<int, List<Tile>> kvp in Board.TilesDictionary)
        {
            foreach (Tile Tile in kvp.Value)
            {
                GetPlayerResources(Tile.ResourceType, Tile.TileNode.GlobalTranslation);
            }
        }
    }
    // Function to get each Placeable that is within distance of MiddleOfTile
    private static List<Placeable> GetPlaceables(Vector3 MiddleOfTile)
    {
        List<Placeable> Placeables = new List<Placeable>();
        // Checks every Building vector
        foreach (Placeable Building in Builder.AllBuildings)
        {
            Vector3 BuildingLocation = Building.GlobalTranslation;
            if (BuildingLocation.DistanceTo(MiddleOfTile) < 0.8*Board.TileSize) // Added if within range
            {
                Placeables.Add(Building);
            }
        }
        return Placeables;
    }
    
    public static void AddResources(string Resource, int PlayerNumber, int Amount)
    {
        GD.Print($"Gave {Resource} to {PlayerNumber}");
        if (Resource != "Sand")
        { InventoryManager.Call($"AddResources", PlayerNumber, Resource, Amount); }

        UpdateResources();
    }

    public static void UpdateResources()
    {
        /*string[] ResourceNames = new string[] {"Gold", "Sheep", "Stone", "Wood", "Grain"};
        for (int ResourceIndex = 0; ResourceIndex < ResourceNames.Length; ResourceIndex++)
        {
            Label ResourceLabel = ResourceLabels[ResourceIndex];
            ResourceLabel.Text = (string)InventoryManager.Get("PlayerInventory[PlayerNumber][resourceIndex]");
        }*/

        InventoryManager.Call("UpdateLabels");
    }

    //This function firstly checks if the Die have been thrown, if this is not the case it will print out a warning in the console
    //If the button has been pressed it will go to the next turn and resets the boolean value of the button press
    public void EndTurn()
    {
        if (ButtonPressedOrNot == false && TurnCount > 2)
        {
            ShowWarningMessage();
        }
		
	    else
        {
            CurrentTurn += 1;
            if (CurrentTurn > PlayerCount)
            {
                CurrentTurn = 1;
                if (TurnCount <= 2)
                { EarlyResources(); }
                TurnCount++;
            } 
            ButtonPressedOrNot = false;
	             
        }
        UpdateResources();
        DiceButton.Show();
        CheckVictoryScreen();
        UpdateScoreLabels();
    }

}
