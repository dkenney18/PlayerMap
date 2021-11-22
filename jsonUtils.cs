using System.Text.Json;
using System.Text.Json.Serialization;
using SimpleAdventureGame;
using PlayerMap;
using System.IO;

public class JsonUtils
{
    public object CreateJsonFromPlayer(Player player)
    {
        var playerModel = new Player
        {
            x = player.x,
            y = player.y,
            player_token = player.player_token,
            name = player.name,
            money = player.money,
            backpack = player.backpack,
            healthPoints = player.healthPoints,
            damage = player.damage,
            leftHand = player.leftHand,
            rightHand = player.rightHand,
            firstTime = player.firstTime,
            guid = player.guid
        };

        string jsonString = JsonSerializer.Serialize(playerModel);

        return jsonString;
    }

    public async void SaveJson(Player player)
    {
        var path = @$"\\P47ISSHRS01\isshared\Everyone\Devin Kenney\Code\C#\PlayerMap\playersJson\";
        var filename = $"{player.guid}.json";
        using FileStream createStream = File.Create(path + filename);
        await JsonSerializer.SerializeAsync(createStream, player);
        await createStream.DisposeAsync();
    }
}
