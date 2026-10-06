using Frent;
using Ping.Data;
using Xunit;

namespace Ping.System.Frent.Tests;

public class PingSystemTests
{
    [Fact]
    public void Ping_IsAnsweredOnTheSameEntity()
    {
        using var world = new World();
        var ping = world.Create(new PingRequest());

        PingSystem.Execute(world);

        Assert.False(ping.Has<PingRequest>());
        Assert.Equal("Pong You!!", ping.Get<PingResponse>().Text);
    }

    [Fact]
    public void EntitiesWithoutPing_AreUntouched()
    {
        using var world = new World();
        var other = world.Create(new PingResponse { Text = "unrelated" });

        PingSystem.Execute(world);

        Assert.Equal("unrelated", other.Get<PingResponse>().Text);
    }
}
