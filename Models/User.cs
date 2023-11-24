namespace WebApplication1.Models
{
    public class User
    {

        public string UserID { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email {  get; set; }

        public string NormalizedEmail { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp {  get; set; }

        public string ConcurrencyStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneConfirmed { get; set; }

        public bool TwoFactor {  get; set; }

        public DateTime LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }
    }
}
