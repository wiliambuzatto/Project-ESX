using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESX.WebApi.Models
{
    public class MarcaPatrimoniosModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string NumeroTombo { get; set; }
    }
}