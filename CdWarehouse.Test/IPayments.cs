namespace CdWarehouse.Test
{
    public interface IPayments
    {
        bool IsAccepted(CreditCard card, in double price);
    }
}