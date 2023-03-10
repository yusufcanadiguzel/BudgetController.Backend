using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Receipt : IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int PaymentTypeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
