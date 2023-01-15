using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MvcFarmasi.Models;

namespace MvcFarmasi.Controllers
{
    public class ProductController : Controller
    {
        IMongoClient mongoClient = new MongoClient("mongodb://localhost:27017");

        public ActionResult Index()
        {
            IMongoDatabase db = mongoClient.GetDatabase("ProductFarmasi");

            IMongoCollection<Products> collection = db.GetCollection<Products>("products");

            var productResults = collection.AsQueryable().ToList();

            return View(productResults);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products product)
        {
            try
            {
                IMongoDatabase db = mongoClient.GetDatabase("ProductFarmasi");

                IMongoCollection<Products> collection = db.GetCollection<Products>("products");
                collection.InsertOne(product);

                return RedirectToAction(nameof(Index));
            }
            catch
            {

                return View();
            }
        }
    }
}
