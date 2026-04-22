using Soenneker.Tests.HostedUnit;

namespace Soenneker.Ups.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class UpsOpenApiClientTests : HostedUnitTest
{
    public UpsOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
