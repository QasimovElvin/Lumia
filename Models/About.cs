using System.ComponentModel.DataAnnotations.Schema;

namespace Lumia.Models;

public class About
{
    public int Id { get; set; }
    public string Image { get; set; }
    [NotMapped]
    public IFormFile ImageFile { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}
