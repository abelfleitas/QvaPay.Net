using QvaPayDotnet.Models;
using QvaPayDotnet.ResultResponse;
using System.Threading.Tasks;

namespace QvaPayDotnet.Contract
{
    public interface IQvaPayInstance
    {
        /// <summary>
        ///     Information about your application
        ///     <returns>
        ///         Application Information Object
        ///     </returns>
        /// </summary>
        Task<AppInfoResponse> AppInfo(string resourcePath = "info?");

        /// <summary>
        ///     Create an invoice
        ///     <paramref name="invoice">
        ///         Invoice Object
        ///     </paramref>
        ///     <returns>
        ///         Invoice Object
        ///     </returns>
        /// </summary>
        Task<InvoiceResponse> Invoice(Invoice invoice, string resourcePath = "create_invoice?");

        /// <summary>
        ///     List all transactions
        ///     <returns>
        ///         Transaction List
        ///     </returns>
        /// </summary>
        Task<TransactionsResponse> Transactions(string resourcePath = "transactions?");

        /// <summary>
        ///     Get a transaction
        ///     <paramref name="uuid">
        ///         Transaction Identifier
        ///     </paramref>
        ///     <returns>
        ///         Transaction Object
        ///     </returns>
        /// </summary>
        Task<TransactionResponse> GetTransaction(string uuid, string resourcePath = "transaction/{0}?");

        /// <summary>
        ///     Get Balance
        ///     <returns>
        ///         Decimal Number
        ///     </returns>
        /// </summary>
        Task<decimal> Balance(string resourcePath = "balance?");
    }
}
