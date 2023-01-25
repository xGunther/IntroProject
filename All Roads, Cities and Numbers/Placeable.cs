using Godot;
using System;


/*This class will be the blueprint for all other board elements, 
 * that can be placed, or 'built' and which belong to different players.
 * Therefore, there will be no instances of class*/
public abstract class Placeable : Spatial
{
    protected string player;//this describes what player this element belongs to
                          //specifically their colour, as this is the only consistent thing across different games

    // Called when the node enters the scene tree for the first time, essentially when the object is constructed
    public override void _Ready() { }

    // This method is WIP, GoDot has mentioned that properties have had troubles in the past
    //Therefore, this method should have been a property, but is currently just a function that returns the player's colour
     public string getPlayer()
    {
         return this.player;
    }
}
