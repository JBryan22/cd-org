using System.Collections.Generic;

namespace CdOrg.Models
{
  public class Artist
  {
    private string _name;
    private int _id;
    private List<CD> _cdList;

    private static List<Artist> _artistList = new List<Artist>{};

    public Artist(string name)
    {
      _name = name;
      _artistList.Add(this);
      _id = _artistList.Count;
      _cdList = new List<CD>{};
    }

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Artist> GetAllArtist()
    {
      return _artistList;
    }

    public List<CD> GetCDs()
    {
      return _cdList;
    }

    public void AddCD(CD newCD)
    {
      _cdList.Add(newCD);
    }

    public static Artist Find(int searchId)
    {
      return _artistList[searchId - 1];
    }

    public static void Clear()
    {
      _artistList.Clear();
    }

  }
}
