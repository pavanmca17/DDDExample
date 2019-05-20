using DDDExample.Interface;
using DDDExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDExample.Service
{
    public class InMemoryPurchaseOrderRepository : IPurchaseOrderRepository
    {
        private Dictionary<String, PurchaseOrder> _collection = new Dictionary<String, PurchaseOrder>();
        public void Add(PurchaseOrder purchaseOrder)
        {
            if (!_collection.ContainsKey(purchaseOrder.Id))
            {
                _collection.Add(purchaseOrder.Id, purchaseOrder);
            }
        }

        public PurchaseOrder GetById(String id)
        {
            if (!_collection.ContainsKey(id)) return null;
            return _collection[id];
        }
    }

}
