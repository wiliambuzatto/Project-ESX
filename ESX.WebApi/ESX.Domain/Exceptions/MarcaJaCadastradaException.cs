using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESX.Domain.Exceptions
{
    public class MarcaJaCadastradaException : AplicacaoExceptionBase
    {
        public override string MensagemErro
        {
            get { return "Marca já cadastrada"; }
        }
    }
}
