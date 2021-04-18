using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S2_MVCProject.Web.Areas.Marketing.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace S2_MVCProject.Web.Areas.Marketing.Controllers
{
    [Area("Marketing")]
    //[Area(nameof(Marketing))]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductsViewModel()
        {
            var products = GetProductsJsonLocal();
            return View(products);
        }

        public IActionResult ProductsViewData()
        {
            var products = GetProductsJsonLocal();
            ViewData["ProductList"] = products;
            ViewData["Titulo"] = "Este es un titulo desde el Controller";
            return View();
        }

        public IActionResult ProductsViewBag()
        {
            var products = GetProductsJsonLocal();
            ViewBag.ProductList = products;
            ViewBag.Titulo = "Este es un titulo desde el Controller";

            return View();
        }


        public async Task<IEnumerable<Product>> GetProductsJsonRemote()
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync("https://raw.githubusercontent.com/dotnet-presentations/ContosoCrafts/master/src/wwwroot/data/products.json");
            string apiReponse = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(apiReponse);
            return products;
        }

        public IEnumerable<Product> GetProductsJsonLocal()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"Areas\\Marketing\\Data\\Products.json");
            var json = System.IO.File.ReadAllText(folderDetails);

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            return products;
        }


    }
}
