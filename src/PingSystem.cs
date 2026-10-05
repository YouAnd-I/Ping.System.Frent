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
            ping.Entity.Add(new PongResponse { Text = "pong" });
            ping.Entity.Remove<PingRequestTag>();
        }
    }
}
