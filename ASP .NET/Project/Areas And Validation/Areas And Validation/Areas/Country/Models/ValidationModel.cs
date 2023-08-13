using System.ComponentModel.DataAnnotations;

namespace Areas_And_Validation.Areas.Country.Models
{
    public class ValidationModel
    {
       [Required]
       public string Name { get; set; }
    }
}
