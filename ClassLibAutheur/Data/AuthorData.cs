using ClassLibAutheur.Business.Entities;
using ClassLibAutheur.Data.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibAutheur.Data
{
    internal class AuthorData : SqlServer
    {
        public string TableName { get; set; }
        public AuthorData()
        {
            TableName = "dbo.Author";
        }
        public SelectResult Select()
        {
            return base.Select(TableName);
        }
        public InsertResult Insert(Author author)
        {
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.CommandText = $"INSERT INTO {TableName} (Name,Country,Birthdate,MostPopularWork,ImageAuthor) " +
                $"VALUES (@name,@country,@birthdate,@mostPopularWork,@imageAuthor)";

            insertCommand.Parameters.AddWithValue("@name", author.Name);
            insertCommand.Parameters.AddWithValue("@country", author.Country);
            insertCommand.Parameters.AddWithValue("@birthdate", author.Birthdate);
            insertCommand.Parameters.AddWithValue("@mostPopularWork", author.MostPopularWork);
            insertCommand.Parameters.AddWithValue("@imageAuthor", author.ImageAuthor);

            return Add(insertCommand);
        }
    }
}
