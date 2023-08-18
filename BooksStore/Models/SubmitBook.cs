using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BooksStore.Models;

public class SubmitBook
{
    [Required]
    [StringLength(80, MinimumLength = 3)]
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [StringLength(5000)]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [Required]
    [StringLength(80, MinimumLength = 3)]
    [JsonPropertyName("authorName")]
    public string? Author { get; set; }

    [Range(typeof(decimal), "0", "99999")]
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [DisplayName("Number of Pages")]
    [Range(0, 9999, ErrorMessage = "Number of pages must be at least 0 and at most 9999")]
    [JsonPropertyName("pagesCount")]
    public int PagesCount { get; set; }

    public string? ISBN { get; set; }
    public string Category { get; set; }
}
