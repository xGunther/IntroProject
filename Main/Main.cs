using Godot;
using System;

public class Main : Spatial
{   
    public Node[] players;
    public int playerCount = 3;

    public override void _Ready()
    { 
        var turnManager = new turnManager();
        turnManager.currentTurn = 0;
        Connect("pressed", this, "endTurn");
        
        // Get a reference to the LineEdit nodes in the previous scene
        var newGameMenuScene = GD.Load<PackedScene>("res://Menu Scenes/New_Game_Menu.tscn");
        LineEdit PlayerName1 = newGameMenuScene.Instance().GetNode<LineEdit>("LineEdit1"); 
        LineEdit PlayerName2 = newGameMenuScene.Instance().GetNode<LineEdit>("LineEdit2"); 
        LineEdit PlayerName3 = newGameMenuScene.Instance().GetNode<LineEdit>("LineEdit3"); 
        LineEdit PlayerName4 = newGameMenuScene.Instance().GetNode<LineEdit>("LineEdit4"); 

        
       
        //Get a reference to the Label nodes
        Label Player_Name1 = GetNode<Label>("UI_Rect_Players_4/Player_Name1");
        Label Player_Name2 = GetNode<Label>("UI_Rect_Players_4/Player_Name2");
        Label Player_Name3 = GetNode<Label>("UI_Rect_Players_4/Player_Name3");
        Label Player_Name4 = GetNode<Label>("UI_Rect_Players_4/Player_Name4");
        Label turnLabel = GetNode<Label>("Players_Turn"); 

        // Set the label's text to the player's name
        PlayerName1.Text = Player_Name1.Text;
        PlayerName2.Text = Player_Name2.Text;  
        PlayerName3.Text = Player_Name3.Text;
        PlayerName4.Text = Player_Name4.Text;
    }
public class turnManager
{
    public int currentTurn { get; set; } 

    public void nextTurn(int playerCount)
    {
        currentTurn++;

        if (currentTurn > playerCount)
        {
            currentTurn = 0;
        }
    }

    public void endTurn(EventArgs ea, object o)
    {
            nextTurn(3);
            {
              if (currentTurn == 0) 
              {
                Players_Turn.Text = "it's ${player 1}'s turn";
              }
              else if(currentTurn == 1 )
              {
                Players_Turn.Text = "it's ${player 1}'s turn";
              }

              else if(currentTurn == 2)
              {
                Players_Turn.Text = "it's ${player 1}'s turn";
              }
              else if(currentTurn == 3)
              {
                Players_Turn.Text = "it's ${player 1}'s turn";
              }
              // Get the current player's node
        var currentPlayer = turnManager.GetCurrentPlayer();

        // Get the current player's name
        var playerName = currentPlayer.Get("name") as string;

        // Set the turn label's text to the current player's name
        turnLabel.Text = "it's " + playerName +"'s turn";
            
          }


    
    }

  }
}