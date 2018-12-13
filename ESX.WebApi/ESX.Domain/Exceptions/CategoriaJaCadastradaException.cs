using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESX.Domain.Exceptions
{
    public class CategoriaJaCadastradaException : AplicacaoExceptionBase
    {
        public override string MensagemErro
        {
            get { return "Categoria já cadastrada"; }
        }
    }
}
