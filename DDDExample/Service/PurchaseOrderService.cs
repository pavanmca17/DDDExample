using DDDExample.Interface;
using DDDExample.Models;
using System.Linq;


namespace DDDExample.Service
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;


        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        // PurchaseOrder object is injected
        public bool CheckLineItemPriceUnderLimitForInsert(PurchaseOrder order, LineItem newItem)
        {
            return order.Items.Sum(i => i.Cost) + newItem.Cost <= order.SpendLimit;
        }


        // Get Item from repo
        public bool CheckLineItemPriceUnderLimitForUpdate(string purchaseOrderId, LineItem existingItem, decimal newCost)
        {
            var po = _purchaseOrderRepository.GetById(purchaseOrderId);
            // check for null, check if item belongs to PO
            if(po == null)
            {

            }
            return po.Items.Sum(i => i.Cost) + (newCost - existingItem.Cost) <= po.SpendLimit;
        }
    }
}
