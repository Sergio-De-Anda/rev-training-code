using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Interfaces
{
  public interface IAudioFactory
  {
    AAudio Create<T>() where T : AAudio, new();
  }
}