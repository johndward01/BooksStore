using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksStore.Models;

public class SubmitBook
{
    [Required]
    [StringLength(80, MinimumLength = 3)]
    public string? Title { get; set; }

    [StringLength(5000)]
    public string? Description { get; set; }

    [DisplayName ("Number of Pages")]
    [Range(0, 9999, ErrorMessage = "Number of pages must be at least 0 and at most 9999")]
    public int PagesCount { get; set; }

    [Required]
    [StringLength(80, MinimumLength = 3)]
    public string? Author { get; set; }

    [Range(typeof(decimal), "0", "99999")]
    public decimal Price { get; set; }

    public string? ISBN { get; set; }
    public string Category { get; set; }
}
