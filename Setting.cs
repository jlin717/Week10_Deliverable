using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UndustedTheGame;

public static class Setting
{
    private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "data", "UndustedtheGame.json");

    private static JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static List<UndustedData> GetUndustedtheGameFromFile()
    {
        string UndustedTheGameJsonString = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<UndustedData>>(UndustedTheGameJsonString, Options)!;
    }

    public static void SaveUndustedtheGameToFile(List<UndustedData> games)
    {
        string stringedGames = JsonSerializer.Serialize<List<UndustedData>>(games, Options);

        File.WriteAllText(FilePath, stringedGames);
    }
}
