namespace MediaWorld.Domain.Interfaces
{
  public interface IControl 
  {
    bool Forward();
    bool Pause();
    bool Play();
    bool Rewind();
    bool Stop();                
  }
}