using System.ComponentModel.DataAnnotations;

namespace AuthenticationApplication.Models.Dtos
{
    public class LoginUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
    public class RegisterUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class CreateRoleDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime ExpireDate { get; set; }
    }

    public class EditRoleDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime ExpireDate { get; set; }
    }
    public class RoleDetailsDto
    {
        public ApplicationRole? Role { get; set; }
        public List<ApplicationUser>? Members { get; set; }
        public List<ApplicationUser>? NonMembers { get; set; }
    }
}
