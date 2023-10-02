using System.ComponentModel.DataAnnotations;

namespace Student_Registration___Theme__.Areas.State.Models
{
    public class LOC_StateModel
    {
        public int? StateId { get; set; } = null;
        [Required]
        public string StateName { get; set; } = string.Empty;
        [Required]
        public string StateCode { get; set; } = string.Empty;
        [Required(ErrorMessage = "Select the country")]
        public int SelectedCountryId { get; set; }
        public List<LOC_CountryModel> Countries { get; set; }
    }
}
