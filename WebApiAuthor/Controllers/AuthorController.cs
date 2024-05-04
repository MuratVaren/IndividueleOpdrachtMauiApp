using ClassLibAutheur.Business;
using ClassLibAutheur.Business.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApiAuthor.Controllers
{
    [ApiController]
    public class AuthorController : ControllerBase
    {
        [HttpGet]
        [Route("/GetAllAuthors")]
        public ActionResult GetAuthors()
        {
            var result = Authors.GetAuthors();
            if (result.Succeeded)
            {
                var authors = result.Datatable;
                string jsonResult = JsonConvert.SerializeObject(authors);
                return Ok(jsonResult);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("/RegisterAuthor")]
        public ActionResult RegisterAuthor(Author author)
        {
            var result = Authors.AddAuthor(author);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return NotFound(result.Errors);
            }
        }
    }
}
