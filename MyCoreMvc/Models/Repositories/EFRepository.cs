﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public class EFRepository : IRepository
    {
        private ApplicationDbContext context;

        public EFRepository(ApplicationDbContext context)
        {
            this.context = context;
            SeedApplicationDb.EnsurePopulated(context);
        }

        public IEnumerable<Post> Posts => context.Posts;

        public void SavePost(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();
        }

        public IEnumerable<Comment> Comments => context.Comments;

    }
}
