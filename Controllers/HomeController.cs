using Microsoft.AspNetCore.Mvc;
using CdOrg.Models;
using System.Collections.Generic;
using System;

namespace CdOrg.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet("/artists")]
    public ActionResult Artists()
    {
      List<Artist> allArtists = Artist.GetAllArtist();
      return View(allArtists);
    }
    [HttpGet("/artists/new")]
    public ActionResult ArtistNewForm()
    {
      return View();
    }
    [HttpPost("/artists/")]
    public ActionResult AddArtist()
    {
      Artist newArtist = new Artist(Request.Form["artist-name"]);
      List<Artist> allArtists = Artist.GetAllArtist();
      return View("artists", allArtists);
    }
    [HttpGet("/artists/{id}")]
    public ActionResult ArtistDetail(int id)
    {
      Dictionary<string, object> model = new Dictionary<string,object>();
      Artist selectedArtist = Artist.Find(id);
      model.Add("artist", selectedArtist);
      model.Add("cd", selectedArtist.GetCDs());
      return View(model);
    }
    [HttpGet("/artists/{id}/cd/new")]
    public ActionResult NewCDForm(int id)
    {
      Dictionary<string, object> model = new Dictionary<string,object>();
      Artist selectedArtist = Artist.Find(id);
      model.Add("artist", selectedArtist);
      return View(model);
    }
    [HttpPost("/cds")]
    public ActionResult ArtistDetailPost()
    {
      Dictionary<string, object> model = new Dictionary<string,object>();
      Artist selectedArtist = Artist.Find(int.Parse(Request.Form["artist-id"]));
      List<CD> cdList = selectedArtist.GetCDs();

      CD newCD = new CD(Request.Form["newCD"]);
      selectedArtist.AddCD(newCD);

      model.Add("artist", selectedArtist);
      model.Add("cd", cdList);

      return View("artistDetail", model);
    }


  }
}
