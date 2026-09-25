using Frent;
using Status.Data;

namespace Discord.Ping.System.Frent;

public partial struct PingRequestTag;
public partial struct PongResponseTag;
public partial struct ResponseReadyTag;
public partial struct ResponseSentTag;

public static class PingSystem
{
    public static void Execute(World world)
    {
        foreach ((Span<PingRequestTag> entities, _) in world
                     .Query<PingRequestTag>()
                     .EnumerateChunks<PingRequestTag>())
        {
            for (var i = 0; i < entities.Length; i++)
            {
                ref var entity = ref entities[i];

                entity.Add<PongResponseTag>();
                entity.Add<ResponseReadyTag>();
                entity.Remove<PingRequestTag>();
            }
        }
    }
}

public static class PingCleanUpSystem
{
    public static void Execute(World world)
    {
        foreach (var (entities, _) in world
                     .Query<ResponseSentTag>()
                     .EnumerateChunks<ResponseSentTag>())
        {
            for (var i = 0; i < entities.Length; i++)
                entities[i].Delete();
        }
    }
}