using System.ComponentModel.DataAnnotations;

namespace Student_Registration___Theme__.Areas.City.Models
{
    public class LOC_CityModel
    {
        public int? CityID { get; set; } = null;

        [Required]
        public string CityName { get; set; } = string.Empty;

        [Required]
        public string Citycode { get; set; } = string.Empty;

        public string StateName { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public int selectedStateID { get; set; }
        public int selectedCountryID { get; set; }
        public List<LOC_StateModel> stateList { get; set; }
        public List<LOC_CountryModel> countryList { get; set; }
    }
}
