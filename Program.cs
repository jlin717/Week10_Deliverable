using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UndustedTheGame;

public class UndustedData
{
    [JsonPropertyName("ItemNames")]
    public string[]? ItemNames { get; set; }

    [JsonPropertyName("ToolNames")]
    public string[]? ToolNames { get; set; }
}

class Program
{
    static string chosenItem = "";
    static int chosenItemNumber;
    static string chosenTool = "";
    static int chosenToolNumber;

    static bool itemCleaned = false;

    static string fileName = "undustedtheGame.json";
    static string jsonstring = File.ReadAllText(fileName);
    static UndustedData undustedTheGame = JsonSerializer.Deserialize<UndustedData>(jsonstring)!;

    static string[]? cleanItems = undustedTheGame.ItemNames;
    static string[]? cleanTools = undustedTheGame.ToolNames;

    static void Main()
    {
        //Telling users to choose an item to clean.
        Console.WriteLine($"Choose which item you would like to clean.");
        DisplayAllItems(cleanItems);
        

        //Check user intput for numbers.
        while(true)
        {
            if (int.TryParse(Console.ReadLine(), out int num))
            {
                ChooseItem(num);
                break;
            }
        }
        
        //Telling users to choose a cleaning tool.
        Console.WriteLine($"Choose a cleaning tool.");
        DisplayAllTools(cleanTools);

        
        while(!itemCleaned)
        {
           while(true)
            {
                if (int.TryParse(Console.ReadLine(), out int num))
                {
                    ChooseTool(num);
                    break;
                }
            } 
            if(itemCleaned) Console.WriteLine("Yes! The item is sparkling clean!!");
        }
    }

    private static void DisplayAllItems(string[]? items)
    {
        int n = 1;
        foreach (var item in items)
        {
            Console.WriteLine($"[{n}]{item}");
            n++;
        }
    }

    private static void DisplayAllTools(string[]? tools)
    {
        int n = 1;
        foreach (var tool in tools)
        {
            Console.WriteLine($"[{n}]{tool}");
            n++;
        }
    }

    private static void ChooseItem(int itemNumber)
    {
        chosenItemNumber = itemNumber;
        switch (itemNumber)
        {
            case 1: //Front Key
                chosenItem = cleanItems[itemNumber-1];
                Console.WriteLine($"You have chosen {chosenItem}.");
                break;
            case 2: //Teacup
                chosenItem = cleanItems[itemNumber-1];
                Console.WriteLine($"You have chosen {chosenItem}.");
                break;
            case 3: //Ocarina
                chosenItem = cleanItems[itemNumber-1];
                Console.WriteLine($"You have chosen {chosenItem}.");
                break;
            case 4: //Attic Key
                chosenItem = cleanItems[itemNumber-1];
                Console.WriteLine($"You have chosen {chosenItem}.");
                break;
        }
    }

    private static void ChooseTool(int toolNumber)
    {
        chosenToolNumber = toolNumber;
        switch (toolNumber)
        {
            case 1: //Toothbrush
                chosenTool = cleanTools[toolNumber-1];
                Console.WriteLine($"You attempt to clean the {chosenItem} using the {chosenTool}.");
                if(chosenItem == cleanItems[0] || chosenItem == cleanItems[3]) itemCleaned = true;
                else Console.WriteLine("That tool doesn't quite seem to get the job done. Try another one.");
                break;
            case 2: //Sponge
                chosenTool = cleanTools[toolNumber-1];
                Console.WriteLine($"You attempt to clean the {chosenItem} using the {chosenTool}.");
                if(chosenItem == cleanItems[2]) itemCleaned = true;
                else Console.WriteLine("That tool doesn't quite seem to get the job done. Try another one.");
                break;
            case 3: //Cloth
                chosenTool = cleanTools[toolNumber-1];
                Console.WriteLine($"You attempt to clean the {chosenItem} using the {chosenTool}.");
                if(chosenItem == cleanItems[1]) itemCleaned = true;
                else Console.WriteLine("That tool doesn't quite seem to get the job done. Try another one.");
                break;
        }
    }
}