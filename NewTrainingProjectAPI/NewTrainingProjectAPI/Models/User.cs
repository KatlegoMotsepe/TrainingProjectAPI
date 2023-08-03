using NewTrainingProjectAPI.DTOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace NewTrainingProjectAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; }
        public byte[] PassSalt { get; set; }
        public byte[] PassHash { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<SessionDetails> SessionDetails { get; set; }

        public User() { }

        public User(AddUserDTO addUser)
        {

            Id = Guid.NewGuid();
            Name = addUser.Name;
            Surname = addUser.Surname;
            Email = addUser.Email;
            PasswordHAsh(addUser.Password);
        }

        public void PasswordHAsh(string password)
        {
            using var hmac = new HMACSHA512();
            PassHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            PassSalt = hmac.Key;
        }

        public bool PassVali(string password)
        {
            using var hmac = new HMACSHA512(PassSalt);

            var newHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            if (newHash.Length != PassHash.Length) { return false; }

            for (int i = 0; i < newHash.Length; i++)
            {
                if (newHash[i] != PassHash[i]) { return false; }
            }
            return true;
        }
    }
}
