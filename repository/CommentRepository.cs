using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using rest_two.data;
using rest_two.interfaces;
using rest_two.Models;

namespace rest_two.Mappers
{
    public class CommentRepository : ICommentRepository
    {

        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context) 
        {
            _context = context;
        }

        public Comment Create(Comment comment)
        {
             _context.Comments.Add(comment);
             _context.SaveChanges();
             return comment;
        }

        public   List<Comment> GetAll()
        {
           return   _context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
              return _context.Comments.Find(id);
        }

        public Comment Update(int id, Comment comment)
        {
             var existingComment = _context.Comments.Find(id);

             if(existingComment == null){
                return null;
             }

             existingComment.Content = comment.Content;
             existingComment.Id = id;
             existingComment.Title = comment.Title;
        
             _context.SaveChanges();
             return existingComment;
        }
    }
}