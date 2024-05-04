using ClassLibAutheur.Business.Entities;
using ClassLibAutheur.Data;
using ClassLibAutheur.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibAutheur.Business
{
    public static class Authors
    {
        public static SelectResult GetAuthors()
        {
            AuthorData authorData = new AuthorData();
            SelectResult result = authorData.Select();
            return result;
        }
        public static InsertResult AddAuthor(Author author)
        {
            AuthorData authorData = new AuthorData();
            InsertResult result = authorData.Insert(author);
            return result;
        }
    }
}
