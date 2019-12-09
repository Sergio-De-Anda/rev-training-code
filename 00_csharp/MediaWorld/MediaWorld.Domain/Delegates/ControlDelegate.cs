using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Delegates
{
    public abstract class ControlDelegate
    {
      public delegate bool ButtonDelegate();
      public delegate void ResultDelegate(AMedia media);
      // public delegate bool PauseDelegate();
      // public delegate bool StopDelegate();     
    }
}