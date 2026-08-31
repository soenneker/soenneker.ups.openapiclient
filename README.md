[![](https://img.shields.io/nuget/v/soenneker.ups.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ups.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ups.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.ups.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.ups.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.ups.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.ups.openapiclient/codeql.yml?style=for-the-badge&label=CodeQL)](https://github.com/soenneker/soenneker.ups.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Ups.OpenApiClient

A Kiota-generated client for UPS shipping, tracking, rating, address validation, and related APIs.

## Installation

```bash
dotnet add package Soenneker.Ups.OpenApiClient
```

## Usage

Create a Kiota adapter with an OAuth access token obtained from UPS:

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Ups.OpenApiClient;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://onlinetools.ups.com/api/")
};

httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", accessToken);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new UpsOpenApiClient(adapter);
```

For example, retrieve tracking details while pinning the request to the production UPS endpoint:

```csharp
string number = Uri.EscapeDataString(trackingNumber);
string url = $"https://onlinetools.ups.com/api/track/v1/details/{number}";

var tracking = await client.Tracking
    .Track
    .V1
    .Details[trackingNumber]
    .WithUrl(url)
    .GetAsync(
        request => request.QueryParameters.Locale = "en_US",
        cancellationToken);
```

UPS client credentials must be exchanged for an access token before calling protected APIs. The caller owns the adapter and `HttpClient`, including token refresh. Use the appropriate UPS test URL instead of the production URL for CIE requests. API failures are thrown through Kiota's normal exception handling.

For configuration-based transport and service registration, use `Soenneker.Ups.OpenApiClientUtil`.
