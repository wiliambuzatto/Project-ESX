﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESX.Domain.Exceptions
{
    public class ErroExcluirMarcaContemPatrimonios : AplicacaoExceptionBase
    {
        public override string MensagemErro
        {
            get { return "Não foi possível excluir a Marca, pois contém vinculos com patrimonio"; }
        }
    }
}
