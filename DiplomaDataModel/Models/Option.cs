using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        [Required]
        [MinLength(2), MaxLength(30)]
        public string Title { get; set; }
        [Required]
        public bool IsActive { get; set; }
        //public List<Choice> Choices { get; set; }
    }
}
