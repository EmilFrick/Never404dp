using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404._404BankServices.Strategies
{
    public static class MembershipRates
    {
        #region PayInvoice
        private static decimal _payInvoicePlatinum = 0.01M;
        private static decimal _payInvoiceGold = 0.05M;
        private static decimal _payInvoiceSilver = 0.12M;

        public static decimal PayInvoicePlatinum
        {
            get { return _payInvoicePlatinum; }
            set { _payInvoicePlatinum = value; }
        }

        public static decimal PayInvoiceGold
        {
            get { return _payInvoiceGold; }
            set { _payInvoiceGold = value; }
        }

        public static decimal PayInvoiceSilver
        {
            get { return _payInvoiceSilver; }
            set { _payInvoiceSilver = value; }
        }
        #endregion


        #region ForeignPayment

        private static decimal _foreignPaymentPlatinum = 0.05M;
        private static decimal _foreignPaymentGold = 0.07M;
        private static decimal _foreignPaymentSilver = 0.09M;

        public static decimal ForeignPaymentPlatinum
        {
            get { return _foreignPaymentPlatinum; }
            set { _foreignPaymentPlatinum = value; }
        }

        public static decimal ForeignPaymentGold
        {
            get { return _foreignPaymentGold; }
            set { _foreignPaymentGold = value; }
        }

        public static decimal ForeignPaymentSilver
        {
            get { return _foreignPaymentSilver; }
            set { _foreignPaymentSilver = value; }
        }
        #endregion


        #region ForeignTransfer

        private static decimal _foreignTransferPlatinum = 50;
        private static decimal _foreignTransferGold = 100;
        private static decimal _foreignTransferSilver = 150;

        public static decimal ForeignTransferPlatinum
        {
            get { return _foreignTransferPlatinum; }
            set { _foreignTransferPlatinum = value; }
        }

        public static decimal ForeignTransferGold
        {
            get { return _foreignTransferGold; }
            set { _foreignTransferGold = value; }
        }

        public static decimal ForeignTransferSilver
        {
            get { return _foreignTransferSilver; }
            set { _foreignTransferSilver = value; }
        }
        #endregion


    }
}
