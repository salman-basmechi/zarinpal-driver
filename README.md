# ZarinPal Driver
ZarinPal payment gateway driver in c#

You can get the latest stable release from the [nuget.org](http://www.nuget.org/packages/zarinpaldriver) or from [github releases page](https://github.com/salmanbasmechi/zarinpaldriver/releases).

Getting Started
---------------

```C#
using ZarinPalDriver;
```

```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddZarinPalDriver();
}
```

```C#
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZarinPalDriver;
using ZarinPalDriver.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> PurchaseRequest([FromServices] IZarinPalClient client)
        {
            var mode = Mode.SandBox;

            var request = new PaymentRequest
            {
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Amount = 1000,
                Email = "salmanbasmechi@gmail.com",
                Mobile = "09129335607",
                Description = "Test Payment",
                CallbackUrl = "http://localhost:5000/api/product/completepurchase",
                Mode = mode
            };

            var response = await client.SendAsync(request);

            if(response.Status != Status.Success)
            {
                return BadRequest();
            }

            return Redirect(response.GatewayUri.AbsoluteUri);
        }

        [HttpPost, HttpGet]
        public async Task<IActionResult> CompletePurchase([FromServices] IZarinPalClient client)
        {
            var mode = Mode.SandBox;

            string status = Request.Query["status"];
            string authority = Request.Query["authority"];

            if (string.IsNullOrEmpty(status) || string.IsNullOrEmpty(authority) || status.ToLower() != "ok")
            {
                return BadRequest();
            }

            var request = new VerificationRequest
            {
                MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                Amount = 1000,
                Authority = authority,
                Mode = mode
            };

            var response = await client.SendAsync(request);

            if (response.Status != Status.Success)
            {
                return BadRequest($"Payment with reference id '{response.ReferenceId}' failed.");
            }

            return Ok(response.ReferenceId);
        }
    }
}
```
