using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ConsolidatedPositionModel
    {
        public int Id { get; set; }
        public decimal TotalBalance { get; set; }
        public IEnumerable<CustodyModel> Custodies { get; set; }
    }
}
