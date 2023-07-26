using System.Security.Cryptography;
using System.Text;
using TrainingProjectAPI.DTOs;

namespace TrainingProjectAPI.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Surname { get; set; } 
        public byte[] PasswordHash { get; set; }    
        public byte[] PasswordSalt { get; set; }    

        public User() { }

        public User(AddUserDTO userDTO)
        {
            UserId = Guid.NewGuid();    
            Name = userDTO.Name;    
            Surname = userDTO.Surname;
            Email = userDTO.Email;
            Hash_password(userDTO.Password);
        }
        public void Hash_password(string password)
        {
            using var BigMac = new HMACSHA512();

            PasswordHash = BigMac.ComputeHash(Encoding.UTF8.GetBytes(password));
            PasswordSalt = BigMac.Key;

        }
    }
}
