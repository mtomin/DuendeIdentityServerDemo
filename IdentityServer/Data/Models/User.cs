using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Username { get; set; }

        [MaxLength(255)]
        public string Password { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
