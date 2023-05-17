using System.ComponentModel.DataAnnotations;

namespace AdoPet_Api.Data.Dto
{
    public class UpdatePetDto
    {
        [Required(ErrorMessage = "Nome é necessário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é necessária")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O status é necessário")]
        public bool Adotado { get; set; }

        [Required(ErrorMessage = "A idade é necessária")]
        public int Idade { get; set; }

        [Required]
        public Enum Enereco { get; set; }

        [Required(ErrorMessage = "A foto é necessária")]
        public string Imagem { get; set; }
    }
}
