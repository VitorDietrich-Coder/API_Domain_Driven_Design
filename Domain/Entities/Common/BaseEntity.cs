using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Common
{
    public  abstract class BaseEntity
    {
      [Key]
       public Guid Id { get; set; }

        private DateTime? _createAt;

        public DateTime? CreateAt { 
            get
            {
                return _createAt;
            }
            set 
            {
                _createAt = value?? DateTime.UtcNow;
            }
           }

        public DateTime UpdateAt { get; set; }
    }
}
