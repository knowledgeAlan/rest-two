using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rest_two.Models;

namespace rest_two.interfaces
{
    public interface ICommentRepository
    {
        List<Comment> GetAll();

        Comment GetById(int id);


        Comment Create(Comment comment);

        Comment Update(int id, Comment comment);


        Comment Delete(int id);
    }
}