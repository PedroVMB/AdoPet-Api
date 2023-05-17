using System.ComponentModel.DataAnnotations;

namespace AdoPet_Api.Data.Dto
{
    public class UpdateShelterDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A cidade é obrigatória")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório")]
        public string Estado { get; set; }
    }
}
