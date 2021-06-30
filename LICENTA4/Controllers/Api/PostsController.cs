using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using LICENTA4.Dtos;
using LICENTA4.Models;

namespace LICENTA4.Controllers.Api
{
    public class PostsController : ApiController
    {
        private ApplicationDbContext _context;

        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/posts
        public IEnumerable<PostDto> GetPosts()
        {
            return _context.Posts.ToList().Select(Mapper.Map<Post, PostDto>);
        }

        // GET /api/posts/1
        public IHttpActionResult GetPost(int Id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == Id);
            if (post == null)
                return NotFound();
            return Ok(Mapper.Map<Post, PostDto>(post));
        }

        // POST /api/posts
        [HttpPost]
        public IHttpActionResult CreatePost(PostDto postDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest(); 

            var post = Mapper.Map<PostDto, Post>(postDto);
            _context.Posts.Add(post);
            _context.SaveChanges();

            postDto.Id = post.Id;

            return Created(new Uri(Request.RequestUri + "/" + post.Id), postDto);
        }

        // PUT /api/posts/1
        [HttpPut]
        public void UpdatePost(int Id, PostDto postDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var postInDd = _context.Posts.SingleOrDefault(p => p.Id == Id);
            
            if (postInDd == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(postDto, postInDd);

            // postInDd.Title = postDto.Title;
            // postInDd.Description = postDto.Description;
            // postInDd.DateAdded = postDto.DateAdded;
            // postInDd.DateRelease = postDto.DateRelease;
            // postInDd.Price = postDto.Price;
            // postInDd.GenreId = postDto.GenreId;

            _context.SaveChanges();

        }

        // DELETE /api/posts/1
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var postInDd = _context.Posts.SingleOrDefault(p => p.Id == Id);

            if (postInDd == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Posts.Remove(postInDd);
            _context.SaveChanges();
        }
    }
}
