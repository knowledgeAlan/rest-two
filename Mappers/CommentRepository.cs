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

        public Task<List<Comment>> GetAllAsync()
        {
           return _context.Comments.ToListAsync();
        }
    }
}