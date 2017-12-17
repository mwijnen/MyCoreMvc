using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MyCoreMvc.Models
{
    public static class SeedDatabase
    {
        public static void EnsurePopulated(ApplicationDbContext context)
        {
            if (!context.Posts.Any())
            {
                context.Posts.AddRange(
                    new Post { Created = DateTime.Now, LastUpdated = DateTime.Now, Title = "SeedTitle", SubTitle = "SeedSubTitle", Author = "SeedAuthor" },
                    new Post { Created = DateTime.Now, LastUpdated = DateTime.Now, Title = "SeedTitle", SubTitle = "SeedSubTitle", Author = "SeedAuthor" });
                context.SaveChanges();
            }
        }
    }
}

