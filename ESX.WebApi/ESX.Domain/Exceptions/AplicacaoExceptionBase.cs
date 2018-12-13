using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESX.Domain.Exceptions
{
    public abstract class AplicacaoExceptionBase : Exception
    {
        protected AplicacaoExceptionBase()
        {
        }

        protected AplicacaoExceptionBase(Exception innerException)
            : base("", innerException)
        {
        }

        public abstract string MensagemErro { get; }
    }
}
