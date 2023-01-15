 using Microsoft.AspNetCore.Mvc;
using MvcFarmasi.Models;
using Redis.OM;
using Redis.OM.Contracts;

namespace MvcFarmasi.Controllers
{
    public class BasketController : Controller
    {
        private readonly IRedisConnectionProvider _provider;

        public BasketController()
        {
            _provider = new RedisConnectionProvider("redis://:password@redis-19601.c281.us-east-1-2.ec2.cloud.redislabs.com:19601");
            _provider.Connection.CreateIndexAsync(typeof(Basket));
        }

        public JsonResult Index()
        {
            bool status = false;
            int count = 0;

            try
            {
                var basket = _provider.RedisCollection<Basket>();

                count = basket.Count();

                status = true;
            }
            catch (Exception) { }


            return Json(new
            {
                status = status,
                count = count
            });
        }

        public async Task<JsonResult> Add(Basket model)
        {
            bool status = false;
            int count = 0;

            try
            {
                var basket = _provider.RedisCollection<Basket>();

                await basket.InsertAsync(model);

                count = basket.Count();

                status = true;
            }
            catch (Exception){}
           

            return Json(new
            {
                status = status,
                count = count
            });
        }
    }
}
