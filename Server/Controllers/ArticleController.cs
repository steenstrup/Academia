using Academia.Shared;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace Academia.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly ILogger<ArticleController> logger;

        public ArticleController(ILogger<ArticleController> logger)
        {
            this.logger = logger;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Article>>> Get()
        {
            List<Article> articles = new List<Article>();

            var path = @"C:\Git\Blazor\Academia\Server\ressurce\Article.json";

            using (FileStream fs = System.IO.File.OpenRead(path))
            {
                articles = await JsonSerializer.DeserializeAsync<List<Article>>(fs);
            }
            return articles;
        }
    }
}