﻿using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{
    public class Visitor
    {
        
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Sex must be entered")]
        [Compare("")]
        public string? Sex { get; set; }
        public int PhoneNumber { get; set; }
    }
}