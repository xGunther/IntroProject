using Godot;
using System;
public class TurnManager : Node {
    // Keep track of the current player's turn
    private int currentTurn = 1;
	//Note the amount of players
	private int playerCount = 4;
	private Label Players_Turn;
	private Button endTurnButton;
		public override void _Ready()
	{ 
		Players_Turn = GetNode("Label_Turn") as Label;
		endTurnButton = GetNode<Button>("Button");
		endTurnButton.Connect("pressed", this, "EndTurn");
	}

    private void EndTurn() {
        // Update the current turn
        currentTurn++;

        // Check if the currentTurn exceeds the player count, if it does go back to the first player
        if (currentTurn > playerCount) 
		{
            currentTurn = 1;
        }

		Players_Turn.Text = "Player " + currentTurn + "'s Turn";
        // Notify players that it's a new turn
        GetTree().CallGroup("players", "NewTurn", currentTurn);
    }
}
