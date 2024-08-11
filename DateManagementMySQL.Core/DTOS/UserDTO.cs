using System.Text.Json.Serialization;

namespace DateManagementMySQL.Core.DTOS
{
    public class UserDTO
    {
        public int? IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string? PassWord { get; set; } = null!;
        [JsonIgnore]
        public string? PassWordSalt { get; set; }
        public int IdRol { get; set; }
        public bool? IsActive { get; set; }
    }
}
