using System.ComponentModel.DataAnnotations.Schema;

namespace Lumia.Models;

public class Slider
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Button { get; set; }

}
