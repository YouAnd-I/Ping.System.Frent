using Frent;
using Ping.Data;

namespace Ping.System.Frent;

// Rule: every PingRequest is answered with "Pong You!!".
public static class PingSystem
{
    public static void Execute(World world)
    {
        foreach (var ping in world
                     .Query<PingRequest>()
                     .EnumerateWithEntities<PingRequest>())
        {
            // Entity is a handle: copy it out of the readonly row before Add/Remove
            var entity = ping.Entity;
            entity.Add(new PingResponse { Text = "Pong You!!" });
            entity.Remove<PingRequest>();
        }
    }
}
