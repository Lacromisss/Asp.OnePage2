using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeyatdanBezmek.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Degre { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

    }
}
