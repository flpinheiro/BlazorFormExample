using BlazorFormExample.Enums;
using System.ComponentModel.DataAnnotations;

namespace BlazorFormExample.ViewModels
{
    public class PersonViewModel
    {
        public string? Id { get; set; } 
        [Required, StringLength(50,ErrorMessage = "Name is too long")]
        public string Name { get; set; } = null!;
        [Required, StringLength(50, ErrorMessage = "surame is too long")]
        public string Surname { get; set; } = null!;
        [Required, StringLength(50, ErrorMessage = "Email is too long"), EmailAddress]
        public string Email { get; set; } = null!;
        public Gender Gender { get; set; } = Gender.Male;
    }
}
