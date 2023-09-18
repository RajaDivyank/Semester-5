using System.ComponentModel.DataAnnotations;

namespace Student_Registration.Areas.Student.Models
{
    public class StudentModel
    {
        public int SelectedCityId { get; set; }
        public List<CityModel> Cities { get; set; }
        public int? StudentID { get; set; }

        [Required]
        public string StudentName { get; set; } = string.Empty;

        [Required]
        public string MobileNoStudent { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        
        [Required]
        public string MobileNoFather { get; set; } = string.Empty;
        
        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }
        
        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
        public List<BranchModel> Branches { get; set;}
        
        [Required]
        public int BranchID { get; set; }
    }
}
