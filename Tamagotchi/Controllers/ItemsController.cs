using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      return View(allItems);
    }
    [HttpGet("/items/new")]
    public ActionResult CreateForm()
    {
      return View();
    }

    [HttpPost("/items")]
    public ActionResult Create()
    {
      Item newItem = new Item (Request.Form["new-item"]);
      List<Item> allItems = Item.GetAll();
      return View("Index", allItems);
    }
    [HttpGet("/items/{id}")]
    public ActionResult Interact(int id)
    {
        Item item = Item.Find(id);
        return View(item);
    }
    [HttpPost("/items/feed")]
    public ActionResult Feed()
    {
      List<Item> allItems = Item.GetAll();
      Item.GameTick(allItems);
      return View();
    }
    [HttpPost("/items/play")]
    public ActionResult Play()
    {
      // Item.GameTick();
      return View();
    }
    [HttpPost("/items/sleep")]
    public ActionResult Sleep()
    {
      // Item.GameTick();
      return View();
    }
  }
}
