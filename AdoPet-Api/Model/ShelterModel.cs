
using System.ComponentModel.DataAnnotations;

namespace AdoPet_Api.Model
{
    public class ShelterModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório")]
        public string Estado { get; set; }
    }
}
