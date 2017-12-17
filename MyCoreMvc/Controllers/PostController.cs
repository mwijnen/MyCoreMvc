using Microsoft.AspNetCore.Mvc;
using MyCoreMvc.Models;

namespace MyCoreMvc.Controllers
{
    public class PostController : Controller
    {
        private IRepository repository;

        public PostController(IRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index() => View(repository.Posts);
    }
}
