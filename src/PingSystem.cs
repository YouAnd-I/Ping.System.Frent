using Frent;
using Ping.Data;

namespace Ping.System.Frent;

public static class PingSystem
{
    public static void Execute(World world)
    {
        foreach (var ping in world
                     .Query<PingRequest>()
                     .EnumerateWithEntities<PingRequest>())
        {
            var entity = ping.Entity;
            entity.Add(new PingResponse { Text = "Pong You!!" });
            entity.Remove<PingRequest>();
        }
    }
}
