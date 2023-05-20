
using System.ComponentModel.DataAnnotations;

namespace AdoPet_Api.Model
{
    public class Shelter
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
    }
}
