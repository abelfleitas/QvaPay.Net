using QvaPayDotnet.Contract;
using QvaPayDotnet.Models;
using QvaPayDotnet.ResultResponse;
using RestSharp;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QvaPayDotnet
{
    public class QvaPayInstance : IQvaPayInstance
    {
        private readonly RestClient client;
        private string base_url = string.Empty;
        private string auth = string.Empty;
        private readonly QvaPayConfig config;

        public QvaPayInstance(QvaPayConfig _config)
        {
            config = _config ?? throw new ArgumentNullException(nameof(_config));
            base_url = $"https://qvapay.com/api/{config.apiversion}/";
            client = new RestClient(base_url);
            auth = $"app_id={config.appid}&app_secret={config.appsecret}";
        }

        /// <summary>
        ///     Information about your application.
        ///     <returns>
        ///         Application Information Object.
        ///     </returns>
        /// </summary>
        public async Task<AppInfoResponse> AppInfo(string resourcePath = "info?")
        {
            var request = new RestRequest(resourcePath + auth, Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = await client.ExecuteAsync<AppInfoResponse>(request);
            if (!response.IsSuccessful)
            {
                await Task.FromException(response.ErrorException);
            }
            return await Task.FromResult(response.Data);
        }

        /// <summary>
        ///     Create an invoice.
        ///     <paramref name="invoice">
        ///         Invoice Object.
        ///     </paramref>
        ///     <returns>
        ///         Invoice Object.
        ///     </returns>
        /// </summary>
        public async Task<InvoiceResponse> Invoice(Invoice invoice, string resourcePath = "create_invoice?")
        {
            string newParam = ConvertObjectToUrl(invoice);
            var request = new RestRequest(resourcePath + auth + newParam, Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = await client.ExecuteAsync<InvoiceResponse>(request);
            if (!response.IsSuccessful)
            {
                await Task.FromException(response.ErrorException);
            }
            return await Task.FromResult(response.Data);
        }

        /// <summary>
        ///     List all transactions.
        ///     <returns>
        ///         Transaction List.
        ///     </returns>
        /// </summary>
        public async Task<TransactionsResponse> Transactions(string resourcePath = "transactions?")
        {
            var request = new RestRequest(resourcePath + auth, Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = await client.ExecuteAsync<TransactionsResponse>(request);
            if (!response.IsSuccessful)
            {
                await Task.FromException(response.ErrorException);
            }
            return await Task.FromResult(response.Data);
        }

        /// <summary>
        ///     Get a transaction.
        ///     <paramref name="uuid">
        ///         Transaction Identifier.
        ///     </paramref>
        ///     <returns>
        ///         Transaction Object.
        ///     </returns>
        /// </summary>
        public async Task<TransactionResponse> GetTransactions(string uuid, string resourcePath = "transaction/{0}?")
        {
            var request = new RestRequest(resourcePath.Replace("{0}",uuid) + auth, Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = await client.ExecuteAsync<TransactionResponse>(request);
            if (!response.IsSuccessful)
            {
                await Task.FromException(response.ErrorException);
            }
            return await Task.FromResult(response.Data);
        }

        /// <summary>
        ///     Get Balance.
        ///     <returns>
        ///         Decimal Number.
        ///     </returns>
        /// </summary>
        public async Task<decimal> Balance(string resourcePath = "balance?")
        {
            var request = new RestRequest(resourcePath + auth, Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            var response = await client.ExecuteAsync<decimal>(request);
            if (!response.IsSuccessful)
            {
                await Task.FromException(response.ErrorException);
            }
            return await Task.FromResult(response.Data);
        }

        /// <summary>
        ///    Format the invoice object to url.
        /// </summary>
        private string ConvertObjectToUrl(Invoice invoice)
        {
            string param = string.Join("&", invoice.GetType().GetProperties()
                .Select(p => p.Name + "=" + p.GetValue(invoice, null)));

            int signed = invoice.signed ? 1 : 0;
            string lastParam = param.Split("&").LastOrDefault();
            string newParam = lastParam.Replace(lastParam.Split("=").LastOrDefault(), signed.ToString());
            param = "&" + param.Replace(lastParam, newParam);
            
            return param;
        }
    }
}
