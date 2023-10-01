using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQuotes.Models;

public class User
{
    public int ID { get; set; }

    public ICollection<Quotes>? Quotes { get; set; }
    [Required(ErrorMessage = "Enter username")]
    public string? Username { get; set; }
    [Required(ErrorMessage = "Enter email")]
    public string? Email { get; set; }
    [StringLength(100, MinimumLength = 8,ErrorMessage = "Password must contain at least 8 characters")]
    [Required(ErrorMessage = "Enter password")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@*#]).{8,15}$", ErrorMessage = "Password MUST contain:" +
        "at least one lowercase letter," +
        "at least one uppercase letter," +
        "at least one number," +
        "at least one special symbol")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    
    [DataType(DataType.Password)]
    [Compare("Password")]
    [NotMapped]
    public string? ConfirmPassword { get; set; }
    
}

