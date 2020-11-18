using System.Threading;
using System.Threading.Tasks;
using ZarinPalDriver.Models;

namespace ZarinPalDriver
{
    public interface IZarinPalClient
    {
        PaymentResponse Send(PaymentRequest request);

        VerificationResponse Send(VerificationRequest request);

        Task<PaymentResponse> SendAsync(PaymentRequest request, CancellationToken cancellationToken = default);

        Task<VerificationResponse> SendAsync(VerificationRequest request, CancellationToken cancellationToken = default);
    }
}
