using Data_access_lyer.models;
using System.ComponentModel.DataAnnotations;

namespace mvc3.viewmodels
{
    public class Employeeviewmodel
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string name { get; set; }
        [Range(19, 60)]
        public int age { get; set; }
        public string address { get; set; }
        [DataType(DataType.Currency)]
        public decimal salary { get; set; }
        [EmailAddress]
        public string email { get; set; }
        [Phone]
        public string phone { get; set; }
        public bool isactive { get; set; }
        public department? department { get; set; }
        public int? departmentId { get; set; }
    }
}
