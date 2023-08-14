

using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public enum Types
    {
        CANCER,GENERAL,CIVIL
    }
    public class Hospital
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Name of Hospital is Manditory")]
        public string name { get; set; }
        [DataType(DataType.Date)]
        public DateTime AdmitDate { get; set; }

        [Required(ErrorMessage ="Type of Hospital is Manditory")]
        [EnumDataType(typeof(Types))]
        public Types hospitaltype { get; set; }

    }
}
