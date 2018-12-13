using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESX.Domain.Exceptions
{
    public class PatrimonioNaoEncontradoException : AplicacaoExceptionBase
    {
        public override string MensagemErro
        {
            get { return "Patrimonio não encontrado"; }
        }
    }
}
