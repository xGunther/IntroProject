using Godot;
using System;

public class Throw_Dice_Button : Button
{
    public int DieSide1 = 1;
    public int DieSide2 = 1;
    public static int DieSideSum = 2;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        float DieWaitTime = 4; // AMOUNT OF TIME TO WAIT BEFORE THE DICE DISAPPEAR
        Timer DieTimer = GetNode<Timer>("Delay");
        DieTimer.WaitTime = DieWaitTime;
    }

    public void ButtonPressed()
    {
        Timer DieTimer = GetNode<Timer>("Delay");

        // Only throws new Die if the timer is on zero.
        // Currently missing an extra check to determine whether they are allowed to throw them game-wise
        if (DieTimer.TimeLeft == 0 && DiceValueManager.TurnCount > 2)
        {
            Spatial Grid = GetNode<Spatial>("../Die_Grid");
            Grid.Show();
            DieTimer.Start();
        }
        this.Hide();
    }

    public int GetDieSide(RigidBody Die)
    {


        // transform[1] == 0 -1 0 => 1
        // transform[0] == 0 -1 0 => 2
        // transform[2] == 0 -1 0 => 3
        // transform[2] == 0 1 0 => 4
        // transform[0] == 0 1 0 => 5
        // transform[1] == 0 1 0 => 6
        float AbsZero = Math.Abs(Die.Transform[0].y);
        float AbsOne = Math.Abs(Die.Transform[1].y);
        float AbsTwo = Math.Abs(Die.Transform[2].y);


        // Case where Transform[0].y is the largest value (2 and 5)
        if (AbsZero > AbsOne && AbsZero > AbsTwo)
        {
            if (Die.Transform[0].y > 0)
                return 5;
            else
                return 2;
        }

        // Case where Transform[1].y is the largest value (1 and 6)
        else if (AbsOne > AbsZero && AbsOne > AbsTwo)
        {
            if (Die.Transform[1].y > 0)
                return 6;
            else
                return 1;
        }

        // Case where Transform[2].y is the largest value (3 and 4)
        else
        {
            if (Die.Transform[2].y > 0)
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
            Sprite DieSprite;

            RigidBody Die1 = GetNode<RigidBody>("../Die_Grid/Die");
            RigidBody Die2 = GetNode<RigidBody>("../Die_Grid/Die2");
            DieSide1 = GetDieSide(Die1);
            DieSide2 = GetDieSide(Die2);
            DieSideSum = DieSide1 + DieSide2;

            // Changes the Texture property to the rolled number of that Die.
            // First Die
            DieSprite = GetNode<Sprite>("../Side1");
            DieSprite.Texture = (Texture)GD.Load($"res://All Sprites/Side{DieSide1}.png");
            // Second Die
            DieSprite = GetNode<Sprite>("../Side2");
            DieSprite.Texture = (Texture)GD.Load($"res://All Sprites/Side{DieSide2}.png");

        }

    }


    // Activated after timer runs out 
    private void TimedOut()
    {
        UpdateDie();
        DiceValueManager.DieValue();
        Spatial Grid = GetNode<Spatial>("../Die_Grid");
        Grid.Hide();
        DiceValueManager.ButtonPressedOrNot = true;
    }

}