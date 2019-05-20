using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Models
{
    // aggregate root
    public class PurchaseOrder 
    {
        public String Id { get; set; }

        private List<LineItem> _items { get; } = new List<LineItem>();

        public decimal SpendLimit { get; set; }

        public IEnumerable<LineItem> Items => _items.ToList();
       
        public PurchaseOrder(String _Id)
        {
            Id = _Id;
        }

        public bool CheckLimit(LineItem item, decimal newValue)
        {
            var currentSum = Items.Sum(i => i.Cost);
            decimal difference = newValue - item.Cost;
            return currentSum + difference <= SpendLimit;
        }

        public bool CheckLimit(LineItem newItem)
        {
            return Items.Sum(i => i.Cost) + newItem.Cost <= SpendLimit;
        }

        // Injecting - IPurchaseOrderService
        public bool AddLineItem(LineItem item, IPurchaseOrderService poService)
        {
            if (poService.CheckLineItemPriceUnderLimitForInsert(this, item))
            {
                _items.Add(item);
                return true;
            }
            return false;
        }
    }

}
