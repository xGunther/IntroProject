using Godot;
using System.Collections.Generic;
using System;
using System.Data;

public class DiceValueManager : Node
{   public static bool ButtonPressedOrNot = false;
    public static int currentTurn = 1; 
    public static int playerCount = 4;
    public static Hex_GridCS Board;
    public static Builder_Node Builder;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    public void UpdateVars()
    {
        Board = GetNode<Hex_GridCS>("../Hex_GridCS");
        Builder = GetNode<Builder_Node>("../Builder_Node");
    }

//This function checks every possible die sum and checks the corresponding tiles with that particular number on the board for settlements or cities

    public static void DieValue()
    {
        int DieNumber = Throw_Dice_Button.dieSideSum;
        GD.Print($"{DieNumber} thrown");

        List<Placeable> Placeables = new List<Placeable>();

        
        foreach(Tile Tile in Board.TilesDictionary[DieNumber])
        {
            Vector3 Location = Tile.TileNode.GlobalTranslation;
            Placeables.AddRange(GetPlaceables(Location));
        }
    }

    private static List<Placeable> GetPlaceables(Vector3 MiddleOfTile)
    {
        List<Placeable> Placeables = new List<Placeable>();
        foreach (Placeable Building in Builder.AllBuildings)
        {
            Vector3 BuildingLocation = Building.GlobalTranslation;
            if (BuildingLocation.DistanceTo(MiddleOfTile) < Board.TileSize);
            {
                Placeables.Add(Building);
            }
        }
        return Placeables;
    }
    public void AddResources(int PlayerNumber)
    {

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
                currentTurn += 1;
                if (currentTurn > playerCount)
                {
                  currentTurn = 1;  
                } 
                ButtonPressedOrNot = false;
	             
            } 

    }	

}
