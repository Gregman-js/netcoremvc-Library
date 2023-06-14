using System.ComponentModel.DataAnnotations;

namespace Library.Enum;

public enum RentStatusEnum
{
    [Display(Name = "W toku")]
    Open,

    [Display(Name = "Zamknięte")]
    Closed
}