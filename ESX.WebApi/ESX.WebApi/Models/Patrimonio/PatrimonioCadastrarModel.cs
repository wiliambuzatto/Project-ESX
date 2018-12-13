using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESX.WebApi.Models
{
    public class PatrimonioCadastrarModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome não pode ser vazio")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "IdMarca não pode ser menor ou igual 0")]
        public int IdMarca { get; set; }
    }
}