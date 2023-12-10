using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Telefone { get; set; }
    }
}
