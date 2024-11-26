using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelTask 
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}
