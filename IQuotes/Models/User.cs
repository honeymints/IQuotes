﻿using System.ComponentModel.DataAnnotations;

namespace IQuotes.Models;

public class User
{
    public int ID { get; set; }
    
    public int QuoteID { get; set; }
    public ICollection<Quotes> Quotes { get; set; }
    public string Username { get; set; }
    [Required] 
    public string Email { get; set; }
    
    public string Password { get; set; }

    public User()
    {
       
    }
}

