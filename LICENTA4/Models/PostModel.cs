using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LICENTA4.Models
{
    public class PostModel
    {
        private List<Post> posts = new List<Post>();

        public PostModel()
        {
            // posts = new List<Post>();
        }

        public List<Post> findAll()
        {
            return posts;
        }

        public Post find(int id)
        {
            return posts.SingleOrDefault(p => p.Id.Equals(id));
        }
    }
}