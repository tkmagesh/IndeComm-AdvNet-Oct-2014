using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POSSystem
{
    public interface ISaleEventListener
    {
        void NewSaleInitialized();
        void SaleEnded();
        void ProductAdded(string barcodeId, int quantity);
    }
}
