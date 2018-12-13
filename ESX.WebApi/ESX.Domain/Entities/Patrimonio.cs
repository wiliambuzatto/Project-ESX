using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESX.Domain.Entities
{
    public class Patrimonio
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int NumeroTombo { get; protected set; }
        public virtual Marca Marca { get; set; }

        public virtual void CriarNumeroTombo()
        {
            this.NumeroTombo = new Random().Next();
        }
    }
}
