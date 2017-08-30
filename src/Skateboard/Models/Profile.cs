using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skateboard.Models
{
    [Table("Profiles")]
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Profile(string firstName, string lastName, string profileName, string bio)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileName = profileName;
            Bio = bio;
        }
    }
}
