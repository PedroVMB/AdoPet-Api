using System.ComponentModel.DataAnnotations;

namespace AdoPet_Api.Model
{
    public class Adoption
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int? PetId { get; set; }
        [Required]
        public int? TutorId { get; set; }
        public DateTime DateTime { get; set; }

    }
}
