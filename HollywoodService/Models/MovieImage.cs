using System.ComponentModel.DataAnnotations;

namespace HollywoodService.Models
{
    public class MovieImage
    {
        [Key]
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Picture { get; set; }
    }
}
