using System;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Interfaces;
using static MediaWorld.Domain.Delegates.ControlDelegate;

namespace MediaWorld.Domain.Singletons
{
  /// <summary>
  /// contains the singleton pattern
  /// </summary>
  public class MediaPlayerSingleton : IPlayer
  {
    private static readonly MediaPlayerSingleton _instance = new MediaPlayerSingleton();
    // private MediaRepository _repository = new MediaRepository();

    public static MediaPlayerSingleton Instance
    {
      get
      {
        return _instance;
      }
    }

    private MediaPlayerSingleton() {}

    public void Execute(ButtonDelegate button, AMedia media)
    {
      // Console.WriteLine(media);
      // button();
      // System.Console.WriteLine(button());

      media.ResultEvent += ResultHandler;
      button();
      
    }

    public void ResultHandler(AMedia media)
    {
      System.Console.WriteLine("{0} is playing...", media.Title);
    }


    public bool VolumeUp()
    {
      return true;
    }

    public bool VolumeDown()
    {
      return true;
    }

    public bool VolumeMute()
    {
      return true;
    }

    public bool PowerUp()
    {
      throw new NotImplementedException();
    }

    public bool PowerDown()
    {
      throw new NotImplementedException();
    }
  }
}