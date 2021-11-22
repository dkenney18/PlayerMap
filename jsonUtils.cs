using System.Text.Json;
using System.Text.Json.Serialization;
using SimpleAdventureGame;
using PlayerMap;
using System.IO;
using System.Threading.Tasks;

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

    public async Task LoadJson(string fileName, Player player)
    {
        using FileStream openStream = File.OpenRead(fileName);
        Player p = await JsonSerializer.DeserializeAsync<Player>(openStream);
        player.x = p.x;
        player.y = p.y;
        player.player_token = p.player_token;
        player.name = p.name;
        player.money = p.money;
        player.backpack = p.backpack;
        player.healthPoints = p.healthPoints;
        player.damage = p.damage;
        player.leftHand = p.leftHand;
        player.rightHand = p.rightHand;
        player.firstTime = p.firstTime;
}
}
