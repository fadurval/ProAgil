using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WEBAPI.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage="Local é obrigatório")]
        [StringLength(100, MinimumLength = 3)]
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required (ErrorMessage = "Tema é obrigatório")]
        [StringLength(50, MinimumLength = 2)]
        public string Tema { get; set; }
        [Range(2, 120000, ErrorMessage="Quantidade de tem quer ser entre 2 e 120000")]
        public int QtdPessoas { get; set; }
        public string ImagemURL { get; set; }
        [Phone]
        public string Telefone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}