namespace VehiclesApi.Models
{
    public class MultichoiceMakePaymentRequest
    {
        public string transactionId { get; set; }
        public string billerId { get; set; }
        public string purposeCode { get; set; }
        public string principalAmount { get; set; }
        public string principalNarration { get; set; }
        public string payerId { get; set; }
        public List<CreditTransactionDetail> creditTransactionDetails { get; set; }
        public List<DebitTransactionDetail> debitTransactionDetails { get; set; }
        public string fullName { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string branchCode { get; set; }
        public string currencyCode { get; set; }
        public string productName { get; set; }
        public string authCode { get; set; }
        public string channelId { get; set; }
        public string channelName { get; set; }
        public string baseCBA { get; set; }
        public string channelType { get; set; }
        public OtherRequestDetails otherRequestDetails { get; set; }

        public class OtherRequestDetails
        {
            public string methodOfPayment { get; set; }
            public string paymentDescription { get; set; }
            public string productUserKey { get; set; }
            public string vendorCode { get; set; }
            public string businessUnit { get; set; }
        }

        public class CreditTransactionDetail
        {
            public string accountToCredit { get; set; }
            public string transactionAmount { get; set; }
            public string transactionNarration { get; set; }
        }

        public class DebitTransactionDetail
        {
            public string accountToDebit { get; set; }
            public string transactionAmount { get; set; }
            public string transactionNarration { get; set; }
        }
    }
}
