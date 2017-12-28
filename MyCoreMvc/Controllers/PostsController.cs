using Microsoft.AspNetCore.Mvc;
using MyCoreMvc.Models;

namespace MyCoreMvc.Controllers
{
    public class PostsController : Controller
    {
        private IRepository repository;

        public PostsController(IRepository repository)
        {
            this.repository = repository;
        }

        //HTTP Verb     Path Controller         #Action	            Used for
        //GET	        /models                 models#index	    display a list of all models
        //GET	        /models/new             models#new	        return an HTML form for creating a new model
        //POST	        /models                 models#create	    create a new model
        //GET	        /models/:id             models#show	        display a specific model
        //GET	        /models/:id/edit        models#edit	        return an HTML form for editing a model
        //PATCH/PUT	    /models/:id             models#update	    update a specific model
        //DELETE	    /models/:id             models#destroy	    delete a specific model
        

        public ViewResult Index() => View(repository.Posts);

        public ViewResult New() => View(new Post());

        public ViewResult Create()
        {
            //obtain posted data
            //create, validate and store 


            return View();
        }

        //Show
        public ViewResult Show() => View();

        //Edit
        public ViewResult Edit() => View();

        //Update
        public ViewResult Update() => View();

        //Destroy
        public ViewResult Destroy() => View();

    }
}
