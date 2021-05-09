using FlowerShopBusinessLogic.BindingModel;
using FlowerShopBusinessLogic.BusinessLogic;
using FlowerShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;
        private readonly FlowerLogic _flower;
        private readonly OrderLogic _main;
        public MainController(OrderLogic order, FlowerLogic product, OrderLogic main)
        {
            _order = order;
            _flower = product;
            _main = main;
        }
        [HttpGet]
        public List<FlowerViewModel> GetFlowerList() => _flower.Read(null)?.ToList();
        [HttpGet]
        public FlowerViewModel GetFlower(int flowerId) => _flower.Read(new FlowerBindingModel { Id = flowerId })?[0];
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);
    }
}
