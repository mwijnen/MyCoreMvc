﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("[controller]/")]
        public ViewResult Index() => View(repository.Posts);

        [HttpGet("[controller]/new")]
        public ViewResult New() => View("Form");

        [HttpPost]
        public ViewResult Create() => View("Post");

        [HttpGet("[controller]/{id}")]
        public ViewResult Show(string id) => View("Post");

        [HttpGet("[controller]/{id}/edit")]
        public ViewResult Edit(string id) => View("Form");

        [HttpPatch]
        public ViewResult Update() => View("Form");

        [HttpDelete]
        public ViewResult Destroy() => View("Index");

    }
}

//Routing in ASP.net core MVC: https://stormpath.com/blog/routing-in-asp-net-core

//CRUD routing cheat sheet:
//HTTP Verb     Path Controller         #Action	            Used for
//GET	        /models                 models#index	    display a list of all models
//GET	        /models/new             models#new	        return an HTML form for creating a new model
//GET	        /models/:id/edit        models#edit	        return an HTML form for editing a model
//GET	        /models/:id             models#show	        display a specific model
//POST	        /models                 models#create	    create a new model
//PATCH/PUT	    /models/:id             models#update	    update a specific model
//DELETE	    /models/:id             models#destroy	    delete a specific model
