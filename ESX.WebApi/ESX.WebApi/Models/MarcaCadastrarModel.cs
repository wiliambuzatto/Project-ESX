using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESX.WebApi.Models
{
    public class MarcaCadastrarModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome não pode ser vazio")]
        public string Nome { get; set; }
    }
}