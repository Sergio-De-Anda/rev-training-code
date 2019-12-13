using System.Linq;
using RestApi.Client.Controllers;
using RestApi.Data;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Test.Client
{
  public class PokemonUnitTest
  {
    [Fact]
    public async void Test_GetAllPokemon()
    {
      // serialization
      // httpclient
      // casting
      var sut = new PokemonController(new PokemonDbContext());
      OkResult actual = await sut.Get() as OkResult;
      // actual.
      // var result = 

      Assert.True(actual.Count() > 0);
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public async void Test_GetPokemon(int id)
    {
      var sut = new PokemonController(new PokemonDbContext());
      var actual = sut.Get(id);

      Assert.False(string.IsNullOrWhiteSpace(actual.Name));
    }
  }
}