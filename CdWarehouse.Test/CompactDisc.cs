namespace CdWarehouse.Test
{
    public class CompactDisc
    {
        private readonly IPayments _payments;
        private string Artist { get; }
        private string Title { get; }

        public bool Matches(string artist, string title)
        {
            return this.Artist == artist && this.Title == title;
        }

        public CompactDisc(string artist, string title, double price, int stock, IPayments payments)
        {
            _payments = payments;
            Artist = artist;
            Title = title;
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