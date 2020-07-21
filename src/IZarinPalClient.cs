using System.Threading;
using System.Threading.Tasks;
using ZarinPalDriver.Models;

namespace ZarinPalDriver
{
    public interface IZarinPalClient
    {
        Task<PaymentResponse> HandleAsync(PaymentRequest request, CancellationToken cancellationToken = default);

        Task<VerificationResponse> HandleAsync(VerificationRequest request, CancellationToken cancellationToken = default);
    }
}
