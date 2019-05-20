using DDDExample.Interface;
using DDDExample.Models;
using DDDExample.Service;
using System;


namespace DDDExample
{
    public class ServiceClient
    {
        private IPurchaseOrderRepository _purchaseOrderRepo;
        private IPurchaseOrderService _purchaseOrderService;       
        private static int LineItemId = 0;

        public ServiceClient()
        {
            _purchaseOrderRepo = new InMemoryPurchaseOrderRepository();
            _purchaseOrderService = new PurchaseOrderService(_purchaseOrderRepo);
        }

       
        public bool AddLineItem()
        {
            var poId = Guid.NewGuid().ToString();
            var po = new PurchaseOrder(poId) { SpendLimit = 100 };
            _purchaseOrderRepo.Add(po);
            LineItemId++;
            var lineitem1 = new LineItem(LineItemId, "LineItem1", "LineItem1", 50);
            po.AddLineItem(lineitem1, _purchaseOrderService);
            LineItemId++;
            var lineitem2 = new LineItem(LineItemId, "LineItemId2", "LineItemId2", 51);
            return po.AddLineItem(lineitem2, _purchaseOrderService);
        }

       
        public bool UpdateLineItem()
        {
            var canbeUpdated = true;
            var po = new PurchaseOrder(Guid.NewGuid().ToString()) { SpendLimit = 100 };
            _purchaseOrderRepo.Add(po);
            LineItemId++;
            po.AddLineItem(new LineItem(LineItemId, "LineItemId3", "LineItemId3", 50),
                           _purchaseOrderService);

            var item = new LineItem(LineItemId, "LineItemId4", "LineItemId4", 25);

            po.AddLineItem(item, _purchaseOrderService);

            canbeUpdated = item.UpdateLineItemCost(51, _purchaseOrderService);
            return canbeUpdated;
        }
    }
}
