using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Ups.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class UpsOpenApiClientTests : FixturedUnitTest
{
    public UpsOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
