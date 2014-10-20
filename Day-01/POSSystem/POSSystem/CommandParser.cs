namespace POSSystem
{
    public class CommandParser : ICommandParser
    {
        private ISaleEventListener _saleEventListener;

        public CommandParser(ISaleEventListener saleEventListener)
        {
            this._saleEventListener = saleEventListener;
        }
        public void Parse(string command)
        {
            var commandParts = command.Split(':');
            if (commandParts[0] == "Command" && commandParts[1] == "NewSale")
                this._saleEventListener.NewSaleInitialized();
            if (commandParts[0] == "Command" && commandParts[1] == "EndSale")
                this._saleEventListener.SaleEnded();
            if (commandParts[0] == "Input")
            {
                var dataParts = commandParts[1].Split(',');
                var barcodeId = dataParts[0].Split('=')[1];
                var quantity = int.Parse(dataParts[1].Split('=')[1]);
                this._saleEventListener.ProductAdded(barcodeId, quantity);
            }
        }
    }
}