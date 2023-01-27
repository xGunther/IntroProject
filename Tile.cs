using Godot;
using System;

public class Tile
{
    // Tile is a way to save the hexatile nodes and connect them with the number above the tile. It also saves the resource
    public Spatial TileNode;
    public int DieNumber;
    public string ResourceType;

    
    public Tile(Spatial Node, int Number)
    {
        TileNode = Node;
        DieNumber = Number;
        ResourceType = GetResource(Node.Name);
    }
    // Checks the Node name to see what kind of resource it is
    private string GetResource(string Name)
    {
        if (Name.Contains("Gold"))
            return "Gold";
        else if (Name.Contains("Grain"))
            return "Grain";
        else if (Name.Contains("Wood"))
            return "Wood";
        else if (Name.Contains("Sheep"))
            return "Sheep";
        else if (Name.Contains("Stone"))
            return "Stone";

        return "Sand";
    }
}
