using System.ComponentModel.DataAnnotations;

namespace Library.Models;

public class BookModel
{
    public int ID { get; set; }
    
    [Display(Name = "Tytuł")]
    [Required(ErrorMessage = "Tytuł jest wymagany")]
    [StringLength(160)]
    public string Title { get; set; }
    
    [Display(Name = "Autor")]
    [Required(ErrorMessage = "Autor jest wymagany")]
    public string Author { get; set; }
    
    [Display(Name = "Opis")]
    [Required(ErrorMessage = "Opis jest wymagany")]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Kod jest wymagany")]
    public string Isbn { get; set; }

    [Display(Name = "Rok publikacji")]
    [RegularExpression(@"^[12][0-9]{3}$", ErrorMessage = "Wprowadź poprawny rok"), Required] 
    public int Year { get; set; }
}