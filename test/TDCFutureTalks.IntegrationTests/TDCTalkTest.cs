namespace TDCFutureTalks.IntegrationTests;
public class TDCTalksTest
{
    private readonly TDCFutureTalksApplication app;

    const string router = "/talk";
    private readonly JsonSerializerOptions jsonOptions = new() { PropertyNameCaseInsensitive = true };

    public TDCTalksTest() => app = new TDCFutureTalksApplication();


    [Fact]
    public async Task GetAll_Talks_Should_Return_Ok_With_Content()
    {
        //Arrange
        using var client = app.CreateClient();

        //Act
        var all = await client.GetAsync(router);
        var response = await all.Content.ReadAsStringAsync();
        var json = JsonSerializer.Deserialize<IEnumerable<Talk>>(response, jsonOptions);

        //Assert
        all.StatusCode.Should().Be(HttpStatusCode.OK);
        json.Should().HaveCountGreaterThan(1);
    }
  
    [Fact]
    public async Task Insert_Talk_Should_Return_Created_With_Content_Of_Talk()
    {
        //Arrange
        using var client = app.CreateClient();
        Talk newTalk = new(Guid.NewGuid(), "Palestra TDC Future � legal", "J�nior Porfirio", "Arquitetura .NET");
        
        //Act

        var added = await client.PostAsync($"{router}/new", JsonContent.Create(newTalk));
        var response = await added.Content.ReadAsStringAsync();
        var json = JsonSerializer.Deserialize<Talk>(response, jsonOptions);

        //Assert
        added.StatusCode.Should().Be(HttpStatusCode.Created);
        json.Should().BeEquivalentTo(newTalk);
    }

    [Fact]
    public async Task GetId_Talk_Should_Return_Ok_With_Content_Of_Talk()
    {
        //Arrange
        using var client = app.CreateClient();
        Talk newTalk = new(Guid.NewGuid(), "Palestra TDC Future � legal", "J�nior Porfirio", "Arquitetura .NET");

        //Act
        var added = await client.PostAsync($"{router}/new", JsonContent.Create(newTalk));
        
        var getId = await client.GetAsync($"{router}/{newTalk.Id}");
        var response = await getId.Content.ReadAsStringAsync();
        var json = JsonSerializer.Deserialize<Talk>(response, jsonOptions);

        //Assert
        added.StatusCode.Should().Be(HttpStatusCode.Created);

        getId.StatusCode.Should().Be(HttpStatusCode.OK);
        json.Should().BeEquivalentTo(newTalk);
    }
}
