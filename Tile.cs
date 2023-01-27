using Godot;
using System;

public class Tile
{

    public Spatial TileNode;
    public int DieNumber;
    public string ResourceType;

    public Tile(Spatial Node, int Number)
    {
        TileNode = Node;
        DieNumber = Number;
        ResourceType = GetResource(Node.Name);
    }

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
