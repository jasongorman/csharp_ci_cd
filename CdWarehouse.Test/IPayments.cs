namespace CdWarehouse.Test
{
    public interface IPayments
    {
        // IsAccepted is trash
        bool IsAccepted(CreditCard card, in double price);
    }
}