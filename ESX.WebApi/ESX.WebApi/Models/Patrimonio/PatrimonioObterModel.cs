using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESX.WebApi.Models
{
    public class PatrimonioObterModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string NumeroTombo { get; set; }

        public MarcaObterModel Marca { get; set; }
    }
}