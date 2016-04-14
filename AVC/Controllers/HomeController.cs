
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

using AVC.Models;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace AVC.Controllers
{
    public class HomeController : Controller
    {
        private AVCEntities db = new AVCEntities();

        public int idCategory = 1392;
        public ActionResult Index(int? idCategory)
        {
            if (idCategory == null)
            {
                idCategory = 7273;
            }
            else
            {
                ViewBag.idCategory = idCategory;
            }

            List<Products> products = db.Products.Where(s => s.CategoryID == idCategory.ToString()).ToList();// (from product in db.Products where product.nid_category == 7273 select product).ToList();
																											 ////var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver()};
																											 //////var serializiProducts = JsonConvert.SerializeObject(products, Formatting.None, settings);
																											 ////var serializiProducts = JsonConvert.SerializeObject(products);

			//var products = new[]
			//    {
			//        new Products {cName =  "CREA101", nPrice_d = 12, nGaranty = 12},
			//        new Products {cName = "DARK502", nPrice_d = 13, nGaranty = 12},
			//        new Products {cName = "TRAN201", nPrice_d = 14, nGaranty = 12},
			//    };
			var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
			var serializeCourses = JsonConvert.SerializeObject(products, Formatting.None, settings);
			//return serializeCourses;
			////return serializiProducts;
			//return Json(products, JsonRequestBehavior.AllowGet);
			return View();
        }

		[HttpGet]
		public string Api(string id)
		{
			ViewBag.idCategory = id;

			List<Products> products = db.Products.Where(s => s.CategoryID == id.ToString()).ToList();

			foreach (Products prod in products)
			{
				double procent = 0.05;
				double price;
                try
				{
					price = Convert.ToDouble(prod.PriceUSD.Replace(".",","));
				}
				catch (Exception ex)
				{
					
					throw;
				}
				
                prod.PriceUSD = ((price * procent) + price).ToString(CultureInfo.InvariantCulture);
			}

			var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
			var serializeCourses = JsonConvert.SerializeObject(products, Formatting.None, settings);
			return serializeCourses;
			
		}

		//public JsonResult Test(int categoryId)
		//{
		// //string id = "1392";
		// //   List<Product> products = db.Products.Where(s => s.CategoryID == id).ToList();

		// //   //Mapper.CreateMap<Products, Product>();//.ForMember(x => x.Cname, y => y.MapFrom(z => z.Сname));

		// //   //List<Product> product = Mapper.Map<List<Products>, List<Product>>(products);
		// //   //var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
		// //   //var serializeCourses = JsonConvert.SerializeObject(product, Formatting.None, settings);
		// //   //return serializeCourses;
		// //   //ViewBag.data = Json(product, JsonRequestBehavior.AllowGet);
		// //   //var aa = Json(product, JsonRequestBehavior.AllowGet);
		// //   return Json(products, JsonRequestBehavior.AllowGet);
		//}

		public ActionResult About()
{
    ViewBag.Message = "Your application description page.";

    return View();
}

public ActionResult Contact()
{
    ViewBag.Message = "Your contact page.";

    return View();
}
    }
}