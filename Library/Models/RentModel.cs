using System.ComponentModel.DataAnnotations;
using Library.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Library.Models;

public class RentModel
{
    public int ID { get; set; }
    
    [Display(Name = "Książka")]
    [Required(ErrorMessage = "Książka jest wymagana")]
    public int BookId { get; set; }

    [ValidateNever]
    public virtual BookModel Book { get; set; }
    
    [Display(Name = "Klient")]
    [Required(ErrorMessage = "Klient jest wymagany")]
    public int ClientId { get; set; }

    [ValidateNever]
    public virtual ClientModel Client { get; set; }
    
    [Display(Name = "Data wypożyczenia")]
    public DateTime RentDate { get; set; }
    
    [Display(Name = "Status")]
    public RentStatusEnum Status { get; set; }
}