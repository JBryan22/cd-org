using System.Collections.Generic;

namespace CdOrg.Models
{
  public class CD
  {
    private string _title;
    private string _artist;
    private int _id;

    private static List<CD> _instances = new List<CD>{};

    public CD(string title)
    {
      _title = title;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public string GetTitle()
    {
      return _title;
    }

    public void SetTitle(string newTitle)
    {
      _title = newTitle;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<CD> GetAllCDs()
    {
      return _instances;
    }

    public string GetArtist()
    {
      return _artist;
    }

    public void SetArtist(string newArtist)
    {
      _artist = newArtist;
    }

  }
}
