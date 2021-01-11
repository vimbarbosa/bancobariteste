using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vini.Application.ViewModels
{
    public class HelloViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Message is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Message")]
        public string Message { get; set; }
    }
}
