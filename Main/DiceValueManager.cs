using Godot;
using System.Collections.Generic;
using System;
using System.Data;

public class DiceValueManager : Node
{   public static bool ButtonPressedOrNot = false;
    public static int CurrentTurn = 1;
    public static int TurnCount = 1;
    public static int playerCount = 4;
    public static Hex_GridCS Board;
    public static BuilderNode Builder;
    public static Node InventoryManager;
    public static List<Label> ResourceLabels = new List<Label>();
    public static Button DiceButton;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        InventoryManager = GetNode("../InventoryManager");
        Board = GetNode<Hex_GridCS>("../Hex_GridCS");
        Builder = GetNode<BuilderNode>("../BuilderNode");
        DiceButton = GetNode<Button>("../Throw_Dice_Button");
    }

//This function checks every possible die sum and checks the corresponding tiles with that particular number on the board for settlements or cities

    public static void DieValue()
    {
        int DieNumber = Throw_Dice_Button.dieSideSum;

        // Goes over each Tile that has the given die number
        foreach(Tile Tile in Board.TilesDictionary[DieNumber])
        {
            Vector3 Location = Tile.TileNode.GlobalTranslation;
            // Goes over each Building that is on the corners of the tile
            foreach (Placeable Placeable in GetPlaceables(Location))
            {
                if (Placeable.GetPlayer() == "red")
                { AddResources(Tile.ResourceType, 1, 1);}
                else if (Placeable.GetPlayer() == "blue")
                { AddResources(Tile.ResourceType, 2, 1); }
                else if (Placeable.GetPlayer() == "green")
                { AddResources(Tile.ResourceType, 3, 1); }
                else if (Placeable.GetPlayer() == "yellow")
                { AddResources(Tile.ResourceType, 4, 1); }

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

    //This function firstly checks if the die have been thrown, if this is not the case it will print out a warning in the console
    //If the button has been pressed it will go to the next turn and resets the boolean value of the button press
    public void EndTurn()
    {
        if (ButtonPressedOrNot == false)
        {
            GD.Print("You can't end the turn, the die have not been thrown yet!!!");
        }
		
	        else if(ButtonPressedOrNot == true)
            {
                CurrentTurn += 1;
                if (CurrentTurn > playerCount)
                {
                CurrentTurn = 1;
                TurnCount++;
                } 
                ButtonPressedOrNot = false;
	             
            }
        UpdateResources();
        DiceButton.Show();
    }

}
