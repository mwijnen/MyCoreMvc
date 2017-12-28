using Microsoft.AspNetCore.Mvc;
using MyCoreMvc.Models;

namespace MyCoreMvc.Controllers
{
    public class CommentsController : Controller
    {
        private IRepository repository;

        public CommentsController(IRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index() => View(repository.Comments);
    }
}
