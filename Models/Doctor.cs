using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter Doctors Name")]
        public string Name { get; set; }

        public string Qualification { get; set; }

        public string Department {  get; set; } 

        public List<PatientInfo> Patients { get; set; }
    }
}
