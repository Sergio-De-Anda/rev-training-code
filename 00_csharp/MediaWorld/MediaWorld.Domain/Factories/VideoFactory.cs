using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Interfaces;

namespace MediaWorld.Domain.Factories
{
  public class VideoFactory : IFactory
  {
    public AMedia Create<T>() where T : AMedia, new()
    {
      return new T();
      // switch (type)
      // {
      //   case "book":
      //     return new Book();

      //   case "song":
      //     return new Song();

      //   default:
      //     return null;
      // }

    }
  }
}