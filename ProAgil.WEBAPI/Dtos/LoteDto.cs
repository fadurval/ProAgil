using System.ComponentModel.DataAnnotations;

namespace ProAgil.WEBAPI.Dtos
{
    public class LoteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        public decimal Preco { get; set; }
        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        [Range(2, 1000)]
        public int Quantidade { get; set; }
    }
}