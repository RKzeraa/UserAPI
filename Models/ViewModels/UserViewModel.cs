using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models;
public class UserViewModel
{
    [Required(ErrorMessage="The name is required",AllowEmptyStrings=false)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Enter your email")]
    [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Enter is Valid Email...")]
    public string? Email { get; set; }
    
    [Required]
    [RegularExpression(@"^(0[1-9]|[1-2][0-9]|3[0-1])[./-](0[1-9]|1[0-2])[./-](19[0-9][0-9]|202[0-3]|20[0-1][0-9])$",ErrorMessage = "Enter is Valid BirthDate... Format Valid is dd/mm/yyyy")]
    public string? BirthDate { get; set; }
}