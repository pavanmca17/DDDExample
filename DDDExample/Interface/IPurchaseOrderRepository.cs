using DDDExample.Models;

namespace DDDExample.Interface
{
    public interface IPurchaseOrderRepository
    {
        void Add(PurchaseOrder purchaseOrder);
        PurchaseOrder GetById(string id);
    }

}
