using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string OwnerName { get; set; }
    }
}
