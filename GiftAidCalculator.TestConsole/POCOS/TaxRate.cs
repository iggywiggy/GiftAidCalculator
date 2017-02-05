using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace GiftAidCalculator.TestConsole.POCOS
{
    public class TaxRate
    {
        public decimal Rate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateDeleted { get; set; }
    }
}
