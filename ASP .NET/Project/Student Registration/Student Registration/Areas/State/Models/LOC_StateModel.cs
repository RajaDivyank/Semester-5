using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Areas.State.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }
        [Required]
        public string? StateName { get; set; }
        [Required]
        public string? StateCode { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }


    }
}
