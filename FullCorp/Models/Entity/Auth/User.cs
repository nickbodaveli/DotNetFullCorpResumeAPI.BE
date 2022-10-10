using System.ComponentModel.DataAnnotations.Schema;

namespace FullCorp.Models.Entity.Auth
{
    public class User
    {
        //public int Id { get; set; }
        //public string Email { get; set; } = string.Empty;
        //public byte[] PasswordHash { get; set; } = new byte[32];
        //public byte[] PasswordSalt { get; set; } = new byte[32];
        //public string? VerificationToken { get; set; }
        //public DateTime? VerifiedAt { get; set; }
        //public string? PasswordResetToken { get; set; }
        //public DateTime? ResetTokenExpires { get; set; }
        //[NotMapped]
        //public string Error { get; set; }

        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public bool AgreeTerm { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool RememberMe { get; set; }
        [NotMapped]
        public string? Token { get; set; }
        [NotMapped]
        public string? AppOriginUrl { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public int TenantId { get; set; }
        public Tenant? Tenant { get; set; }
    }
}
