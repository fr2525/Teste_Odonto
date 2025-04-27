using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNHibernate.Models
{
    public class Cliente
    {
        public virtual int? Id { get; set; }
        public virtual string nome { get; set; }
        public virtual string email { get; set; }
        public virtual string cpf { get; set; }
        public virtual string telefone { get; set; }

    }
}