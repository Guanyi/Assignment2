using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DiplomaDataModel.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "Only 9 characters")]
        [RegularExpression("A[0-9]{8}", ErrorMessage = "Must be A00000000 Form")]
        [Display(Name = "Student Id:")]
        public string StudentId { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Max 40 characters")]
        [Display(Name = "First Name:")]
        public string StudentFirstName { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Max 40 characters")]
        [Display(Name = "Last Name:")]
        public string StudentLastName { get; set; }

        //only the first choice foreign can be [required], if add other required foreign keys in other option choices,
        //migration will produce error
        [Required]
        [Display(Name = "First Choice:")]
        [ForeignKey("Option1")]
        public int? FirstChoiceOptionId { get; set; }

        //this object reference is the one will actually produce the foreign key relation to Option table
        //[Required]
        [ForeignKey("FirstChoiceOptionId")]
        public Option Option1 { get; set; }

        [Display(Name = "Second Choice:")]
        [ForeignKey("Option2")]
        public int? SecondChoiceOptionId { get; set; }

        [ForeignKey("SecondChoiceOptionId")]
        public Option Option2 { get; set; }

        [Display(Name = "Third Choice:")]
        [ForeignKey("Option3")]
        public int? ThirdChoiceOptionId { get; set; }

        [ForeignKey("ThirdChoiceOptionId")]
        public Option Option3 { get; set; }

        [Display(Name = "Fourth Choice:")]
        [ForeignKey("Option4")]
        public int? FourthChoiceOptionId { get; set; }

        [ForeignKey("FourthChoiceOptionId")]
        public Option Option4 { get; set; }

        [Required]
        [Display(Name = "Selection Date")]
        public DateTime SelectionDate { get; set; }

        [Display(Name = "Year & Term")]
        public int YearTermId { get; set; }
        public YearTerm YearTerm { get; set; }
    }
}