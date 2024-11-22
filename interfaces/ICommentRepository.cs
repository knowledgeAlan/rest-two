using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rest_two.Models;

namespace rest_two.interfaces
{
    public interface ICommentRepository
    {
        public List<Comment> GetAll();

        public Comment GetById(int id);


        public Comment Create(Comment comment);

        public Comment Update(int id, Comment comment);
    }
}