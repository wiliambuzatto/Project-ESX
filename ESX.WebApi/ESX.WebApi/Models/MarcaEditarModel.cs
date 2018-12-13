﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ESX.WebApi.Models
{
    public class MarcaEditarModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id não pode ser menor ou igual 0")]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Nome não pode ser vazio")]
        public string Nome { get; set; }
    }
}