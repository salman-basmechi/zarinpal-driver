using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZarinPalDriver.Models;

namespace ZarinPalDriver.Internals
{
    internal class ZarinPalClient : IZarinPalClient
    {
        private readonly IBaseUriResolver baseUriResolver;

        public ZarinPalClient(IBaseUriResolver baseUriResolver)
        {
            this.baseUriResolver = baseUriResolver ?? throw new ArgumentNullException(nameof(baseUriResolver));
        }

        private static Uri GatewayUri(Mode mode)
        {
            string uriString;

            if(mode == Mode.Operational)
            {
                uriString = "https://www.zarinpal.com/pg/StartPay";
            }
            else
            {
                uriString = "https://sandbox.zarinpal.com/pg/StartPay";
            }

            return new Uri(uriString);
        }

        public async Task<PaymentResponse> SendAsync(PaymentRequest request, CancellationToken cancellationToken)
        {
            string baseUri = baseUriResolver.Resolve(request.Mode);

            string requestUri = $"{baseUri}/request.json";
            string json = request.ToJson();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(requestUri, content, cancellationToken);

            json = await response.Content.ReadAsStringAsync();

            var model = JObject.Parse(json);

            int code = model["data"]["code"].Value<int>();
            string authority = model["data"]["authority"].Value<string>();

            var status = new Status(code);
            var gatewayUri = GatewayUri(request.Mode);

            return new PaymentResponse(authority, status, gatewayUri);
        }

        public async Task<VerificationResponse> SendAsync(VerificationRequest request, CancellationToken cancellationToken)
        {
            string baseUri = baseUriResolver.Resolve(request.Mode);

            string requestUri = $"{baseUri}/verify.json";
            string json = request.ToJson();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(requestUri, content, cancellationToken);

            json = await response.Content.ReadAsStringAsync();

            var model = JObject.Parse(json);

            int code = model["data"]["code"].Value<int>();
            string referenceId = model["data"]["ref_id"].Value<string>();

            var status = new Status(code);

            return new VerificationResponse(status, referenceId);
        }
    }
}
