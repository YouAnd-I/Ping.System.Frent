using Discord.Ping.Data;
using Frent;
using Xunit;

namespace Discord.Ping.System.Frent.Tests;

public class PingSystemTests
{
    [Fact]
    public void Ping_BecomesPong()
    {
        using var world = new World();
        var ping = world.Create(new PingRequestTag());

        PingSystem.Execute(world);

        Assert.False(ping.Has<PingRequestTag>());
        Assert.True(ping.Has<PongResponse>());
        Assert.Equal("Pong You!!", ping.Get<PongResponse>().Text);
    }

    [Fact]
    public void EntitiesWithoutPing_AreUntouched()
    {
        using var world = new World();
        var other = world.Create(new PongResponse { Text = "unrelated" });

        PingSystem.Execute(world);

        Assert.True(other.Has<PongResponse>());
        Assert.False(other.Has<PingRequestTag>());
    }
}
