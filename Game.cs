using System;

namespace UndustedTheGame;

public class Game(string itemName, string toolName)
{
    public string ItemName { get; set; } = itemName;
    public string ToolName { get; set; } = toolName;
}
