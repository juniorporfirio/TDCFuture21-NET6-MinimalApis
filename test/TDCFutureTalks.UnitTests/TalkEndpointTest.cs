using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace TDCFutureTalks.UnitTests;

public class TalkEndpointTest
{

    [Fact]
    public void Should_get_all_talks_and_return_StatusCode200_and_must_have_content()
    {
        //Arrange
       var talkRepositoryMock =  Substitute.For<ITalkRepository>();
        talkRepositoryMock.GetAll().Returns(new List<Talk>());

        //Act
        var all = TalkEndpointExtensions.All(talkRepositoryMock);

        //Assert
        var result = all.Should().BeOfType<MinimalApis.Extensions.Results.Ok<IEnumerable<Talk>>>().Subject;
        result.StatusCode.Should().Be(200);
        result.Value.Should().NotBeNull(); 
       
    }

    [Fact]
    public void Should_add_new_talk_and_return_StatusCode201_and_must_have_content()
    {
        //Arrange
        var talkRepositoryMock = Substitute.For<ITalkRepository>();
        var mytalk = new Talk(System.Guid.NewGuid(), "My Title", "Speaker", "Trail");

        //Act
        var created = TalkEndpointExtensions.Add(talkRepositoryMock,mytalk);

        //Assert
        var result = created.Should().BeOfType<MinimalApis.Extensions.Results.Created<Talk>>().Subject;
        result.StatusCode.Should().Be(201);
        result.Value.Should().BeEquivalentTo(mytalk);

    }

    [Fact]
    public void Should_get_one_talk_and_return_StatusCode200_and_must_have_content()
    {
        //Arrange
        var talkRepositoryMock = Substitute.For<ITalkRepository>();
        var mytalk = new Talk(System.Guid.NewGuid(), "My Title", "Speaker", "Trail");
        talkRepositoryMock.Get(mytalk.Id).Returns(mytalk);

        //Act
        var get = TalkEndpointExtensions.Get(talkRepositoryMock, mytalk.Id);

        //Assert
        var result = get.Should().BeOfType<MinimalApis.Extensions.Results.Ok<Talk>>().Subject;
        result.StatusCode.Should().Be(200);
        result.Value.Should().BeEquivalentTo(mytalk);

    }
}
