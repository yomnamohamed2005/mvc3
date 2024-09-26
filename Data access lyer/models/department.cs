using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_access_lyer.models
{
    public class department
    {
        public int id { get; set; }
        [Range(0,500)]
        public int code { get; set; }
        [Required(ErrorMessage ="Name is Requried !!")]
        public string name { get; set; }
        [Display(Name = "Create at")]
        public DateTime time { get; set; }
    }
}
