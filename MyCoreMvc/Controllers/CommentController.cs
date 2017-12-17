using Microsoft.AspNetCore.Mvc;
using MyCoreMvc.Models;

namespace MyCoreMvc.Controllers
{
    public class CommentController : Controller
    {
        private IRepository repository;

        public CommentController(IRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index() => View(repository.Comments);
    }
}
