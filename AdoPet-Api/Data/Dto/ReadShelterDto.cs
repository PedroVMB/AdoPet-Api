using System.ComponentModel.DataAnnotations;

namespace AdoPet_Api.Data.Dto
{
    public class ReadShelterDto
    {
        public string Nome { get; set; }
     
        public string Cidade { get; set; }

        public string Estado { get; set; }
    }
}
