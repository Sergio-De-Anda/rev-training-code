using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Models
{
  public class Photo : AVideo
  {
    public Photo()
    {
      Initialize();
    }

    public Photo(string title)
    {
      Initialize(title);
    }

    public void Initialize(string title="Untitled Photo")
    {
      Title = title;
    }

    // public override string ToString()
    // {
    //   return $"{Title}";
    // }
  }
}