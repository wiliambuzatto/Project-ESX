using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESX.Domain.Entities
{
    public class Marca
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; set; }
        public virtual IEnumerable<Patrimonio> Patrimonios { get; protected set; }
    }
}
