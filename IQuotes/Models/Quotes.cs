using System.ComponentModel.DataAnnotations;

namespace IQuotes.Models;

public class Quotes
{
    [Key]
    public int ID { get; set; }

    public int UserID { get; set;}
    public User User { get; set; }
    [Required]
    public string? QuoteText { get; set; }
    public DateTime CreatedAt { get; set; }
    
    
}

