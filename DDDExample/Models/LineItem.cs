using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Models
{
    public class LineItem
    {
        public int Id { get; set; }

        // avoid having circular reference between aggregate and children
        public String PurchaseOrderId { get; set; }

        public String Name { get; set; }

        public String Desc { get; set; }

        public decimal Cost { get; private set; }

        public LineItem(int _Id,String _Name,String _Desc,decimal _Cost)
        {
            Id = _Id;
            Name = _Name;
            Desc = _Desc;
            Cost = _Cost;
        }
        
        public bool UpdateLineItemCost(decimal cost, IPurchaseOrderService poService)
        {
            if (poService.CheckLineItemPriceUnderLimitForUpdate(PurchaseOrderId, this, cost))
            {
                Cost = cost;
                return true;
            }
            return false;
        }
    }
}
