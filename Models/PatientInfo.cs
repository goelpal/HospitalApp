using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Models
{
    public class PatientInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Patients Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Male/Female")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter Patients Age")]
        public int Age { get; set; }
        public string Symptoms { get; set; }

        [Display(Name = "Doctors Notes")]
        public string Notes { get; set; }

        [Display(Name = "Doctors Name")]
        public int DoctorId { get; set; }
        public Doctor Doctor {  get; set; }
    }
}
