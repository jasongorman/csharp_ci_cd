namespace CdWarehouse.Test
{
    public class CompactDisc
    {
        private readonly IPayments _payments;

        public CompactDisc(double price, int stock, IPayments payments)
        {
            _payments = payments;
            Price = price;
            Stock = stock;
        }

        private double Price { get; }
        public double Stock { get; private set; }

        public void Buy(int quantity, CreditCard card)
        {
            if(quantity > Stock)
                throw new OutOfStockException();
            
            if(!_payments.IsAccepted(card, Price))
                throw new PaymentRejectedException();
            
            Stock -= quantity;
        }
    }
}