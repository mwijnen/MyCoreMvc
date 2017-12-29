using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMvc.Models
{
    public interface IRepository
    {
        IEnumerable<Post> Posts { get; }

        IEnumerable<Comment> Comments { get; }

        void SavePost(Post post);

        Post GetPost(string id);
    }
}
