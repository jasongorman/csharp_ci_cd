using System;
using NUnit.Framework;

namespace CdWarehouse.Test
{
    [TestFixture]
    public class BuyCdTests
    {
        [Test]
        public void InStockPaymentAccepted()
        {
            IPayments payments = new PaymentsStub(true);
            CompactDisc cd = new CompactDisc(9.99, 10, payments);
            cd.Buy(1, new CreditCard());
            Assert.AreEqual(9, cd.Stock);
        }
        
        [Test]
        public void OutOfStock()
        {
            IPayments payments = new PaymentsStub(true);
            CompactDisc cd = new CompactDisc(9.99, 0, payments);
            Assert.Throws<OutOfStockException>(() => cd.Buy(1, new CreditCard()));
        }
        
        [Test]
        public void PaymentRejected()
        {
            IPayments payments = new PaymentsStub(false);
            CompactDisc cd = new CompactDisc(9.99, 10, payments);
            Assert.Throws<PaymentRejectedException>(() => cd.Buy(1, new CreditCard()));
        }

        private class PaymentsStub : IPayments
        {
            private readonly bool _accepted;

            public PaymentsStub(bool accepted)
            {
                _accepted = accepted;
            }

            public bool IsAccepted(CreditCard card, in double price)
            {
                return _accepted;
            }
        }
    }
}