using System.Threading;
using System.Threading.Tasks;
using ZarinPalDriver.Models;

namespace ZarinPalDriver
{
    public interface IZarinPalClient
    {
        Task<PaymentResponse> SendAsync(PaymentRequest request, CancellationToken cancellationToken = default);

        Task<VerificationResponse> SendAsync(VerificationRequest request, CancellationToken cancellationToken = default);
    }
}
