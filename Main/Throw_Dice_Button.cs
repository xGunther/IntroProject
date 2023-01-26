using Godot;
using System;

public class Throw_Dice_Button : Button
{
    public int dieSide1 = 1;
    public int dieSide2 = 1;
    public static int dieSideSum = 2;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        float DieWaitTime = 4; // AMOUNT OF TIME TO WAIT BEFORE THE DICE DISAPPEAR

        Timer dieTimer = GetNode<Timer>("Delay");
        dieTimer.WaitTime = DieWaitTime;
    }

    public void ButtonPressed()
    {
        Timer dieTimer = GetNode<Timer>("Delay");

        // Only throws new die if the timer is on zero.
        // Currently missing an extra check to determine whether they are allowed to throw them game-wise
        if (dieTimer.TimeLeft == 0)
        {
            Spatial Grid = GetNode<Spatial>("../Die_Grid");
            Grid.Show();
            dieTimer.Start();
            DiceValueManager.ButtonPressedOrNot = true;
        }

    }

    public int GetDieSide(RigidBody die)
    {


        // transform[1] == 0 -1 0 => 1
        // transform[0] == 0 -1 0 => 2
        // transform[2] == 0 -1 0 => 3
        // transform[2] == 0 1 0 => 4
        // transform[0] == 0 1 0 => 5
        // transform[1] == 0 1 0 => 6
        float AbsZero = Math.Abs(die.Transform[0].y);
        float AbsOne = Math.Abs(die.Transform[1].y);
        float AbsTwo = Math.Abs(die.Transform[2].y);


        // Case where Transform[0].y is the largest value (2 and 5)
        if (AbsZero > AbsOne && AbsZero > AbsTwo)
        {
            if (die.Transform[0].y > 0)
                return 5;
            else
                return 2;
        }

        // Case where Transform[1].y is the largest value (1 and 6)
        else if (AbsOne > AbsZero && AbsOne > AbsTwo)
        {
            if (die.Transform[1].y > 0)
                return 6;
            else
                return 1;
        }

        // Case where Transform[2].y is the largest value (3 and 4)
        else
        {
            if (die.Transform[2].y > 0)
                return 4;
            else
                return 3;
        }


    }

    public void UpdateDie()
    {
        Spatial Grid = GetNode<Spatial>("../Die_Grid");

        // Checks if the dice are visible before throwing them 
        if (Grid.Visible)
        {
            Sprite dieSprite;

            RigidBody die1 = GetNode<RigidBody>("../Die_Grid/die");
            RigidBody die2 = GetNode<RigidBody>("../Die_Grid/die2");
            dieSide1 = GetDieSide(die1);
            dieSide2 = GetDieSide(die2);
            dieSideSum = dieSide1 + dieSide2;

            // Changes the Texture property to the rolled number of that die.
            // First die
            dieSprite = GetNode<Sprite>("../Side1");
            dieSprite.Texture = (Texture)GD.Load($"res://All Sprites/Side{dieSide1}.png");
            // Second die
            dieSprite = GetNode<Sprite>("../Side2");
            dieSprite.Texture = (Texture)GD.Load($"res://All Sprites/Side{dieSide2}.png");

        }

    }


    // Activated after timer runs out 
    private void TimedOut()
    {
        UpdateDie();
        DiceValueManager.DieValue();
        Spatial Grid = GetNode<Spatial>("../Die_Grid");
        Grid.Hide();
    }

}