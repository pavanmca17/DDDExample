using DDDExample.Models;

namespace DDDExample
{
    public interface IPurchaseOrderService
    {
        bool CheckLineItemPriceUnderLimitForInsert(PurchaseOrder order, LineItem newItem);
        bool CheckLineItemPriceUnderLimitForUpdate(string purchaseOrderId, LineItem existingItem, decimal newCost);
    }
}
