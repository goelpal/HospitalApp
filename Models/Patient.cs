using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HospitalApp.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Patients Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Male/Female")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter Patients Age")]
        public int Age {  get; set; }
        public string Symptoms {  get; set; }

        [Display(Name = "Doctor's Notes")]
        public string Notes {  get; set; }

        public int DocId {  get; set; }
        public Doctor Doctor1 {  get; set; }
    }
}
