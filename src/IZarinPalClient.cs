using System.Threading;
using System.Threading.Tasks;
using ZarinPalDriver.Models;

namespace ZarinPalDriver
{
    public interface IZarinPalClient
    {
        Task<PaymentResponse> RequestAsync(PaymentRequest request, CancellationToken cancellationToken = default);

        Task<VerificationResponse> RequestAsync(VerificationRequest request, CancellationToken cancellationToken = default);
    }
}
