namespace VehiclesApi.Models
{
    public class BuildCreditDebitPayload
    {
        public static List<MultichoiceMakePaymentRequest.CreditTransactionDetail> BuildCreditDebitPayloadData(string transactionAmount, string commision, string VAT)
        {
            var multichoiceOtherSettingsRaw = "9201848939|990999NGN8017001|0.0|990999NGN5213000|0.0|990999|TRANSFER|NGN";
            var multichoiceOtherSettings = multichoiceOtherSettingsRaw.Split('|');
            if ( Convert.ToDecimal(commision) ==0 || Convert.ToDecimal(VAT) == 0)
                {
                return new List<MultichoiceMakePaymentRequest.CreditTransactionDetail>()
                    {
                        new MultichoiceMakePaymentRequest.CreditTransactionDetail()
                        {
                            accountToCredit = multichoiceOtherSettings[0],
                            transactionAmount = transactionAmount,
                            //transactionNarration = "payment"
                            transactionNarration = "pay"
                        }
                    };
            }
            else
            {
                return new List<MultichoiceMakePaymentRequest.CreditTransactionDetail>()
                    {
                        new MultichoiceMakePaymentRequest.CreditTransactionDetail()
                        {
                            accountToCredit = multichoiceOtherSettings[0],
                            transactionAmount = "",
                            transactionNarration = "payment"
                        },
                        new MultichoiceMakePaymentRequest.CreditTransactionDetail()
                        {
                            accountToCredit = multichoiceOtherSettings[1],
                            transactionAmount = multichoiceOtherSettings[2],
                            transactionNarration = "COMM on Multichoice Transaction"
                        },
                        new MultichoiceMakePaymentRequest.CreditTransactionDetail()
                        {
                            accountToCredit = multichoiceOtherSettings[3],
                            transactionAmount = multichoiceOtherSettings[4],
                            transactionNarration = "VAT on Multichoice Transaction Fee"
                        }
                    };
            }
        }
    }
}
