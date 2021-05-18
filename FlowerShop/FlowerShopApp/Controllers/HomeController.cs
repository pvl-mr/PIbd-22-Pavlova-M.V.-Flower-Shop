using FlowerShopApp.Models;
using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShopApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<StorePlaceViewModel>>("api/storePlace/GetStorePlaces"));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string password)
        {
            
            if (!string.IsNullOrEmpty(password))
            {
                if (password != Program.Password)
                {
                    throw new Exception("Неверный пароль");
                }
                Program.Enter = true;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(string storePlaceName, string administratorName)
        {
            if (!string.IsNullOrEmpty(storePlaceName) && !string.IsNullOrEmpty(administratorName))
            {
                APIClient.PostRequest("api/storePlace/createorupdatestoreplace", new StorePlaceBindingModel
                {
                    AdministratorName = administratorName,
                    StorePlaceName = storePlaceName,
                    DateCreate = DateTime.Now,
                    StorePlaceComponents = new Dictionary<int, (string, int)>()
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите имя и ответственного");
        }

        [HttpGet]
        public IActionResult Update(int storePlaceId)
        {
            Console.WriteLine("Mariya " + storePlaceId);
            var storePlace = APIClient.GetRequest<StorePlaceViewModel>($"api/storePlace/GetStorePlace?storePlaceId={storePlaceId}");
            ViewBag.Components = storePlace.StorePlaceComponents.Values;
            ViewBag.StorePlaceName = storePlace.StorePlaceName;
            ViewBag.AdministratorName = storePlace.AdministratorName;
            return View();
        }

        [HttpPost]
        public void Update(int storePlaceId, string storePlaceName, string administratorName)
        {
            if (!string.IsNullOrEmpty(storePlaceName) && !string.IsNullOrEmpty(administratorName))
            {
                var storePlace = APIClient.GetRequest<StorePlaceViewModel>($"api/storePlace/GetStorePlace?storePlaceId={storePlaceId}");
                if (storePlace == null)
                {
                    return;
                }
                APIClient.PostRequest("api/storePlace/createorupdatestoreplace", new StorePlaceBindingModel
                {
                    AdministratorName = administratorName,
                    StorePlaceName = storePlaceName,
                    DateCreate = DateTime.Now,
                    StorePlaceComponents = storePlace.StorePlaceComponents,
                    Id = storePlace.Id
                });
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.StorePlace = APIClient.GetRequest<List<StorePlaceViewModel>>("api/storePlace/getstoreplaces");
            return View();
        }

        [HttpPost]
        public void Delete(int storePlaceId)
        {
            APIClient.PostRequest("api/storePlace/DeleteStorePlace", new StorePlaceBindingModel
            {
                Id = storePlaceId
            });
            Response.Redirect("Index");
        }

        [HttpGet]
        public IActionResult AddComponent()
        {
            if (Program.Enter == null)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.StorePlace = APIClient.GetRequest<List<StorePlaceViewModel>>("api/storePlace/getStorePlaces");
            ViewBag.Component = APIClient.GetRequest<List<ComponentViewModel>>("api/storePlace/getComponents");
            return View();
        }

        [HttpPost]
        public void AddComponent(int storeplaceId, int componentId, int count)
        {
            APIClient.PostRequest("api/storePlace/addComponent", new StorePlaceComponentBindingModel
            {
                StorePlaceId = storeplaceId,
                ComponentId = componentId,
                Count = count
            });
            Response.Redirect("AddComponent");
        }
    }
}
