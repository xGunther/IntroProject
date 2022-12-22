using Godot;
using System;

public class turnManager : Node
{
    public Node[] players;
    public int playerCount = 3;
    private int currentPlayer = 0;

    public override void _Ready()
    { 
        players = GetChildren();

        // Get a reference to the LineEdit nodes in the previous scene
    }

    public int currentTurn { get; set; } 

    public void nextTurn(int playerCount)
    {
        currentTurn++;

        if (currentTurn > playerCount)
        {
            currentTurn = 0;
        }
    }

        public Node GetCurrentPlayer()
    {
        // Return the current player's node
        return players[currentPlayer];
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
