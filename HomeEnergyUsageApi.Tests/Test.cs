using System.Text;
using System.Text.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

public class Test
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private List<Home> testHomes = new List<Home>() {
    new Home("Kim", "204 Maple Hill Road", "Atlanta", 4923),
    new Home("Garcia", "West 7th Street", "Tuscon", 3521),
    new Home("Connor", "332 Birchwood Circle", "Miami", 2576)};
    private string expectedNotFound = JsonSerializer.Serialize(new
    {
        ownerLastName = "Nobody",
        streetAddress = "000 Nowhere Ave",
        city = "No Owner Was Found",
        monthlyElectricUsage = 0
    });

    public Test(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/Homes")]
    public async Task HomeEnergyUsageApiReturnsSuccessfulHTTPResponseCodeOnGETHomes(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);

        Assert.True(response.IsSuccessStatusCode, $"HomeEnergyUsageApi did not return successful HTTP Response Code on GET request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");
    }

    [Theory]
    [InlineData("/Homes")]
    public async Task HomeEnergyUsageApiCanReturnFirstHomeByOwnerLastNameRouterParam(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url + $"/{testHomes[0].ownerLastName}");
        string responseContent = await response.Content.ReadAsStringAsync();
        
        string firstTestHome = JsonSerializer.Serialize(testHomes[0]);
        bool homeRecordMatches = (responseContent == firstTestHome);

        Assert.True(response.IsSuccessStatusCode, $"HomeEnergyUsageApi did not return successful HTTP Response Code on GET request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");
        Assert.True(homeRecordMatches, $"HomeEnergyUsageApi did not return the correct owner Record when trying to GET by Owner's Last Name Route Parameter \n Expected:{firstTestHome} \n Received:{responseContent}");
    }

    [Theory]
    [InlineData("/Homes")]
    public async Task HomeEnergyUsageApiCanReturnSecondHomeByOwnerLastNameRouterParam(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url + $"/{testHomes[1].ownerLastName}");
        string responseContent = await response.Content.ReadAsStringAsync();
        
        string secondTestHome = JsonSerializer.Serialize(testHomes[1]);
        bool homeRecordMatches = (responseContent == secondTestHome);

        Assert.True(response.IsSuccessStatusCode, $"HomeEnergyUsageApi did not return successful HTTP Response Code on GET request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");
        Assert.True(homeRecordMatches, $"HomeEnergyUsageApi did not return the correct owner Record when trying to GET by Owner's Last Name Route Parameter \n Expected:{secondTestHome} \n Received:{responseContent}");
    }

    [Theory]
    [InlineData("/Homes")]
    public async Task HomeEnergyUsageApiCanReturnThirdHomeByOwnerLastNameRouterParam(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url + $"/{testHomes[2].ownerLastName}");
        string responseContent = await response.Content.ReadAsStringAsync();
        
        string thirdTestHome = JsonSerializer.Serialize(testHomes[2]);
        bool homeRecordMatches = (responseContent == thirdTestHome);

        Assert.True(response.IsSuccessStatusCode, $"HomeEnergyUsageApi did not return successful HTTP Response Code on GET request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");
        Assert.True(homeRecordMatches, $"HomeEnergyUsageApi did not return the correct owner Record when trying to GET by Owner's Last Name Route Parameter \n Expected:{thirdTestHome} \n Received:{responseContent}");
    }

    [Theory]
    [InlineData("/Homes/DoesntExist")]
    public async Task HomeEnergyUsageApiGivesExpectedResponseWhenCantFindHomeByOwnerLastNameRouterParam(string url)
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync(url);
        string responseContent = await response.Content.ReadAsStringAsync();
        
        bool homeRecordMatches = (responseContent == expectedNotFound);

        Assert.True(response.IsSuccessStatusCode, $"HomeEnergyUsageApi did not return successful HTTP Response Code on GET request at {url}; instead received {(int)response.StatusCode}: {response.StatusCode}");
        Assert.True(homeRecordMatches, $"HomeEnergyUsageApi did not return the correct \"No Owner Was Found\" record when trying to GET by Owner's Last Name Route Parameter with an owner who doesn't exist \n Expected:{expectedNotFound} \n Received:{responseContent}");
    }
}