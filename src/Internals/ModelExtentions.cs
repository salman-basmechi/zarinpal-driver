using Newtonsoft.Json;
using ZarinPalDriver.Models;

namespace ZarinPalDriver.Internals
{
    public static class ModelExtentions
    {
        public static string ToJson(this PaymentRequest request)
        {
            var model = new
            {
                merchant_id = request.MerchantId,
                amount = request.Amount,
                callback_url = request.CallbackUrl,
                description = request.Description,
                metadata = new
                {
                    mobile = request.Mobile,
                    email = request.Email
                }
            };

            var setting = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(model, setting);
        }

        public static string ToJson(this VerificationRequest request)
        {
            var model = new
            {
                merchant_id = request.MerchantId,
                amount = request.Amount,
                authority = request.Authority
            };

            var setting = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(model, setting);
        }
    }
}
