using Discord.Ping.Data;
using Frent;

namespace Discord.Ping.System.Frent;

public static class PingSystem
{
    public static void Execute(World world)
    {
        foreach (var ping in world
                     .Query<PingRequestTag>()
                     .EnumerateWithEntities<PingRequestTag>())
        {
            var entity = ping.Entity;
            entity.Add(new PongResponse { Text = "Pong You!!" });
            entity.Remove<PingRequestTag>();
        }
    }
}
