using System.ComponentModel.DataAnnotations;

namespace Blog.Common.Models.User;
public class UpdateUserModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string UserName { get; set; }
}
