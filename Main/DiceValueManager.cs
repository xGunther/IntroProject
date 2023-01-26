using Godot;
using System;


public class DiceValueManager : Node
{   public static bool ButtonPressedOrNot = false;
    public static int currentTurn = 1; 
    public static int playerCount = 4;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//This function checks every possible die sum and checks the corresponding tiles with that particular number on the board for settlements or cities

    public static void DieValue()
    {
        if (Throw_Dice_Button.dieSideSum == 2)
        {   //functions that checks the settlements or cities that are connected to the this specific sheep tile
            
            GD.Print("The number 2 has been thrown.");
        }
        
        else if (Throw_Dice_Button.dieSideSum == 3)
        {
            //functions that checks the settlements or cities that are connected to the tile
            //Gold and Wood tile
            GD.Print("The number 3 has been thrown.");
        }

        else if (Throw_Dice_Button.dieSideSum == 4)
        {
            //functions that checks the settlements or cities that are connected to the tile
            //Sheep and Grain tile
            GD.Print("The number 4 has been thrown.");
        }

        else if (Throw_Dice_Button.dieSideSum == 5)
        {
            //functions that checks the settlements or cities that are connected to the tile
            //Stone and Sheep tile
            GD.Print("The number 5 has been thrown.");
        }

        else if (Throw_Dice_Button.dieSideSum == 6)
        {
            //functions that checks the settlements or cities that are connected to the tile
            //Stone and Grain tile
            GD.Print("The number 6 has been thrown.");
        }

        else if (Throw_Dice_Button.dieSideSum == 8)
        {
            //functions that checks the settlements or cities that are connected to the tile
            //Gold and Wood tile
            GD.Print("The number 8 has been thrown.");
        }

        else if (Throw_Dice_Button.dieSideSum == 9)
        {
            //functions that checks the settlements or cities that are connected to the tile
            //Wood and Grain Tile
            GD.Print("The number 9 has been thrown.");
        }

        else if (Throw_Dice_Button.dieSideSum == 10)
        {
            //functions that checks the settlements or cities that are connected to the tile
            //Stone and Gold tile
            GD.Print("The number 10 has been thrown.");
        }

        else if (Throw_Dice_Button.dieSideSum == 11)
        {
            //functions that checks the settlements or cities that are connected to the tile
            //Wood and Sheep tile
            GD.Print("The number 11 has been thrown.");
        }

        else if (Throw_Dice_Button.dieSideSum == 12)
        {
            //functions that checks the settlements or cities that are connected to the tile
            //Grain tile
            GD.Print("The number 12 has been thrown.");
        }

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
