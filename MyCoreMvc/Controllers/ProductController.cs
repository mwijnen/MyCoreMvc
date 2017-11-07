using Microsoft.AspNetCore.Mvc;
using MyCoreMvc.Models;

namespace MyCoreMvc.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index() => View(repository.Products);
    }
}
