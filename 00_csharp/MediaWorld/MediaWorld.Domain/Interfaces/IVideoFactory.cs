using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Interfaces
{
  public interface IVideoFactory
  {
    AVideo Create<T>() where T : AVideo, new();
  }
}