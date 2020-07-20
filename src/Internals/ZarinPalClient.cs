using Newtonsoft.Json.Linq;
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
            this.baseUriResolver = baseUriResolver ?? throw new System.ArgumentNullException(nameof(baseUriResolver));
        }

        public async Task<PaymentResponse> RequestAsync(PaymentRequest request, CancellationToken cancellationToken)
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

            return new PaymentResponse(authority, status);
        }

        public async Task<VerificationResponse> RequestAsync(VerificationRequest request, CancellationToken cancellationToken)
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
