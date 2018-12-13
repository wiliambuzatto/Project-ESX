using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESX.WebApi.Models
{
    public class MarcaPatrimoniosObterModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public List<MarcaPatrimoniosModel> Patrimonios { get; set; }
    }
}