using AspNetCore;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Student_Registration___Theme__.Areas.Country.Models
{
    public class CountModel
    {
        public int? CountryCount {  get; set; }
        public int? StateCount { get; set; }
        public int? CityCount { get; set; }
    }
}
