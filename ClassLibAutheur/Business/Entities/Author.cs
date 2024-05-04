using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibAutheur.Business.Entities
{
    public class Author

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime Birthdate { get; set; }
        public string MostPopularWork { get; set; }
        public string ImageAuthor { get; set; }

    }
}
