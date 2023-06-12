using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class ClientModel
{
    public int ID { get; set; }
    
    [Display(Name = "Pesel")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "Wprowadź poprawny pesel"), Required] 
    public string Pesel { get; set; }
    
    [Display(Name = "Imię")]
    [Required(ErrorMessage = "Imię jest wymagane")]
    public string Firstname { get; set; }
    
    [Display(Name = "Nazwisko")]
    [Required(ErrorMessage = "Nazwisko jest wymagane")]
    public string Lastname { get; set; }
}